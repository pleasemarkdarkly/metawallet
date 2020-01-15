

/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.ComponentModel;
using MW.MComm.CarrierSim.BLL.Customers;
using MOD.Data;
using MW.MComm.CarrierSim.BLL.Config;
using BLL = MW.MComm.CarrierSim.BLL;
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage Phone related information.</summary>
	///
	/// File History:
	/// <created>6/4/2007 (Chris Grundy)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class PhoneManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public PhoneManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------
		/// <summary>This method deletes Phone data.</summary>
		///
		/// <param name="item">The Phone to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePhone(BLL.Customers.Phone item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.PhoneManager.DeleteOnePhone(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes Phone data.</summary>
		///
		/// <param name="item">The Phone to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOnePhone(BLL.Customers.Phone item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Phone itemDAL = new DAL.Customers.Phone();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Phone.DeleteOnePhone(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOnePhone");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all Phone data by a key.</summary>
		///
		/// <param name="customerID">A key for Phone items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPhoneDataByCustomerID(Guid customerID)
		{
			// perform main method tasks
			BLL.Customers.PhoneManager.DeleteAllPhoneDataByCustomerID(customerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all Phone data by a key.</summary>
		///
		/// <param name="customerID">A key for Phone items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllPhoneDataByCustomerID(Guid customerID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Customers.Phone.DeleteAllPhoneDataByCustomerID(customerID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteAllPhoneDataByCustomerID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single Phone by an index.</summary>
		///
		/// <param name="phoneID">The index for Phone to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Phone GetOnePhone(Guid phoneID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetOnePhone(phoneID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single Phone by an index.</summary>
		///
		/// <param name="phoneID">The index for Phone to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Phone GetOnePhone(Guid phoneID)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetOnePhone(phoneID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single Phone by an index.</summary>
		///
		/// <param name="phoneID">The index for Phone to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Phone GetOnePhone(Guid phoneID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.Phone itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.Phone)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.Phone.GetCacheKey(typeof(BLL.Customers.Phone), "PrimaryKey", phoneID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.Phone)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.Phone item = DAL.Customers.Phone.GetOnePhone(phoneID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.Phone();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOnePhone");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetAllPhoneData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneData()
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetAllPhoneData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Phone> sortableList = new BLL.SortableList<BLL.Customers.Phone>(DAL.Customers.Phone.GetAllPhoneData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Phone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllPhoneData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by a key.</summary>
		///
		/// <param name="customerID">A key for Phone items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneDataByCustomerID(Guid customerID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetAllPhoneDataByCustomerID(customerID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by a key.</summary>
		///
		/// <param name="customerID">A key for Phone items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneDataByCustomerID(Guid customerID)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetAllPhoneDataByCustomerID(customerID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by a key.</summary>
		///
		/// <param name="customerID">A key for Phone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneDataByCustomerID(Guid customerID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Phone> sortableList = new BLL.SortableList<BLL.Customers.Phone>(DAL.Customers.Phone.GetAllPhoneDataByCustomerID(customerID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Phone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllPhoneDataByCustomerID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Phone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Phone items to be fetched</param>
		/// <param name="phoneNumber">A key for Phone items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string phoneNumber, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetAllPhoneDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, phoneNumber, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Phone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Phone items to be fetched</param>
		/// <param name="phoneNumber">A key for Phone items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string phoneNumber)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetAllPhoneDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, phoneNumber, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Phone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Phone items to be fetched</param>
		/// <param name="phoneNumber">A key for Phone items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetAllPhoneDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string phoneNumber, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Phone> sortableList = new BLL.SortableList<BLL.Customers.Phone>(DAL.Customers.Phone.GetAllPhoneDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, phoneNumber, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Phone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllPhoneDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Phone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Phone items to be fetched</param>
		/// <param name="phoneNumber">A key for Phone items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetManyPhoneDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string phoneNumber, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetManyPhoneDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, phoneNumber, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all Phone data by criteria.</summary>
		///
		/// <param name="lastModifiedDateStart">A key for Phone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for Phone items to be fetched</param>
		/// <param name="phoneNumber">A key for Phone items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.Phone> GetManyPhoneDataByCriteria(DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, string phoneNumber, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.Phone> sortableList = new BLL.SortableList<BLL.Customers.Phone>(DAL.Customers.Phone.GetManyPhoneDataByCriteria(lastModifiedDateStart, lastModifiedDateEnd, phoneNumber, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.Phone loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetManyPhoneDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Phone data.</summary>
		///
		/// <param name="item">The Phone to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOnePhone(BLL.Customers.Phone item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.PhoneManager.UpsertOnePhone(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates Phone data.</summary>
		///
		/// <param name="item">The Phone to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOnePhone(BLL.Customers.Phone item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.Phone itemDAL = new DAL.Customers.Phone();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.Phone.UpsertOnePhone(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpsertOnePhone");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single Phone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for Phone to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Phone GetOnePhoneByPhoneNumber(string phoneNumber, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetOnePhoneByPhoneNumber(phoneNumber, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single Phone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for Phone to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Phone GetOnePhoneByPhoneNumber(string phoneNumber)
		{
			// perform main method tasks
			return BLL.Customers.PhoneManager.GetOnePhoneByPhoneNumber(phoneNumber, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single Phone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for Phone to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.Phone GetOnePhoneByPhoneNumber(string phoneNumber, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.Phone itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.Phone)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.Phone.GetCacheKey(typeof(BLL.Customers.Phone), "PrimaryKey", phoneNumber.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.Phone)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.Phone item = DAL.Customers.Phone.GetOnePhoneByPhoneNumber(phoneNumber, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.Phone();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOnePhoneByPhoneNumber");
			}
		}
		#endregion Methods
	}
}