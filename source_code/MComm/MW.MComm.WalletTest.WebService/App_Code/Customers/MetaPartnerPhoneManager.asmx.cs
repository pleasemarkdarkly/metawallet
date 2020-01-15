
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
using MW.MComm.WalletTest.WebService.Customers;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Customers;
using MOD.Data;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace MW.MComm.WalletTest.WebService.Customers
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage MetaPartnerPhone related information.</summary>
	///
	/// File History:
	/// <created>1/26/2007 (Dave Clemmer)</created>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class MetaPartnerPhoneManager : System.Web.Services.WebService
	{
		#region "Service Methods"
		// ------------------------------------------------------------------
		/// <summary>This web service method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(string carrierMetaPartnerID)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhoneManager.DeleteAllMetaPartnerPhoneDataByCarrierMetaPartnerID(MOD.Data.DataHelper.GetGuid(carrierMetaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be deleted</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults DeleteAllMetaPartnerPhoneDataByMetaPartnerID(string metaPartnerID)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhoneManager.DeleteAllMetaPartnerPhoneDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid));
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
		/// <summary>This web service method deletes MetaPartnerPhone data.</summary>
		///
		/// <param name="metaPartnerPhoneID">A property of MetaPartnerPhone item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults DeleteOneMetaPartnerPhone(string metaPartnerPhoneID)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhone item = new BLL.Customers.MetaPartnerPhone();
				item.MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(metaPartnerPhoneID, MOD.Data.DefaultValue.Guid);
				BLL.Customers.MetaPartnerPhoneManager.DeleteOneMetaPartnerPhone(item, false);
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
		/// <summary>This web service method gets all MetaPartnerPhone data.</summary>
		///
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetAllMetaPartnerPhoneData(string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneData(Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="carrierMetaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(string carrierMetaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByCarrierMetaPartnerID(MOD.Data.DataHelper.GetGuid(carrierMetaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetAllMetaPartnerPhoneDataByCriteria(string phoneNumber, string lastModifiedDateStart, string lastModifiedDateEnd, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByCriteria(MOD.Data.SearchHelper.GetString(phoneNumber), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerPhone data by a key.</summary>
		///
		/// <param name="metaPartnerID">A key for MetaPartnerPhone items to be fetched</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetAllMetaPartnerPhoneDataByMetaPartnerID(string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				results.Results = BLL.Customers.MetaPartnerPhoneManager.GetAllMetaPartnerPhoneDataByMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets all MetaPartnerPhone data by criteria.</summary>
		///
		/// <param name="phoneNumber">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateStart">A key for MetaPartnerPhone items to be fetched</param>
		/// <param name="lastModifiedDateEnd">A key for MetaPartnerPhone items to be fetched</param>
         /// <param name="startIndex">Start Index (beginning at 1)</param>
         /// <param name="pageSize">Page Size</param>
         /// <param name="maximumListSize">Maximum List Size</param>
        /// <param name="sortColumn">Column to sort list data by</param>
         /// <param name="sortDirection">Sort direction (ascending or descending)</param>
		/// <param name="debugLevel">Debug level on error</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetManyMetaPartnerPhoneDataByCriteria(string phoneNumber, string lastModifiedDateStart, string lastModifiedDateEnd, int startIndex, int pageSize, int maximumListSize, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				int totalRecords = 0;
				bool maximumListSizeExceeded = false;
				results.Results = BLL.Customers.MetaPartnerPhoneManager.GetManyMetaPartnerPhoneDataByCriteria(MOD.Data.SearchHelper.GetString(phoneNumber), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateStart), MOD.Data.SearchHelper.GetDateTime(lastModifiedDateEnd), out totalRecords, out maximumListSizeExceeded, Globals.getDataOptions(sortColumn, sortDirection, startIndex, pageSize, maximumListSize));
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
		/// <summary>This web service method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetOneMetaPartnerPhone(string metaPartnerPhoneID, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhone item =  BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhone(MOD.Data.DataHelper.GetGuid(metaPartnerPhoneID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="metaPartnerPhoneID">The index for MetaPartnerPhone to be fetched</param>
		/// <param name="metaPartnerID">The index for MetaPartnerPhone to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(string metaPartnerPhoneID, string metaPartnerID, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhone item =  BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByMetaPartnerPhoneIDAndMetaPartnerID(MOD.Data.DataHelper.GetGuid(metaPartnerPhoneID, MOD.Data.DefaultValue.Guid), MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method gets a single MetaPartnerPhone by an index.</summary>
		///
		/// <param name="phoneNumber">The index for MetaPartnerPhone to be fetched</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults GetOneMetaPartnerPhoneByPhoneNumber(string phoneNumber, string sortColumn, string sortDirection)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhone item =  BLL.Customers.MetaPartnerPhoneManager.GetOneMetaPartnerPhoneByPhoneNumber(MOD.Data.DataHelper.GetString(phoneNumber, MOD.Data.DefaultValue.String), Globals.getDataOptions(sortColumn, sortDirection));
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
		/// <summary>This web service method inserts or updates MetaPartnerPhone data.</summary>
		///
		/// <param name="metaPartnerPhoneID">A property of MetaPartnerPhone item to be managed</param>
		/// <param name="phoneNumber">A property of MetaPartnerPhone item to be managed</param>
		/// <param name="metaPartnerID">A property of MetaPartnerPhone item to be managed</param>
		/// <param name="pIN">A property of MetaPartnerPhone item to be managed</param>
		/// <param name="carrierMetaPartnerID">A property of MetaPartnerPhone item to be managed</param>
		/// <param name="rank">A property of MetaPartnerPhone item to be managed</param>
		/// <param name="isActive">A property of MetaPartnerPhone item to be managed</param>
		// ------------------------------------------------------------------
		[WebMethod]
		public Components.Customers.MetaPartnerPhoneResults UpsertOneMetaPartnerPhone(string metaPartnerPhoneID, string phoneNumber, string metaPartnerID, string pIN, string carrierMetaPartnerID, int rank, bool isActive)
		{
			Components.Customers.MetaPartnerPhoneResults results = new Components.Customers.MetaPartnerPhoneResults();
			results.StatusDescription = "Results OK";
			try
			{
				// perform main method tasks
				BLL.Customers.MetaPartnerPhone item = new BLL.Customers.MetaPartnerPhone();
				item.MetaPartnerPhoneID = MOD.Data.DataHelper.GetGuid(metaPartnerPhoneID, MOD.Data.DefaultValue.Guid);
				item.PhoneNumber = phoneNumber;
				item.MetaPartnerID = MOD.Data.DataHelper.GetGuid(metaPartnerID, MOD.Data.DefaultValue.Guid);
				item.PIN = pIN;
				item.CarrierMetaPartnerID = MOD.Data.DataHelper.GetGuid(carrierMetaPartnerID, MOD.Data.DefaultValue.Guid);
				item.Rank = rank;
				item.IsActive = isActive;
				BLL.Customers.MetaPartnerPhoneManager.UpsertOneMetaPartnerPhone(item, false);
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
		public MetaPartnerPhoneManager()
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