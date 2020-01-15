
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
	/// <summary>This class is used to manage MetaPartnerPhone related information.</summary>
	///
	/// File History:
	/// <created>2/28/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerPhoneManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerPhoneManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerPhone(BLL.Customers.MetaPartnerPhone item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerPhoneManager.UpsertOneMetaPartnerPhone(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneMetaPartnerPhone(BLL.Customers.MetaPartnerPhone item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartnerPhone itemDAL = new DAL.Customers.MetaPartnerPhone();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerPhone.UpsertOneMetaPartnerPhone(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpsertOneMetaPartnerPhone");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerPhone(BLL.Customers.MetaPartnerPhone item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerPhoneManager.DeleteOneMetaPartnerPhone(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerPhone data.</summary>
		///
		/// <param name="item">The MetaPartnerPhone to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerPhone(BLL.Customers.MetaPartnerPhone item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerPhone itemDAL = new DAL.Customers.MetaPartnerPhone();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerPhone.DeleteOneMetaPartnerPhone(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneMetaPartnerPhone");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerPhoneManager.DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(carrierMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerPhone.DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(carrierMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerPhoneManager.DeleteAllMetaPartnerPhoneDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerPhone.DeleteAllMetaPartnerPhoneDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerPhoneDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhone(Guid metaPartnerPhoneID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(metaPartnerPhoneID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhone(Guid metaPartnerPhoneID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(metaPartnerPhoneID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhone(Guid metaPartnerPhoneID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerPhone itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerPhone)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerPhone.GetCacheKey(typeof(BLL.Customers.MetaPartnerPhone), "PrimaryKey", metaPartnerPhoneID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerPhone)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerPhone item = DAL.Customers.MetaPartnerPhone.GetOneMetaPartnerPhone(metaPartnerPhoneID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerPhone();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerPhone");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumber(string phoneNumber, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(phoneNumber, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumber(string phoneNumber)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(phoneNumber, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumber(string phoneNumber, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerPhone itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerPhone)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerPhone.GetCacheKey(typeof(BLL.Customers.MetaPartnerPhone), "PrimaryKey", phoneNumber.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerPhone)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerPhone item = DAL.Customers.MetaPartnerPhone.GetOneMetaPartnerPhoneByPhoneNumber(phoneNumber, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerPhone();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerPhoneByPhoneNumber");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneData()
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>(DAL.Customers.MetaPartnerPhone.GetAllMetaPartnerPhoneData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerPhone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerPhoneData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(carrierMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(carrierMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(Guid carrierMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>(DAL.Customers.MetaPartnerPhone.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(carrierMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerPhone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>(DAL.Customers.MetaPartnerPhone.GetAllMetaPartnerPhoneDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerPhone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerPhoneDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByCriteria(phoneNumber, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByCriteria(phoneNumber, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetAllMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>(DAL.Customers.MetaPartnerPhone.GetAllMetaPartnerPhoneDataByCriteria(phoneNumber, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerPhone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerPhoneDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetManyMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetManyMetaPartnerPhoneDataByCriteria(phoneNumber, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerPhone> GetManyMetaPartnerPhoneDataByCriteria(string phoneNumber, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerPhone> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerPhone>(DAL.Customers.MetaPartnerPhone.GetManyMetaPartnerPhoneDataByCriteria(phoneNumber, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerPhone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyMetaPartnerPhoneDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(Guid metaPartnerPhoneID, Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(metaPartnerPhoneID, metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerPhone to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(Guid metaPartnerPhoneID, Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(metaPartnerPhoneID, metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(Guid metaPartnerPhoneID, Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerPhone itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerPhone)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerPhone.GetCacheKey(typeof(BLL.Customers.MetaPartnerPhone), "PrimaryKey", metaPartnerPhoneID.ToString() + ", " + metaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerPhone)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerPhone item = DAL.Customers.MetaPartnerPhone.GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(metaPartnerPhoneID, metaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerPhone();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="pIN">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumberAndPIN(string phoneNumber, string pIN, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumberAndPIN(phoneNumber, pIN, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="pIN">The index for MetaPartnerPhone to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumberAndPIN(string phoneNumber, string pIN)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumberAndPIN(phoneNumber, pIN, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="pIN">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerPhone GetOneMetaPartnerPhoneByPhoneNumberAndPIN(string phoneNumber, string pIN, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerPhone itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerPhone)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerPhone.GetCacheKey(typeof(BLL.Customers.MetaPartnerPhone), "PrimaryKey", phoneNumber.ToString() + ", " + pIN.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerPhone)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerPhone item = DAL.Customers.MetaPartnerPhone.GetOneMetaPartnerPhoneByPhoneNumberAndPIN(phoneNumber, pIN, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerPhone();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerPhoneByPhoneNumberAndPIN");
			}
		}
		#endregion Methods
	}
}