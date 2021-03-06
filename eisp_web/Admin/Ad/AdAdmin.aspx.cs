﻿using System;
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
namespace Eisp.Web.Admin.ad
{
    public partial class AdAdmin : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                AdBind();
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

       
            if (string.IsNullOrEmpty(this.File2.Value))
            {
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('图样地址不能为空！')", true);
                Label1.Text = "图样地址不能为空！";
                Label1.ForeColor = Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(this.txtLinkUrl.Text))
            {
                Label1.Text = "网址不能为空";
                Label1.ForeColor = Color.Red;
                return;
            }
            if (!VerifyTool.IsUrlValid(this.txtLinkUrl.Text))
            {
                Label1.Text = "网址格式不正确";
                Label1.ForeColor = Color.Red;
                return;
            }



            AdModel a = new AdModel();

            a.F_Pic = "Upload/" + ImageTools.UpLoad(this.File2, Server.MapPath("/UpLoad"));
            a.F_Url = this.txtLinkUrl.Text;
            int res = EispAdBLL.Add(a);

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
         //   this.txtUrl.Text = "";
            this.txtLinkUrl.Text = "";

            AdBind();
        }

        protected void AdBind()
        {
            List<AdModel> list = EispAdBLL.GetAdList();

            this.GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "ID" };

            this.GridView1.DataBind();

        }
        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            AdBind();

        }
        //编辑
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            AdBind();
        }

        //执行更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value.ToString());
            string LinkName = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.Trim().ToString();
            string LinkUrl = ((TextBox)(this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim().ToString();

            if (string.IsNullOrEmpty(LinkName))
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

            AdModel a = new AdModel();

            a.F_Pic = LinkName;
            a.F_Url = LinkUrl;
            a.ID = id;
            int res = EispAdBLL.UpdateByID(a);

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
            AdBind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            string url = GridView1.Rows[e.RowIndex].Cells[1].Text.ToString();
            int res = EispAdBLL.DeleteByID(id);
            ImageTools.DeleteImg(url);

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
            AdBind();
        }


    }
}
