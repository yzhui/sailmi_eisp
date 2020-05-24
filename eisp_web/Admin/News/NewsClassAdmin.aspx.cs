using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Web;
using System.Text;
namespace Eisp.Web.Admin.News
{
    public partial class NewsClassAdmin : AdminPage
    {
        protected string listsort = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.QueryString["op"]))
            {
                #region 删除
                if (Request.QueryString["op"].ToString() == "del")
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    if ((EispNewsClassBLL.IsSub(id)) > 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('该类包含子类，不能删除，请先删除子类!');location.href='NewsClassAdmin.aspx?lang=" + lang + "';", true);

                        return;
                    }

                    if((EispNewsBLL.HasNews(id))>0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('该类别包含产品，请先删除该类别下的产品!');location.href='NewsClassAdmin.aspx?lang="+lang+"';", true);

                        return;
                    }

                    int res = EispNewsClassBLL.DeleteNewsClass(id);


                    if (res > 0)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');location.href='NewsClassAdmin.aspx?lang="+lang+"';", true);
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
                    }

                }
                #endregion
                #region 排序
                //升
                if (Request.QueryString["op"].ToString()=="up")
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    EispProClassBLL.UPSort(id,0);

                }
                //降
                if (Request.QueryString["op"].ToString() == "down")
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    EispProClassBLL.UPSort(id, 1);

                }



                #endregion

            }

            listsort = NewsClassTreeBind(0);

        }

        protected string NewsClassTreeBind(int parentid)
        {

            string FolderType = string.Empty;
            int ChildCount;//子节点个数
            int i = 1;
            int proClassCount;
            string FolderName = "";
            string ListType = string.Empty;
            List<NewsClassModel> list = EispNewsClassBLL.GetNewsClassListByLang(lang,parentid);

            proClassCount = list.Count;
            StringBuilder sb = new StringBuilder();

            sb.Append("<table border='0' cellspacing='0' cellpadding='0'>");
            foreach (NewsClassModel proclass in list)
            {

                ChildCount = EispNewsClassBLL.IsSub(proclass.ID);

                if (ChildCount == 0)//没有子节点
                {
                    if (proClassCount == i)
                    {
                        FolderType = "SortFileEnd";
                    }
                    else
                    {
                        FolderType = "SortFile";
                    }

                    FolderName = proclass.F_ClassName;

                }
                else
                {
                    if (proClassCount == i)
                    {
                        FolderType = "SortEndFolderClose";
                        ListType = "SortEndListline";
                    }
                    else
                    {
                        FolderType = "SortFolderClose";
                        ListType = "SortListline";
                    }

                    FolderName = proclass.F_ClassName;

                }

                sb.Append("<tr>");
                sb.Append("<td nowrap  class='" + FolderType + "'></td><td nowrap style='text-align:left'><span class='menu'>" + FolderName + "</span> <a href='###' onclick=\"doAdd(" + proclass.ID + ",'" + FolderName + "');\">添加</> | <a href='###' onclick=\"doEdit(" + proclass.ID + ",'" + FolderName + "');\">编辑</a> | <a href='NewsClassAdmin.aspx?lang="+lang+"&op=del&id=" + proclass.ID.ToString() + "'>删除</a> | <a href='NewsClassAdmin.aspx?lang="+lang+"&op=up&id=" + proclass.ID.ToString() + "'>上移</a> | <a href='NewsClassAdmin.aspx?lang="+lang+"&op=down&id=" + proclass.ID.ToString() + "'>下移</a></td></tr>");

                if (ChildCount > 0)
                {

                    sb.Append("<tr id='c" + proclass.ID.ToString() + "'><td class='" + ListType + "' nowrap></td><td>" + NewsClassTreeBind(proclass.ID) + "</td></tr>");
                }


                i++;
            }
            sb.Append("</table>");
            return sb.ToString();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtClassName.Text))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('分类名称不能为空!');", true);
                return;
            }

            if (string.IsNullOrEmpty(this.txtSort.Text))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('排序不能为空!');", true);
                return;
            }

            if (!VerifyTool.IsInt(this.txtSort.Text, true, true))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('排序格式只能是数字!');", true);
                return;
            }

            int res;
            NewsClassModel proclass = new NewsClassModel();

            proclass.F_ParentID = Convert.ToInt32(this.hidParentID.Value);
            proclass.F_ClassName = this.txtClassName.Text.Trim().ToString();
            proclass.F_Sort = Convert.ToInt32(this.txtSort.Text);
            proclass.F_Lang = lang;
            if (this.txtHiddParentName.Value.Trim().ToString() == "编辑分类")
            {
                res = EispNewsClassBLL.UpdateNewsClass(proclass.F_ClassName, proclass.F_ParentID);

            }
            else
            {
                res = EispNewsClassBLL.AddNewsClass(proclass);
            }
            if (res > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功');location.href='NewsClassAdmin.aspx?lang="+lang+"';", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败,数据库繁忙');", true);
            }
        }


    }
}
