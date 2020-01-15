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
using MW.MComm.WalletSolution.Utility;
using MW.MComm.WalletSolution.BLL.Core;
namespace MW.MComm.Admin.WebUI.Components.Desktop
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage the base information and behavior of all search user controls (lists that have search criteria and various actions).</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BaseSearchUserControl : BaseListUserControl
	{
		#region "Declarations"
		// for ProvideWorkingSet property
		private bool _provideWorkingSet = false;
		#endregion "Declarations"
		#region "Public Properties"
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not to provide a working set</summary>
		// ------------------------------------------------------------------------------
		public virtual bool ProvideWorkingSet
		{
			get
			{
				return _provideWorkingSet;
			}
			set
			{
				_provideWorkingSet = value;
			}
		}
		#endregion "Public Properties"
		#region "Public Methods"
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <exception cref="CustomAppException"></exception>
        /// <exception cref="System.Exception"></exception>
        // ------------------------------------------------------------------------------
        protected virtual void Validate()
        {
            try
            {
                // perform any necessary validation steps here (if necessary)
                Page.Validate();
            }
            catch (CustomAppException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new CustomAppException(ErrorNumber.GeneralException, SeverityLevelCode.CriticalError, EventTypeCode.ErrorLog, "Validate", ErrorManager.GetErrorMessageFromErrorNumber(ErrorNumber.GeneralException), ex);
            }
            finally
            {
            }
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <exception cref="CustomAppException"></exception>
        /// <exception cref="System.Exception"></exception>
        // ------------------------------------------------------------------------------
        protected virtual void Search()
        {
            try
            {
                // validate search criteria
                this.Validate();
				// set search parameters
				this.SetDataFromForm();
				
				// search if valid
				if (Page.IsValid == true)
				{
					// update the list if not in internal mode
					if (this.WorkflowMode != MOD.Data.WorkflowMode.Internal)
					{
						LoadCollectionFromDatabase();
						if (this.TotalRecords == 0)
						{
							Globals.AddStatusMessage("No results were found matching your search criteria, please refine your search and try again.");
						}
					}
				}
				else
				{
					this.TotalRecords = 0;
				}
            }
            catch (CustomAppException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw new CustomAppException(ErrorNumber.GeneralException, SeverityLevelCode.CriticalError, EventTypeCode.ErrorLog, "Search", ErrorManager.GetErrorMessageFromErrorNumber(ErrorNumber.GeneralException), ex);
            }
            finally
            {
            }
        }
        protected void OnSearch(object sender, EventArgs e)
        {
            try
            {
                // reset page index
                this.StartIndex = 1;
                // perform the search
                this.Search();
            }
            catch (CustomAppException ex)
            {
                base.HandleError(ex);
            }
            catch (System.Exception ex)
            {
                base.HandleError(new CustomAppException(ErrorNumber.GeneralException, SeverityLevelCode.CriticalError, EventTypeCode.ErrorLog, "Search_Click", ErrorManager.GetErrorMessageFromErrorNumber(ErrorNumber.GeneralException), ex));
            }
            finally
            {
            }
        }
        virtual protected void SetDataFromForm()
        {
        }
		public override void OnPreRender()
		{
			base.OnPreRender();
		}
        #endregion "Public Methods"
		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public BaseSearchUserControl()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}
