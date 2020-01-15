
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
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using MW.MComm.WalletTest.WebService;
using MW.MComm.WalletTest.WebService.Core;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Core;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage DataType related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class DataTypeManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method inserts DataType data.</summary>
		///
		/// <param name="dataTypeCode">A property of DataType item to be managed</param>
		/// <param name="dataTypeName">A property of DataType item to be managed</param>
		/// <param name="description">A property of DataType item to be managed</param>
		/// <param name="isActive">A property of DataType item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DataTypeResults AddOneDataType(int dataTypeCode, string dataTypeName, string description, bool isActive)
		{
			Components.Core.DataTypeResults results = new Components.Core.DataTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DataType item = new BLL.Core.DataType();
				item.DataTypeCode = dataTypeCode;
				item.DataTypeName = dataTypeName;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Core.DataTypeManager.AddOneDataType(item, false);
				results.Results.Add(item);
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes DataType data.</summary>
		///
		/// <param name="dataTypeCode">A property of DataType item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DataTypeResults DeleteOneDataType(int dataTypeCode)
		{
			Components.Core.DataTypeResults results = new Components.Core.DataTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DataType item = new BLL.Core.DataType();
				item.DataTypeCode = dataTypeCode;
				BLL.Core.DataTypeManager.DeleteOneDataType(item, false);
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets all DataType data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DataTypeResults GetAllDataTypeData(string sortColumn, string sortDirection)
		{
			Components.Core.DataTypeResults results = new Components.Core.DataTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Core.DataTypeManager.GetAllDataTypeData(Globals.getDataOptions(sortColumn, sortDirection));
				results.TotalRecords = results.Results.Count;
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method gets a single DataType by an index.</summary>
		///
		/// <param name="dataTypeCode">The index for DataType to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DataTypeResults GetOneDataType(int dataTypeCode, string sortColumn, string sortDirection)
		{
			Components.Core.DataTypeResults results = new Components.Core.DataTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DataType item =  BLL.Core.DataTypeManager.GetOneDataType(MOD.Data.DataHelper.GetInt(dataTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				results.Results.Add(item);
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		// ------------------------------------------------------------------
		/// <summary>This web service method updates DataType data.</summary>
		///
		/// <param name="dataTypeCode">A property of DataType item to be managed</param>
		/// <param name="dataTypeName">A property of DataType item to be managed</param>
		/// <param name="description">A property of DataType item to be managed</param>
		/// <param name="isActive">A property of DataType item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.DataTypeResults UpdateOneDataType(int dataTypeCode, string dataTypeName, string description, bool isActive)
		{
			Components.Core.DataTypeResults results = new Components.Core.DataTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.DataType item = new BLL.Core.DataType();
				item.DataTypeCode = dataTypeCode;
				item.DataTypeName = dataTypeName;
				item.Description = description;
				item.IsActive = isActive;
				BLL.Core.DataTypeManager.UpdateOneDataType(item, false);
				results.Results.Add(item);
			}
			catch (System.Exception ex)
			{
				results.StatusCode = -1;
				string exceptionMessage = "";
				System.Exception messageEx = ex;
				while (messageEx != null)
				{
					exceptionMessage += System.Environment.NewLine + messageEx.Message;
					messageEx = messageEx.InnerException;
				}
				results.StatusDescription = exceptionMessage;
			}
			finally
			{
			}
			return results;
		}
		#endregion "Service Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This web service method is the constructor.</summary>
		// ------------------------------------------------------------------------------
		public DataTypeManager()
		{
			//
			// constructor logic
			//
			InitializeComponent();
		}
			//Required by the Web Services Designer
			private IContainer components = null;
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#endregion "Miscellaneous"
	}
}