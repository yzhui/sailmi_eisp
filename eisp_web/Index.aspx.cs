using System;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
using Eisp.Common.Utility;

//
namespace Eisp.Web
{
    public partial class Index : ServicePage
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
                        
        }
        protected string AboutBind(string id)
        {
            SysInfoResult result = EispSysInfoBLL.GetSysInfoByID(id);

            if (!result.HasError)
            {

                return VerifyTool.CheckStringLength(VerifyTool.RemoveHtml(result.Result.Content),360,false);
            }
            else
            {
                return "";
            }
        }

        public string TopPro(int count)
        { 
             

            List<ProModel> list = EispProBLL.GetTopRecommended(count);
            StringBuilder sb = new StringBuilder();
            foreach (ProModel p in list)
            {
                sb.Append("<div class=\"ProductBox\">");
                sb.Append("<div class=\"ProductPhoto\"><a href='ProductDetail-" + p.ProID + ".aspx'><img src=\"" + GetPicID(p.ProID, 0) + "\" alt='" + p.F_ProName + "'  /></a></div>");
                sb.Append("<div class=\"productName\"><a href='ProductDetail-" + p.ProID + ".aspx'>" + p.F_ProName + "</a></div>");
                sb.Append("</div>");

            }

            return sb.ToString();

           

        }
        protected string GetPicID(int proid, int colorid)
        {

            return "";
        }
    }
}


//