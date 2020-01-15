
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
using MW.MComm.WalletSolution.BLL.Events;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using DAL = MW.MComm.WalletSolution.DAL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletSolution.BLL.Events
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage EventAttribute related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class EventAttributeManager
	{
		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public EventAttributeManager()
		{
			//
			// constructor logic
			//
		}
		#endregion Constructors
		#region Methods
		// ------------------------------------------------------------------
		/// <summary>This method inserts EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.EventAttributeManager.AddOneEventAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method inserts EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be added.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void AddOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.EventAttribute itemDAL = new DAL.Events.EventAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.EventAttribute.AddOneEventAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.AddOneEventAttribute");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			// perform main method tasks
			BLL.Events.EventAttributeManager.DeleteAllEventAttributeDataByAttributeTypeCode(attributeTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventAttribute.DeleteAllEventAttributeDataByAttributeTypeCode(attributeTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllEventAttributeDataByAttributeTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventAttributeDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			BLL.Events.EventAttributeManager.DeleteAllEventAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventAttribute.DeleteAllEventAttributeDataByBaseAttributeID(baseAttributeID, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllEventAttributeDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventAttributeDataByDataTypeCode(int dataTypeCode)
		{
			// perform main method tasks
			BLL.Events.EventAttributeManager.DeleteAllEventAttributeDataByDataTypeCode(dataTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllEventAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventAttribute.DeleteAllEventAttributeDataByDataTypeCode(dataTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteAllEventAttributeDataByDataTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.EventAttributeManager.DeleteOneEventAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method deletes EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Events.EventAttribute itemDAL = new DAL.Events.EventAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.EventAttribute.DeleteOneEventAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.DeleteOneEventAttribute");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeData(MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeData(BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeData()
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeData(BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventAttribute> sortableList = new BLL.SortableList<BLL.Events.EventAttribute>(DAL.Events.EventAttribute.GetAllEventAttributeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventAttributeData");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByAttributeTypeCode(attributeTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByAttributeTypeCode(attributeTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventAttribute> sortableList = new BLL.SortableList<BLL.Events.EventAttribute>(DAL.Events.EventAttribute.GetAllEventAttributeDataByAttributeTypeCode(attributeTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventAttributeDataByAttributeTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByBaseAttributeID(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByBaseAttributeID(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="baseAttributeID">A key for EventAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByBaseAttributeID(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventAttribute> sortableList = new BLL.SortableList<BLL.Events.EventAttribute>(DAL.Events.EventAttribute.GetAllEventAttributeDataByBaseAttributeID(baseAttributeID, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventAttributeDataByBaseAttributeID");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventAttribute> sortableList = new BLL.SortableList<BLL.Events.EventAttribute>(DAL.Events.EventAttribute.GetAllEventAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventAttributeDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByDataTypeCode(dataTypeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByDataTypeCode(int dataTypeCode)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetAllEventAttributeDataByDataTypeCode(dataTypeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetAllEventAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventAttribute> sortableList = new BLL.SortableList<BLL.Events.EventAttribute>(DAL.Events.EventAttribute.GetAllEventAttributeDataByDataTypeCode(dataTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetAllEventAttributeDataByDataTypeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetManyEventAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetManyEventAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets all EventAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for EventAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for EventAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for EventAttribute items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Events.EventAttribute> GetManyEventAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Events.EventAttribute> sortableList = new BLL.SortableList<BLL.Events.EventAttribute>(DAL.Events.EventAttribute.GetManyEventAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Events.EventAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetManyEventAttributeDataByCriteria");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for EventAttribute to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventAttribute GetOneEventAttribute(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetOneEventAttribute(baseAttributeID, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for EventAttribute to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventAttribute GetOneEventAttribute(Guid baseAttributeID)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetOneEventAttribute(baseAttributeID, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for EventAttribute to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventAttribute GetOneEventAttribute(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Events.EventAttribute itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Events.EventAttribute)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Events.EventAttribute.GetCacheKey(typeof(BLL.Events.EventAttribute), "PrimaryKey", baseAttributeID.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Events.EventAttribute)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Events.EventAttribute item = DAL.Events.EventAttribute.GetOneEventAttribute(baseAttributeID, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Events.EventAttribute();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneEventAttribute");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for EventAttribute to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventAttribute GetOneEventAttributeByAttributeCode(int attributeCode, MOD.Data.DataOptions dataOptions)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetOneEventAttributeByAttributeCode(attributeCode, BusinessObjectManager.DBOptions, dataOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for EventAttribute to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventAttribute GetOneEventAttributeByAttributeCode(int attributeCode)
		{
			// perform main method tasks
			return BLL.Events.EventAttributeManager.GetOneEventAttributeByAttributeCode(attributeCode, BusinessObjectManager.DBOptions, BusinessObjectManager.DataOptions(), BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method gets a single EventAttribute by an index.</summary>
		///
		/// <param name="attributeCode">The index for EventAttribute to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Events.EventAttribute GetOneEventAttributeByAttributeCode(int attributeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				bool useCache = false;
				string key = String.Empty;
				BLL.Events.EventAttribute itemBLL = null;
				if (dbOptions.IsCacheable(typeof(BLL.Events.EventAttribute)) == true && dataOptions.UseCache == true)
				{
					useCache = true;
					key = BLL.Events.EventAttribute.GetCacheKey(typeof(BLL.Events.EventAttribute), "PrimaryKey", attributeCode.ToString());
				}
				if (useCache == true)
				{
					itemBLL = (BLL.Events.EventAttribute)Utility.CacheManager.Cache[key];
				}
				if (itemBLL == null)
				{
					DAL.Events.EventAttribute item = DAL.Events.EventAttribute.GetOneEventAttributeByAttributeCode(attributeCode, dbOptions, dataOptions, debugLevel);
					if (item != null)
					{
						itemBLL = new BLL.Events.EventAttribute();
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
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.GetOneEventAttributeByAttributeCode");
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation )
		{
			// perform main method tasks
			BLL.Events.EventAttributeManager.UpdateOneEventAttribute(item, performCascadeOperation, BusinessObjectManager.DBOptions, BusinessObjectManager.DebugLevel, BusinessObjectManager.ApplicationUserID);
		}
		// ------------------------------------------------------------------
		/// <summary>This method updates EventAttribute data.</summary>
		///
		/// <param name="item">The EventAttribute to be updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpdateOneEventAttribute(BLL.Events.EventAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Events.EventAttribute itemDAL = new DAL.Events.EventAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Events.EventAttribute.UpdateOneEventAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Events.UpdateOneEventAttribute");
			}
		}
		#endregion Methods
	}
}