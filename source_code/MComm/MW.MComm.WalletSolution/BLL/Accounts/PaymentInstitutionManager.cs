
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MW.MComm.WalletSolution.BLL.Accounts;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Accounts
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage PaymentInstitution related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PaymentInstitutionManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PaymentInstitutionManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts PaymentInstitution data.</summary>
		///
		/// <param name="item">The PaymentInstitution to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOnePaymentInstitution(BLL.Accounts.PaymentInstitution item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.PaymentInstitutionManager.AddOnePaymentInstitution(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts PaymentInstitution data.</summary>
		///
		/// <param name="item">The PaymentInstitution to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOnePaymentInstitution(BLL.Accounts.PaymentInstitution item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(PaymentInstitutionCode), item.PaymentInstitutionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.PaymentInstitution itemDAL = new DAL.Accounts.PaymentInstitution();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.PaymentInstitution.AddOnePaymentInstitution(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.AddOnePaymentInstitution");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes PaymentInstitution data.</summary>
		///
		/// <param name="item">The PaymentInstitution to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePaymentInstitution(BLL.Accounts.PaymentInstitution item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.PaymentInstitutionManager.DeleteOnePaymentInstitution(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes PaymentInstitution data.</summary>
		///
		/// <param name="item">The PaymentInstitution to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePaymentInstitution(BLL.Accounts.PaymentInstitution item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(PaymentInstitutionCode), item.PaymentInstitutionCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.Accounts.PaymentInstitution itemDAL = new DAL.Accounts.PaymentInstitution();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.PaymentInstitution.DeleteOnePaymentInstitution(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.DeleteOnePaymentInstitution");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentInstitution data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.PaymentInstitution> GetAllPaymentInstitutionData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.PaymentInstitutionManager.GetAllPaymentInstitutionData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentInstitution data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.PaymentInstitution> GetAllPaymentInstitutionData()
		{
			// perform main method tasks
			return BLL.Accounts.PaymentInstitutionManager.GetAllPaymentInstitutionData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all PaymentInstitution data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Accounts.PaymentInstitution> GetAllPaymentInstitutionData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Accounts.PaymentInstitution> sortableList = new BLL.SortableList<BLL.Accounts.PaymentInstitution>(DAL.Accounts.PaymentInstitution.GetAllPaymentInstitutionData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Accounts.PaymentInstitution loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetAllPaymentInstitutionData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentInstitution by an index.</summary>
		///
		/// <param name="paymentInstitutionCode">The index for PaymentInstitution to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.PaymentInstitution GetOnePaymentInstitution(int paymentInstitutionCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Accounts.PaymentInstitutionManager.GetOnePaymentInstitution(paymentInstitutionCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentInstitution by an index.</summary>
		///
		/// <param name="paymentInstitutionCode">The index for PaymentInstitution to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.PaymentInstitution GetOnePaymentInstitution(int paymentInstitutionCode)
		{
			// perform main method tasks
			return BLL.Accounts.PaymentInstitutionManager.GetOnePaymentInstitution(paymentInstitutionCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single PaymentInstitution by an index.</summary>
		///
		/// <param name="paymentInstitutionCode">The index for PaymentInstitution to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Accounts.PaymentInstitution GetOnePaymentInstitution(int paymentInstitutionCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Accounts.PaymentInstitution itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Accounts.PaymentInstitution)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Accounts.PaymentInstitution.GetCacheKey(typeof(BLL.Accounts.PaymentInstitution), "PrimaryKey", paymentInstitutionCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Accounts.PaymentInstitution)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Accounts.PaymentInstitution item = DAL.Accounts.PaymentInstitution.GetOnePaymentInstitution(paymentInstitutionCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Accounts.PaymentInstitution();
						ReflectionHelper.Copy(item, itemBLL, true);
						itemBLL.ClearDirtyState(true);
						itemBLL.IsLoaded = true;
						if (useCache == true)
						{
							Utility.CacheManager.Cache.Add(key, itemBLL);
						}
					}
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.GetOnePaymentInstitution");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates PaymentInstitution data.</summary>
		///
		/// <param name="item">The PaymentInstitution to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOnePaymentInstitution(BLL.Accounts.PaymentInstitution item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Accounts.PaymentInstitutionManager.UpdateOnePaymentInstitution(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates PaymentInstitution data.</summary>
		///
		/// <param name="item">The PaymentInstitution to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOnePaymentInstitution(BLL.Accounts.PaymentInstitution item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Accounts.PaymentInstitution itemDAL = new DAL.Accounts.PaymentInstitution();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Accounts.PaymentInstitution.UpdateOnePaymentInstitution(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Accounts.UpdateOnePaymentInstitution");
			}
		}
		#endregion Methods
	}
}