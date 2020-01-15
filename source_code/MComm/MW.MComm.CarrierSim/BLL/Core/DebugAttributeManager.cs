

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
using MW.MComm.CarrierSim.BLL.Core;
using MOD.Data;
using MW.MComm.CarrierSim.BLL.Config;
using BLL = MW.MComm.CarrierSim.BLL;
using DAL = MW.MComm.CarrierSim.DAL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage DebugAttribute related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class DebugAttributeManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public DebugAttributeManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------
		/// <summary>This method inserts DebugAttribute data.</summary>
		///
		/// <param name="item">The DebugAttribute to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneDebugAttribute(BLL.Core.DebugAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Core.DebugAttributeManager.AddOneDebugAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts DebugAttribute data.</summary>
		///
		/// <param name="item">The DebugAttribute to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneDebugAttribute(BLL.Core.DebugAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.DebugAttribute itemDAL = new DAL.Core.DebugAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.DebugAttribute.AddOneDebugAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.AddOneDebugAttribute");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all DebugAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllDebugAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			// perform main method tasks
			BLL.Core.DebugAttributeManager.DeleteAllDebugAttributeDataByAttributeTypeCode(attributeTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all DebugAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllDebugAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.DebugAttribute.DeleteAllDebugAttributeDataByAttributeTypeCode(attributeTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllDebugAttributeDataByAttributeTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all DebugAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllDebugAttributeDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			BLL.Core.DebugAttributeManager.DeleteAllDebugAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all DebugAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllDebugAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.DebugAttribute.DeleteAllDebugAttributeDataByBaseAttributeID(baseAttributeID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllDebugAttributeDataByBaseAttributeID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all DebugAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for DebugAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllDebugAttributeDataByDataTypeCode(int dataTypeCode)
		{
			// perform main method tasks
			BLL.Core.DebugAttributeManager.DeleteAllDebugAttributeDataByDataTypeCode(dataTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all DebugAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for DebugAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllDebugAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.DebugAttribute.DeleteAllDebugAttributeDataByDataTypeCode(dataTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllDebugAttributeDataByDataTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes DebugAttribute data.</summary>
		///
		/// <param name="item">The DebugAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneDebugAttribute(BLL.Core.DebugAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Core.DebugAttributeManager.DeleteOneDebugAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes DebugAttribute data.</summary>
		///
		/// <param name="item">The DebugAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneDebugAttribute(BLL.Core.DebugAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.DebugAttribute itemDAL = new DAL.Core.DebugAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.DebugAttribute.DeleteOneDebugAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteOneDebugAttribute");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeData()
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttribute> sortableList = new BLL.SortableList<BLL.Core.DebugAttribute>(DAL.Core.DebugAttribute.GetAllDebugAttributeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByAttributeTypeCode(attributeTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByAttributeTypeCode(attributeTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttribute> sortableList = new BLL.SortableList<BLL.Core.DebugAttribute>(DAL.Core.DebugAttribute.GetAllDebugAttributeDataByAttributeTypeCode(attributeTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeDataByAttributeTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for DebugAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttribute> sortableList = new BLL.SortableList<BLL.Core.DebugAttribute>(DAL.Core.DebugAttribute.GetAllDebugAttributeDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeDataByBaseAttributeID");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for DebugAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for DebugAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for DebugAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttribute> sortableList = new BLL.SortableList<BLL.Core.DebugAttribute>(DAL.Core.DebugAttribute.GetAllDebugAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByDataTypeCode(dataTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByDataTypeCode(int dataTypeCode)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetAllDebugAttributeDataByDataTypeCode(dataTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetAllDebugAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttribute> sortableList = new BLL.SortableList<BLL.Core.DebugAttribute>(DAL.Core.DebugAttribute.GetAllDebugAttributeDataByDataTypeCode(dataTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllDebugAttributeDataByDataTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for DebugAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttribute items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetManyDebugAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetManyDebugAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all DebugAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for DebugAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for DebugAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for DebugAttribute items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.DebugAttribute> GetManyDebugAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.DebugAttribute> sortableList = new BLL.SortableList<BLL.Core.DebugAttribute>(DAL.Core.DebugAttribute.GetManyDebugAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.DebugAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetManyDebugAttributeDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for DebugAttribute to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttribute GetOneDebugAttribute(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetOneDebugAttribute(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for DebugAttribute to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttribute GetOneDebugAttribute(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetOneDebugAttribute(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for DebugAttribute to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttribute GetOneDebugAttribute(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Core.DebugAttribute itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Core.DebugAttribute)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Core.DebugAttribute.GetCacheKey(typeof(BLL.Core.DebugAttribute), "PrimaryKey", baseAttributeID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Core.DebugAttribute)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Core.DebugAttribute item = DAL.Core.DebugAttribute.GetOneDebugAttribute(baseAttributeID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Core.DebugAttribute();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttribute");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for DebugAttribute to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttribute GetOneDebugAttributeByAttributeCode(int attributeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetOneDebugAttributeByAttributeCode(attributeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for DebugAttribute to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttribute GetOneDebugAttributeByAttributeCode(int attributeCode)
		{
			// perform main method tasks
			return BLL.Core.DebugAttributeManager.GetOneDebugAttributeByAttributeCode(attributeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single DebugAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for DebugAttribute to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.DebugAttribute GetOneDebugAttributeByAttributeCode(int attributeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Core.DebugAttribute itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Core.DebugAttribute)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Core.DebugAttribute.GetCacheKey(typeof(BLL.Core.DebugAttribute), "PrimaryKey", attributeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Core.DebugAttribute)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Core.DebugAttribute item = DAL.Core.DebugAttribute.GetOneDebugAttributeByAttributeCode(attributeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Core.DebugAttribute();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneDebugAttributeByAttributeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method updates DebugAttribute data.</summary>
		///
		/// <param name="item">The DebugAttribute to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneDebugAttribute(BLL.Core.DebugAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Core.DebugAttributeManager.UpdateOneDebugAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}



		// ------------------------------------------------------------------
		/// <summary>This method updates DebugAttribute data.</summary>
		///
		/// <param name="item">The DebugAttribute to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneDebugAttribute(BLL.Core.DebugAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.DebugAttribute itemDAL = new DAL.Core.DebugAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.DebugAttribute.UpdateOneDebugAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.UpdateOneDebugAttribute");
			}
		}
		#endregion Methods
	}
}