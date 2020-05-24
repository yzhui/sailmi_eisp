using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Eisp.BLL;
using Eisp.Entity;
using System.Text;
namespace Eisp.Web.Controls.biz
{
    public partial class Profile: Eisp.Web.TemplatePage
    {
        protected string link = string.Empty;
        protected string companydesc = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<LinkModel> list = EispLinkBLL.GetLinkList();
            StringBuilder sb = new StringBuilder();
                        
            foreach (LinkModel l in list)
            {

                sb.Append("<a href=\"" + l.F_LinkUrl + "\" class=\"LinkOption\" target=\"_blank\">" + l.F_LinkName + "</a>");

            }
            link = sb.ToString();
        }

    }
}
