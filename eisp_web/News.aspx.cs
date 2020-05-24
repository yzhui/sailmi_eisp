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
    public partial class News : ServicePage
    {
        protected string pages = "0";
        public int Records = 0;
        protected string NewsHtml = string.Empty;
        public int CurrentPage = 1;
        public int RecordsPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int classid = -1;
            if (Request.QueryString["classid"] != null) {
                classid = Convert.ToInt32(Request.QueryString["classid"]);
            }
            int totalNum = EispNewsBLL.GetRecordCountByClassid(lang,classid);
            if (VerifyTool.IsInt(Request.QueryString["page"]))
            {
                CurrentPage = Convert.ToInt32(Request.QueryString["page"]);
                //要减去的记录数
                int subtract_number = 20 * (CurrentPage - 1);

                //要获取的记录数：记录总数-要减去的记录数
                int number = - subtract_number;


                if (totalNum > 0)
                {
                    BindNews(number, 20, totalNum, classid);
                }
            }
            else
            {
                if (totalNum > 0)
                {
                    BindNews(totalNum, 20, totalNum, classid);
                }
            }
            //Page.Title = " 公司简介";
            Page.Title = "新闻动态";
        }
        //5~1~a~s~p~x
        //绑定新闻
        protected void BindNews(int number, int pagesize, int recordcount,int classid)
        {



            List<NewsModel> list = EispNewsBLL.GetArticleListPageNoByLang(lang,number, pagesize,classid);
            AspNetPager.RecordCount = recordcount;
            AspNetPager.CurrentPageIndex = number;
            AspNetPager.PageSize = pagesize;

            Records = recordcount;
            RecordsPage =int.Parse(pages);
            StringBuilder sb = new StringBuilder();

            foreach (NewsModel n in list)
            {
                sb.Append("<div class=\"NewsRow\"><div class=\"NewsRowTitle\"><a href=\"NewsDetail.aspx?id=" + n.ID + "\" target=\"_blank\">" + n.F_Title + " </a>[" + n.F_Date.ToString("yyyy-MM-dd") + "]</div></div>");
            }
            NewsHtml = sb.ToString();
        }

        protected void AspNetPager_PageChanged(object src, EventArgs e)
        {
        }
    }
}
