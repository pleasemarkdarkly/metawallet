using System;
using System.Collections.Generic;
using System.Text;
using MOD.Data;

namespace MW.MComm.Ganadero.BLL
{
    public class BusinessObjectManager
    {
        #region Static Fields
        private static ApplicationOptionsProvider _applicationOptionsProvider;
        #endregion

        #region Static Properties
        /// <summary>
        /// If no value was returned by the discovery service, default to 0 until
        /// loaded from database.
        /// </summary>
        public static int DebugLevel
        {
            get
            {
                if (_applicationOptionsProvider == null)
                    throw new ApplicationException("BusinessObjectManager was not correctly initialized with a DatabaseOptionsProvider. " + 
                        "Use BusinessObjectManager.Initialize");

                return _applicationOptionsProvider.ApplicationDebugLevel;
            }
        }

        /// <summary>
        /// Contains the default connection string to be used by the business layer if no other database
        /// options are specified.
        /// </summary>
        public static DatabaseOptions DBOptions
        {
            get
            {
                if (_applicationOptionsProvider == null)
                    throw new ApplicationException("BusinessObjectManager was not correctly initialized with a DatabaseOptionsProvider. " +
                        "Use BusinessObjectManager.Initialize");

                return _applicationOptionsProvider.ApplicationDBOptions;
            }
        }

        public static Guid ApplicationUserID
        {
            get
            {
                if (_applicationOptionsProvider == null)
                    throw new ApplicationException("BusinessObjectManager was not correctly initialized with a DatabaseOptionsProvider. " +
                        "Use BusinessObjectManager.Initialize");

                   return _applicationOptionsProvider.ApplicationUserID;
            }
        }
        #endregion

        #region Static methods
        public static void Initialize(ApplicationOptionsProvider provider)
        {
            _applicationOptionsProvider = provider;
        }

        public static DataOptions DataOptions()
        {
            return GetDataOptions("", "", false, true);
        }

        public static DataOptions GetDataOptions(string sortColumn, string sortDirection, bool includeInactive, bool includeDateInactive)
        {
            if (_applicationOptionsProvider == null)
                throw new ApplicationException("BusinessObjectManager was not correctly initialized with a DatabaseOptionsProvider. " +
                    "Use BusinessObjectManager.Initialize");

            return _applicationOptionsProvider.GetDataOptions(sortColumn, sortDirection, includeInactive, includeDateInactive);
        }


        #endregion
    }
}
