using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Web;
using System.Text;
namespace Eisp.Web.Admin.Products
{
    public partial class productedit : AdminPage
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


                        ProBind(id);
                    }
                }

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtTitle.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品型号不能为空！')", true);
                return;
            }

            if (string.IsNullOrEmpty(this.txtSort.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品排序不能为空！')", true);
                return;
            }
            if (!VerifyTool.IsLong(this.txtSort.Text, true))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品排序只能填写数字！')", true);
                return;
            }



            if (string.IsNullOrEmpty(this.txtYingyong.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品应用不能为空！')", true);
                return;
            }



            if (string.IsNullOrEmpty(this.content.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品描述不能为空！')", true);
                return;
            }

            Boolean istop = false;
            if (this.cbCommend.Checked)
                istop = true;
            Boolean isprovider = false;
            if (this.cbProvider.Checked)
                isprovider = true;


            //处理缩略图
            long timeStamp = DateTime.Now.Ticks;
            string smallfilepath = txtImgPath.Text;
            string smallfileurl = smallfilepath.Replace("userfiles", "userfiles/_thumbs");
            smallfileurl = smallfilepath.Replace("UserFiles", "UserFiles/_thumbs");

            ProModel p = new ProModel();

            p.F_ProClassID = Convert.ToInt32(drpClass.SelectedValue);
            p.F_ProName = VerifyTool.DeleteAll(this.txtTitle.Text.Trim().ToString());
            p.F_ProSize = VerifyTool.DeleteAll(this.txtYingyong.Value.ToString());
            p.F_ProSizeTable = this.txtGuige.Value;
            p.F_ProWashing = "";
            p.F_ProDescription = VerifyTool.DeleteScript(this.content.Value);
            p.F_Proattributes = this.hangye.Value;
            p.ProID = Convert.ToInt32(this.txtProid.Value);
            p.F_Sort = Convert.ToInt32(this.txtSort.Text.Trim().ToString());
            p.F_IsTop = istop;
            p.F_Lang = lang;
            p.F_Pic = txtImgPath.Text;
            p.F_SmallPic = smallfileurl;
            p.F_IsProvider = isprovider;
            string lbselectedstr = string.Empty;
            foreach (ListItem li in lbClass.Items)
            {
                if (li.Selected)
                {
                    lbselectedstr += "," + li.Value;
                }
            }
            p.F_ExtClass = lbselectedstr+",";
            int pid = EispProBLL.UpdatePro(p);

            if (pid > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "m", "alert('更新成功！')", true);
            }

           

        }

        //绑定类别
        protected void BindDrpClass(int parentId, string str, int selected,string extclass)
        {

            str += str;

            List<ProClassModel> list = EispProClassBLL.GetProClassListByLang(lang,parentId);

            foreach (ProClassModel type in list)
            {
                drpClass.Items.Add(new ListItem(str + type.F_ClassName, type.ID.ToString()));


                ListItem lli = new ListItem(str + type.F_ClassName, type.ID.ToString());

                if (type.ID == selected)
                {
                    lli.Selected = true;
                }
                ListItem li=new ListItem(str + type.F_ClassName, type.ID.ToString());
                extclass =","+ extclass + ",";
                if (extclass.IndexOf("," + type.ID + ",") > 0) { 
                    li.Selected=true;
                }else{
                    li.Selected=false;
                }
                lbClass.Items.Add(li);

                BindDrpClass(type.ID, str, selected,extclass);

            }

          

        }

        protected void ProBind(int id)
        {

            ProModel p = EispProBLL.GetProByID(id);

            this.txtTitle.Text = p.F_ProName;
            this.txtProid.Value = id.ToString();

            this.txtGuige.Value = p.F_ProSizeTable;
            this.hangye.Value = p.F_Proattributes;

            this.txtSort.Text = p.F_Sort.ToString();

            this.txtImgPath.Text = p.F_Pic;
            this.txtYingyong.Value = p.F_ProSize;
            this.content.Value = p.F_ProDescription;
            this.cbCommend.Checked = p.F_IsTop;
            this.cbProvider.Checked = p.F_IsProvider;
            BindDrpClass(0, "-", p.F_ProClassID,p.F_ExtClass);

          
        }
    }
}
