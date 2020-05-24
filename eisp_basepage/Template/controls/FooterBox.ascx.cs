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
using System.Text;
using System.Collections.Generic;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
using Eisp.Common.Utility;
namespace Eisp.Web.Controls.biz
{
    public partial class FooterBox : Eisp.Web.ControlPage
    {
        protected string New = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<NewsModel> list = EispNewsBLL.GetArticleListPageNoByLang(lang,8, 10,1);

            StringBuilder sb = new StringBuilder();
            foreach (NewsModel n in list)
            {

                sb.Append("<div class=\"NewsRow\"><a href=\"newDetails-" + n.ID + ".aspx\" target=_blank Title='" + n.F_Title + "'>" +VerifyTool.CheckStringLength(n.F_Title,16,false) + "</a></div>");

            }
            sb.Append("<div class=\"ViewMore\"><a target=\"_blank\" href=\"News.aspx\">更多...</a></div>");

            New = sb.ToString();
        }

        public string getFriendLink() {
            string link = string.Empty;
            List<LinkModel> list = EispLinkBLL.GetLinkList();
            StringBuilder sb = new StringBuilder();

            foreach (LinkModel l in list)
            {

                sb.Append("<a href=\"" + l.F_LinkUrl + "\" class=\"LinkOption\" target=\"_blank\">" + l.F_LinkName + "</a>");

            }
            link = sb.ToString();
            return link;
        }
    }
}