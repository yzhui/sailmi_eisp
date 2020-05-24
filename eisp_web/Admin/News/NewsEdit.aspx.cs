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
    public partial class News_Edit : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    if (VerifyTool.IsLong(Request.QueryString["id"]))
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);

                        NewsBind(id);
                    }
                }
            }

        }
        //绑定类别
        protected void BindDrpClass(int parentId, string str, int selected)
        {

            str += str;

            List<NewsClassModel> list = EispNewsClassBLL.GetNewsClassListByLang(lang, parentId);

            foreach (NewsClassModel type in list)
            {
                drpClass.Items.Add(new ListItem(str + type.F_ClassName, type.ID.ToString()));


                if (type.ID == selected)
                {
                    drpClass.SelectedValue = type.ID.ToString();
                }
                BindDrpClass(type.ID, str, selected);
            }
        }
        protected void NewsBind(int id)
        {
            NewsModel a = EispNewsBLL.GetNewsByID(id);

            this.txtTitle.Text = a.F_Title;
            this.txtID.Value = a.ID.ToString();
            this.content.Value = a.F_Content;
            this.txtLocation.Text = a.F_Location;
            this.txtKeyword.Text = a.F_Keyword;
            BindDrpClass(0, "-", a.F_ParentID);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTitle.Text))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('标题不能为空！')", true);
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
            a.ID = Convert.ToInt32(this.txtID.Value);
            a.F_Title = VerifyTool.DeleteHtml(this.txtTitle.Text.Trim().ToString());
            a.F_Location = VerifyTool.DeleteHtml(this.txtLocation.Text.Trim().ToString());
            a.F_Content = VerifyTool.DeleteScript(this.content.Value);
            a.F_ParentID = Convert.ToInt32(drpClass.SelectedValue);
            a.F_Lang = Convert.ToInt32(lang);
            int res = EispNewsBLL.UpdateNewByID(a);

            if (res > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('修改成功！');location.href='NewsAdmin.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('修改失败！')", true);
            }

        }
    }
}
