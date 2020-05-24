using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.Web;
namespace Eisp.Web.Admin
{
    public partial class TopFrame : AdminPage
    {
        public string username = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            username =this.CurrentUser.Name;
        }
    }
}
