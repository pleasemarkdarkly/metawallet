
/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using MW.MComm.WalletSolution.Utility;
using MOD.Data;
namespace MW.MComm.WalletSolution.BLL
{
    [Serializable()]
    public class BusinessObject : ICloneable
    {
        #region Fields
		private bool _isLoaded = false;
		protected bool? _isSerializing = null;
		/// <summary>
		/// Indicates a field has been changed and the object has not been saved to the database
		/// </summary>
		protected bool _isDirty = false;
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
		// ------------------------------------------------------------------------------
		/// <summary>This property returns whether or not the entity can be lazy loaded.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IsLazyLoadable
		{
			get
			{
				// in order to lazy load, object must be loaded, and not in the process of serialization
				return IsLoaded == true && IsSerializing == false;
			}
		}
		// ------------------------------------------------------------------------------
		/// <summary>This property determines whether or not the entity is being serialized.</summary>
		// ------------------------------------------------------------------------------
		[XmlIgnore]
		public virtual bool IsSerializing
		{
			get
			{
				// the hack to check the calling assembly is done to prevent the serializer from lazy loading everything
				// TODO: look for a cleaner solution
				if (_isSerializing == null)
				{
					_isSerializing = System.Reflection.Assembly.GetCallingAssembly().ManifestModule.Name.Contains("Unknown") == true || System.Reflection.Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName.ToLower().Contains("webservice") == true || System.Reflection.Assembly.GetCallingAssembly().ManifestModule.FullyQualifiedName.ToLower().Contains("public.webui") == true;
				}
				return (bool)_isSerializing;
			}
			set
			{
				_isSerializing = value;
			}
		}
		#endregion Properties
        #region Methods
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
		public object Clone()
		{
			object o = this.GetType().GetConstructor(System.Type.EmptyTypes).Invoke(null);
			DataTransformAttribute.CopyTo(o, this, true);
			return o;
		}
		#endregion Methods
        #region "Miscellaneous"
        // ------------------------------------------------------------------------------
        /// <summary>This method is the constructor (currently does nothing).</summary>
        // ------------------------------------------------------------------------------
		public BusinessObject()
		{ }
		public BusinessObject(BaseDataAccessObject dataObject)
		{
			ReflectionHelper.Copy(dataObject, this, true);
		}
		#endregion "Miscellaneous"
    }
}
