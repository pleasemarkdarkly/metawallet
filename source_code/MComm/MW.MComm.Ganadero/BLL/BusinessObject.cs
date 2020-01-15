using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using MW.MComm.Ganadero.Utility;
using MOD.Data;

namespace MW.MComm.Ganadero.BLL
{
    [Serializable()]
    public class BusinessObject : Utility.BaseDataAccessObject
    {
        #region Fields
		private bool _isLoaded = false;
		#endregion

        #region Properties
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the loaded state.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IsLoaded
		{
			get
			{
				return _isLoaded;
			}
			set
			{
				_isLoaded = value;
			}
		}
		#endregion Properties

        #region Static Methods
		#endregion

        public BusinessObject()
        { }

        public BusinessObject(BaseDataAccessObject dataObject)
        {
            ReflectionHelper.Copy(dataObject, this, true);
        }

        #region Methods
        #endregion Methods
    }
}
