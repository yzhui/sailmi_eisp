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
using System.Text;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
using Eisp.Common.Utility;
using System.Collections.Generic;
namespace Eisp.Web
{
    public partial class Downloas : ServicePage
    {
        protected string pages = "0";
        public int Records = 0;
        protected string NewsHtml = string.Empty;
        public int CurrentPage = 1;
        public int RecordsPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (VerifyTool.IsInt(Request.QueryString["page"]))
            {
                CurrentPage = Convert.ToInt32(Request.QueryString["page"]);
                //要减去的记录数
                int subtract_number = 20 * (CurrentPage - 1);

                //要获取的记录数：记录总数-要减去的记录数
                int number = EispDownloadsBLL.GetRecordCountByLang(lang) - subtract_number;


                if (EispDownloadsBLL.GetRecordCountByLang(lang) > 0)
                {
                    BindDownloads(number, 20, EispDownloadsBLL.GetRecordCountByLang(lang));
                }
            }
            else
            {
                if (EispDownloadsBLL.GetRecordCountByLang(lang) > 0)
                {
                    BindDownloads(EispDownloadsBLL.GetRecordCountByLang(lang), 20, EispDownloadsBLL.GetRecordCountByLang(lang));
                }
            }
            //Page.Title = " 公司简介";
            Page.Title = "资料下载";
        }
        //
        //绑定新闻
        protected void BindDownloads(int number, int pagesize, int recordcount)
        {

            List<DownloadsModel> list = EispDownloadsBLL.GetDownloadsListByLang(lang,number, pagesize);
            AspNetPager.RecordCount = recordcount;
            AspNetPager.CurrentPageIndex = number;
            AspNetPager.PageSize = pagesize;

            Records = recordcount;
            RecordsPage = int.Parse(pages);
            StringBuilder sb = new StringBuilder();

            foreach (DownloadsModel n in list)
            {
                sb.Append("<div class=\"DownloadListRow\"><table width=\"100%\" height=\"100%\" valign=\"top\"><tr><td width='130'><a href=\"" + n.F_Content + "\"><img width='150px' height='204px' src=\"" + n.F_FileImage + "\"></a></td><td valign=\"top\"><div class=\"DownloadRowTitle\"><a href=\"" + n.F_Content + "\">" + n.F_Title + " </a>[" + n.F_Date.ToString("yyyy-MM-dd") + "]</div><div class=\"DownloadRowTitle\">" + n.F_Keywords + "</div><div class=\"DownloadRowTitle\">" + n.F_Desc + "</div></td></tr></table></div>");
            }
            NewsHtml = sb.ToString();
        }
        protected void AspNetPager_PageChanged(object src, EventArgs e)
        {
        }

    }
}


//--------------------------5-1-a-s-p-x--------------------------//