using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
using Eisp.Common.Utility;

//
namespace Eisp.Web
{
    public partial class Contact : ServicePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = " 联系我们";
        }

        protected string AboutBind(string id)
        {
            EnInfoResult result = EispEnInfoBLL.GetEnInfoByLang(lang);
            if (!result.HasError)
            {
                return VerifyTool.DeleteScript(result.Result.EnContact);
            }
            else
            {
                return "";
            }
        }
    }
}
