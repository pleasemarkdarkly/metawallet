

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
using MW.MComm.Ganadero.BLL.Core;
using MOD.Data;
using MW.MComm.Ganadero.BLL.Config;
using BLL = MW.MComm.Ganadero.BLL;
using DAL = MW.MComm.Ganadero.DAL;
using Utility = MW.MComm.Ganadero.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.Ganadero.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage BaseAttribute related information.</summary>
	///
	/// File History:
	/// <created>10/20/2006 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public partial class BaseAttributeManager
	{

		#region Constructors
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BaseAttributeManager()
		{
			//
			// constructor logic
			//
		}

		#endregion Constructors

		#region Methods

		// ------------------------------------------------------------------------------
		/// <summary>This method loads the BaseAttribute from its primary key parameters.</summary>
		// ------------------------------------------------------------------------------
		public static BLL.Core.BaseAttribute Load(Guid baseAttributeID)
		{
			BLL.Core.BaseAttribute businessObject = new BLL.Core.BaseAttribute(baseAttributeID);
			string key = BLL.Core.BaseAttribute.GetCacheKey(typeof(BLL.Core.BaseAttribute), "PrimaryKey", businessObject.PrimaryKey);
			businessObject = (BLL.Core.BaseAttribute)Utility.CacheManager.Cache[key];
			if (businessObject == null)
			{
				businessObject = BLL.Core.BaseAttributeManager.GetOneBaseAttribute(baseAttributeID);
				Utility.CacheManager.Cache.Add(key, businessObject);
			}
			return businessObject;
		}


		// ------------------------------------------------------------------
		/// <summary>This method deletes all BaseAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBaseAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			try
			{
				// perform main method tasks
				DAL.Core.BaseAttribute.DeleteAllBaseAttributeDataByAttributeTypeCode(attributeTypeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllBaseAttributeDataByAttributeTypeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all BaseAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBaseAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.BaseAttribute.DeleteAllBaseAttributeDataByAttributeTypeCode(attributeTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllBaseAttributeDataByAttributeTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes all BaseAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for BaseAttribute items to be deleted</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBaseAttributeDataByDataTypeCode(int dataTypeCode)
		{
			try
			{
				// perform main method tasks
				DAL.Core.BaseAttribute.DeleteAllBaseAttributeDataByDataTypeCode(dataTypeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllBaseAttributeDataByDataTypeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes all BaseAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for BaseAttribute items to be deleted</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteAllBaseAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.BaseAttribute.DeleteAllBaseAttributeDataByDataTypeCode(dataTypeCode, dbOptions, debugLevel);
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteAllBaseAttributeDataByDataTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method deletes BaseAttribute data.</summary>
		///
		/// <param name="item">The BaseAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneBaseAttribute(BLL.Core.BaseAttribute item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				DAL.Core.BaseAttribute itemDAL = new DAL.Core.BaseAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.BaseAttribute.DeleteOneBaseAttribute(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteOneBaseAttribute");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method deletes BaseAttribute data.</summary>
		///
		/// <param name="item">The BaseAttribute to be deleted.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void DeleteOneBaseAttribute(BLL.Core.BaseAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				DAL.Core.BaseAttribute itemDAL = new DAL.Core.BaseAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.BaseAttribute.DeleteOneBaseAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = false;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.DeleteOneBaseAttribute");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data.</summary>
		///
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeData(MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeData(ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data.</summary>
		///
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeData()
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeData(ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeData");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data.</summary>
		///
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeData(MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeData(dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeData");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByAttributeTypeCode(attributeTypeCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByAttributeTypeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByAttributeTypeCode(int attributeTypeCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByAttributeTypeCode(attributeTypeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByAttributeTypeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by a key.</summary>
		///
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByAttributeTypeCode(int attributeTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByAttributeTypeCode(attributeTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByAttributeTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for BaseAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for BaseAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BaseAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for BaseAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BaseAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByDataTypeCode(dataTypeCode, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByDataTypeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByDataTypeCode(int dataTypeCode)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByDataTypeCode(dataTypeCode, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByDataTypeCode");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by a key.</summary>
		///
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetAllBaseAttributeDataByDataTypeCode(int dataTypeCode, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetAllBaseAttributeDataByDataTypeCode(dataTypeCode, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetAllBaseAttributeDataByDataTypeCode");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for BaseAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BaseAttribute items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetManyBaseAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetManyBaseAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetManyBaseAttributeDataByCriteria");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets all BaseAttribute data by criteria.</summary>
		///
		/// <param name="attributeName">A key for BaseAttribute items to be fetched</param>
		/// <param name="attributeTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="dataTypeCode">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for BaseAttribute items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for BaseAttribute items to be fetched</param>
		/// <param name="totalRecords">Number of records in search</param>
		 /// <param name="maximumListSizeExceeded">Shows if total records size has exceeded max list size</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <param name="currentUserID">ID of the current user for authentication and auditing</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.SortableList<BLL.Core.BaseAttribute> GetManyBaseAttributeDataByCriteria(string attributeName, int? attributeTypeCode, int? dataTypeCode, DateTime? lastModifiedDateStart, DateTime? lastModifiedDateEnd, out int totalRecords, out bool maximumListSizeExceeded, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				BLL.SortableList<BLL.Core.BaseAttribute> sortableList = new BLL.SortableList<BLL.Core.BaseAttribute>(DAL.Core.BaseAttribute.GetManyBaseAttributeDataByCriteria(attributeName, attributeTypeCode, dataTypeCode, lastModifiedDateStart, lastModifiedDateEnd, out totalRecords, out maximumListSizeExceeded, dbOptions, dataOptions, debugLevel), true, true);
				foreach(BLL.Core.BaseAttribute loopObject in sortableList)
				{
					loopObject.IsLoaded = true;
				}
				return sortableList;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetManyBaseAttributeDataByCriteria");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method gets a single BaseAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for BaseAttribute to be fetched</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.BaseAttribute GetOneBaseAttribute(Guid baseAttributeID, MOD.Data.DataOptions dataOptions)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.BaseAttribute item = null;
				item = DAL.Core.BaseAttribute.GetOneBaseAttribute(baseAttributeID, ConfigurationInterface.DBOptions, dataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.BaseAttribute itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.BaseAttribute();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneBaseAttribute");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single BaseAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for BaseAttribute to be fetched</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.BaseAttribute GetOneBaseAttribute(Guid baseAttributeID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.CurrentUserID);
				DAL.Core.BaseAttribute item = null;
				item = DAL.Core.BaseAttribute.GetOneBaseAttribute(baseAttributeID, ConfigurationInterface.DBOptions, ConfigurationInterface.DefaultDataOptions, ConfigurationInterface.DebugLevel);
				BLL.Core.BaseAttribute itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.BaseAttribute();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneBaseAttribute");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method gets a single BaseAttribute by an index.</summary>
		///
		/// <param name="baseAttributeID">The index for BaseAttribute to be fetched</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="dataOptions">Data retrieval options</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static BLL.Core.BaseAttribute GetOneBaseAttribute(Guid baseAttributeID, MOD.Data.DatabaseOptions dbOptions, MOD.Data.DataOptions dataOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				Globals.AddRequiredFilterProperties(dataOptions, currentUserID);
				DAL.Core.BaseAttribute item = null;
				item = DAL.Core.BaseAttribute.GetOneBaseAttribute(baseAttributeID, dbOptions, dataOptions, debugLevel);
				BLL.Core.BaseAttribute itemBLL = null;
				if (item != null)
				{
					itemBLL = new BLL.Core.BaseAttribute();
					ReflectionHelper.Copy(item, itemBLL, true);
					itemBLL.ClearDirtyState(true);
					itemBLL.IsLoaded = true;
				}
				return itemBLL;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.GetOneBaseAttribute");
			}
		}

		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates BaseAttribute data.</summary>
		///
		/// <param name="item">The BaseAttribute to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneBaseAttribute(BLL.Core.BaseAttribute item, bool performCascadeOperation )
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = ConfigurationInterface.CurrentUserID;
				item.LastModifiedByUserID = ConfigurationInterface.CurrentUserID;
				DAL.Core.BaseAttribute itemDAL = new DAL.Core.BaseAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.BaseAttribute.UpsertOneBaseAttribute(itemDAL, performCascadeOperation, ConfigurationInterface.DBOptions, ConfigurationInterface.DebugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.UpsertOneBaseAttribute");
			}
		}



		// ------------------------------------------------------------------
		/// <summary>This method inserts or updates BaseAttribute data.</summary>
		///
		/// <param name="item">The BaseAttribute to be inserted or updated.</param>
		/// <param name="performCascadeOperation">Peform the upserts of the child entities of the item, if any exist</param>
		/// <param name="dbOptions">Database connection information</param>
		/// <param name="debugLevel">Debug level on error</param>
		/// <exception cref="CustomAppException">Thrown when an error is encountered in BLL</exception>
		/// <exception cref="System.Exception">Thrown when prior exceptions are thrown</exception>
		// ------------------------------------------------------------------
		public static void UpsertOneBaseAttribute(BLL.Core.BaseAttribute item, bool performCascadeOperation , MOD.Data.DatabaseOptions dbOptions, int debugLevel, Guid currentUserID)
		{
			try
			{
				// perform main method tasks
				item.CreatedByUserID = currentUserID;
				item.LastModifiedByUserID = currentUserID;
				DAL.Core.BaseAttribute itemDAL = new DAL.Core.BaseAttribute();
				ReflectionHelper.Copy(item, itemDAL, true);
				DAL.Core.BaseAttribute.UpsertOneBaseAttribute(itemDAL, performCascadeOperation, dbOptions, debugLevel);
				ReflectionHelper.Copy(itemDAL, item, true);
				item.IsLoaded = true;
			}
			catch (System.Exception ex)
			{
				throw Utility.CustomAppException.WrapException(ex, "BLL.Core.UpsertOneBaseAttribute");
			}
		}
		#endregion Methods
	}
}