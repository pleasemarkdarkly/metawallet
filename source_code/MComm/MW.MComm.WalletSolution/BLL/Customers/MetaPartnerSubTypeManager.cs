
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
	/// <summary>This class is used to manage MetaPartnerSubType related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class MetaPartnerSubTypeManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public MetaPartnerSubTypeManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts MetaPartnerSubType data.</summary>
		///
		/// <param name="item">The MetaPartnerSubType to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneMetaPartnerSubType(BLL.Customers.MetaPartnerSubType item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerSubTypeManager.AddOneMetaPartnerSubType(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts MetaPartnerSubType data.</summary>
		///
		/// <param name="item">The MetaPartnerSubType to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneMetaPartnerSubType(BLL.Customers.MetaPartnerSubType item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(MetaPartnerSubTypeCode), item.MetaPartnerSubTypeCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationAddException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationAddException), null);
				}
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartnerSubType itemDAL = new DAL.Customers.MetaPartnerSubType();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerSubType.AddOneMetaPartnerSubType(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.AddOneMetaPartnerSubType");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerSubType data.</summary>
		///
		/// <param name="item">The MetaPartnerSubType to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerSubType(BLL.Customers.MetaPartnerSubType item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerSubTypeManager.DeleteOneMetaPartnerSubType(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes MetaPartnerSubType data.</summary>
		///
		/// <param name="item">The MetaPartnerSubType to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneMetaPartnerSubType(BLL.Customers.MetaPartnerSubType item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				// perform enum check
				if (Enum.IsDefined(typeof(MetaPartnerSubTypeCode), item.MetaPartnerSubTypeCode) == true)
				{
					throw new Utility.CustomAppException(BLL.Core.ErrorNumber.EnumerationDeleteException, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.EnumerationDeleteException), null);
				}
				DAL.Customers.MetaPartnerSubType itemDAL = new DAL.Customers.MetaPartnerSubType();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerSubType.DeleteOneMetaPartnerSubType(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.DeleteOneMetaPartnerSubType");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerSubType data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerSubType> GetAllMetaPartnerSubTypeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerSubTypeManager.GetAllMetaPartnerSubTypeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerSubType data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerSubType> GetAllMetaPartnerSubTypeData()
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerSubTypeManager.GetAllMetaPartnerSubTypeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all MetaPartnerSubType data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Customers.MetaPartnerSubType> GetAllMetaPartnerSubTypeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Customers.MetaPartnerSubType> sortableList = new BLL.SortableList<BLL.Customers.MetaPartnerSubType>(DAL.Customers.MetaPartnerSubType.GetAllMetaPartnerSubTypeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Customers.MetaPartnerSubType loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetAllMetaPartnerSubTypeData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerSubType by an index.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">The index for MetaPartnerSubType to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerSubType GetOneMetaPartnerSubType(int metaPartnerSubTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerSubTypeManager.GetOneMetaPartnerSubType(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerSubType by an index.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">The index for MetaPartnerSubType to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerSubType GetOneMetaPartnerSubType(int metaPartnerSubTypeCode)
		{
			// perform main method tasks
			return BLL.Customers.MetaPartnerSubTypeManager.GetOneMetaPartnerSubType(metaPartnerSubTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single MetaPartnerSubType by an index.</summary>
		///
		/// <param name="metaPartnerSubTypeCode">The index for MetaPartnerSubType to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Customers.MetaPartnerSubType GetOneMetaPartnerSubType(int metaPartnerSubTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Customers.MetaPartnerSubType itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Customers.MetaPartnerSubType)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Customers.MetaPartnerSubType.GetCacheKey(typeof(BLL.Customers.MetaPartnerSubType), "PrimaryKey", metaPartnerSubTypeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Customers.MetaPartnerSubType)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Customers.MetaPartnerSubType item = DAL.Customers.MetaPartnerSubType.GetOneMetaPartnerSubType(metaPartnerSubTypeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Customers.MetaPartnerSubType();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.GetOneMetaPartnerSubType");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates MetaPartnerSubType data.</summary>
		///
		/// <param name="item">The MetaPartnerSubType to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneMetaPartnerSubType(BLL.Customers.MetaPartnerSubType item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Customers.MetaPartnerSubTypeManager.UpdateOneMetaPartnerSubType(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates MetaPartnerSubType data.</summary>
		///
		/// <param name="item">The MetaPartnerSubType to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneMetaPartnerSubType(BLL.Customers.MetaPartnerSubType item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Customers.MetaPartnerSubType itemDAL = new DAL.Customers.MetaPartnerSubType();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Customers.MetaPartnerSubType.UpdateOneMetaPartnerSubType(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Customers.UpdateOneMetaPartnerSubType");
			}
		}
		#endregion Methods
	}
}