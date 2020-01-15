
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
	/// <summary>This class is used to manage MetaPartnerEmail related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerEmailManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerEmailManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerEmail data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerEmail items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerEmailDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerEmailManager.DeleteAllMetaPartnerEmailDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerEmail data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerEmail items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerEmailDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerEmail.DeleteAllMetaPartnerEmailDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerEmailDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerEmail data.</summary>
		///
		/// <param name="item">The MetaPartnerEmail to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerEmail(BLL.Customers.MetaPartnerEmail item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerEmailManager.DeleteOneMetaPartnerEmail(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerEmail data.</summary>
		///
		/// <param name="item">The MetaPartnerEmail to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerEmail(BLL.Customers.MetaPartnerEmail item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerEmail itemDAL = new DAL.Customers.MetaPartnerEmail();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerEmail.DeleteOneMetaPartnerEmail(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneMetaPartnerEmail");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailData()
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerEmail> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>(DAL.Customers.MetaPartnerEmail.GetAllMetaPartnerEmailData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerEmail loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerEmailData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerEmail items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerEmail> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>(DAL.Customers.MetaPartnerEmail.GetAllMetaPartnerEmailDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerEmail loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerEmailDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerEmail items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetAllMetaPartnerEmailDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetAllMetaPartnerEmailDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerEmail> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>(DAL.Customers.MetaPartnerEmail.GetAllMetaPartnerEmailDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerEmail loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerEmailDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetManyMetaPartnerEmailDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetManyMetaPartnerEmailDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerEmail data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerEmail items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerEmail> GetManyMetaPartnerEmailDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerEmail> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerEmail>(DAL.Customers.MetaPartnerEmail.GetManyMetaPartnerEmailDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerEmail loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyMetaPartnerEmailDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerEmail by an index.</summary>
		///
		/// <param name="metaPartnerEmailID">The index for MetaPartnerEmail to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerEmail GetOneMetaPartnerEmail(Guid metaPartnerEmailID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(metaPartnerEmailID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerEmail by an index.</summary>
		///
		/// <param name="metaPartnerEmailID">The index for MetaPartnerEmail to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerEmail GetOneMetaPartnerEmail(Guid metaPartnerEmailID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmail(metaPartnerEmailID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerEmail by an index.</summary>
		///
		/// <param name="metaPartnerEmailID">The index for MetaPartnerEmail to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerEmail GetOneMetaPartnerEmail(Guid metaPartnerEmailID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerEmail itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerEmail)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerEmail.GetCacheKey(typeof(BLL.Customers.MetaPartnerEmail), "PrimaryKey", metaPartnerEmailID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerEmail)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerEmail item = DAL.Customers.MetaPartnerEmail.GetOneMetaPartnerEmail(metaPartnerEmailID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerEmail();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerEmail");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerEmail by an index.</summary>
		///
		/// <param name="emailAddress">The index for MetaPartnerEmail to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerEmail GetOneMetaPartnerEmailByEmailAddress(string emailAddress, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmailByEmailAddress(emailAddress, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerEmail by an index.</summary>
		///
		/// <param name="emailAddress">The index for MetaPartnerEmail to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerEmail GetOneMetaPartnerEmailByEmailAddress(string emailAddress)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerEmailManager.GetOneMetaPartnerEmailByEmailAddress(emailAddress, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerEmail by an index.</summary>
		///
		/// <param name="emailAddress">The index for MetaPartnerEmail to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerEmail GetOneMetaPartnerEmailByEmailAddress(string emailAddress, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerEmail itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerEmail)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerEmail.GetCacheKey(typeof(BLL.Customers.MetaPartnerEmail), "PrimaryKey", emailAddress.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerEmail)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerEmail item = DAL.Customers.MetaPartnerEmail.GetOneMetaPartnerEmailByEmailAddress(emailAddress, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerEmail();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerEmailByEmailAddress");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerEmail data.</summary>
		///
		/// <param name="item">The MetaPartnerEmail to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerEmail(BLL.Customers.MetaPartnerEmail item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerEmailManager.UpsertOneMetaPartnerEmail(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerEmail data.</summary>
		///
		/// <param name="item">The MetaPartnerEmail to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerEmail(BLL.Customers.MetaPartnerEmail item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartnerEmail itemDAL = new DAL.Customers.MetaPartnerEmail();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerEmail.UpsertOneMetaPartnerEmail(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpsertOneMetaPartnerEmail");
			}
		}
		#endregion Methods
	}
}