using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Eisp.Common.Utility;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Web;
namespace Eisp.Web.Admin.Products
{
    public partial class ProductAdmin : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                if (EispProBLL.GetRecordCount() > 0)
                {
                    AspNetPager1.RecordCount = EispProBLL.GetRecordCount();
                    ProductBind(AspNetPager1.RecordCount, AspNetPager1.PageSize);

                    BindDrpClass(0, "-");
                }
            }


        }


        //绑定类别
        protected void BindDrpClass(int parentId, string str)
        {

            str += str;

            List<ProClassModel> list = EispProClassBLL.GetProClassList(parentId);

            foreach (ProClassModel type in list)
            {
                drpClass.Items.Add(new ListItem(str + type.F_ClassName, type.ID.ToString()));
                BindDrpClass(type.ID, str);
            }



        }

        protected void ProductBind(int n, int p)
        {



            List<ProModel> list = EispProBLL.GetProListPageNoByLang(lang,n, p);

            GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "ProID" };
            GridView1.DataBind();


        }
        //编辑
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // GridView1.EditIndex = e.NewEditIndex;

            string id = this.GridView1.DataKeys[e.NewEditIndex].Value.ToString();

            Response.Redirect("productedit.aspx?lang="+lang+"&id=" + id + "");

        }

       

        //删除

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)

            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            //删除产品
            int res = EispProBLL.DeletePro(id);

           // Page.ClientScript.RegisterStartupScript(this.GetType(), "", "javascript:return confirm('删除后无法恢复！请确认!');", true);
            if (res > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),"","alert('删除成功！');",true);
                if (EispProBLL.GetRecordCount()>0)
                {
                AspNetPager1.Visible = true;
                AspNetPager1.RecordCount = EispProBLL.GetRecordCount();
                ProductBind(AspNetPager1.RecordCount, AspNetPager1.PageSize);
                }
                else
                {
                    this.GridView1.Visible = false;
                }
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("chk")).Checked)
                {
                    int id = int.Parse(((Label)row.FindControl("id")).Text);
                    // this.News_Delete(id);
                    EispProBLL.DeletePro(id);//删除产品
                }
                AspNetPager1.Visible = true;
               
            }
            if (EispProBLL.GetRecordCount() > 0)
            {
                AspNetPager1.RecordCount = EispProBLL.GetRecordCount();
                ProductBind(AspNetPager1.RecordCount, AspNetPager1.PageSize);
            }
            else
            {
                this.GridView1.Visible = false;
            }

        }



        //翻页
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

            //要减去的记录数
            int subtract_number = AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1);

            //要获取的记录数：记录总数-要减去的记录数
            int number = AspNetPager1.RecordCount - subtract_number;

            ProductBind(number, AspNetPager1.PageSize);
        }

        protected void SearchBtn_Click_Click(object sender, EventArgs e)
        {
            AspNetPager1.Visible = false;

            List<ProModel> list = EispProBLL.SearchProList(lang,Convert.ToInt32(drpClass.SelectedValue));

            GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "ProID" };
            GridView1.DataBind();
            

        }

    }
}
