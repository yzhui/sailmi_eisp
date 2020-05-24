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
    public partial class NewADD : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDrpClass(0, "-");
        }
        protected void BindDrpClass(int parentId, string str)
        {

            str += str;

            List<NewsClassModel> list = EispNewsClassBLL.GetNewsClassListByLang(lang, parentId);

            foreach (NewsClassModel type in list)
            {
                drpClass.Items.Add(new ListItem(str + type.F_ClassName, type.ID.ToString()));
                BindDrpClass(type.ID, str);
            }



        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtTitle.Text))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(),"msg","alert('标题不能为空！')",true);
                return;

            }

            if (string.IsNullOrEmpty(this.txtLocation.Text))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('新闻来源不能为空！')", true);
                return;

            }

            if (string.IsNullOrEmpty(this.content.Value))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('新闻内容不能为空！')", true);
                return;

            }

            NewsModel a = new NewsModel();

            a.F_Title = VerifyTool.DeleteHtml(this.txtTitle.Text.Trim().ToString());
            a.F_Location = VerifyTool.DeleteHtml(this.txtLocation.Text.Trim().ToString());
            a.F_Content = VerifyTool.DeleteScript(this.content.Value);
            a.F_ParentID = Convert.ToInt32(drpClass.SelectedValue);
            a.F_Keyword = txtKeyword.Text.Trim();
            a.F_Lang = Convert.ToInt32(lang);
            int res = EispNewsBLL.AddNew(a);

            if(res>0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('添加成功！');location.href='NewsADD.aspx?lang="+lang+"'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('添加失败！')", true);
            }

            Response.Write(drpClass.SelectedValue);

        }
    }
}
