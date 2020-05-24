using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Web;
namespace Eisp.Web.Admin.Downloads
{
    public partial class DownloadAdmin : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                DownloadsBind(EispDownloadsBLL.GetRecordCountByLang(lang), 20);
            }
          
        }

        protected void DownloadsBind(int number,int pagesize)
        {
            List<DownloadsModel> list = EispDownloadsBLL.GetDownloadsListByLang(lang,number,pagesize);
            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {


            foreach (GridViewRow row in this.GridView1.Rows)
            {
                if(((CheckBox)row.FindControl("chk")).Checked)
                {

                    int id = Convert.ToInt32(((Label)row.FindControl("id")).Text);

                    EispDownloadsBLL.Delete(id);

                }



            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('删除成功')", true);

            DownloadsBind(EispDownloadsBLL.GetRecordCountByLang(lang), 20);
        }
    }
}
