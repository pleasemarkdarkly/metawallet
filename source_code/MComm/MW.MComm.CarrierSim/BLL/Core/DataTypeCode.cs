

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
using System.ComponentModel;
using MOD.Data;
using MW.MComm.CarrierSim.BLL.Config;
using BLL = MW.MComm.CarrierSim.BLL;
using Utility = MW.MComm.CarrierSim.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace MW.MComm.CarrierSim.BLL.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This enumeration is for holding known DataType codes.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public enum DataTypeCode
	{
		/// <summary>None.</summary>
		None = 0,
		/// <summary>For integer values.</summary>
		Integer = 1,
		/// <summary>For long values.</summary>
		Long = 2,
		/// <summary>For string values.</summary>
		String = 3,
		/// <summary>For boolean values.</summary>
		Boolean = 4,
		/// <summary>For float values.</summary>
		Float = 5,
		/// <summary>For decimal values.</summary>
		Decimal = 6,
		/// <summary>For date values.</summary>
		DateTime = 7,
		/// <summary>For GUID values.</summary>
		GUID = 8,
	}
}