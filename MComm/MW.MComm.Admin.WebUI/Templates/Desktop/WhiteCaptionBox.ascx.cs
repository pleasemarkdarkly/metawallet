namespace MW.MComm.Admin.WebUI.Templates.Desktop
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	/// <summary>
	///		Summary description for WhiteCaptionBox.
	/// </summary>
	public partial class WhiteCaptionBox : CaptionBox
	{
		public WhiteCaptionBox() 
		{
			expanded_class = "captionbox_white_header_expanded";
			collapsed_class = "captionbox_white_header";
			table_class = "captionbox_white";
		}
	}
}
