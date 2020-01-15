
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
namespace MW.MComm.WalletSolution.BLL
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
