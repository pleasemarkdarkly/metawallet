
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Collections.Generic;
using System.Text;
using MOD.Data;
using MW.MComm.WalletSolution.BLL.Config;
namespace MW.MComm.WalletSolution.BLL
{
    /// <summary>
    /// This is a base class for the application classes previously known as "Globals"
    /// </summary>
    public class ApplicationOptionsProvider
    {
		public virtual DatabaseOptions ApplicationDBOptions
        {
            get
            {
                DatabaseOptions dbOptions = new DatabaseOptions();
                if (ConfigurationContext.IsCurrentContextLoaded)
                {
                    dbOptions.ConnectionString = ConfigurationContext.Current.AllValues.GetRequiredValue("ConnectionString");
                    // TODO: set command time out
                }
                else
                {
                    dbOptions.ConnectionString = ConfigurationContext.ConnectionString; // return the default from the discovery service
                    // TODO: set command time out
                }
                return dbOptions;
            }
        }
        public virtual int ApplicationDebugLevel
        {
            get
            {
                if (ConfigurationContext.IsCurrentContextLoaded)
                {
                    // return the one in the configuration file, database, cookie, or query string
                    return ConfigurationContext.Current.AllValues.GetIntValue("DebugLevel", 0);
                }
                else
                {
                    // return the default from the discovery service
                    return 0; 
                }
            }
        }
        /// <summary>
        /// Service applications currently override this and specify a hard coded Guid.
        /// The WebUI will specify either an authenticated user or anonymous.
        /// </summary>
        public virtual Guid ApplicationUserID
        {
            get { return Guid.Empty; }
        }
        public virtual DataOptions GetDataOptions()
        {
            return GetDataOptions("", "");
        }
        // ------------------------------------------------------------------
        /// <summary>Get a list options instance, based on input sort and direction.</summary>
        /// 
        /// <param name="sortColumn">The column to sort by</param>
        /// <param name="sortDirection">The direction to sort by</param>
        /// <returns>A ListOptions instance, based on sortColumn and sortDirection</returns>
        // ------------------------------------------------------------------
        public virtual MOD.Data.DataOptions GetDataOptions(string sortColumn, string sortDirection)
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
        public virtual MOD.Data.DataOptions GetDataOptions(string sortColumn, string sortDirection, bool includeInactive, bool includeDataInactive)
        {
            // populate new list options with sort and direction
            MOD.Data.DataOptions newOptions = new MOD.Data.DataOptions();
            newOptions.IncludeDateInactive = includeDataInactive;
            newOptions.IncludeInactive = includeInactive;
            if (sortColumn != null)
                newOptions.SortColumn = sortColumn.Trim();
            else
                newOptions.SortColumn = string.Empty;
            newOptions.SortDirection = MOD.Data.SortDirection.Ascending;
            if (sortDirection == null)
                newOptions.SortDirection = MOD.Data.SortDirection.Random;
            else
            {
                if ((sortDirection.ToLower().Trim() == "descending") || (sortDirection.ToLower().Trim() == "desc"))
                {
                    newOptions.SortDirection = MOD.Data.SortDirection.Descending;
                }
                else if ((sortDirection.ToLower().Trim() == "random") || (sortDirection.ToLower().Trim() == "rand"))
                {
                    newOptions.SortDirection = MOD.Data.SortDirection.Random;
                }
            }
            return newOptions;
        }
    }
}
