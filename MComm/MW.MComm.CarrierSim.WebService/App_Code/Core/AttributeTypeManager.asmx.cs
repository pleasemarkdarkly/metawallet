

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
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using MW.MComm.CarrierSim.WebService;
using MW.MComm.CarrierSim.WebService.Core;
using BLL = MW.MComm.CarrierSim.BLL;
using MW.MComm.CarrierSim.BLL.Core;
using MOD.Data;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.WebService.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage AttributeType related information.</summary>
	///
	/// File History:
	/// <created>6/27/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[WebService(Namespace = "http://modsystems.com/MW.MComm.CarrierSim.WebService/Core/AttributeTypeManager")]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.CarrierSim.WebService/Core")]
	public class AttributeTypeManager : System.Web.Services.WebService
	{

		#region "Service Methods"

		// ------------------------------------------------------------------
		/// <summary>This web service method inserts AttributeType data.</summary>
		///
		/// <param name="item">The AttributeType to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the AttributeType item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.AttributeTypeResults AddOneAttributeType(BLL.Core.AttributeType item, bool performCascadeOperation)
		{
			Components.Core.AttributeTypeResults results = new Components.Core.AttributeTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.AttributeTypeManager.AddOneAttributeType(item, performCascadeOperation);
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
		/// <summary>This web service method updates AttributeType data.</summary>
		///
		/// <param name="item">The AttributeType to be managed.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade operation should be performed on the AttributeType item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.AttributeTypeResults UpdateOneAttributeType(BLL.Core.AttributeType item, bool performCascadeOperation)
		{
			Components.Core.AttributeTypeResults results = new Components.Core.AttributeTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.AttributeTypeManager.UpdateOneAttributeType(item, performCascadeOperation);
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
		/// <summary>This web service method deletes AttributeType data.</summary>
		///
		/// <param name="item">The AttributeType to be deleted.</param>
		/// <param name="performCascadeOperation">Flag, indicating if a cascade delete should be performed on the AttributeType item.</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.AttributeTypeResults DeleteOneAttributeType(BLL.Core.AttributeType item, bool performCascadeOperation)
		{
			Components.Core.AttributeTypeResults results = new Components.Core.AttributeTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.AttributeTypeManager.DeleteOneAttributeType(item, performCascadeOperation);
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
		/// <summary>This web service method gets a single AttributeType by an index.</summary>
		///
		/// <param name="attributeTypeCode">The index for AttributeType to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.AttributeTypeResults GetOneAttributeType(int attributeTypeCode, string sortColumn, string sortDirection)
		{
			Components.Core.AttributeTypeResults results = new Components.Core.AttributeTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Core.AttributeType item =  BLL.Core.AttributeTypeManager.GetOneAttributeType(MOD.Data.DataHelper.GetInt(attributeTypeCode, MOD.Data.DefaultValue.Int), Globals.getDataOptions(sortColumn, sortDirection));
				// populate desired collections with lazy loading
				bool isAccessed = true;
				item.IsSerializing = false;
				item.IsSerializing = true;
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
		/// <summary>This web service method gets all AttributeType data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Core.AttributeTypeResults GetAllAttributeTypeData(string sortColumn, string sortDirection)
		{
			Components.Core.AttributeTypeResults results = new Components.Core.AttributeTypeResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Core.AttributeTypeManager.GetAllAttributeTypeData(Globals.getDataOptions(sortColumn, sortDirection));
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
		#endregion "Service Methods"

		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This web service method is the constructor.</summary>
		// ------------------------------------------------------------------------------
		public AttributeTypeManager()
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