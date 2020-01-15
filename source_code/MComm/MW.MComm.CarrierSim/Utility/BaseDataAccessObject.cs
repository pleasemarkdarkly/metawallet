/*<copyright>
 MOD Systems, Inc (c) 2005 All Rights Reserved. 720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036 
All Rights Reserved, (c) 2005, covered by Trademark Laws, contents are considered Restricted Secrets 
by MOD Systems.  The contents also may only be viewed by MOD Systems Engineers (employees) and selected 
SBUX employees as outlined in the Licensing Agreement between MOD Systems and Starbuck Corporation on 
June 3rd, 2005.   
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, 
read, or have access to any part or whole of software source code.  If you have done so, immediatly 
report yourself to your manager. 
Do not reproduce any portions of this software.  Unauthorized use or disclosure of this information 
could impact MOD System's competitive advantage.   
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel 
or otherwise, to any intellectual property rights is granted in this source code.   
CONFIDENTIAL SOURCE CODE
</copyright>*/

using System;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using MOD.Data;

namespace MW.MComm.CarrierSim.Utility
{
    // ------------------------------------------------------------------------------
    /// <summary>This class is used to manage the base properties of all data access objects.</summary>
    /// 
    /// <remarks></remarks>
    // ------------------------------------------------------------------------------
    [Serializable()]
    public class BaseDataAccessObject : ICloneable, IBaseDataAccessObject
    {
        /// <summary>
        /// The default value for date and time initializations.
        /// </summary>
        public readonly DateTime DEFAULT_DATETIME = DateTime.MinValue;
        const string GUID_EMPTY = "00000000-0000-0000-0000-000000000000";


        #region "Declarations"

        // for CreatedByUserID property
		protected Guid? _createdByUserID = MOD.Data.DefaultValue.Guid;

        // for CreatedDate property
		protected DateTime? _createdDate = DateTime.MinValue;

        // for LastModifiedByUserID property
		protected Guid? _lastModifiedByUserID = MOD.Data.DefaultValue.Guid;

        // for LastModifiedDate property
		protected DateTime? _lastModifiedDate = DateTime.MinValue;

        // for Timestamp property
		private System.Byte[] _timestamp;

        /// <summary>
        /// Indicates a field has been changed and the object has not been saved to the database
        /// </summary>
        protected bool _isDirty = false;

		/// <summary>
		/// Indicates if entitiy has been loaded from the database
		/// </summary>
		protected bool _isLoaded = false;

		#endregion "Declarations"

        #region "Public Properties"

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the data created by user id.</summary>
        // ------------------------------------------------------------------------------
		[XmlElementAttribute(IsNullable = true)]
		[DataTransform]
        public virtual Guid? CreatedByUserID
        {
            get
            {
                return _createdByUserID;
            }
            set
            {
                if (_createdByUserID != value)
                {
                    _createdByUserID = value;
                    _isDirty = true;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the data created date.</summary>
        // ------------------------------------------------------------------------------
        [DefaultValue(typeof(DateTime), "0001-01-01T00:00:00.0000000-08:00")]
		[XmlElementAttribute(IsNullable = true)]
		[DataTransform]
        public virtual DateTime? CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                if (_createdDate != value)
                {
                    _createdDate = value;
                    _isDirty = true;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the data last modified by user id.</summary>
        // ------------------------------------------------------------------------------
		[XmlElementAttribute(IsNullable = true)]
		[DataTransform]
        public virtual Guid? LastModifiedByUserID
        {
            get
            {
                return _lastModifiedByUserID;
            }

            set
            {
                if (_lastModifiedByUserID != value)
                {
                    _lastModifiedByUserID = value;
                    _isDirty = true;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the data last modified date.</summary>
        // ------------------------------------------------------------------------------
        [DefaultValue(typeof(DateTime), "0001-01-01T00:00:00.0000000-08:00")]
		[XmlElementAttribute(IsNullable = true)]
		[DataTransform]
        public virtual DateTime? LastModifiedDate
        {
            get
            {
                return _lastModifiedDate;
            }
            set
            {
                if (_lastModifiedDate != value)
                {
                    _lastModifiedDate = value;
                    _isDirty = true;
                }
            }
        }

        // ------------------------------------------------------------------------------
        /// <summary>This property gets or sets the data timestamp.</summary>
        // ------------------------------------------------------------------------------
		[XmlElementAttribute(IsNullable = true)]
		[DataTransform]
        public virtual System.Byte[] Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                bool same = true;

                if (_timestamp == null || value == null)
                {
                    same = (_timestamp == value);
                }
                else // neither is null
                {
                    if (_timestamp.Length != value.Length)
                        same = false;
                    else
                    {
                        for (int i = 0; i < _timestamp.Length; i++)
                        {
                            if (_timestamp[i] != value[i])
                            {
                                same = false;
                                break;
                            }
                        }
                    }
                }

                if (!same)
                {
                    _timestamp = value;
                    _isDirty = true;
                }
            }
        }

        /// <summary>
        /// This property indicates whether this object's fields have changed since it was 
        /// last loaded from or saved to the database.
        /// </summary>
        [XmlIgnore]
        public virtual bool IsDirty
        {
            get { return _isDirty || IsCollectionDirty; }
            //set { _isDirty = value; } // note, this should not be settable, but needs to be since this object is saved by other classes
        }

		/// <summary>
		/// This property indicates whether this entity has been loaded from the database.
		/// </summary>
		[XmlIgnore]
		public virtual bool IsLoaded
		{
			get { return _isLoaded; }
			set { _isLoaded = value; }
		}

		[XmlIgnore]
        public virtual bool IsCollectionDirty
        {
            get { return false; } // no collections in base class
        }


        #endregion "Public Properties"

        #region "Public Methods"
        /// <summary>
        /// Sets _isDirty = false. Does not set collections
        /// </summary>
        public virtual void ClearDirtyState()
        {
            _isDirty = false;
        }

        /// <summary>
        /// Recurse all collections, and clear the dirty state of all the objects they contain.
        /// </summary>
        /// 
        public static string GetCacheKey(Type type, string propertyName, object propertyValue)
        {
            return string.Format("{0}|{1}={2}", type.ToString(), propertyName, propertyValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="properties"></param>
        /// <returns>"typename|prop1=val1|prop2=val2</returns>
        public static string GetCacheKey(Type type, StringDictionary properties)
        {
            string cacheKey = type.ToString();

            foreach (string key in properties.Keys)
            {
                cacheKey += "|";
                cacheKey += string.Format("{0}={1}", key, properties[key]);
            }

            return cacheKey;
        }

        public virtual void ClearDirtyState(bool clearCollectionDirtyState)
        {
            ClearDirtyState();

             // recursion to be implemented by derived classes
        }

        public virtual string GetCacheKey()
        {
            return GetType().ToString() + "|HashCode=" + GetHashCode();
        }

        /// <summary>
        /// Generates a cache key based on the type of this object, and
        /// the value of the specified property.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public virtual string GetCacheKey(string propertyName)
        {
            PropertyInfo pi = GetType().GetProperty(propertyName);
            return GetType().ToString() + "|" + propertyName + "=" + pi.GetValue(this, null).ToString();
        }
        #endregion "Public Methods"

        #region "Miscellaneous"
        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
        public BaseDataAccessObject()
        {
            //
            // constructor logic
            //
        }
        #endregion "Miscellaneous"


        public object Clone()
        {
            object o = this.GetType().GetConstructor(System.Type.EmptyTypes).Invoke(null);
            DataTransformAttribute.CopyTo(o, this, true);
            return o;
        }

    }
}
