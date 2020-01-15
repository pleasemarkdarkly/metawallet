using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
public partial class UserControls_Desktop_Utility_Diagnostics : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBind();
			//lblConfigurationContext.Text = ConfigurationContext.Current.ToString();
        }
    }
    protected void btnSaveCookie_Click(object sender, EventArgs e)
    {
        Response.Cookies.Add(new HttpCookie(txtKey.Text, HttpUtility.UrlEncode(txtValue.Text)));
        Response.Redirect(Request.RawUrl);
    }
    public override void DataBind()
    {
		//List<ConfigurationValue> configValues = new List<ConfigurationValue>();
		//// gridview didn't like list of IConfigurationValue objects
		//foreach (IConfigurationValue cv in ConfigurationContext.Current.AllValues)
		//    configValues.Add(new ConfigurationValue(cv.Key, cv.Value, cv.Source.ToString()));
		//gvConfiguration.DataSource = configValues;
		//gvConfiguration.DataBind();
		//List<ConfigurationValue> cookies = new List<ConfigurationValue>();
		//foreach (string key in Request.Cookies.Keys)
		//    cookies.Add(new ConfigurationValue(key, Request.Cookies[key].Value));
		//gvCookies.DataSource = cookies;
		//gvCookies.DataBind();
    }
}
