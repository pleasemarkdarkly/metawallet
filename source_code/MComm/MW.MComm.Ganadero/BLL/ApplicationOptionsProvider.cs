using System;
using System.Collections.Generic;
using System.Text;
using MOD.Data;
using MW.MComm.Ganadero.BLL.Config;

namespace MW.MComm.Ganadero.BLL
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
