using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Eisp.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["theme"] = "default";
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["SYS_LANG"] = "1";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["lang"] != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Session["SYS_LANG"].ToString());
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["SYS_LANG"].ToString());
                }
            }
            catch (Exception)
            { }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}