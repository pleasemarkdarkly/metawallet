using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MOD.Data;
using MW.MComm.WalletSolution.Utility;
using BLL = MW.MComm.WalletSolution.BLL;
namespace MW.MComm.Admin.WebUI.Components.Desktop
{
    public delegate void EntityEditEventHandler(BaseFormlUserControl sender, EntityEditEventArgs e);
    /// <summary>
    /// Summary description for EntityEditEventArgs
    /// </summary>
    public class EntityEditEventArgs : EventArgs
    {
		private BLL.PersistedBusinessObject _entity;
        public BLL.PersistedBusinessObject Entity
        {
            get { return _entity; }
        }
		public EntityEditEventArgs(BLL.PersistedBusinessObject entity)
        {
            _entity = entity;
        }
    }
}
