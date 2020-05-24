using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Web;
namespace Eisp.Web.Admin.New
{
    public partial class NewAdmin : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (EispNewsBLL.GetRecordCountByLang(lang)>0)
                {
                AspNetPager1.RecordCount = EispNewsBLL.GetRecordCountByLang(lang);
                BindNews(AspNetPager1.RecordCount, AspNetPager1.PageSize);
                }
            }
        }

        //绑定新闻
        protected void BindNews(int number, int pagesize)
        {


            // AspNetPager1.RecordCount = recordcount;
            List<NewsModel> list = EispNewsBLL.GetArticleListPageNoByLang(Convert.ToInt32(lang),number, pagesize,-1);
            //  AspNetPager1.RecordCount = 9; 

            this.GridView1.DataSource = list;
            this.GridView1.DataBind();

        }

        //翻页
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            //要减去的记录数
            int subtract_number = AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1);

            //要获取的记录数：记录总数-要减去的记录数
            int number = AspNetPager1.RecordCount - subtract_number;

            BindNews(number, AspNetPager1.PageSize);
        }

        // 删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("chk")).Checked)
                {
                    int id = int.Parse(((Label)row.FindControl("id")).Text);
                    // this.News_Delete(id);
                    EispNewsBLL.DeleteNewByID(id);

                }
            }
            if (EispNewsBLL.GetRecordCountByLang(lang) > 0)
            {
                AspNetPager1.RecordCount = EispNewsBLL.GetRecordCountByLang(lang);
                BindNews(AspNetPager1.RecordCount, AspNetPager1.PageSize);

            }
            else
            {
                this.GridView1.Visible = false;
            }
        }


    }
}
