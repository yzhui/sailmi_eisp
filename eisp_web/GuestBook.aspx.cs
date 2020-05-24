using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
using Eisp.Common.Utility;
namespace Eisp.Web
{
    public partial class GuestBook : ServicePage
    {
        protected string code = string.Empty;
        protected string name = string.Empty;
        protected string way = string.Empty;
        protected string content = string.Empty;
        protected string script = string.Empty;
        protected string errostr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsHttpPost)
            {
                if (Request.Form["op"].Trim().ToString() == "add")
                {
                    code = Request.Form["txtcode"].Trim().ToString();
                    name = Request.Form["txtName"].Trim().ToString();
                    way = Request.Form["txtWay"].Trim().ToString();
                    content = Request.Form["txtContent"].Trim().ToString();
                    if (code != Request.Cookies["CheckCode"].Value.ToString())
                    {
                        errostr = Request.Form["hint_9001"].ToString();
                    }
                    else
                    {
                        GuestBookModel g = new GuestBookModel();
                        g.F_Contacts = VerifyTool.DeleteAll(name);
                        g.F_Way = VerifyTool.DeleteAll(way);
                        g.F_Content = VerifyTool.DeleteAll(content);
                        g.F_IP = WebTools.GetRealIP();
                        g.F_Lang = lang;
                        int res = EispGuestBookBLL.AddGuestBook(g);

                        if (res > 0)
                        {
                            errostr = Request.Form["hint_1001"].ToString();
                        }
                    }
                    ((Label)Master.FindControl("ErroStr")).Text = errostr;

                }

            }
        }
    }
}
