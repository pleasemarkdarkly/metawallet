/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

using System;
using System.Web;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using MW.MComm.WalletSolution.Utility;
using System.Web.UI.WebControls;
using System.Web.UI;
using MOD.Data;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Core;
using MW.MComm.WalletSolution.BLL.Events;

namespace MW.MComm.Phone.WebUI.Components.Desktop
{
    /// <summary>
    /// Places key value pairs into session state after prefixing the kye
    /// with the associated control name.
    /// </summary>
    public class BaseUserControlSessionState
    {
        BaseUserControl _buc;

        public BaseUserControlSessionState(BaseUserControl buc)
        {
            _buc = buc;
        }

        public object this[string key]
        {
            get { return _buc.Session[_buc.ID+key]; }
            set { _buc.Session[_buc.ID+key] = value; }
        }
    }

	// ------------------------------------------------------------------------------
	/// <summary>This class is used to manage the base information and behavior of all user controls.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class BaseUserControl : System.Web.UI.UserControl, IAttributeAccessor
	{
        BaseUserControlSessionState _bucss;

        public string GetAttribute(string name)
        {
            return (string)Session[name];
        }

        public void SetAttribute(string name, string value1)
        {
            Session[name] = value1;
        }

		#region "Declarations"

		// for AccessMode property
		private MOD.Data.AccessMode _accessMode = MOD.Data.AccessMode.None;

        // for WorkflowMode property
        private MOD.Data.WorkflowMode _workflowMode = MOD.Data.WorkflowMode.None;

        // for DisplayMode property
        private MOD.Data.DisplayMode _displayMode = MOD.Data.DisplayMode.None;

        // for CurrentSection property
        private string _currentSection = "";

        // for ErrorMessage property
		private string _errorMessage = "";

        // for RequiresAuthentication property
        private bool _requiresAuthentication = false;

		// for UseValidation property
		private bool _useValidation = true;

		#endregion "Declarations"

		#region "Public Properties"

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the access mode.</summary>
		// ------------------------------------------------------------------------------
		public virtual MOD.Data.AccessMode AccessMode
		{
			get 
			{
				return _accessMode;
			}
			set
			{
				if (RequiresAuthentication == false)
				{
					// allow any access mode if authentication is not required
					_accessMode = value;
				}
				else if (Globals.CurrentUserID == MOD.Data.DefaultValue.Guid)
				{
					// don't allow any access if current user isn't available
					_accessMode = MOD.Data.AccessMode.None;
				}
				else
				{
					// determine activity based access
					string strCurrentURLShort = System.Web.HttpContext.Current.Request.FilePath.Substring(System.Web.HttpContext.Current.Request.ApplicationPath.ToString().Length).ToLower().Replace("/pages/desktop/", "");
					if (strCurrentURLShort.IndexOf('.') > 0)
					{
						strCurrentURLShort = strCurrentURLShort.Substring(0, strCurrentURLShort.IndexOf('.'));
					}
					string activityDetail = strCurrentURLShort;
					if (strCurrentURLShort.IndexOf('/') > 0)
					{
						strCurrentURLShort = strCurrentURLShort.Substring(0, strCurrentURLShort.IndexOf('/'));
					}
					string activityFeature = strCurrentURLShort;
					BLL.Users.Activity currentActivity = null;
					foreach (BLL.Users.Activity loopActivity in Globals.Activities)
					{
						if (activityDetail.ToLower().Trim() == loopActivity.ActivityName.ToLower().Trim())
						{
							currentActivity = loopActivity;
							break;
						}
					}
					if (currentActivity == null)
					{
						foreach (BLL.Users.Activity loopActivity in Globals.Activities)
						{
							if (activityFeature.ToLower().Trim() == loopActivity.ActivityName.ToLower().Trim())
							{
								currentActivity = loopActivity;
								break;
							}
						}
					}
					if (currentActivity == null)
					{
						_accessMode = value;
					}
					else
					{
						MOD.Data.AccessMode allowedMode = MOD.Data.AccessMode.None;
						MOD.Data.AccessMode requestedMode = value;

						// determine highest level of access for activity by user
						foreach (BLL.Users.UserRoleUser loopUserRoleUser in Globals.CurrentUser.UserRoleUserList)
						{
							if (loopUserRoleUser.UserRoleItem != null)
							{
								foreach (BLL.Users.UserRoleActivity loopUserRoleActivity in loopUserRoleUser.UserRoleItem.UserRoleActivityList)
								{
									if (loopUserRoleActivity.ActivityCode == currentActivity.ActivityCode)
									{
										if (loopUserRoleActivity.AccessModeCode == (int)BLL.Users.AccessModeCode.All)
										{
											// allow requested access mode
											allowedMode = requestedMode;
										}
										else if (loopUserRoleActivity.AccessModeCode == (int)BLL.Users.AccessModeCode.View)
										{
											switch (requestedMode)
											{
												case MOD.Data.AccessMode.All:
												case MOD.Data.AccessMode.Add:
												case MOD.Data.AccessMode.Edit:
												case MOD.Data.AccessMode.Delete:
												case MOD.Data.AccessMode.View:
													// upgrade allowed mode to view
													switch (allowedMode)
													{
														case MOD.Data.AccessMode.None:
															allowedMode = MOD.Data.AccessMode.View;
															break;
														default:
															break;
													}
													break;
												default:
													break;
											}
										}
										else if (loopUserRoleActivity.AccessModeCode == (int)BLL.Users.AccessModeCode.Add || loopUserRoleActivity.AccessModeCode == (int)BLL.Users.AccessModeCode.Edit || loopUserRoleActivity.AccessModeCode == (int)BLL.Users.AccessModeCode.Delete)
										{
											switch (requestedMode)
											{
												case MOD.Data.AccessMode.All:
													// upgrade allowed mode to edit
													switch (allowedMode)
													{
														case MOD.Data.AccessMode.View:
														case MOD.Data.AccessMode.None:
															allowedMode = MOD.Data.AccessMode.Edit;
															break;
														default:
															break;
													}
													break;
												case MOD.Data.AccessMode.Add:
												case MOD.Data.AccessMode.Edit:
												case MOD.Data.AccessMode.Delete:
													// allow requested access mode
													allowedMode = requestedMode;
													break;
												case MOD.Data.AccessMode.View:
													// upgrade allowed mode to view
													switch (allowedMode)
													{
														case MOD.Data.AccessMode.None:
															allowedMode = MOD.Data.AccessMode.View;
															break;
														default:
															break;
													}
													break;
												default:
													break;
											}
										}
									}
								}
							}
						}
						_accessMode = allowedMode;
					}
				}
			}
		}

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the workflow mode.</summary>
        // ------------------------------------------------------------------------------
        public virtual MOD.Data.WorkflowMode WorkflowMode
        {
            get
            {
                return _workflowMode;
            }
            set
            {
                _workflowMode = (MOD.Data.WorkflowMode)MOD.Data.DataHelper.GetEnum(typeof(MOD.Data.WorkflowMode), value, MOD.Data.WorkflowMode.None); ;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the display mode.</summary>
        // ------------------------------------------------------------------------------
        public virtual MOD.Data.DisplayMode DisplayMode
        {
            get
            {
                return _displayMode;
            }
            set
            {
                _displayMode = (MOD.Data.DisplayMode)MOD.Data.DataHelper.GetEnum(typeof(MOD.Data.DisplayMode), value, MOD.Data.DisplayMode.None); ;
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the current section.</summary>
        // ------------------------------------------------------------------------------
        public virtual string CurrentSection
        {
            get
            {
                return _currentSection;
            }
            set
            {
                _currentSection = value;
            }
        }

        // ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the error message.</summary>
		// ------------------------------------------------------------------------------
		public virtual string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				_errorMessage = value;
			}
		}

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets whether or not authentication is required (set by code-in-front)</summary>
        // ------------------------------------------------------------------------------
        public virtual bool RequiresAuthentication
        {
            get
            {
                return _requiresAuthentication;
            }
            set
            {
                _requiresAuthentication = value;
            }
        }

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not to use validation</summary>
		// ------------------------------------------------------------------------------
		public virtual bool UseValidation
		{
			get
			{
				return _useValidation;
			}
			set
			{
				_useValidation = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not viewing is available.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool IsViewAvailable
		{
			get
			{
                return (_accessMode == AccessMode.View ||
                    _accessMode == AccessMode.Edit ||
                    _accessMode == AccessMode.Add ||
                    _accessMode == AccessMode.Delete ||
                    _accessMode == AccessMode.All);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not adding is available.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool IsAddAvailable
		{
			get
			{
				return (_accessMode == AccessMode.Add || _accessMode == AccessMode.All);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not editing is available.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool IsEditAvailable
		{
			get
			{
                return (_accessMode == AccessMode.Edit || _accessMode == AccessMode.All);
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets whether or not deleting is available.</summary>
		// ------------------------------------------------------------------------------
		public virtual bool IsDeleteAvailable
		{
			get
			{
				return (_accessMode == AccessMode.Edit || _accessMode == AccessMode.Delete || _accessMode == AccessMode.All);
			}
		}

        public BaseUserControlSessionState ControlSession
        {
            get { return _bucss; }
        }



		#endregion "Public Properties"

		#region "Public Methods"
        protected override void LoadControlState(object savedState)
        {
            object[] state = (object[])savedState;
            base.LoadControlState(state[0]);
            _accessMode = (AccessMode)state[1];
        }

        protected override object SaveControlState()
        {
            object[] state = new object[2];
            state[0] = base.SaveControlState();
            state[1] = _accessMode;
            return state;
        }
		#endregion "Public Methods"

		#region "Protected Methods"
        protected virtual void OnLoad()
        {
            // Hack: Check if session is still valid
            // TODO: Use forms authentication with a shorter time-out than the session
            if (Session.Count == 0)
                Response.Redirect(Page.ResolveUrl("~/Pages/Desktop/Anon/Logon.aspx"));

			if (!IsPostBack)
			{
				SetAccessModeFromQueryString();
			}

			// set base enable and visible settings
			SetControlValidatorEnabled();
		}

        // ------------------------------------------------------------------------------
        /// <summary>Set access mode for editing Album.</summary>
        ///
        // ------------------------------------------------------------------------------
        private void SetAccessModeFromQueryString()
        {
            if (Request.QueryString.Get("mode") != null)
            {
                if (Request.QueryString.Get("mode").ToLower() == AccessMode.Edit.ToString().ToLower())
                {
                    if (WorkflowMode == WorkflowMode.External)
                        _accessMode = AccessMode.Edit;
                    else
                        _accessMode = AccessMode.Add; // default to "Add" when internal
                }
				else if (Request.QueryString.Get("mode").ToLower() == AccessMode.Add.ToString().ToLower())
				{
					_accessMode = AccessMode.Add;
				}
				else if (Request.QueryString.Get("mode").ToLower() == AccessMode.View.ToString().ToLower())
				{
					_accessMode = AccessMode.View;
				}
				else if (Request.QueryString.Get("mode").ToLower() == AccessMode.Delete.ToString().ToLower())
                {
                    _accessMode = AccessMode.Delete;
                }
                else
                {
                    _accessMode = AccessMode.None;
                }
            }
        }

        private void CheckAuthentication()
        {
            if (RequiresAuthentication == true && Globals.CurrentUserID == MOD.Data.DefaultValue.Guid)
            {
                HttpContext.Current.Session.Remove("CurrentUser");
                HttpContext.Current.Session.Remove("CurrentUserID");
                HttpContext.Current.Session.Remove("CurrentSiteXml");
                Response.Redirect("~/Pages/Desktop/anon/Logon.aspx");
            }
        }


		// ------------------------------------------------------------------------------
		/// <summary>This method performs error handling tasks.</summary>
		/// 
		/// <param name="ex">The exception to be handled.</param>
		// ------------------------------------------------------------------------------
		protected void HandleError(CustomAppException ex)
		{
            #if ENABLE_ERROR_HANDLING
			// TODO: determine desired user control level behavior here (such as publishing exceptions
			Exception e = ex;
			Response.Write("<!--\r\n");
			do
			{
				Response.Write(e.Message);
				Response.Write("\r\n");
				Response.Write(e.StackTrace);
				Response.Write("\r\n");
				Response.Write(e.Source);
				Globals.AddErrorMessage(Page,e.Message);
				e = e.InnerException;
			} while( e != null );
			Response.Write("-->\r\n");
			Server.ClearError();

			// Send this exception to the core for handling
			bool rethrow = CustomAppException.HandleException(ex);
			if (rethrow)
            #endif
                throw ex;
		}

		protected Control SetControlText(Control item, string controlName, object o)
		{
			return SetControlText(item,controlName,o.ToString());
		}

		protected Control SetControlText(Control item, string controlName, string text)
		{
			return SetControlString(item, controlName, "Text", text);
		}

		protected Control SetControlString(Control item, string controlName, string propertyName, string text)
		{
			Control control = item.FindControl(controlName);
           
            if (control != null)
                control.GetType().GetProperty(propertyName).SetValue(control, text == null ? string.Empty : text, null);

			return control;
		}

        protected string BuildQueryString(string item, string value, string queryString)
        {
            if (queryString.Trim() == "")
            {
                return "?" + item + "=" + value;
            }
            return queryString + "&" + item + "=" + value;
        }

        protected string GetPageUrl(bool changeMode, bool changeSection)
        {
            return GetPageUrl(new NameValueCollection(), changeMode, changeSection);
        }

        protected string GetPageUrl(NameValueCollection replacements, bool changeMode, bool changeSection)
        {
            NameValueCollection old = (NameValueCollection)HttpContext.Current.Request.QueryString;
            Hashtable query = new Hashtable();

            foreach (string key in old.Keys)
                query[key] = old[key];

            foreach (string key in replacements.Keys)
                query[key] = replacements[key];

            if (!changeMode)
                query["mode"] = AccessMode.ToString();

            if (!changeSection)
                query["currentsection"] = CurrentSection;

            string queryString = string.Empty;

            foreach (string key in query.Keys)
            {
                if (queryString.Length > 0)
                    queryString += "&";

                queryString += key + "=" + query[key];
            }

            return HttpContext.Current.Request.FilePath + "?" + queryString;
        }

		private void SetChildControlValidatorEnabled(System.Web.UI.Control currentControl)
		{
			foreach (System.Web.UI.Control loopChildControl in currentControl.Controls)
			{
				if ((loopChildControl is BaseUserControl) == false)
				{
					SetChildControlValidatorEnabled(loopChildControl);
				}
				if (loopChildControl is BaseValidator)
				{
					BaseValidator validatorControl = (BaseValidator)loopChildControl;
					if (validatorControl.Enabled == true)
					{
						validatorControl.Enabled = UseValidation;
					}
				}
			}
		}

		private void SetControlValidatorEnabled()
		{
			// set display of controls based on access availabilities
			foreach (System.Web.UI.Control loopMasterControl in this.Controls)
			{
				if (loopMasterControl is Wilson.MasterPages.MasterPage)
				{
					foreach (System.Web.UI.Control loopSectionControl in loopMasterControl.Controls)
					{
						if (loopSectionControl is Wilson.MasterPages.ContentRegion)
						{
							foreach (System.Web.UI.Control loopControl in loopSectionControl.Controls)
							{
								if (loopControl is Controls.PageSection)
								{
									SetChildControlValidatorEnabled(loopControl);
								}
								if (loopControl is BaseValidator)
								{
									BaseValidator validatorControl = (BaseValidator)loopControl;
									if (validatorControl.Enabled == true)
									{
										validatorControl.Enabled = UseValidation;
									}
								}
							}
						}
					}
				}
			}
		}

		private void SetChildControlEnabled(System.Web.UI.Control currentControl)
		{
			foreach (System.Web.UI.Control loopChildControl in currentControl.Controls)
			{
				if ((loopChildControl is BaseUserControl) == false)
				{
					SetChildControlEnabled(loopChildControl);
				}
				if (loopChildControl is WebControl)
				{
					WebControl webControl = (WebControl)loopChildControl;
					if (webControl.Enabled == true)
					{
						webControl.Enabled = (IsEditAvailable || IsAddAvailable);
					}
					if (webControl.Visible == true)
					{
						webControl.Visible = IsViewAvailable;
					}
				}
			}
		}

		private void SetControlEnabled()
		{
			// set display of controls based on access availabilities
			foreach (System.Web.UI.Control loopMasterControl in this.Controls)
			{
				if (loopMasterControl.Visible == true)
				{
					loopMasterControl.Visible = IsViewAvailable;
				}

				if (loopMasterControl is Wilson.MasterPages.MasterPage)
				{
					foreach (System.Web.UI.Control loopSectionControl in loopMasterControl.Controls)
					{
						if (loopSectionControl is Wilson.MasterPages.ContentRegion)
						{
							foreach (System.Web.UI.Control loopControl in loopSectionControl.Controls)
							{
								if (loopControl is Controls.PageSection)
								{
									SetChildControlEnabled(loopControl);
								}
							}
						}
					}
				}
			}
		}

		public virtual void OnPreRender()
		{
			// set base enable and visible settings
			SetControlEnabled();
		}
		
		#endregion "Protected Methods"

		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (sets availability properties).</summary>
		// ------------------------------------------------------------------------------
		public BaseUserControl()
		{
            CheckAuthentication();
            _bucss = new BaseUserControlSessionState(this);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method initializes and adds error handling event.</summary>
		/// 
		/// <param name="e"></param>
		// ------------------------------------------------------------------------------
		protected override void OnInit(EventArgs e) 
		{
            Page.RegisterRequiresControlState(this);
			InitializeComponent();
			base.OnInit(e);
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method adds error handling event.</summary>
		// ------------------------------------------------------------------------------
		private void InitializeComponent()
		{    
            #if ENABLE_ERROR_HANDLING
			this.Error += new EventHandler(BaseUserControl_Error);
            #endif
		}

		// ------------------------------------------------------------------------------
		/// <summary>This method handles the unhandled error event.</summary>
		/// 
		/// <param name="sender">The object to send the error event.</param>
		/// <param name="e">The error event arguments.</param>
		// ------------------------------------------------------------------------------
        #if ENABLE_ERROR_HANDLING
		private void BaseUserControl_Error(object sender, EventArgs e)
		{
			// get exception and handle
			CustomAppException ex = new CustomAppException(ErrorNumber.GeneralException, SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, "BaseUserControl_Error", ErrorManager.GetErrorMessageFromErrorNumber(ErrorNumber.GeneralException), Server.GetLastError());
			HandleError(ex);
		}
        #endif
		#endregion "Miscellaneous"

       

        #region ASP.NET Server Control Helpers

        protected string GetStringFromTextBox(TextBox txt, string defaultValue)
        {
            try
            {
                string s = txt.Text.Trim();
                return s != String.Empty ? s : defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        protected string GetStringFromTextBox(TextBox txt)
        {
            return GetStringFromTextBox(txt,null);
        }

		protected string GetSelectedValueFromDropDownList(DropDownList ddl)
		{
			if(ddl.SelectedValue != null && ddl.SelectedValue != "-1" && ddl.SelectedValue != string.Empty)
				return ddl.SelectedValue;
			else
				return null;
		}
        #endregion ASP.NET Server Control Helpers

	}
}
