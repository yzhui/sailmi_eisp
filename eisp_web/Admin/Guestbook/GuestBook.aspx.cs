using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Web;
namespace Eisp.Web.Admin.guestbook
{
    public partial class GuestBook :AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                if (EispGuestBookBLL.GetRecordCount()>0)
                {
                AspNetPager1.RecordCount = EispGuestBookBLL.GetRecordCount();
                GuestBookBind(AspNetPager1.RecordCount, AspNetPager1.PageSize);
                }
            }
        }

        protected void GuestBookBind(int number, int pagesize)
        {
            List<GuestBookModel> list = EispGuestBookBLL.GetGuestBookListByLang(lang,number, pagesize);
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

            GuestBookBind(number, AspNetPager1.PageSize);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("chk")).Checked)
                {
                    int id = int.Parse(((Label)row.FindControl("id")).Text);
                    // this.News_Delete(id);
                    EispGuestBookBLL.DeleteGuestBookByID(id);

                }
            }
            if (EispGuestBookBLL.GetRecordCount() > 0)
            {
                AspNetPager1.RecordCount = EispGuestBookBLL.GetRecordCount();
                GuestBookBind(AspNetPager1.RecordCount, AspNetPager1.PageSize);
            }
        }



    }
}
