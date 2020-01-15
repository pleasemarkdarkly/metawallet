

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

namespace MW.MComm.CarrierSim.BLL
{
	// ------------------------------------------------------------------------------
	/// <summary></summary>
	/// Used for sorting lists by two properties
	/// <remarks></remarks>
	// ------------------------------------------------------------------------------
	public class GenericTwoPropertyComparer<T> : IComparer<T>
	{
		#region Fields
		GenericComparer<T> m_comparer1;
		GenericComparer<T> m_comparer2;
		#endregion

		// ------------------------------------------------------------------------------
		/// <summary></summary>
		/// 
		/// <param name="propertyName"></param>
		/// <param name="sortDirection"></param>
		// ------------------------------------------------------------------------------
		public GenericTwoPropertyComparer(string propertyName1, SortDirection sortDirection1, string propertyName2, SortDirection sortDirection2)
		{
			m_comparer1 = new GenericComparer<T>(propertyName1, sortDirection1);
			m_comparer2 = new GenericComparer<T>(propertyName2, sortDirection2);
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
			int i = m_comparer1.Compare(x, y);
			if (i == 0)
			{
				return m_comparer2.Compare(x, y);
			}
			else
			{
				return i;
			}
		}
		#endregion
	}
}