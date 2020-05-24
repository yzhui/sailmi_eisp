using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
using Eisp.Common.Utility;
using System.Text;
using System.Collections.Generic;
namespace Eisp.Web
{
    public partial class OrderList : ServicePage
    {
        protected string pages = "0";
        public int Records = 0;
        protected string ProductHtml = string.Empty;
        public int CurrentPage = 1;
        public int pagesize = 30;
        public int RecordsPage = 0;
        public string classname = string.Empty;
        protected int isprovider = 1;
        public string ErroStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

                int classid = 0;
                if (Request.QueryString["classid"] != null)
                {
                    classid = Convert.ToInt32(Request.QueryString["classid"]);
                }
                
                if (Request.QueryString["isprovider"] != null)
                {
                    isprovider = Convert.ToInt32(Request.QueryString["isprovider"]);
                }

                GetClassName(0, classid, false, ref classname);
                int totalNum = EispProBLL.GetRecordCountByClassidByLang(lang, classid, isprovider);
                if (VerifyTool.IsInt(Request.QueryString["page"]))
                {
                    CurrentPage = Convert.ToInt32(Request.QueryString["page"]);
                    //要减去的记录数
                    int subtract_number = pagesize * (CurrentPage - 1);

                    //要获取的记录数：记录总数-要减去的记录数
                    int number = totalNum - subtract_number;

                    if (totalNum > 0)
                        ProTopBind(number, pagesize, classid, totalNum);

                }
                else
                {
                    if (totalNum > 0)
                    {
                        ProTopBind(totalNum, pagesize, classid, totalNum);
                    }
                }
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

        protected void ProTopBind(int number, int pagesize, int classid, int recordcount)
        {
            List<ProModel> list = EispProBLL.GetListPageNoByClassIDByLang(lang, number, pagesize, classid, isprovider);
            AspNetPager.RecordCount = recordcount;
            AspNetPager.CurrentPageIndex = number;
            AspNetPager.PageSize = pagesize;
            
            RecordsPage = int.Parse(pages);
            Records = recordcount;
            StringBuilder sb = new StringBuilder();
            foreach (ProModel p in list)
            {
                sb.Append("<div class=\"productBox\">");
                sb.Append("<div class=\"ProductPhoto\"><a href='OrderDetail.aspx?isprovider=" + isprovider + "&id=" + p.ProID + "'><img src=\"" + p.F_SmallPic+ "\" alt='" + p.F_ProName + "' /></a></div>");
                sb.Append("<div class=\"productName\"><a href='OrderDetail.aspx?isprovider=" + isprovider + "&id=" + p.ProID + "'>" + p.F_ProName + "</a></div>");
                sb.Append("</div>");

            }
            ProductHtml = sb.ToString();
            //ProductHtml = ProductHtml + list.Count;
        }
        protected void AspNetPager_PageChanged(object src, EventArgs e)
        {
        }

    }
}
