using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
[WebService(Namespace = "http://www.bg.com.bo/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
  public Service()
  {

    //Uncomment the following line if using designed components 
    //InitializeComponent(); 
  }
  #region structures
  public struct CustomerInformationResult
  {
    public string CustomerName;
    public string CustomerType;
    public int AccountCount;
    public int RegisteredBillerCount;
    public int ErrorCode;
    public string ErrorDescription;
  }
  public struct AccountInformationResult
  {
    public string AccountCode;
    public string AccountType;
    public decimal AccountBalance;
    public decimal AccountDailyLimit;
    public string AccountCurrency;
    public int ErrorCode;
    public string ErrorDescription;

  }
  public struct CurrencyConversionCalculationResult
  {

    public decimal ExchangeRate;
    public decimal SignificativeDigits;
    public decimal DestinationAmmount;
    public int ErrorCode;
    public string ErrorDescription;

  }
  public struct AccountTransferResult
  {

    public decimal ITFOriginAccount;
    public decimal ITFDestinationAccount;
    public string ConfirmationCode;
    public int ErrorCode;
    public string ErrorDescription;

  }
  #endregion
  public CustomerInformationResult GetCustomerInformation(string CustomerCode, string CustomerPin, string AuditId)
  {
    CustomerInformationResult result = new CustomerInformationResult();
    SqlConnection rdbms = RDBMSConnection();
    SqlCommand query = new SqlCommand("dbo.SpGetClient '" + CustomerCode + "'", rdbms);
    rdbms.Open();
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = query;
    DataSet ds = new DataSet();
    da.Fill(ds);
    if (ds.Tables[0].Rows.Count > 0)
    {
      if (ds.Tables[0].Rows[0]["PIN"].ToString() == CustomerPin)
      {
        result.CustomerName = ds.Tables[0].Rows[0]["ClientName"].ToString();
        result.CustomerType = ds.Tables[0].Rows[0]["ClientType"].ToString();
        result.AccountCount = (int)ds.Tables[0].Rows[0]["AccountCount"];
        result.RegisteredBillerCount = 0;
        result.ErrorCode = 0;
        result.ErrorDescription = "";
      }
      else
      {
        result.ErrorDescription = "Incorrect Pin";
        result.ErrorCode = 10002;
      }
    }
    else
    {
      result.ErrorDescription = "Client not found";
      result.ErrorCode = 10001;
    }
    rdbms.Close();
    return result;
  }
  public AccountInformationResult GetAccountInformation(string CustomerCode, string CustomerPin, string AuditId, int AccountNumber)
  {
    AccountInformationResult result = new AccountInformationResult();

    SqlConnection rdbms = RDBMSConnection();
    string querystring;
    querystring = "select * from dbo.bgeAccount t0 inner join dbo.bgeClient t1 on t0.ClientCode = t1.ClientCode where t0.ClientCode = '" + CustomerCode + "' and pin = '" + CustomerPin + "' order by AccountCod";


    SqlCommand query = new SqlCommand(querystring, rdbms);
    rdbms.Open();
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = query;
    DataSet ds = new DataSet();
    da.Fill(ds);

    if (ds.Tables[0].Rows.Count >= AccountNumber)
    {
      result.AccountCode = ds.Tables[0].Rows[AccountNumber - 1]["AccountCod"].ToString();
      result.AccountType = ds.Tables[0].Rows[AccountNumber - 1]["AccountType"].ToString();
      result.AccountBalance = (decimal)ds.Tables[0].Rows[AccountNumber - 1]["AccountBalance"];
      result.AccountDailyLimit = 0;
      result.AccountCurrency = ds.Tables[0].Rows[AccountNumber - 1]["AccountCurrency"].ToString();
      result.ErrorCode = 0;
      result.ErrorDescription = "";
    }
    else
    {
      result.ErrorDescription = "Client/Pin not found";
      result.ErrorCode = 10003;
    }


    rdbms.Close();
    return result;
  }
  public AccountInformationResult GetAccountInformation(string AccountCod)
  {



    AccountInformationResult result = new AccountInformationResult();

    SqlConnection rdbms = RDBMSConnection();
    string querystring;
    querystring = "select * from dbo.bgeAccount t0 where t0.AccountCod = '" + AccountCod + "'";


    SqlCommand query = new SqlCommand(querystring, rdbms);


    rdbms.Open();

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = query;
    DataSet ds = new DataSet();
    da.Fill(ds);

    if (ds.Tables[0].Rows.Count >= 1)
    {
      result.AccountCode = ds.Tables[0].Rows[0]["AccountCod"].ToString();
      result.AccountType = ds.Tables[0].Rows[0]["AccountType"].ToString();
      result.AccountBalance = (decimal)ds.Tables[0].Rows[0]["AccountBalance"];
      result.AccountDailyLimit = 0;
      result.AccountCurrency = ds.Tables[0].Rows[0]["AccountCurrency"].ToString();
      result.ErrorCode = 0;
      result.ErrorDescription = "";
    }
    else
    {
      result.ErrorDescription = "Account not found";
      result.ErrorCode = 10004;
    }


    rdbms.Close();
    return result;
  }
  public AccountInformationResult GetAccountInformation(string AccountCod, string CustomerCode, string CustomerPin)
  {
    AccountInformationResult result = new AccountInformationResult();

    SqlConnection rdbms = RDBMSConnection();
    string querystring;
    querystring = "select * from dbo.bgeAccount t0 inner join dbo.bgeClient t1 on t0.ClientCode = t1.ClientCode where t0.AccountCod = '" + AccountCod + "' and t1.ClientCode = '" + CustomerCode + "' and PIN = '" + CustomerPin + "'";


    SqlCommand query = new SqlCommand(querystring, rdbms);


    rdbms.Open();

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = query;
    DataSet ds = new DataSet();
    da.Fill(ds);


    if (ds.Tables[0].Rows.Count >= 1)
    {
      result.AccountCode = ds.Tables[0].Rows[0]["AccountCod"].ToString();
      result.AccountType = ds.Tables[0].Rows[0]["AccountType"].ToString();
      result.AccountBalance = (decimal)ds.Tables[0].Rows[0]["AccountBalance"];
      result.AccountDailyLimit = 0;
      result.AccountCurrency = ds.Tables[0].Rows[0]["AccountCurrency"].ToString();
      result.ErrorCode = 0;
      result.ErrorDescription = "";
    }
    else
    {
      result.ErrorDescription = "Customer/PIN/Account combination is incorrect";
      result.ErrorCode = 10005;
    }


    rdbms.Close();
    return result;
  }
  public CurrencyConversionCalculationResult GetCurrencyConversionCalculation(string OriginalCurrency, string DestinationCurrency, string Type, decimal Amount, string CustomerCode)
  {

    CurrencyConversionCalculationResult result = new CurrencyConversionCalculationResult();


    SqlConnection rdbms = RDBMSConnection();
    string querystring;
    querystring = "select * from dbo.bgeExchangeRate where OriginCurrencyCode = '" + OriginalCurrency + "' and DestinationCurrencyCode = '" + DestinationCurrency + "' and ExchangeRateGroupId = 1";


    SqlCommand query = new SqlCommand(querystring, rdbms);


    rdbms.Open();

    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = query;
    DataSet ds = new DataSet();
    da.Fill(ds);

    if (ds.Tables[0].Rows.Count >= 1)
    {
      result.ExchangeRate = (decimal)ds.Tables[0].Rows[0]["ExchangeRate"];
      result.ErrorCode = 0;
      result.ErrorDescription = "";
    }
    else
    {
      result.ErrorDescription = "Invalid Exchange Rate";
      result.ErrorCode = 10006;
    }
    rdbms.Close();
    result.DestinationAmmount = Amount * result.ExchangeRate;
    return (result);

  }
  [WebMethod]
  public CustomerInformationResult CustomerInformation(string CustomerCode, string CustomerPin, string AuditId)
  {
    CustomerInformationResult result = GetCustomerInformation(CustomerCode, CustomerPin, AuditId);
    return result;
  }
  [WebMethod]
  public AccountInformationResult AccountInformation(string CustomerCode, string CustomerPin, string AuditId, int AccountNumber)
  {
    AccountInformationResult result = GetAccountInformation(CustomerCode, CustomerPin, AuditId, AccountNumber);
    return result;
  }
  [WebMethod]
  public AccountInformationResult AccountInformation2(string CustomerCode, string CustomerPin, string AuditId, string AccountCod)
  {
    AccountInformationResult result = GetAccountInformation(AccountCod, CustomerCode, CustomerPin);
    return result;
  }
  [WebMethod]
  public CurrencyConversionCalculationResult CurrencyConversionCalculation(string OriginalCurrency, string DestinationCurrency, string Type, decimal Amount, string CustomerCode)
  {


    CurrencyConversionCalculationResult result = GetCurrencyConversionCalculation(OriginalCurrency, DestinationCurrency, Type, Amount, CustomerCode);

    return result;

  }
  [WebMethod]
  public AccountTransferResult AccountTransfer(string CustomerCode, string CustomerPin, string AuditId, string OriginAccountCode, string DestinationAccountCode, decimal Ammount, string TransactionCurrency)
  {

    // Read setting string hostIP = ReadSetting("hostIP");

    AccountTransferResult result = new AccountTransferResult();
    // Verify the CustomerCode / CustomerPin combination

    AccountInformationResult originAccount = GetAccountInformation(OriginAccountCode, CustomerCode, CustomerPin);

    if (originAccount.ErrorCode != 0)
    {
      result.ErrorCode = originAccount.ErrorCode;
      result.ErrorDescription = originAccount.ErrorDescription;
      return result;
    }
    AccountInformationResult destinationAccount = GetAccountInformation(DestinationAccountCode);

    if (destinationAccount.ErrorCode != 0)
    {
      result.ErrorCode = destinationAccount.ErrorCode;
      result.ErrorDescription = destinationAccount.ErrorDescription;
      return result;
    }



    // Verify that there are enough founds for the transaction

    if (destinationAccount.AccountBalance < Ammount)
    {
      result.ErrorCode = 10010;
      result.ErrorDescription = "The origin account has not eough founds for the transaction";
      return result;
    }


    // Perform the founds transfer


    SqlConnection rdbms = RDBMSConnection();
    rdbms.Open();
    SqlCommand objCmd = new System.Data.SqlClient.SqlCommand("bgeTransfer", rdbms);
    objCmd.CommandType = System.Data.CommandType.StoredProcedure;

    SqlParameter pTransactionDate = objCmd.Parameters.Add("@TransactionDate", System.Data.SqlDbType.DateTime);
    pTransactionDate.Direction = System.Data.ParameterDirection.Input;
    pTransactionDate.Value = System.DateTime.Now;

    //pTransactionDate.Value = "2006-01-01";

    SqlParameter pAmount = objCmd.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal);
    pAmount.Direction = System.Data.ParameterDirection.Input;
    pAmount.Value = Ammount;

    SqlParameter pOriginAccount = objCmd.Parameters.Add("@OriginAccount", System.Data.SqlDbType.VarChar);
    pOriginAccount.Direction = System.Data.ParameterDirection.Input;
    pOriginAccount.Value = OriginAccountCode;

    SqlParameter pDestinationAccount = objCmd.Parameters.Add("@DestinationAccount", System.Data.SqlDbType.VarChar);
    pDestinationAccount.Direction = System.Data.ParameterDirection.Input;
    pDestinationAccount.Value = DestinationAccountCode;

    objCmd.ExecuteNonQuery();


    rdbms.Close();

    return (result);



  }
  #region auxiliar
  public SqlConnection RDBMSConnection()
  {

    string rdbmsConnectionString = ConfigurationManager.AppSettings["rdbmsConnectionString"];
    SqlConnection rdbms = new SqlConnection(rdbmsConnectionString);
    return (rdbms);

  }
  #endregion
}
