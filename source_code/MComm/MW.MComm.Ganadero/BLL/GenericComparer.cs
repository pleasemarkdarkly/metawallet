using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using MOD.Data;

namespace MW.MComm.Ganadero.BLL
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