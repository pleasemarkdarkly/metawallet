/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using MW.MComm.WalletSolution;
using System.Web;
using MW.MComm.WalletSolution.BLL;
using BLL = MW.MComm.WalletSolution.BLL;
using MW.MComm.WalletSolution.BLL.Users;
using MW.MComm.WalletSolution.Utility;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using MOD.Data;
namespace MW.MComm.Admin.WebUI
{
	// ------------------------------------------------------------------------------
	/// <summary>This class contains global methods and properties for the web ui layer.</summary>
	/// 
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class Globals : ApplicationOptionsProvider
	{
		#region "Declarations"
		#endregion "Declarations"
		#region "Constants And Enumerations"
		#endregion "Constants And Enumerations"
		#region "Public Static Properties"
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the site utilities xml from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string SitePublicUtilitiesXml
        {
            get
            {
                // get the site utilities xml from the application setting
				return Globals.getAppSettingString("SitePublicUtilitiesXml", "~/sitePublicUtilities.xml");
            }
        }
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the site utilities xml from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string SiteAuthenticatedUtilitiesXml
        {
            get
            {
                // get the site utilities xml from the application setting
				return Globals.getAppSettingString("SiteAuthenticatedUtilitiesXml", "~/siteAuthenticatedUtilities.xml");
            }
        }
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the site features xml from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string SiteFeaturesXml
        {
            get
            {
                // get the site features xml from the application setting
				return Globals.getAppSettingString("SiteFeaturesXml", "~/siteFeatures.xml");
            }
        }
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the site help xsl from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static string SiteHelpXsl
		{
			get
			{
				// get the site help xsl from the application setting
				return Globals.getAppSettingString("SiteHelpXsl", "~/StyleSheets/SiteHelp.xsl");
			}
		}
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the primary navigation xsl from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string PrimaryNavigationXsl
        {
            get
            {
                // get the primary navigation xsl from the application setting
				return Globals.getAppSettingString("PrimaryNavigationXsl", "~/StyleSheets/PrimaryNav.xsl");
            }
        }
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the secondary navigation xsl from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string SecondaryNavigationXsl
        {
            get
            {
                // get the secondary navigation xsl from the application setting
				return Globals.getAppSettingString("SecondaryNavigationXsl", "~/StyleSheets/SecondaryNav.xsl");
            }
        }
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the bread crumb navigation xsl from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string BreadCrumbNavigationXsl
        {
            get
            {
                // get the bread crumb navigation xsl from the application setting
				return Globals.getAppSettingString("BreadCrumbNavigationXsl", "~/StyleSheets/BreadCrumbNav.xsl");
            }
        }
        // ------------------------------------------------------------------
        /// <summary>This method retrieves the site map navigation xsl from the system configuration.</summary>
        // ------------------------------------------------------------------
        public static string SiteMapNavigationXsl
        {
            get
            {
                // get the site map navigation xsl from the application setting
				return Globals.getAppSettingString("SiteMapNavigationXsl", "~/StyleSheets/SiteMapNav.xsl");
            }
        }
        // ------------------------------------------------------------------
        /// <summary>This method creates an item xml node.</summary>
        // ------------------------------------------------------------------
        private static XmlNode CreateItemXmlNode(XmlDocument inputDocument, string itemName, string itemTarget, string itemActivity, string itemRole, string itemPath, string itemURL)
        {
            // create an item node with name, target, activityName, roleName, path, and url attributes
            XmlNode newNode = inputDocument.CreateNode(System.Xml.XmlNodeType.Element, "item", inputDocument.NamespaceURI);
            XmlAttribute newAttribute = inputDocument.CreateAttribute("", "name", inputDocument.NamespaceURI);
            newAttribute.Value = itemName;
            newNode.Attributes.Append(newAttribute);
            newAttribute = inputDocument.CreateAttribute("", "target", inputDocument.NamespaceURI);
            newAttribute.Value = itemTarget;
            newNode.Attributes.Append(newAttribute);
            newAttribute = inputDocument.CreateAttribute("", "activityName", inputDocument.NamespaceURI);
            newAttribute.Value = itemActivity;
            newNode.Attributes.Append(newAttribute);
            newAttribute = inputDocument.CreateAttribute("", "roleName", inputDocument.NamespaceURI);
            newAttribute.Value = itemRole;
            newNode.Attributes.Append(newAttribute);
            newAttribute = inputDocument.CreateAttribute("", "path", inputDocument.NamespaceURI);
            newAttribute.Value = itemPath;
            newNode.Attributes.Append(newAttribute);
            newAttribute = inputDocument.CreateAttribute("", "url", inputDocument.NamespaceURI);
            newAttribute.Value = itemURL;
            newNode.Attributes.Append(newAttribute);
            return newNode;
        }
        // ------------------------------------------------------------------
        /// <summary>This method manages the current site xml that the current user has access to.</summary>
        // ------------------------------------------------------------------
        public static XmlDocument CurrentSiteXml
        {
            get
            {
                XmlDocument siteXml = null;
                siteXml = (XmlDocument) HttpContext.Current.Session["CurrentSiteXml"];
                
                if (siteXml == null)
                {
                    // get site xml
                    if (CurrentUser == null)
                    {
                        // get public utilities
                        siteXml = XmlUtility.GetXmlDocument(HttpContext.Current.Server.MapPath(SitePublicUtilitiesXml));
                    }
                    else
                    {
                        // get features
                        siteXml = XmlUtility.GetXmlDocument(HttpContext.Current.Server.MapPath(SiteFeaturesXml));
                        // additional features or site nav could be dynamically added from search results or user profiles here
                        //foreach(int x in y)
                        //{
                        //   XmlNode newNode = CreateItemXmlNode(siteXml, "itemName", "", "activityName", "roleName", "path", "urlValue");
                        //   siteXml.DocumentElement.AppendChild(newNode);
                        //}
                        // filter out features by activities and roles not associated with user
						SortableList<BLL.Users.Activity> activities = ActivityManager.GetAllActivityData(DBOptions, 
                            getDataOptions("ActivityName", ""), DebugLevel, CurrentUserID);
						SortableList<BLL.Users.UserRole> roles = UserRoleManager.GetAllUserRoleData(DBOptions, 
                            getDataOptions("UserRoleName", ""), DebugLevel, CurrentUserID);
                        // filter out roles that the user doesn't have
                        foreach (BLL.Users.UserRole loopRole in roles)
                        {
                            bool isUserInRole = false; // user has role
							foreach (BLL.Users.UserRoleUser loopUserRole in CurrentUser.UserRoleUserList)
                            {
                                if (loopUserRole.UserRoleCode == loopRole.UserRoleCode)
                                {
                                    isUserInRole = true;
                                    break;
                                }
                            }
                            // remove items from siteXml
                            if (!isUserInRole)
                                while (XmlUtility.RemoveXmlNodeFromDocument("roleName", loopRole.UserRoleName, siteXml));
                        }
                        // filter out activities that the user doesn't have
						foreach (BLL.Users.Activity loopActivity in activities)
                        {
                            bool isValidActivity = false;
							foreach (BLL.Users.UserRoleUser loopUserRole in Globals.CurrentUser.UserRoleUserList)
                            {
								BLL.Users.UserRole userRole = UserRoleManager.GetOneUserRole(loopUserRole.UserRoleCode, DBOptions, 
                                    getDataOptions("", ""), DebugLevel, CurrentUserID);
								foreach (BLL.Users.UserRoleActivity loopUserRoleActivity in userRole.UserRoleActivityList)
                                {
                                    if (loopUserRoleActivity.ActivityCode == loopActivity.ActivityCode)
                                    {
                                        isValidActivity = true;
                                        break;
                                    }
                                }
                                
                                if (isValidActivity)
                                    break;
                            }
                            // remove activity from siteXml
                            if (!isValidActivity)
                                while (XmlUtility.RemoveXmlNodeFromDocument("activityName", loopActivity.ActivityName, siteXml));
                        }
                        // get authenticated utilities and add to filtered features
                        XmlDocument siteUtilitiesXml = MOD.Data.XmlUtility.GetXmlDocument(
                            System.Web.HttpContext.Current.Server.MapPath(SiteAuthenticatedUtilitiesXml));
                        foreach (XmlNode loopNode in siteUtilitiesXml.DocumentElement.ChildNodes)
                        {
                            XmlNode newNode = MOD.Data.XmlUtility.CreateItemXmlNode(siteXml, "item", loopNode);
                            siteXml.DocumentElement.AppendChild(newNode);
                        }
                        HttpContext.Current.Session["CurrentSiteXml"] = siteXml;
                    }
                }
                return siteXml;
            }
        }
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the debug level setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static Guid CurrentUserID
		{
			get
			{
				Guid currentUserID = MOD.Data.DefaultValue.Guid;
#if LOGIN_COOKIE_ENABLED
                if (HttpContext.Current.Request.Cookies["UserID"] != null)
                    currentUserID = new Guid(HttpContext.Current.Request.Cookies["UserID"].Value.ToString());
#endif
				if (HttpContext.Current.Session["CurrentUserID"] != null)
					currentUserID = (Guid)HttpContext.Current.Session["CurrentUserID"];
				return currentUserID;
			}
		}
		public override Guid ApplicationUserID
		{
			get
			{
				return CurrentUserID;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the debug level setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static MW.MComm.WalletSolution.BLL.Users.User CurrentUser
		{
			get 
			{
				MW.MComm.WalletSolution.BLL.Users.User user = null;
				Guid currentUserID = CurrentUserID;
				try
				{
					user = (MW.MComm.WalletSolution.BLL.Users.User)HttpContext.Current.Session["CurrentUser"];
				}
				catch
                {
                }
				if(user != null)
				{
					if(user.UserID == currentUserID)
						return user;
					else
					{
						HttpContext.Current.Session.Remove("CurrentUser");
                        HttpContext.Current.Session.Remove("CurrentUserID");
                        HttpContext.Current.Session.Remove("CurrentSiteXml");
                        user = null;
					}
				}
				
				if(user == null && currentUserID != MOD.Data.DefaultValue.Guid)
				{
					user = MW.MComm.WalletSolution.BLL.Users.UserManager.GetOneUser(CurrentUserID, DBOptions, getDataOptions("",""), DebugLevel, CurrentUserID);
					HttpContext.Current.Session["CurrentUser"] = user;
                    HttpContext.Current.Session.Remove("CurrentSiteXml");
                    return user;
				}
                HttpContext.Current.Session.Remove("CurrentSiteXml");
                return null;
			}
			set
			{
                HttpContext.Current.Session.Remove("CurrentSiteXml");
                if (value == null)
                {
                    HttpContext.Current.Session.Remove("CurrentUser");
                    HttpContext.Current.Session.Remove("CurrentUserID");
#if LOGIN_COOKIE_ENABLED
                    HttpContext.Current.Response.Cookies.Remove("UserID");
#endif 
                }
                else
                {
                    HttpContext.Current.Session["CurrentUser"] = value;
                    MW.MComm.WalletSolution.BLL.Users.User user = value;
                    
                    HttpContext.Current.Session["CurrentUserID"] = user.UserID;
#if LOGIN_COOKIE_ENABLED
                    HttpCookie cookie = new HttpCookie("UserID", user.UserID.ToString());
                    cookie.Expires = DateTime.Now.Add(new TimeSpan(4, 0, 0)); // 4 hours
                    HttpContext.Current.Response.Cookies.Add(cookie);
#endif
                }
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the debug level setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static int DebugLevel
		{
			get
			{
				// get the debug level from the application setting
				return Globals.getAppSettingInt("DebugLevel", 0);
			}
		}
		public override int ApplicationDebugLevel
		{
			get
			{
				// get the debug level from the application setting
				return DebugLevel;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the mail server from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static string MailServer
		{
			get
			{
				// get the database connection string from the application setting
				// TODO: this should be encrypted if not handled by enterprise application blocks
				return "dotexchange.dotcorporation.com";
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the mail sender email from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static string MailSenderEmail
		{
			get
			{
				// get the database connection string from the application setting
				return "dclemmer@modsystems.com";
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the mail sender email from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static string SMSSenderPhone
		{
			get
			{
				// get the database connection string from the application setting
				return "70066111";
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the database connection string from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static string DBConnectionString
		{
			get
			{
				// get the database connection string from the application setting
				// TODO: this should be encrypted if not handled by enterprise application blocks
				return Globals.getAppSettingString("DBConnectionString", "");
			}
		}
   
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the database timeout setting from the system configuration.</summary>
		// ------------------------------------------------------------------
		public static int DBCommandTimeout
		{
			get
			{
				// get the database timeout setting from the application setting
				return Globals.getAppSettingInt("DBCommandTimeout", 60);
			}
		}
		// ------------------------------------------------------------------
		/// <summary>
		/// Gets the default setting for the <see cref="BaseListUserControl.PageSize"/> property from the system configuration.
		/// </summary>
		// ------------------------------------------------------------------
		public static int DefaultPageSize
		{
			get
			{
 				return Globals.getAppSettingInt("DefaultPageSize", MOD.Data.DefaultValue.DefaultPageSize);
			}
		}
		// ------------------------------------------------------------------
		/// <summary>
		/// Gets the default setting for the <see cref="BaseListUserControl.MaximumListSize"/> property from the system configuration.
		/// </summary>
		// ------------------------------------------------------------------
		public static int DefaultMaximumListSize
		{
			get
			{
 				return Globals.getAppSettingInt("DefaultMaximumListSize", MOD.Data.DefaultValue.DefaultMaximumListSize);
			}
		}
		// ------------------------------------------------------------------
		/// <summary>
		/// Gets the default setting for the <see cref="BaseListUserControl.SortDirection"/> property from the system configuration.
		/// </summary>
		// ------------------------------------------------------------------
		public static MOD.Data.SortDirection DefaultSortDirection
		{
			get
			{
				return (MOD.Data.SortDirection)MOD.Data.DataHelper.GetEnum( typeof( MOD.Data.SortDirection ), Globals.getAppSettingString( "DefaultSortDirection", "Ascending" ), MOD.Data.SortDirection.Ascending );
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the application database options.</summary>
		// ------------------------------------------------------------------
		public static MOD.Data.DatabaseOptions DBOptions
		{
			get
			{
				MOD.Data.DatabaseOptions databaseOptions = (MOD.Data.DatabaseOptions) Globals.getAppCacheObject("MODDBOptions");
				// build new database options if not in application cache
				if (databaseOptions == null)
				{
					databaseOptions = new MOD.Data.DatabaseOptions();
					databaseOptions.ConnectionString = Globals.DBConnectionString;
					databaseOptions.CommandTimeout = Globals.DBCommandTimeout;
					Globals.setAppCacheObject("MODDBOptions", databaseOptions, Globals.DefaultMinutesInAppCache);
					// kind of a kludge, but here is where CoreLib error list is set
					BLL.Core.ErrorManager.SetErrors(Globals.DebugLevel, databaseOptions, CurrentUserID);
				}
				return databaseOptions;
			}
		}
		public override MOD.Data.DatabaseOptions ApplicationDBOptions
		{
			get
			{
				// get the database options
				return DBOptions;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the available activities.</summary>
		// ------------------------------------------------------------------
		public static SortableList<BLL.Users.Activity> Activities
		{
			get
			{
				SortableList<BLL.Users.Activity> activities = (SortableList<BLL.Users.Activity>)Globals.getAppCacheObject("Activities");
				// build new database options if not in application cache
				if (activities == null)
				{
					activities = BLL.Users.ActivityManager.GetAllActivityData(DBOptions, getDataOptions("ActivityName", "", false, false), DebugLevel, CurrentUserID);
                    Globals.setAppCacheObject("Activities", activities);
				}
				return activities;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method determines whether or not to perform strict activity based access.</summary>
		// ------------------------------------------------------------------
		public static bool EmployStrictAccess
		{
			get
			{
				// get the debug level from the application setting
 				return Globals.getAppSettingBool("EmployStrictAccess", true);
			}
		}
		public static int LocaleCode
		{
			get
			{
				return 409;
			}
		}
		// ------------------------------------------------------------------
		/// <summary>This method retrieves the default minutes data should stay in the application cache the system configuration.</summary>
		// ------------------------------------------------------------------
		public static int DefaultMinutesInAppCache
		{
			get
			{  
				// get the database timeout setting from the application setting
 				return Globals.getAppSettingInt("DefaultMinutesInAppCache", 60);
			}
		}
		// ------------------------------------------------------------------
        /// <summary>Returns the Enterprise Caching Library</summary>
        // ------------------------------------------------------------------
		public static Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager Cache
        {
            get
            {
                return MW.MComm.WalletSolution.Utility.CacheManager.Cache;
            }
        }
		#endregion "Public Static Properties"
		#region "Public Static Methods"
 		// ------------------------------------------------------------------
		/// <summary>Get the application setting as a string.</summary>
		/// 
		/// <param name="appSettingKey">The key value of the AppSetting to be referenced</param>
		/// <param name="defaultValue">The default value to get if the AppSetting is empty</param>
		/// <returns>The string representing the value of the AppSetting</returns>
		// ------------------------------------------------------------------
		public static string getAppSettingString(string appSettingKey, string defaultValue)
		{
			// get app setting as a string
			return MOD.Data.DataHelper.GetString(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey], defaultValue);
		}
		// ------------------------------------------------------------------
		/// <summary>Get the application setting as an int.</summary>
		/// 
		/// <param name="appSettingKey">The key value of the AppSetting to be referenced</param>
		/// <param name="defaultValue">The default value to get if the AppSetting is empty</param>
		/// <returns>The string representing the value of the AppSetting</returns>
		// ------------------------------------------------------------------
		public static int getAppSettingInt(string appSettingKey, int defaultValue)
		{
			// get app setting as an int
			return MOD.Data.DataHelper.GetInt(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey], defaultValue);
		}
		// ------------------------------------------------------------------
		/// <summary>Get the application setting as a bool.</summary>
		/// 
		/// <param name="appSettingKey">The key value of the AppSetting to be referenced</param>
		/// <param name="defaultValue">The default value to get if the AppSetting is empty</param>
		/// <returns>The string representing the value of the AppSetting</returns>
		// ------------------------------------------------------------------
		public static bool getAppSettingBool(string appSettingKey, bool defaultValue)
		{
			// get app setting as a bool
			return MOD.Data.DataHelper.GetBool(System.Configuration.ConfigurationSettings.AppSettings[appSettingKey], defaultValue);
		}
       // ------------------------------------------------------------------
        /// <summary>Get rendered site navigation with the input xsl.</summary>
        /// 
        /// <param name="xslUrl">The url to the xsl file.</param>
        /// <returns>Rendered site navigation.</returns>
        // ------------------------------------------------------------------
        public static string getRenderedSiteNav(string xslUrl)
        {
            string renderedNav = "";
            // current url
            string strCurrentURL = System.Web.HttpContext.Current.Request.RawUrl.Substring(System.Web.HttpContext.Current.Request.ApplicationPath.ToString().Length).ToLower();
            if (strCurrentURL.StartsWith("/"))
            {
                strCurrentURL = strCurrentURL.Substring(1);
            }
            // current url minus query strings
            string strCurrentURLShort = System.Web.HttpContext.Current.Request.FilePath.Substring(System.Web.HttpContext.Current.Request.ApplicationPath.ToString().Length).ToLower();
            if (strCurrentURLShort.StartsWith("/"))
            {
                strCurrentURLShort = strCurrentURLShort.Substring(1);
            }
            // home
            string strHome = System.Web.HttpContext.Current.Request.ApplicationPath.ToString();
            if (!(strHome.EndsWith("/")))
            {
                strHome += "/";
            }
            // set up xsl parameters
            XsltArgumentList xslArgs = new XsltArgumentList();
            xslArgs.AddParam("Home", "", strHome);
            xslArgs.AddParam("CurrentURL", "", strCurrentURL);
            xslArgs.AddParam("CurrentURLShort", "", strCurrentURLShort);
            xslArgs.AddParam("ID", "", getSiteXmlIDForUrl(strCurrentURLShort));
            try
            {
                renderedNav = MOD.Data.XmlUtility.Transform(CurrentSiteXml, System.Web.HttpContext.Current.Server.MapPath(xslUrl), xslArgs);
            }
            catch {}
            return renderedNav;
        }
		// ------------------------------------------------------------------
		/// <summary>Get rendered site help with the input xsl.</summary>
		/// 
		/// <param name="xslUrl">The url to the xsl file.</param>
		/// <returns>Rendered site help.</returns>
		// ------------------------------------------------------------------
		public static void getPageHelp(out string title, out string text)
		{
			// determine activity based access
			BLL.UserExperience.AdminHelp currentHelp = null;
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
					foreach(BLL.UserExperience.AdminHelp loopHelp in BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByActivityCode(loopActivity.ActivityCode, Globals.DBOptions, Globals.getDataOptions("",""), Globals.DebugLevel, Globals.CurrentUserID))
					{
						currentHelp = loopHelp;
						break;
					}
					break;
				}
			}
			if (currentHelp == null)
			{
				foreach (BLL.Users.Activity loopActivity in Globals.Activities)
				{
					if (activityFeature.ToLower().Trim() == loopActivity.ActivityName.ToLower().Trim())
					{
						foreach(BLL.UserExperience.AdminHelp loopHelp in BLL.UserExperience.AdminHelpManager.GetAllAdminHelpDataByActivityCode(loopActivity.ActivityCode, Globals.DBOptions, Globals.getDataOptions("",""), Globals.DebugLevel, Globals.CurrentUserID))
						{
							currentHelp = loopHelp;
							break;
						}
						break;
					}
				}
			}
			if (currentHelp == null)
			{
				title = "<b>Help</b>";
				text = "Help is currently unavailable for this page.";
			}
			else
			{
				title = currentHelp.AdminHelpTitle;
				text = currentHelp.AdminHelpText;
			}
		}
		// ------------------------------------------------------------------
        /// <summary>Get the selected object from the application cache.</summary>
        /// 
        /// <param name="cacheSettingKey">The key id of the CacheSetting to be accessed</param>
        /// <returns>The object found in the cache data</returns>
        // ------------------------------------------------------------------
        public static string getSiteXmlIDForUrl(string url)
        {
            XmlNode testNode = null;
            XmlNode urlNode = null;
            int foundID = 0;
            bool continueSearch = true;
            while (continueSearch == true)
            {
                testNode = MOD.Data.XmlUtility.GetXmlNodeFromDocument("url", url, CurrentSiteXml, urlNode);
                if (testNode == null)
                {
                    continueSearch = false;
                }
                else
                {
                    foreach (XmlAttribute loopAttribute in testNode.Attributes)
                    {
                        if (loopAttribute.Name == "id")
                        {
                            int testID = MOD.Data.DataHelper.GetInt(loopAttribute.Value, 0);
                            if (testID > foundID)
                            {
                                foundID = testID;
                                urlNode = testNode;
                            }
                            else
                            {
                                continueSearch = false;
                            }
                            break;
                        }
                    }
                }
            }
            if (urlNode != null)
            {
                foreach (XmlAttribute loopAttribute in urlNode.Attributes)
                {
                    if (loopAttribute.Name == "id")
                    {
                        return loopAttribute.Value;
                    }
                }
            }
            // didn't find requested node, get first node you can
            foreach (XmlNode loopNode in CurrentSiteXml.DocumentElement.ChildNodes)
            {
                foreach (XmlAttribute loopAttribute in loopNode.Attributes)
                {
                    if (loopAttribute.Name == "id")
                    {
                        return loopAttribute.Value;
                    }
                }
            }
            return "";
        }
        // ------------------------------------------------------------------
		/// <summary>Get the selected object from the application cache.</summary>
		/// 
		/// <param name="cacheSettingKey">The key id of the CacheSetting to be accessed</param>
		/// <returns>The object found in the cache data</returns>
		// ------------------------------------------------------------------
		public static object getAppCacheObject(string cacheSettingKey)
		{
			// get the object from the cache
			return Globals.Cache.GetData(cacheSettingKey);
		}
		// ------------------------------------------------------------------
		/// <summary>Store the selected object to the application cache.</summary>
		/// 
		/// <param name="cacheSettingKey">The key value of the cache where the object will be stored</param>
		/// <param name="cacheObject">The object to be stored</param>
		/// <param name="minutesInCache">The time (in minutes) that the object should be store in the cache</param>
		// ------------------------------------------------------------------
		public static void setAppCacheObject(string cacheSettingKey, object cacheObject, int minutesInCache)
		{
			// set the object to the cache
			Globals.Cache.Add(cacheSettingKey, cacheObject, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(minutesInCache)));
		}
		// ------------------------------------------------------------------
		/// <summary>Store the selected object to the application cache (using default minutes in cache).</summary>
		/// 
		/// <param name="cacheSettingKey">The key value of the cache where the object will be stored</param>
		/// <param name="cacheObject">The object to be stored</param>
		// ------------------------------------------------------------------
		public static void setAppCacheObject(string cacheSettingKey, object cacheObject)
		{
			// set the object to the cache
			Globals.setAppCacheObject(cacheSettingKey, cacheObject, Globals.DefaultMinutesInAppCache);
		}
		// ------------------------------------------------------------------
		/// <summary>Get a list options instance, based on input sort and direction.</summary>
		/// 
		/// <param name="sortColumn">The column to sort by</param>
		/// <param name="sortDirection">The direction to sort by</param>
		/// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
		// ------------------------------------------------------------------
		public static MOD.Data.DataOptions getDataOptions(string sortColumn, string sortDirection)
		{
			// populate new list options with sort and direction
			MOD.Data.DataOptions newOptions = new MOD.Data.DataOptions();
            newOptions.IncludeDateInactive = false;
            newOptions.IncludeInactive = false;
			newOptions.SortColumn = sortColumn.Trim();
			newOptions.SortDirection = MOD.Data.SortDirection.Ascending;
			if ((sortDirection.ToLower().Trim() == "descending") || (sortDirection.ToLower().Trim() == "desc"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Descending;
			}
			else if ((sortDirection.ToLower().Trim() == "random") || (sortDirection.ToLower().Trim() == "rand"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Random;
			}
			return newOptions;
		}
		// ------------------------------------------------------------------
		/// <summary>Get a list options instance, based on input sort and direction.</summary>
		/// 
		/// <param name="sortColumn">The column to sort by</param>
		/// <param name="sortDirection">The direction to sort by</param>
		/// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
		// ------------------------------------------------------------------
		public static MOD.Data.DataOptions getDataOptions(string sortColumn, string sortDirection, bool includeInactive, bool includeDataInactive)
		{
			// populate new list options with sort and direction
			MOD.Data.DataOptions newOptions = new MOD.Data.DataOptions();
			newOptions.IncludeDateInactive = includeDataInactive;
			newOptions.IncludeInactive = includeInactive;
			newOptions.SortColumn = sortColumn.Trim();
			newOptions.SortDirection = MOD.Data.SortDirection.Ascending;
			if ((sortDirection.ToLower().Trim() == "descending") || (sortDirection.ToLower().Trim() == "desc"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Descending;
			}
			else if ((sortDirection.ToLower().Trim() == "random") || (sortDirection.ToLower().Trim() == "rand"))
			{
				newOptions.SortDirection = MOD.Data.SortDirection.Random;
			}
			return newOptions;
		}
		public static ArrayList GetMessages(string key)
		{
            ArrayList al = (ArrayList)HttpContext.Current.Session[key];
			if(al == null)
			{
				al = new ArrayList();
                HttpContext.Current.Session[key] = al;
			}
			return al;
		}
        public static void ClearMessages()
        {
            HttpContext.Current.Session["StatusMessages"] = null;
            HttpContext.Current.Session["ErrorMessages"] = null;
        }
        public static void AddStatusMessage(string msg, params object[] args)
		{
			GetMessages("StatusMessages").Add(string.Format(msg,args));
		}
		public static void AddErrorMessage(System.Web.UI.Page page, string msg, params object[] args)
		{
			
            
            string s = string.Format(msg,args);
			if(s.Trim().Length > 0)
				GetMessages("ErrorMessages").Add(s);
			/*
			// reference code if we want to include error messages in validation summary block 
			
			ADOT.Validate.ValidateMessage vm =  new ADOT.Validate.ValidateMessage( string.Format( msg, args ) );
			page.Validators.Add(vm);
			System.Web.UI.WebControls.ValidationSummary valSum = (System.Web.UI.WebControls.ValidationSummary)page.FindControl("valSum");
			if(valSum != null)
				valSum.ShowSummary = true;
			*/
		}
		public static int ErrorCount
		{
			get
			{
				return GetMessages("ErrorMessages").Count;
			}
		}
		#endregion "Public Static Methods"
        #region "Miscellaneous"
        // ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public Globals()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}
