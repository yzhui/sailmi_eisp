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
using System.Text;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using System.Collections.Generic;
namespace Eisp.Web.Controls.biz
{
    public partial class ProductBox : ControlPage
    {
        protected string ProductHtml = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            List<ProModel> list = EispProBLL.GetTopRecommendedByLang(lang,20);
            StringBuilder sb = new StringBuilder();
            foreach (ProModel p in list)
            {
                sb.Append("<div class=\"productBox\">");
                sb.Append("<div class=\"ProductPhoto\"><a href='ProductDetail.aspx?isprovider=0&id=" + p.ProID + "'><img src=\"" + p.F_SmallPic + "\" alt='" + p.F_ProName + "' /></a></div>");
                sb.Append("<div class=\"productName\"><a href='ProductDetail.aspx?isprovider=0&id=" + p.ProID + "'>" + p.F_ProName + "</a></div>");
                sb.Append("</div>");

            }
            ProductHtml = sb.ToString();
        }
    }
}