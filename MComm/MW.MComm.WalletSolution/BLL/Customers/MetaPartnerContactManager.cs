
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
	/// <summary>This class is used to manage MetaPartnerContact related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerContactManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerContactManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts MetaPartnerContact data.</summary>
		///
		/// <param name="item">The MetaPartnerContact to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneMetaPartnerContact(BLL.Customers.MetaPartnerContact item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerContactManager.AddOneMetaPartnerContact(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts MetaPartnerContact data.</summary>
		///
		/// <param name="item">The MetaPartnerContact to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneMetaPartnerContact(BLL.Customers.MetaPartnerContact item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartnerContact itemDAL = new DAL.Customers.MetaPartnerContact();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerContact.AddOneMetaPartnerContact(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.AddOneMetaPartnerContact");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="contactMetaPartnerID">A key for MetaPartnerContact items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerContactDataByContactMetaPartnerID(Guid contactMetaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerContactManager.DeleteAllMetaPartnerContactDataByContactMetaPartnerID(contactMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="contactMetaPartnerID">A key for MetaPartnerContact items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerContactDataByContactMetaPartnerID(Guid contactMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerContact.DeleteAllMetaPartnerContactDataByContactMetaPartnerID(contactMetaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerContactDataByContactMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerContact items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerContactDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerContactManager.DeleteAllMetaPartnerContactDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerContact items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllMetaPartnerContactDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerContact.DeleteAllMetaPartnerContactDataByMetaPartnerID(metaPartnerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllMetaPartnerContactDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerContact data.</summary>
		///
		/// <param name="item">The MetaPartnerContact to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerContact(BLL.Customers.MetaPartnerContact item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerContactManager.DeleteOneMetaPartnerContact(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerContact data.</summary>
		///
		/// <param name="item">The MetaPartnerContact to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerContact(BLL.Customers.MetaPartnerContact item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.MetaPartnerContact itemDAL = new DAL.Customers.MetaPartnerContact();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerContact.DeleteOneMetaPartnerContact(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneMetaPartnerContact");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetAllMetaPartnerContactData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactData()
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetAllMetaPartnerContactData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerContact> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerContact>(DAL.Customers.MetaPartnerContact.GetAllMetaPartnerContactData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerContact loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerContactData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="contactMetaPartnerID">A key for MetaPartnerContact items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactDataByContactMetaPartnerID(Guid contactMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetAllMetaPartnerContactDataByContactMetaPartnerID(contactMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="contactMetaPartnerID">A key for MetaPartnerContact items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactDataByContactMetaPartnerID(Guid contactMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetAllMetaPartnerContactDataByContactMetaPartnerID(contactMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="contactMetaPartnerID">A key for MetaPartnerContact items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactDataByContactMetaPartnerID(Guid contactMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerContact> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerContact>(DAL.Customers.MetaPartnerContact.GetAllMetaPartnerContactDataByContactMetaPartnerID(contactMetaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerContact loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerContactDataByContactMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerContact items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetAllMetaPartnerContactDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerContact items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactDataByMetaPartnerID(Guid metaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetAllMetaPartnerContactDataByMetaPartnerID(metaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerContact data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerContact items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerContact> GetAllMetaPartnerContactDataByMetaPartnerID(Guid metaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerContact> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerContact>(DAL.Customers.MetaPartnerContact.GetAllMetaPartnerContactDataByMetaPartnerID(metaPartnerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerContact loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerContactDataByMetaPartnerID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerContact by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for MetaPartnerContact to be fetched</param>
		/// <param name="contactMetaPartnerID">The index for MetaPartnerContact to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerContact GetOneMetaPartnerContact(Guid metaPartnerID, Guid contactMetaPartnerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetOneMetaPartnerContact(metaPartnerID, contactMetaPartnerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerContact by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for MetaPartnerContact to be fetched</param>
		/// <param name="contactMetaPartnerID">The index for MetaPartnerContact to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerContact GetOneMetaPartnerContact(Guid metaPartnerID, Guid contactMetaPartnerID)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerContactManager.GetOneMetaPartnerContact(metaPartnerID, contactMetaPartnerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerContact by an index.</summary>
		///
		/// <param name="metaPartnerID">The index for MetaPartnerContact to be fetched</param>
		/// <param name="contactMetaPartnerID">The index for MetaPartnerContact to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerContact GetOneMetaPartnerContact(Guid metaPartnerID, Guid contactMetaPartnerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerContact itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerContact)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerContact.GetCacheKey(typeof(BLL.Customers.MetaPartnerContact), "PrimaryKey", metaPartnerID.ToString() + ", " + contactMetaPartnerID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerContact)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerContact item = DAL.Customers.MetaPartnerContact.GetOneMetaPartnerContact(metaPartnerID, contactMetaPartnerID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerContact();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerContact");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates MetaPartnerContact data.</summary>
		///
		/// <param name="item">The MetaPartnerContact to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneMetaPartnerContact(BLL.Customers.MetaPartnerContact item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerContactManager.UpdateOneMetaPartnerContact(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates MetaPartnerContact data.</summary>
		///
		/// <param name="item">The MetaPartnerContact to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneMetaPartnerContact(BLL.Customers.MetaPartnerContact item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartnerContact itemDAL = new DAL.Customers.MetaPartnerContact();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerContact.UpdateOneMetaPartnerContact(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpdateOneMetaPartnerContact");
			}
		}
		#endregion Methods
	}
}