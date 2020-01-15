
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
using System.Collections;
using System.Reflection;
using MOD.Data;
namespace MW.MComm.WalletSolution.BLL
{
    // ------------------------------------------------------------------------------
    /// <summary></summary>
    /// Used for sorting lists
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    public class GenericComparer<T> : IComparer<T>
    {
        #region Fields
        string m_propertyName;
        protected SortDirection m_sortDirection;
        #endregion
        #region Properties
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        // ------------------------------------------------------------------------------
        protected Comparer DefaultComparer
        {
            get
            {
                return Comparer.Default;
            }
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        // ------------------------------------------------------------------------------
        protected int LessThan
        {
            get { return m_sortDirection == SortDirection.Ascending ? -1 : 1; }
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        // ------------------------------------------------------------------------------
        protected int GreaterThan
        {
            get { return m_sortDirection == SortDirection.Ascending ? 1 : -1; }
        }
        #endregion
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <param name="propertyName"></param>
        /// <param name="sortDirection"></param>
        // ------------------------------------------------------------------------------
        public GenericComparer(string propertyName, SortDirection sortDirection)
        {
            m_propertyName = propertyName;
            m_sortDirection = sortDirection;
        }
        #region Methods
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        // ------------------------------------------------------------------------------
        public virtual int Compare(T x, T y)
        {
            if (m_sortDirection == SortDirection.Random)
                return new Random((int)DateTime.Now.Ticks).Next(-1, 1);
            else if (x == null)
                return LessThan;
            else if (y == null)
                return GreaterThan;
            object xval = GetValueFromObject(x);
            if (xval == null)
                return LessThan;
            object yval = GetValueFromObject(y);
            if (yval == null)
                return GreaterThan;
            return CorrectCompareResult(DefaultComparer.Compare(xval, yval));
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        /// 
        /// <param name="o"></param>
        /// <returns></returns>
        // ------------------------------------------------------------------------------
        protected object GetValueFromObject(object o)
        {
            PropertyInfo prop = o.GetType().GetProperty(m_propertyName);
            if (prop != null)
            {
                return prop.GetValue(o, new object[] { });
            }
            else
                return null;
        }
        // ------------------------------------------------------------------------------
        /// <summary></summary>
        // ------------------------------------------------------------------------------
        protected int CorrectCompareResult(int compareResult)
        {
            return m_sortDirection == SortDirection.Ascending ? compareResult : -1 * compareResult;
        }
        #endregion
    }
}