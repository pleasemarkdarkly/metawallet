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
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using MW.MComm.CarrierSim.BLL;
using System.Xml;
using System.Xml.Serialization;
using System.Data.SqlClient;
using MW.MComm.CarrierSim.Utility;
using MOD.Exceptions;
using MW.MComm.CarrierSim.BLL.Core;

namespace MW.MComm.CarrierSim.Utility
{
	// ------------------------------------------------------------------------------
	/// <summary>
	/// Used to specify that an exception's property should be logged in the database with the
	/// give debug attribute type code.
	/// </summary>
	// ------------------------------------------------------------------------------
	[AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
	public class DebugAttributeValueAttribute : Attribute
	{
		/// <summary>
		/// Attribute code to specify in tblCORE_DebugAttibuteValues.
		/// </summary>
		public DebugAttributeCode AttributeCode;
	}


	// ------------------------------------------------------------------------------
	/// <summary>
	/// The exception that is thrown when an application error occurs in the system.
	/// </summary>
	/// <remarks>
	/// This class is the default exception handling mechanism for the system.
	/// </remarks>
	// ------------------------------------------------------------------------------
	[Serializable]
	public class CustomAppException : MOD.Exceptions.CustomAppException
	{
		private BLL.Core.ErrorNumber m_errorNumber = BLL.Core.ErrorNumber.None;
		private BLL.Core.SeverityLevelCode m_severityLevel = BLL.Core.SeverityLevelCode.None;
        private BLL.Core.EventTypeCode m_eventType = BLL.Core.EventTypeCode.ErrorLog;

		// for EventName property
		private string _eventName = "";
      
		// for DebugAttributeValues property
		private MOD.Data.SortableObjectCollection _debugAttributeValues = new MOD.Data.SortableObjectCollection();

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class.
		/// Obsolete: Please use a different constructor to specify an exception type when using <see cref="CustomAppException"/>.
		/// </summary>
		// ------------------------------------------------------------------------------
		[Obsolete("Please use a different constructor to specify an exception type when using CustomAppException",false)]
		public CustomAppException() : base()
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class with a specified error 
		/// message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If the innerException parameter is not a
		/// null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.
		/// </param>
		// ------------------------------------------------------------------------------
		public CustomAppException(string message, Exception innerException)
			: this(BLL.Core.ErrorNumber.GeneralException, BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, message, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.GeneralException), innerException)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class with a specified error 
		/// message and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="innerSqlException">
		/// The <see cref="System.Data.SqlClient.SqlException"/> that is the cause of the current exception. If the innerSqlException parameter is not a
		/// null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.
		/// </param>
		// ------------------------------------------------------------------------------
        public CustomAppException(string message, System.Data.SqlClient.SqlException innerSqlException)
            : this(BLL.Core.ErrorManager.GetErrorNumberFromSqlError(innerSqlException.Number), 
                    Globals.GetSeverityLevelFromSqlSeverity(innerSqlException.Class),
                    BLL.Core.EventTypeCode.ErrorLog, message,
					BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(
						BLL.Core.ErrorManager.GetErrorNumberFromSqlError(innerSqlException.Number)), innerSqlException)
		{
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class.
		/// </summary>
		/// <param name="errorNumber">The exception type describing this application exception.</param>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If the innerException parameter is not a
		/// null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.
		/// </param>
		// ------------------------------------------------------------------------------
		public CustomAppException(BLL.Core.ErrorNumber errorNumber, string message, Exception innerException)
			: base(message, innerException)
		{
			ErrorNumber = errorNumber;
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class.
		/// </summary>
		/// <param name="errorNumber">The exception type describing this application exception.</param>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If the innerException parameter is not a
		/// null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.
		/// </param>
		// ------------------------------------------------------------------------------
		public CustomAppException(BLL.Core.ErrorNumber errorNumber)
			: base(errorNumber.ToString(), null)
		{
			ErrorNumber = errorNumber;
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class.
		/// </summary>
		/// <param name="errorNumber">The exception type describing this application exception.</param>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If the innerException parameter is not a
		/// null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.
		/// </param>
		// ------------------------------------------------------------------------------
		public CustomAppException(BLL.Core.ErrorNumber errorNumber, Exception innerException)
			: base(errorNumber.ToString(), innerException)
		{
			ErrorNumber = errorNumber;
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class.
		/// </summary>
		/// <param name="errorNumber">The exception type describing this application exception.</param>
		/// <param name="severity">The severity describing this exception.</param>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="eventType">The type of event (debug or error).</param>
		/// <param name="eventName">The event (method) name.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If the innerException parameter is not a
		/// null reference, the current exception is raised in a <b>catch</b> block that handles the inner exception.
		/// </param>
		// ------------------------------------------------------------------------------
		public CustomAppException(BLL.Core.ErrorNumber errorNumber, BLL.Core.SeverityLevelCode severity, BLL.Core.EventTypeCode eventType, string eventName, string message, Exception innerException)
            : this(errorNumber, message, innerException)
		{
			SeverityLevel = severity;
			EventTypeCode = eventType;
			EventName = eventName;
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomAppException"/> class with serialized data.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data. </param>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <remarks>
		/// Protected constructor to de-seralize state data across remoting boundaries.
		/// Required to enable remoting.
		/// </remarks>
		// ------------------------------------------------------------------------------
		protected CustomAppException(SerializationInfo info, StreamingContext context) : base (info, context)
		{  
			// Initialize state 
			m_errorNumber = (BLL.Core.ErrorNumber)info.GetInt32("m_errorNumber");
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Sets the <see cref="SerializationInfo"/> with information about the exception.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
		// ------------------------------------------------------------------------------
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Serialize this class' state and then call the base class GetObjectData
			info.AddValue("m_errorNumber", m_errorNumber, typeof(int));
			info.AddValue("m_severityLevel", m_severityLevel, typeof(int));
			base.GetObjectData(info, context);
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the error number.
		/// </summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		public virtual BLL.Core.ErrorNumber ErrorNumber
		{
			get
			{
				return m_errorNumber;
			}
			set
			{
				m_errorNumber = value;
			}
		}
      
		// ------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the exception severity.
		/// </summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
		public BLL.Core.SeverityLevelCode SeverityLevel
		{
			get
			{
				return m_severityLevel;
			}
			set
			{
				m_severityLevel = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the event type (debug, error, etc.).
		/// </summary>
		// ------------------------------------------------------------------------------
		[XmlElementAttribute()]
        public BLL.Core.EventTypeCode EventTypeCode
		{
			get
			{
				return m_eventType;
			}
			set
			{
				m_eventType = value;
			}
		}

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the event (method) name.</summary>
		// ------------------------------------------------------------------------------
		[DefaultValueAttribute("")]
		[XmlElementAttribute()]
		public virtual string EventName
		{
			get
			{
				return _eventName;
			}
			set
			{
				_eventName = value;
			}
		}
      
		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the debug attribute values.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(MW.MComm.CarrierSim.BLL.Core.DebugAttributeValueLog), ElementName="DebugAttributeValueLog")]
		public virtual MOD.Data.SortableObjectCollection DebugAttributeValues
		{
			get
			{
				return _debugAttributeValues;
			}
			set
			{
				_debugAttributeValues = value;
			}
		}
		
		// ------------------------------------------------------------------------------
		/// <summary>
		/// The main entry point into the exception handling framework for the Pop Media system.
		/// Handles the specified <see cref="System.Exception"/> object according to the policy configurations
		/// that are provided in the applications that use this library.
		/// </summary>
		/// <param name="ex">A <see cref="System.Exception"/> object.</param>
		/// <returns>Whether or not a rethrow is recommended.</returns>
		// ------------------------------------------------------------------------------
		public static bool HandleException(Exception ex)
		{
            try
            {
				// get configuration context
				MOD.Data.DatabaseOptions dbOptions = new MOD.Data.DatabaseOptions();
				dbOptions.ConnectionString = BLL.Config.ConfigurationContext.ConnectionString;
				dbOptions.CommandTimeout = BLL.Config.ConfigurationContext.CommandTimeout;
				if (ex is CustomAppException)
                {
                    // Log to database (depending on severity)
					Logger.Log((CustomAppException)ex, dbOptions, BLL.Config.ConfigurationContext.DebugLevel, BLL.Config.ConfigurationContext.CurrentUserID);
                    CustomAppException customEx = ex as CustomAppException;
                    return ExceptionPolicy.HandleException(ex, "Custom " + customEx.SeverityLevel.ToString() + " Policy");
                }
				else
				{
					// Log to database (depending on severity)
					Logger.Log(ex, dbOptions, BLL.Config.ConfigurationContext.DebugLevel, BLL.Config.ConfigurationContext.CurrentUserID);
					return ExceptionPolicy.HandleException(ex, "Global Policy");
				}
            }
            catch
            {
                return false;
            }
		}

		public static CustomAppException WrapException(Exception ex, string eventName)
		{
			if (ex is CustomAppException)
			{
				return ex as CustomAppException;
			}
			else if (ex is SqlException)
			{
				BLL.Core.ErrorNumber errorNumber = BLL.Core.ErrorManager.GetErrorNumberFromSqlError(((SqlException)ex).Number, ex.Message);
				return new CustomAppException(errorNumber, BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, eventName, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(errorNumber), ex);
			}
			else
			{
				return new CustomAppException(BLL.Core.ErrorNumber.GeneralException, BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, eventName, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(BLL.Core.ErrorNumber.GeneralException), ex);
			}
		}
		public static CustomAppException WrapException(Exception ex, BLL.Core.ErrorNumber errorNumber, string eventName)
		{
			if (ex is CustomAppException)
			{
				return ex as CustomAppException;
			}
			else
			{
				return new CustomAppException(errorNumber, BLL.Core.SeverityLevelCode.CriticalError, BLL.Core.EventTypeCode.ErrorLog, eventName, BLL.Core.ErrorManager.GetErrorMessageFromErrorNumber(errorNumber), ex);
			}
		}

	}
}
