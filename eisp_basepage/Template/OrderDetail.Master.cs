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
using Eisp.Common.Utility;
using Eisp.BLL;
using Eisp.Entity;
using System.Text;
namespace Eisp.Web.Controls.biz
{ 
    public partial class OrderDetail: Eisp.Web.TemplatePage
    {
        public string classname = null;
        public string picstyle = string.Empty;
        public string prosize = string.Empty;
        public string proshuxing = string.Empty;
        public string prosizetable = string.Empty;
        public string procontent = string.Empty;
        public string propic = string.Empty;
        public string procolor = string.Empty;
        public string ProWashing = string.Empty;
        public string proname = string.Empty;
        public int cid = 0;
        public string litpic = string.Empty;
        protected int isprovider = 0;

        protected override void OnLoad(EventArgs e)
        {
            if (Request.QueryString["isprovider"] != null)
            {
                isprovider = Convert.ToInt32(Request.QueryString["isprovider"]);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (VerifyTool.IsLong(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    ProBind(id);


                }
                else
                {

                    Response.Redirect(Request.Url.ToString());
                }
            }
        }


        public void ProBind(int id)
        {
            ProModel p = EispProBLL.GetProByID(id);

            Page.Title = p.F_ProName;
            proname = p.F_ProName;
            propic = p.F_Pic;
            prosize = p.F_ProSize;
            proshuxing = p.F_Proattributes;
            prosizetable = p.F_ProSizeTable;
            procontent = p.F_ProDescription;
            litpic = ProTopBind(10, 10, p.F_ProClassID);
            GetClassName(0, p.F_ProClassID, false, ref classname);

        }

        protected string ProTopBind(int number, int pagesize, int classid)
        {
            List<ProModel> list = EispProBLL.GetListPageNoByClassID(number, pagesize, classid, isprovider);
            StringBuilder sb = new StringBuilder();
            foreach (ProModel p in list)
            {

                sb.Append("<div class=\"ProductBox\">");
                sb.Append("<div class=\"ProductPhoto\"><a href='ProductDetail.aspx?id=" + p.ProID + "'><img src=\"" + p.F_Pic + "\" alt='" + p.F_ProName + "' /></a></div>");
                sb.Append("<div class=\"ProductName\"><a href='ProductDetail.aspx?id=" + p.ProID + "'>" + p.F_ProName + "</a></div>");
                sb.Append("</div>");

            }

            return sb.ToString();
        }



        protected void GetClassName(int classid, int id, Boolean bFind, ref string sl)
        {


            if (!bFind)
            {
                if (classid == 0 && id == 0)
                {
                    sl = ">>所有产品";
                }
                else
                {
                    ProClassModel c = EispProClassBLL.GetParentName(id);

                    //string temp = string.Empty;
                    //  temp = sl;
                    sl = ">>" + c.F_ClassName + sl;
                    if (c.F_ParentID != 0)
                    {
                        GetClassName(classid, c.F_ParentID, false, ref sl);
                    }
                    else
                    {
                        bFind = true;
                    }

                }
            }


        }

    }
}
