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
using Eisp.Common.Utility;
using Eisp.Common;
namespace Eisp.Web
{
    public partial class NewsDetail : ServicePage
    {
        protected string NewsTitle = string.Empty;
        protected string location = string.Empty;
        protected string date = string.Empty;
        protected string NewsContent = string.Empty;
        protected string NewsClass = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (VerifyTool.IsLong(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    NewsModel a = EispNewsBLL.GetNewsByID(id);

                    NewsTitle = a.F_Title;
                    date = a.F_Date.ToString();
                    NewsContent = VerifyTool.DeleteScript(a.F_Content);
                    location = a.F_Location;
                    NewsClass = a.F_ClassName;
                    Page.Title = NewsTitle;
                }
                else
                {
                    Response.Redirect("Error.aspx");
                }
            }

        }

    }
}
