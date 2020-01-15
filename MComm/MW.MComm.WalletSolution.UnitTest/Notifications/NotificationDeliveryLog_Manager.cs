

/*<copyright>
Meta Wallet, Inc (c) 2007 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2007, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MOD.Data;
using MOD.Test;
using MbUnit.Framework;
using MbUnit.Core;
using MW.MComm.WalletSolution.BLL.Config;
using BLL = MW.MComm.WalletSolution.BLL;
using Utility = MW.MComm.WalletSolution.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.WalletSolution.UnitTest.Notifications
{
    // ------------------------------------------------------------------------------
    /// <summary>This class contains support methods to test NotificationDeliveryLog instances.</summary>
    ///
    /// File History:
    /// <created>7/31/2007 (Brian MacDonald)</created>
    ///
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public partial class NotificationDeliveryLog_Manager
    {

		#region Properties
        #endregion Properties

        #region Constructors

        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public NotificationDeliveryLog_Manager()
        {
            //
            // constructor logic
            //
        }

        #endregion Constructors

		#region Methods

        // ------------------------------------------------------------------------------
        /// <summary>This method is used to add NotificationDeliveryLog items.</summary>
        // ------------------------------------------------------------------------------
        public static void PopulateItem(BLL.Notifications.NotificationDeliveryLog item, MOD.Data.NamedObjectCollection useCollections, bool performCascade, bool isAddOperation, bool isCollectionOperation, MOD.Test.TestResults results)
        {
            if (item == null)
            {
                return;
            }

            //
            // populate the NotificationDeliveryLog item
            //
            int totalRecords = 0;
            bool totalRecordsExceeded = false;
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Notifications.NotificationLog> itemNotificationLogNotificationLogID = null;
                if (useCollections != null && useCollections["Notifications.NotificationLog"] != null)
                {
                    itemNotificationLogNotificationLogID = (BLL.SortableList<BLL.Notifications.NotificationLog>)useCollections["Notifications.NotificationLog"];
                }
                if (itemNotificationLogNotificationLogID == null || itemNotificationLogNotificationLogID.Count <= 0)
                {
                    itemNotificationLogNotificationLogID = BLL.Notifications.NotificationLogManager.GetManyNotificationLogDataByCriteria(null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemNotificationLogNotificationLogID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemNotificationLogNotificationLogID.Count-1));
                    item.NotificationLogID = itemNotificationLogNotificationLogID[index].NotificationLogID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for NotificationLog.", null);
                }
            }
            if (isCollectionOperation == true && isAddOperation == true)
            {
                totalRecords = 0;
                totalRecordsExceeded = false;
                BLL.SortableList<BLL.Customers.MetaPartner> itemMetaPartnerMetaPartnerID = null;
                if (useCollections != null && useCollections["Customers.MetaPartner"] != null)
                {
                    itemMetaPartnerMetaPartnerID = (BLL.SortableList<BLL.Customers.MetaPartner>)useCollections["Customers.MetaPartner"];
                }
                if (itemMetaPartnerMetaPartnerID == null || itemMetaPartnerMetaPartnerID.Count <= 0)
                {
                    itemMetaPartnerMetaPartnerID = BLL.Customers.MetaPartnerManager.GetManyMetaPartnerDataByCriteria(null, null, null, null, null, null, null, out totalRecords, out totalRecordsExceeded, Globals.getDataOptions("","",1,200,2000));
                    results.TotalRecords = totalRecords;
                    results.TotalRecordsExceeded = totalRecordsExceeded;
                }
                if (itemMetaPartnerMetaPartnerID.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemMetaPartnerMetaPartnerID.Count-1));
                    item.MetaPartnerID = itemMetaPartnerMetaPartnerID[index].MetaPartnerID;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for MetaPartner.", null);
                }
            }
            if (isCollectionOperation == true && isAddOperation == true)
            {
                BLL.SortableList<BLL.Notifications.NotificationDeliveryType> itemNotificationDeliveryTypeNotificationDeliveryTypeCode = null;
                if (useCollections != null && useCollections["Notifications.NotificationDeliveryType"] != null)
                {
                    itemNotificationDeliveryTypeNotificationDeliveryTypeCode = (BLL.SortableList<BLL.Notifications.NotificationDeliveryType>)useCollections["Notifications.NotificationDeliveryType"];
                }
                if (itemNotificationDeliveryTypeNotificationDeliveryTypeCode == null || itemNotificationDeliveryTypeNotificationDeliveryTypeCode.Count <= 0)
                {
                    itemNotificationDeliveryTypeNotificationDeliveryTypeCode = BLL.Notifications.NotificationDeliveryTypeManager.GetAllNotificationDeliveryTypeData();
                }
                if (itemNotificationDeliveryTypeNotificationDeliveryTypeCode.Count > 0)
                {
                    int index = TestHelper.GetInt(0, Math.Max(0, itemNotificationDeliveryTypeNotificationDeliveryTypeCode.Count-1));
                    item.NotificationDeliveryTypeCode = itemNotificationDeliveryTypeNotificationDeliveryTypeCode[index].NotificationDeliveryTypeCode;
                }
                else
                {
                    throw new UnitTestException(UnitTestErrorType.Warning, "Could not find values for NotificationDeliveryType.", null);
                }
            }
            PopulateItemCleanup(item, useCollections, performCascade, isAddOperation, isCollectionOperation, results);
        }
        #endregion Methods
    }
}