using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Eisp.Common;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Web;
using Eisp.Common.Utility;
namespace Eisp.Web.Admin.link
{
    public partial class Admin_Link : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LinkBind();
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                Label1.Text = "名称不能为空";
                Label1.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(this.txtUrl.Text))
            {
                Label1.Text = "网址不能为空";
                Label1.ForeColor = Color.Red;
                return;
            }
            if (!VerifyTool.IsUrlValid(this.txtUrl.Text))
            {
                Label1.Text = "网址格式不正确";
                Label1.ForeColor = Color.Red;
                return;
            }



            LinkModel l = new LinkModel();
            l.F_LinkName = this.txtName.Text.Trim().ToString();
            l.F_LinkUrl = this.txtUrl.Text.Trim().ToString();

            int res = EispLinkBLL.AddLink(l);

            if (res > 0)
            {
                Label1.Text = "添加成功!";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                Label1.Text = "添加失败";
                Label1.ForeColor = Color.Red;
            }
            this.txtName.Text = "";
            this.txtUrl.Text = "";
            LinkBind();
        }

        protected void LinkBind()
        {
            List<LinkModel> list = EispLinkBLL.GetLinkList();

            this.GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "ID" };

            this.GridView1.DataBind();

        }
        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            LinkBind();

        }
        //编辑
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LinkBind();
        }

        //执行更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value.ToString());
            string LinkName = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
            string LinkUrl = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString();

            if( string.IsNullOrEmpty(LinkName))
            {
                Label1.Text = "名称不能为空";
                Label1.ForeColor = Color.Red;
                return;
            }
            if (!VerifyTool.IsUrlValid(LinkUrl))
            {
                Label1.Text = "网址格式不正确";
                Label1.ForeColor = Color.Red;
                return;
            }

            LinkModel l = new LinkModel();
            l.ID = id;
            l.F_LinkName = LinkName;
            l.F_LinkUrl = LinkUrl;
            int res = EispLinkBLL.UpdateLink(l);

            if (res > 0)
            {
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功了!')", true);
                Label1.Text = "更新成功!";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败!')", true);
                Label1.Text = "更新失败";
                Label1.ForeColor = Color.Red;
            }


            GridView1.EditIndex = -1;
            LinkBind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);

            int res = EispLinkBLL.DeleteLink(id);

            if (res > 0)
            {
                Label1.Text = "删除成功!";
                Label1.ForeColor = Color.Green;
            }
            else
            {
                Label1.Text = "删除失败";
                Label1.ForeColor = Color.Red;
            }
            LinkBind();
        }



    }
}
