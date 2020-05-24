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
    public partial class ProductADD : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDrpClass(0,"-");

            }

        }
        //绑定类别
        protected void BindDrpClass(int parentId, string str)
        {

            str+=str;

            List<ProClassModel> list = EispProClassBLL.GetProClassListByLang(lang,parentId);

            foreach (ProClassModel type in list)
            {
                drpClass.Items.Add(new ListItem(str + type.F_ClassName,type.ID.ToString()));
                lbClass.Items.Add(new ListItem(str + type.F_ClassName, type.ID.ToString()));
                BindDrpClass(type.ID, str);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(this.txtTitle.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品型号不能为空！')", true);
                return;
            }


            if (string.IsNullOrEmpty(this.txtSort.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('产品排序不能为空！')", true);
                return;
            }
            if (!VerifyTool.IsLong(this.txtSort.Text,true))
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

         
            Boolean istop=false;
            Boolean isprovider = false;
            if (this.cbCommend.Checked)
                istop=true;
            if (this.cbProvider.Checked)
                isprovider = true;
            long timeStamp = DateTime.Now.Ticks;
            string smallfilepath = txtImgPath.Text;
            string smallfileurl = smallfilepath.Replace("userfiles", "userfiles/_thumbs");
            smallfileurl = smallfilepath.Replace("UserFiles", "UserFiles/_thumbs");

            ProModel p = new ProModel();
            p.F_IsProvider = isprovider;
            p.F_ProClassID = Convert.ToInt32(drpClass.SelectedValue);
            p.F_ProName = VerifyTool.DeleteAll(this.txtTitle.Text.Trim().ToString());
            p.F_ProSize = VerifyTool.DeleteAll(this.txtYingyong.Value.ToString());
            p.F_ProSizeTable = this.txtGuige.Value;
            p.F_ProWashing  = "";
            p.F_Pic = txtImgPath.Text;
            p.F_SmallPic = smallfileurl;
            p.F_ProDescription =VerifyTool.DeleteScript( this.content.Value);
            p.F_Proattributes = this.hangye.Value;
            p.F_Lang = Convert.ToInt32(lang);
            p.F_Sort = Convert.ToInt32(this.txtSort.Text.Trim().ToString());
            p.F_IsTop = istop;
            string lbselectedstr = string.Empty;
            foreach (ListItem li in lbClass.Items)
            {
                if (li.Selected)
                {
                    lbselectedstr += "," + li.Value;
                }
            }
            p.F_ExtClass = lbselectedstr+",";
            int pid = EispProBLL.AddPro(p);

            if(pid>0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('添加成功！');", true);
            }

        }
    }
}
