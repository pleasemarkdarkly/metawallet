using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

/// <summary>
/// simulates bak services provided by a transaction hub (multiple banks centralized in one interface)
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class multiBank : System.Web.Services.WebService
{
  #region structures
  public struct bank
  {
    public Guid BankId;
    public string BankName;
    public string DefaultCurrency;
  }
  public struct account
  {
    public Guid BankId;
    public string BankName;
    public string CustomerCode;
    public string CustomerName;
    public string AccountCode;
    public string AccountCurrency;
    public decimal AccountBalance;
  }
  public struct BankQueryResult
  {
    public int ErroCode;
    public string ErrorText;
    public List<bank> Banks;
  }
  public struct CustomerQueryResult
  {
    public int ErroCode;
    public string ErrorText;
    public List<account> Accounts;
  }
  public struct AccountQueryResult
  {
    public int ErroCode;
    public string ErrorText;
    public account Accountdata;
  }
  public struct accountDetail
  {
    public DateTime TimeDate;
    public string Description;
    public decimal Amount;
    public decimal Balance;
    public string Memo;
  }
  public struct HistoryQueryResult
  {
    public int ErroCode;
    public string ErrorText;
    public account Accountdata;
    public List<accountDetail> Detail;
  }

  public struct TransferResult
  {
    public int ErrorCode;
    public string ErrorText;
    public account NewBalanceSender;
    public account NewBalanceReceiver;
  }
  #endregion
  #region auxiliar
  public SqlConnection coneXion;
  public SqlConnection RDBMSConnection()
  {
    string rdbmsConnectionString = ConfigurationManager.AppSettings["rdbmsConnectionString"];
    SqlConnection rdbms = new SqlConnection(rdbmsConnectionString);
    return (rdbms);
  }
  public multiBank()
  {
    //Uncomment the following line if using designed components 
    //InitializeComponent(); 
    coneXion = RDBMSConnection();
  }
  #endregion
  #region queries
  [WebMethod]
  public BankQueryResult listBanks()
  {
    BankQueryResult result =new BankQueryResult();
    try
    {
      if (coneXion.State!= ConnectionState.Open) coneXion.Open();
      SqlCommand cmd = new SqlCommand("select bankid,bankname,defaultcurrency from tblmultibank_bank where isactive=1",
        coneXion);
      SqlDataReader rd = cmd.ExecuteReader();
      List<bank> banks = new List<bank>(); 
      while (rd.Read())
      {
        bank b1 = new bank();
        b1.BankId = rd.GetGuid(0);
        b1.BankName = rd.GetString(1);
        b1.DefaultCurrency = rd.GetString(2);
        banks.Add(b1);
      }
      result.Banks = banks;
      rd.Close();
      result.ErroCode = 0;
      result.ErrorText = string.Empty;
    }
    catch (Exception ex)
    {
      result.ErroCode = -1;
      result.ErrorText = ex.Message;
    }
    return result;
  }
  [WebMethod]
  public AccountQueryResult accountInfo2(string BankId, string CustomerCode, string AccountCode)
  {
    try
    {
      Guid G = new Guid(BankId);
      return accountInfo(G, CustomerCode, AccountCode);
    }catch (Exception ex)
    { 
      AccountQueryResult r =new AccountQueryResult();
      r.ErroCode=-99;
      r.ErrorText="Invalid Bank Id received";
      return r;
    }
  }
  [WebMethod]
  public AccountQueryResult accountInfo(Guid BankId, string CustomerCode,string AccountCode)
  {
    AccountQueryResult resultAcc = new AccountQueryResult();
    bool accountFound = false;
    try
    {
      if (coneXion.State != ConnectionState.Open) coneXion.Open();
      SqlCommand cmd = new SqlCommand("[MWGanadero_Dev].[dbo].[spMultiBank_CustomerInfo] '@1','@2'".Replace(
          "@1", BankId.ToString()).Replace("@2", CustomerCode), coneXion);
      SqlDataReader rd = cmd.ExecuteReader();
      while (rd.Read())
      {
        account ac = new account();
        ac.BankId = rd.GetGuid(0);
        ac.BankName = rd.GetString(1);
        ac.CustomerCode = rd.GetString(2);
        ac.CustomerName = rd.GetString(3);
        ac.AccountCode = rd.GetString(4);
        ac.AccountCurrency = rd.GetString(5);
        ac.AccountBalance = rd.GetDecimal(6);
        if (ac.AccountCode == AccountCode)
        {
          accountFound = true;
          resultAcc.Accountdata = ac;
        }
      }
      rd.Close();
      if (accountFound)
      {
        resultAcc.ErrorText = string.Empty;
        resultAcc.ErroCode = 0;
      }
      else
      {
        resultAcc.ErroCode = -2;
        resultAcc.ErrorText = "Unable to locate account";
      }
    }
    catch (Exception ex)
    {
      resultAcc.ErroCode = -1;
      resultAcc.ErrorText = ex.Message;
    }
    return resultAcc;

  }
  [WebMethod]
  public HistoryQueryResult accountHistory2(string BankId, string CustomerCode, string AccountCode)
  {
    Guid G = new Guid(BankId);
    return accountHistory(G, CustomerCode, AccountCode);
  }
  [WebMethod]
  public HistoryQueryResult accountHistory(Guid BankId, string CustomerCode, string AccountCode)
  {
    HistoryQueryResult resultHis = new HistoryQueryResult();
    AccountQueryResult resultAcc;
    resultHis.Detail=new List<accountDetail>();
    try
    {
      resultAcc=accountInfo(BankId,CustomerCode,AccountCode);
      if (resultAcc.ErroCode==0)
      {
        resultHis.Accountdata=resultAcc.Accountdata;
        if (coneXion.State != ConnectionState.Open) coneXion.Open();
        SqlCommand cmd = new SqlCommand("[dbo].[spMultiBank_History] '@1','@2','@3'".Replace(
            "@1", BankId.ToString()).Replace("@2", CustomerCode).Replace("@3",AccountCode), coneXion);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
          accountDetail d=new accountDetail();
          //2007-07-16 14:52:54.903	Opening balance	50000.00	50000.00	Opening balance 
          d.TimeDate=rd.GetDateTime(0);
          d.Description=rd.GetString(1);
          d.Amount=rd.GetDecimal(2);
          d.Balance=rd.GetDecimal(3);
          d.Memo=rd.GetString(4);
          resultHis.Detail.Add(d);
        }
        rd.Close();
      }
      else
      {
        resultHis.ErroCode=-1;
        resultHis.ErrorText="Unable to find account";
      }
    }
    catch (Exception ex)
    {
      resultHis.ErroCode = -1;
      resultHis.ErrorText = ex.Message;
    }
    return resultHis;
  }
  [WebMethod]
  public CustomerQueryResult customerInfo(Guid BankId, string CustomerCode)
  {
    CustomerQueryResult result = new CustomerQueryResult();
    try
    {
      result.Accounts = new List<account>();
      if (coneXion.State != ConnectionState.Open) coneXion.Open();
      SqlCommand cmd = new SqlCommand("[MWGanadero_Dev].[dbo].[spMultiBank_CustomerInfo] '@1','@2'".Replace(
          "@1", BankId.ToString()).Replace("@2", CustomerCode), coneXion);
      SqlDataReader rd = cmd.ExecuteReader();
      while (rd.Read())
      {
        account ac = new account();
        ac.BankId = rd.GetGuid(0);
        ac.BankName = rd.GetString(1);
        ac.CustomerCode = rd.GetString(2);
        ac.CustomerName = rd.GetString(3);
        ac.AccountCode = rd.GetString(4);
        ac.AccountCurrency = rd.GetString(5);
        ac.AccountBalance = rd.GetDecimal(6);
        result.Accounts.Add(ac);
      }
      rd.Close();
      result.ErrorText = string.Empty;
      result.ErroCode = 0;
    }
    catch (Exception ex)
    {
      result.ErroCode = -1;
      result.ErrorText = ex.Message;
    }
    return result;
  }
  [WebMethod]
  #endregion
  #region transfers
  public TransferResult transfer(Guid SenderBank, String SenderCode, String SenderAccount,
    Guid ReceiverBank, string ReceiverCode, String ReceiverAccount, decimal Amount, string Currency, 
    string Memo)
  {
    TransferResult result = new TransferResult();
    result.ErrorCode = 0;
    try
    {
      //validate amount
      if (Amount <= 0)
      {
        result.ErrorCode = -2;
        throw new Exception("Amount must be a positive number.");
      }
      //validate customers
      CustomerQueryResult Sending, Receiving;
      Sending = customerInfo(SenderBank, SenderCode);
      Receiving = customerInfo(ReceiverBank, ReceiverCode);
      if (Sending.ErroCode != 0 || Receiving.ErroCode != 0)
      {
        result.ErrorCode = -3;
        throw new Exception("Unable to find customer information");
      }
      //validate accounts;
      AccountQueryResult senderQuery = accountInfo(SenderBank, SenderCode, SenderAccount);
      AccountQueryResult receiverQuery = accountInfo(ReceiverBank, ReceiverCode, ReceiverAccount);
      account SenderAcc ;
      account ReceiverAcc;
      if (senderQuery.ErroCode!=0 || receiverQuery.ErroCode!=0)
      {
        result.ErrorCode = -4;
        throw new Exception("Unable to find account");
      }
      SenderAcc = senderQuery.Accountdata;
      ReceiverAcc = receiverQuery.Accountdata;
      //validate balance and currency
      if (SenderAcc.AccountCurrency.ToUpper() != Currency.ToUpper() 
          || ReceiverAcc.AccountCurrency.ToUpper() != Currency.ToUpper())
      {
        result.ErrorCode = -5;
        throw new Exception("Currency conversion can not be performed");
      }
      if (Amount > SenderAcc.AccountBalance)
      {
        result.ErrorCode = -6;
        throw new Exception("Not enough balance in account");
      }
      //perform transaction
      /*EXECUTE @RC = [MWGanadero_Dev].[dbo].[spMultiBank_TransferSingleCurrency] 
         @bankIdSender  ,@customerCodeSender   ,@accountCodeSender   
        ,@bankIdReceiv  ,@customerCodeReceiv   ,@accountCodeReceiv
        ,@currency  ,@Amount   ,@memo*/
      if (coneXion.State != ConnectionState.Open) coneXion.Open();
      string commandText = "dbo.[spMultiBank_TransferSingleCurrency] "
        + "'@bankIdSender','@customerCodeSender','@accountCodeSender',"
        + "'@bankIdReceiv','@customerCodeReceiv','@accountCodeReceiv',"
        + "'@currency',@Amount,'@memo'";
      commandText = commandText.Replace("@bankIdSender", SenderBank.ToString());
      commandText = commandText.Replace("@bankIdReceiv", ReceiverBank.ToString());
      commandText = commandText.Replace("@customerCodeSender", SenderCode);
      commandText = commandText.Replace("@customerCodeReceiv", ReceiverCode);
      commandText = commandText.Replace("@accountCodeSender", SenderAccount);
      commandText = commandText.Replace("@accountCodeReceiv", ReceiverAccount);
      commandText = commandText.Replace("@currency", Currency);
      commandText = commandText.Replace("@Amount", Amount.ToString("0.00"));
      commandText = commandText.Replace("@memo", Memo);
      SqlCommand cmd = new SqlCommand(commandText, coneXion);
      SqlDataReader rd = cmd.ExecuteReader();
      while (rd.Read())
      { 
        //396F589C-13E2-4100-8C93-73515FDECE0E	Continetal Bank	12345	Chris Grundy	200-12345	Euro	14999.00	1	Receiver
        //396F589C-13E2-4100-8C93-73515FDECE0E	Continetal Bank	54321	George Busch	200-54321	Euro	18001.00	1	Sender
         account ac=new account();
        ac.BankId=rd.GetGuid(0);
        ac.BankName=rd.GetString(1);
        ac.CustomerCode=rd.GetString(2);
        ac.CustomerName = rd.GetString(3);
        ac.AccountCode = rd.GetString(4);
        ac.AccountCurrency = rd.GetString(5);
        ac.AccountBalance=rd.GetDecimal(6); 
        if (rd.GetString(8).ToLower() == "receiver")
          result.NewBalanceReceiver = ac;
        if (rd.GetString(8).ToLower() == "sender")
          result.NewBalanceSender = ac;
      }
      rd.Close();
      result.ErrorCode = 0;
      result.ErrorText = string.Empty;
    }
    catch (Exception ex)
    {
      if (result.ErrorCode == 0) result.ErrorCode = -1;
      result.ErrorText = ex.Message;
    }
    return result;
  }
  [WebMethod]
  public TransferResult UpdateBalance(Guid BankId,string CustomerCode, string AccountCode,decimal Amount, 
    string Memo, string Description)
  {
    TransferResult result = new TransferResult();
    result.ErrorCode = 0;
    try
    {
      //validate amount
      if (Amount <= 0)
      {
        result.ErrorCode = -2;
        throw new Exception("Amount must be a positive number.");
      }
      //validate customers
      CustomerQueryResult  Receiving;
      Receiving = customerInfo(BankId, CustomerCode);
      if (Receiving.ErroCode != 0)
      {
        result.ErrorCode = -3;
        throw new Exception("Unable to find customer information");
      }
      //validate accounts;
      AccountQueryResult receiverQuery = accountInfo(BankId, CustomerCode, AccountCode);
      account ReceiverAcc;
      if (receiverQuery.ErroCode != 0)
      {
        result.ErrorCode = -4;
        throw new Exception("Unable to find account");
      }
      ReceiverAcc = receiverQuery.Accountdata;
      //validate balance and currency
      if ((Amount + ReceiverAcc.AccountBalance)<0)
      {
        result.ErrorCode = -6;
        throw new Exception("Not enough balance in account");
      }
      //perform transaction
      /*[dbo].[spMultiBank_UpdateBalance] @bankIdReceiv,@customerCodeReceiv,@accountCodeReceiv,@Amount,@description,@memo*/
      if (coneXion.State != ConnectionState.Open) coneXion.Open();
      string commandText = "[dbo].[spMultiBank_UpdateBalance] '@bankIdReceiv','@customerCodeReceiv'" +
        ",'@accountCodeReceiv',@Amount,'@description','@memo'";
      commandText = commandText.Replace("@bankIdReceiv", ReceiverAcc.BankId.ToString());
      commandText = commandText.Replace("@customerCodeReceiv", ReceiverAcc.CustomerCode);
      commandText = commandText.Replace("@accountCodeReceiv", ReceiverAcc.AccountCode);
      commandText = commandText.Replace("@Amount", Amount.ToString("0.00"));
      commandText = commandText.Replace("@memo", Memo);
      commandText = commandText.Replace("@description", Description);
      SqlCommand cmd = new SqlCommand(commandText, coneXion);
      SqlDataReader rd = cmd.ExecuteReader();
      while (rd.Read())
      {
        //396F589C-13E2-4100-8C93-73515FDECE0E	Continetal Bank	12345	Chris Grundy	200-12345	Euro	14999.00	1	Receiver
        //396F589C-13E2-4100-8C93-73515FDECE0E	Continetal Bank	54321	George Busch	200-54321	Euro	18001.00	1	Sender
        account ac = new account();
        ac.BankId = rd.GetGuid(0);
        ac.BankName = rd.GetString(1);
        ac.CustomerCode = rd.GetString(2);
        ac.CustomerName = rd.GetString(3);
        ac.AccountCode = rd.GetString(4);
        ac.AccountCurrency = rd.GetString(5);
        ac.AccountBalance = rd.GetDecimal(6);
        if (rd.GetString(8).ToLower() == "receiver")
          result.NewBalanceReceiver = ac;
        if (rd.GetString(8).ToLower() == "sender")
          result.NewBalanceSender = ac;
      }
      rd.Close();
      result.ErrorCode = 0;
      result.ErrorText = string.Empty;
    }
    catch (Exception ex)
    {
      if (result.ErrorCode == 0) result.ErrorCode = -1;
      result.ErrorText = ex.Message;
    }
    return result;
  }
  #endregion
}

