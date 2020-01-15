
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
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage BusinessCustomer related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class BusinessCustomerManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BusinessCustomerManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.BusinessCustomerManager.AddOneBusinessCustomer(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.BusinessCustomer itemDAL = new DAL.Customers.BusinessCustomer();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.BusinessCustomer.AddOneBusinessCustomer(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.AddOneBusinessCustomer");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBusinessCustomerDataByBusinessMetaPartnerID(Guid businessMetaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.BusinessCustomerManager.DeleteAllBusinessCustomerDataByBusinessMetaPartnerID(businessMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBusinessCustomerDataByBusinessMetaPartnerID(Guid businessMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.BusinessCustomer.DeleteAllBusinessCustomerDataByBusinessMetaPartnerID(businessMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllBusinessCustomerDataByBusinessMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBusinessCustomerDataByCustomerMetaPartnerID(Guid customerMetaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.BusinessCustomerManager.DeleteAllBusinessCustomerDataByCustomerMetaPartnerID(customerMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBusinessCustomerDataByCustomerMetaPartnerID(Guid customerMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.BusinessCustomer.DeleteAllBusinessCustomerDataByCustomerMetaPartnerID(customerMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllBusinessCustomerDataByCustomerMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.BusinessCustomerManager.DeleteOneBusinessCustomer(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.BusinessCustomer itemDAL = new DAL.Customers.BusinessCustomer();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.BusinessCustomer.DeleteOneBusinessCustomer(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneBusinessCustomer");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerData()
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.BusinessCustomer> sortableList = new BLL.SortableList<BLL.Customers.BusinessCustomer>(DAL.Customers.BusinessCustomer.GetAllBusinessCustomerData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.BusinessCustomer loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllBusinessCustomerData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerDataByBusinessMetaPartnerID(Guid businessMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerDataByBusinessMetaPartnerID(businessMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerDataByBusinessMetaPartnerID(Guid businessMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerDataByBusinessMetaPartnerID(businessMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="businessMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerDataByBusinessMetaPartnerID(Guid businessMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.BusinessCustomer> sortableList = new BLL.SortableList<BLL.Customers.BusinessCustomer>(DAL.Customers.BusinessCustomer.GetAllBusinessCustomerDataByBusinessMetaPartnerID(businessMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.BusinessCustomer loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllBusinessCustomerDataByBusinessMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerDataByCustomerMetaPartnerID(Guid customerMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerDataByCustomerMetaPartnerID(customerMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerDataByCustomerMetaPartnerID(Guid customerMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetAllBusinessCustomerDataByCustomerMetaPartnerID(customerMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all BusinessCustomer data by a key.</summary>
		///
		/// <param name="customerMetaPartnerID">A key for BusinessCustomer items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.BusinessCustomer> GetAllBusinessCustomerDataByCustomerMetaPartnerID(Guid customerMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.BusinessCustomer> sortableList = new BLL.SortableList<BLL.Customers.BusinessCustomer>(DAL.Customers.BusinessCustomer.GetAllBusinessCustomerDataByCustomerMetaPartnerID(customerMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.BusinessCustomer loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllBusinessCustomerDataByCustomerMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single BusinessCustomer by an index.</summary>
		///
		/// <param name="businessMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <param name="customerMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.BusinessCustomer GetOneBusinessCustomer(Guid businessMetaPartnerID, Guid customerMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetOneBusinessCustomer(businessMetaPartnerID, customerMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single BusinessCustomer by an index.</summary>
		///
		/// <param name="businessMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <param name="customerMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.BusinessCustomer GetOneBusinessCustomer(Guid businessMetaPartnerID, Guid customerMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.BusinessCustomerManager.GetOneBusinessCustomer(businessMetaPartnerID, customerMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single BusinessCustomer by an index.</summary>
		///
		/// <param name="businessMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <param name="customerMetaPartnerID">The index for BusinessCustomer to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.BusinessCustomer GetOneBusinessCustomer(Guid businessMetaPartnerID, Guid customerMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.BusinessCustomer itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.BusinessCustomer)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.BusinessCustomer.GetCacheKey(typeof(BLL.Customers.BusinessCustomer), "PrimaryKey", businessMetaPartnerID.ToString() + ", " + customerMetaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.BusinessCustomer)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.BusinessCustomer item = DAL.Customers.BusinessCustomer.GetOneBusinessCustomer(businessMetaPartnerID, customerMetaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.BusinessCustomer();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneBusinessCustomer");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.BusinessCustomerManager.UpdateOneBusinessCustomer(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates BusinessCustomer data.</summary>
		///
		/// <param name="item">The BusinessCustomer to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneBusinessCustomer(BLL.Customers.BusinessCustomer item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.BusinessCustomer itemDAL = new DAL.Customers.BusinessCustomer();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.BusinessCustomer.UpdateOneBusinessCustomer(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpdateOneBusinessCustomer");
			}
		}
		#endregion Methods
	}
}