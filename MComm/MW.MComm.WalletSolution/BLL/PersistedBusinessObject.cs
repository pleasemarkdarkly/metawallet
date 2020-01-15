
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
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Collections.Specialized;
using MW.MComm.WalletSolution.Utility;
using MOD.Data;
namespace MW.MComm.WalletSolution.BLL
{
	[Serializable()]
	public class PersistedBusinessObject : BusinessObject
	{
		/// <summary>
		/// The default value for date and time initializations.
		/// </summary>
		public readonly DateTime DEFAULT_DATETIME = DateTime.MinValue;
		const string GUID_EMPTY = "00000000-0000-0000-0000-000000000000";
		#region "Declarations"
		#endregion "Declarations"
		#region Fields
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
		// for PrimaryName property
		protected string _primaryName = MOD.Data.DefaultValue.String;
		// for PrimarySortColumn property
		protected string _primarySortColumn = MOD.Data.DefaultValue.String;
		#endregion Fields
		#region Properties
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
		[XmlIgnore]
		public virtual bool IsCollectionDirty
		{
			get { return false; } // no collections in base class
		}
		#endregion Properties
		#region Static Methods
		#endregion
		public PersistedBusinessObject()
		{ }
		public PersistedBusinessObject(BaseDataAccessObject dataObject)
		{
			ReflectionHelper.Copy(dataObject, this, true);
		}
		#region Methods
		#endregion Methods
	}
}
