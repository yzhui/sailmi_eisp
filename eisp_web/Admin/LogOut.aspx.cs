using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.Common;
using Eisp.BLL;
namespace Eisp.Web.Admin
{
    public partial class loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EispAdminSession Logout = new EispAdminSession();


                Logout.Logout();
                Response.Redirect(SystemConfig.LoginPage);
            }
        }
    }
}
