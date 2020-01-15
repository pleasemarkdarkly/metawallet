/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/

using System;
using System.Collections;
using System.Web.UI.WebControls;
using DAL = MW.MComm.WalletSolution.DAL;

namespace MW.MComm.Phone.WebUI.Components
{
	/// <summary>
	/// Summary description for Lists.
	/// </summary>
	public class Lists
	{
		public Lists()
		{
			//
			// constructor logic
			//
		}

		public static void DataBind(DropDownList list, ICollection soc, string propValue, string propText, bool includeAny, bool includeNone)
		{
			string any = includeAny ? "Any" : null;
			string none = includeNone ? "None" : null;
			DataBind( list, soc, propValue, propText, any, none );
		}

        public static void DataBind(DropDownList list, ICollection soc, string propValue, string propText, string includeAny, string includeNone)
        {
			list.Items.Clear();

            if(includeAny != null)
				list.Items.Add(new ListItem( includeAny,((int)MOD.Data.Lists.ListDefaultSelection.Any).ToString()));

			if(includeNone != null)
				list.Items.Add(new ListItem( includeNone,((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));

			foreach(object o in soc)
				list.Items.Add(new ListItem(
					o.GetType().GetProperty(propText).GetValue(o,null).ToString(),
					o.GetType().GetProperty(propValue).GetValue(o,null).ToString()));
        }

		public enum SortOrder
		{
			Value,
			Name
		}

		public static void DataBind(DropDownList list, Type enumType, bool includeAny, bool includeNone, SortOrder sortOrder)
		{
			list.Items.Clear();

			if(sortOrder == SortOrder.Value)
				foreach(object val in Enum.GetValues(enumType))
				{
					long l = Convert.ToInt64(val);
					list.Items.Add(new ListItem(HumpTheString(Enum.GetName(enumType,val)),l.ToString()));
				}
			else
			{
				ArrayList names = new ArrayList(Enum.GetNames(enumType));
				names.Sort();
				foreach(string name in names)
				{
					long l = Convert.ToInt64(Enum.Parse(enumType,name));
					list.Items.Add(new ListItem(HumpTheString(name),l.ToString()));
				}
			}

			if(includeAny)
				list.Items.Insert(0,new ListItem("Any",((int)MOD.Data.Lists.ListDefaultSelection.Any).ToString()));

			if(includeNone)
				list.Items.Insert(0,new ListItem("None",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
		}

		public static void DataBind(DropDownList list, Type enumType, SortOrder sortOrder, long min, long max)
		{
			list.Items.Clear();

			if(sortOrder == SortOrder.Value)
				foreach(object val in Enum.GetValues(enumType))
				{
					long l = Convert.ToInt64(val);
					if( l > min && l < max )
					{
						list.Items.Add(new ListItem(HumpTheString(Enum.GetName(enumType,val)),l.ToString()));
					}
				}
			else
			{
				ArrayList names = new ArrayList(Enum.GetNames(enumType));
				names.Sort();
				foreach(string name in names)
				{
					long l = Convert.ToInt64(Enum.Parse(enumType,name));
					if( l > min && l < max)
						list.Items.Add(new ListItem(HumpTheString(name),l.ToString()));
				}
			}

			list.Items.Insert(0,new ListItem("Any",((int)MOD.Data.Lists.ListDefaultSelection.None).ToString()));
		}


		private static string HumpTheString(string s)
		{
			return System.Text.RegularExpressions.Regex.Replace(s,"([A-Z][a-z])", " $&").Trim();
		}



	}

}
