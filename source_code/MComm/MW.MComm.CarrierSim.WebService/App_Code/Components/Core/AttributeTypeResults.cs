
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
using System.IO;
using System.Text;
using BLL = MW.MComm.CarrierSim.BLL;

namespace MW.MComm.CarrierSim.WebService.Components.Core
{
	// ------------------------------------------------------------------------------
	/// <summary>This class is used to hold AttributeType information.</summary>
	///
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	[Serializable()]
	[XmlType(Namespace = "http://modsystems.com/MW.MComm.CarrierSim/Core/DataTypes")]
	public class AttributeTypeResults : MOD.Data.StatusObject
	{
		#region "Declarations"

		// for Results property
		private BLL.SortableList<BLL.Core.AttributeType> _results = new BLL.SortableList<BLL.Core.AttributeType>();

		#endregion "Declarations"

		#region "Public Properties"

		// ------------------------------------------------------------------------------
		/// <summary>This property gets or sets the results.</summary>
		// ------------------------------------------------------------------------------
		[XmlArrayItem(typeof(BLL.Core.AttributeType), ElementName="AttributeType")]
		public virtual BLL.SortableList<BLL.Core.AttributeType> Results
		{
			get
			{
				return _results;
			}
			set
			{
				_results = value;
			}
		}

		#endregion "Public Properties"

		#region "Public Static Methods"

		#endregion "Public Static Methods"

		#region "Public Methods"
		#endregion "Public Methods"

		#region "Miscellaneous"
		// ------------------------------------------------------------------------------
		/// <summary>This method is the constructor (currently does nothing).</summary>
		// ------------------------------------------------------------------------------
		public AttributeTypeResults()
		{
			//
			// constructor logic
			//
		}
		#endregion "Miscellaneous"
	}
}