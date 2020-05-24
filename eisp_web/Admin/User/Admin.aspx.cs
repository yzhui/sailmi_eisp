using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Eisp.Common;
using Eisp.Entity;
using Eisp.BLL;
using Eisp.Web;
namespace Eisp.Web.Admin.user
{
    public partial class Admin : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BingGrivdView();
            }

        }
        protected void BingGrivdView()
        {
            List<AdminModel> list = EispAdminBLL.GetAdminList();

            this.GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "UID" };

            this.GridView1.DataBind();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            AdminModel u = new AdminModel();
            u.Name = UserName.Text.Trim().ToString();



            u.Pass = PassWord.Text.Trim().ToString();
            u.Authority = 0;

            UserResult res = new UserResult();

            res = EispAdminBLL.Add(u);

            if (!res.HasError)
            {
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('ok')", true);
                Label1.Text = "添加成功！";
                Label1.ForeColor = Color.Green;

            }
            else
            {
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('失败')", true);
                Label1.Text = res.ErrorMessage;
                Label1.ForeColor = Color.Red;

            }

            BingGrivdView();
        }
        //编辑状态
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BingGrivdView();

        }
        //取消编辑状态
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BingGrivdView();
        }
        //执行更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            string passWord = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString();


            UserResult result = EispAdminBLL.UpdateAdminByID(id, passWord);

            if (!result.HasError)
            {
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功了!')", true);
                Label1.Text = "操作成功!";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败!')", true);
                Label1.Text = result.ErrorMessage;
                Label1.ForeColor = Color.Red;
            }


            GridView1.EditIndex = -1;
            BingGrivdView();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();


            UserResult result = EispAdminBLL.DeleteAdminByID(id);

            if (!result.HasError)
            {
                //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功!')", true);
                Label1.Text = "删除成功!";
                Label1.ForeColor = Color.Green;
                BingGrivdView();
            }
            else
            {
                //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败!不能删除保留账号')", true);
                Label1.Text = result.ErrorMessage;
                Label1.ForeColor = Color.Red;
            }


        }
    }
}
