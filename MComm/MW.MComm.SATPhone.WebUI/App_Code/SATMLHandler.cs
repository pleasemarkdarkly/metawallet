using System;
using System.Web;
namespace MW.MComm.SATPhone.WebUI
{
	public class SATMLHandler : IHttpHandler
	{
		HttpApplication aspxhand;
		public SATMLHandler()
		{
			aspxhand = new HttpApplication();
		}
		public void ProcessRequest(HttpContext context)
		{
			//implement the handler here
		}
		public bool IsReusable
		{
			get { return true; }
		}
	}
}
