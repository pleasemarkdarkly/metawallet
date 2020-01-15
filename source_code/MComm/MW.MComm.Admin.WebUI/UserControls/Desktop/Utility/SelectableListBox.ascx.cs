/*<copyright>
Meta Wallet, Inc (c) 2006 All Rights Reserved.
720 3rd Ave #1100, Seattle WA 98104 - (206) 973-1036
All Rights Reserved, (c) 2006, covered by Trademark Laws, contents are considered Restricted Secrets by Meta Wallet.  The contents also may only be viewed by Meta Wallet Engineers (employees) and selected partners as outlined in the Licensing Agreement between Meta Wallet and said partners.
No copying, printing, distribution, or transmission of any contents allowed.  No 3rd Party may open, read, or have access to any part or whole of software source code, configuration files, log files or performance information, including process naming conventions or benchmarks.
No rights to reproduce this software, configuration files, of log files are granted.  Unauthorized use or disclosure of this information could impact Meta Wallet's competitive advantage.
Information in this document is considered trade secret.  No license, expressed or implied, by estoppel or otherwise, to any intellectual property rights is granted in this source code, configuration file, or log file.
</copyright>*/
namespace MW.MComm.Admin.WebUI.UserControls.Desktop.Utility
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using MOD.Data;
	using DAL = MW.MComm.WalletSolution.DAL;
	/// <summary>
	///		Summary description for SelectableListBox.
	/// </summary>
	public partial class SelectableListBox : Components.Desktop.BaseUserControl
	{
		protected MOD.Data.SortableObjectCollection _socAll;
		protected MOD.Data.SortableObjectCollection _socSelected;
		protected MOD.Data.SortableObjectCollection _socUnselected;
		protected string _dataTextField;
		protected string _dataValueField;
		protected ObjectValueFromString _objectValueFromString;
		public event OnSelectedListChangedHandler OnSelectedListChanged;
		/// <summary>
		/// Represents the methods that will be called when the selected list changes
		/// </summary>
		public delegate void OnSelectedListChangedHandler(object sender, System.EventArgs e);
		/// <summary>
		/// Used to convert from a string to the data value type, if an implicit conversion isn't available.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public delegate object ObjectValueFromString( string s );
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		private void RealizeUnselectedItems()
		{
			_socUnselected = new MOD.Data.SortableObjectCollection();
			foreach (object o in _socAll)
			{
				if( ! _socSelected.Contains(o, _dataValueField) )
					_socUnselected.Add(o);
			}
		}
        public String UnselectedHeadingText
        {
            get { return lblUnselectedHeadingText.Text; }
            set { lblUnselectedHeadingText.Text = value; }
        }
        public String SelectedHeadingText
        {
            get { return lblSelectedHeadingText.Text; }
            set { lblSelectedHeadingText.Text = value; }
        }
		public void DataBindSortableObjectLists(MOD.Data.SortableObjectCollection socAll, MOD.Data.SortableObjectCollection socSelected, string dataTextField, string dataValueField)
		{
			DataBindSortableObjectLists( socAll, socSelected, dataTextField, dataValueField, null );
		}
		public void DataBindSortableObjectLists(MOD.Data.SortableObjectCollection socAll, MOD.Data.SortableObjectCollection socSelected, string dataTextField, string dataValueField, ObjectValueFromString objectValueFromString)
		{
			_socAll = socAll;
			_socSelected = socSelected;
			_dataTextField = dataTextField;
			_dataValueField = dataValueField;
			_objectValueFromString = objectValueFromString;
			ControlSession["SelectableListBox_socAll"] = _socAll;
			ControlSession["SelectableListBox_socSelected"] = _socSelected;
			ControlSession["SelectableListBox_dataTextField"] = _dataTextField;
			ControlSession["SelectableListBox_dataValueField"] = _dataValueField;
			ControlSession["SelectableListBox_dataValueConversion"] = _objectValueFromString;
			DataBind();
		}
		public void HideMoveButtons()
		{
			btnMoveDown.Visible = false;
			btnMoveUp.Visible = false;
		}
		public MOD.Data.SortableObjectCollection GetSelectedSortableObjectList()
		{
			return _socSelected;
		}
		public void btnSelect_Click(object sender, System.EventArgs e)
		{
			if(ListBoxUnselected.SelectedItem != null)
			{
				object item = _socUnselected.Find( _dataValueField, _objectValueFromString == null ? ListBoxUnselected.SelectedItem.Value : _objectValueFromString( ListBoxUnselected.SelectedItem.Value ) );
				_socSelected.Add(item);
				DataBind();
				if(OnSelectedListChanged != null)
					OnSelectedListChanged(sender, e);
			}
		}
		public void btnUnselect_Click(object sender, System.EventArgs e)
		{
			if(ListBoxSelected.SelectedItem != null)
			{
				object item = _socSelected.Find( _dataValueField, _objectValueFromString == null ? ListBoxSelected.SelectedItem.Value : _objectValueFromString( ListBoxSelected.SelectedItem.Value ) );
				_socSelected.Remove( item );
				DataBind();
				// TODO: resort the unselected items so they are in alpha order
				if(OnSelectedListChanged != null)
					OnSelectedListChanged(sender, e);
			}
		}
		public void btnMoveUp_Click(object sender, System.EventArgs e)
		{
			int selectedIndex = ListBoxSelected.SelectedIndex;
			if(ListBoxSelected.SelectedItem != null && selectedIndex > 0)
			{
				_socSelected.Insert(selectedIndex - 1, _socSelected[selectedIndex]);
				_socSelected.RemoveAt(selectedIndex + 1);
				ListBoxSelected.SelectedIndex = selectedIndex - 1;
				DataBind();
				if(OnSelectedListChanged != null)
					OnSelectedListChanged(sender, e);
			}
		}
		public void btnMoveDown_Click(object sender, System.EventArgs e)
		{
			int selectedIndex = ListBoxSelected.SelectedIndex;
			if(ListBoxSelected.SelectedItem != null && selectedIndex >= 0 && selectedIndex < ListBoxSelected.Items.Count - 1)
			{
				_socSelected.Insert(selectedIndex + 2, _socSelected[selectedIndex]);
				_socSelected.RemoveAt(selectedIndex);
				ListBoxSelected.SelectedIndex = selectedIndex + 1;
				DataBind();
				if(OnSelectedListChanged != null)
					OnSelectedListChanged(sender, e);
			}
		}
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
			//load if possible the socs from the session
			_socAll = (MOD.Data.SortableObjectCollection)ControlSession["SelectableListBox_socAll"];
			_socSelected = (MOD.Data.SortableObjectCollection)ControlSession["SelectableListBox_socSelected"];
			_dataTextField = (string)ControlSession["SelectableListBox_dataTextField"];
			_dataValueField = (string)ControlSession["SelectableListBox_dataValueField"];
			_objectValueFromString = (ObjectValueFromString)ControlSession["SelectableListBox_dataValueConversion"];
			if(_socAll != null)
				RealizeUnselectedItems();
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);
			this.DataBinding += new EventHandler(SelectableListBox_DataBinding);
		}
		#endregion
		private void SelectableListBox_DataBinding(object sender, EventArgs e)
		{
			RealizeUnselectedItems();
			ListBoxUnselected.DataSource = _socUnselected;
			ListBoxUnselected.DataTextField = _dataTextField;
			ListBoxUnselected.DataValueField = _dataValueField;
			ListBoxUnselected.DataBind();
			ListBoxSelected.DataSource = _socSelected;
			ListBoxSelected.DataTextField = _dataTextField;
			ListBoxSelected.DataValueField = _dataValueField;
			ListBoxSelected.DataBind();
		}
	}
}
