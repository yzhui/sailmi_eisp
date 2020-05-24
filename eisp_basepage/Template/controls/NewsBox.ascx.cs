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
    public partial class NewsBox : Eisp.Web.ControlPage
    {
        protected string NewsHtml = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<NewsModel> list = EispNewsBLL.GetArticleListPageNoByLang(lang,8, 10,-1);

            StringBuilder sb = new StringBuilder();
            foreach (NewsModel n in list)
            {

                sb.Append("<div class=\"NewsRow\"><a href=\"NewsDetail.aspx?id=" + n.ID + "\" target=_blank Title='" + n.F_Title + "'>" +VerifyTool.CheckStringLength(n.F_Title,16,false) + "</a></div>");

            }
            NewsHtml = sb.ToString();
        }
    }
}