using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using Eisp.Common;
using System.Text;
using Eisp.BLL;
using Eisp.Entity;
namespace Eisp.Web.Controls.biz
{
    public partial class Category : ControlPage
    {
        protected string cate_menu = string.Empty;
        public int isprovider = 0;
        public string productcateurl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            cate_menu = ProClassBindByLang(lang,0);
            if (Request.QueryString["isprovider"] != null) isprovider = Convert.ToInt16(Request.QueryString["isprovider"]);

        }
        protected string ProClassBindByLang(int lang,int prentid)
        {
            int ChildCount;//子节点个数
            List<ProClassModel> list = EispProClassBLL.GetProClassListByLang(lang,prentid);
            StringBuilder sb = new StringBuilder();
            foreach (ProClassModel proclass in list)
            {
                ChildCount = EispProClassBLL.IsSub(proclass.ID);
                string ClassNameStr = proclass.F_ClassName;

                if (Eisp.Common.Utility.StringTools.GetStrLength(ClassNameStr) > 22) ClassNameStr = Eisp.Common.Utility.StringTools.InterceptStr(ClassNameStr,22)+"..";
                if (productcateurl == null || productcateurl.Equals("")) productcateurl = "ProductList";
                sb.Append("<div class=\"CategoryCote\"><a target=\"_self\" alt=\"" + proclass.F_ClassName + "\" href=\"" + productcateurl + ".aspx?isprovider=" + isprovider + "&classid=" + proclass.ID + "\">" + ClassNameStr + "</a></div>");
                if (ChildCount > 0)
                {
                    sb.Append(ProClassBind(proclass.ID));
                }
            }

            return sb.ToString();
        }
        protected string ProClassBind(int prentid)
        {
            int ChildCount;//子节点个数
            List<ProClassModel> list = EispProClassBLL.GetProClassList(prentid);
            StringBuilder tsb=new StringBuilder();
            foreach (ProClassModel proclass in list)
            {
                ChildCount = EispProClassBLL.IsSub(proclass.ID);
                string ClassNameStr = proclass.F_ClassName;
                if (Eisp.Common.Utility.StringTools.GetStrLength(ClassNameStr) > 22) ClassNameStr = Eisp.Common.Utility.StringTools.InterceptStr(ClassNameStr, 22) + "..";
                tsb.Append("<div class=\"CategoryRow\"><a target=\"_self\" alt=\"" + proclass.F_ClassName + "\" href=\"ProductList.aspx?isprovider=" + isprovider + "&classid=" + proclass.ID + "\">" + ClassNameStr + "</a></div>");
                if (ChildCount > 0)
                {
                    tsb.Append(ProClassBind(proclass.ID));
                }
            }
            return tsb.ToString();
        }
    }
}