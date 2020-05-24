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
namespace Eisp.Web
{
    public partial class Profile : ServicePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = " 公司简介";
        }

        protected string AboutBind(string id)
        {
            SysInfoResult result = EispSysInfoBLL.GetSysInfoByID(id);

            if (!result.HasError)
            {
                return VerifyTool.DeleteScript(result.Result.Content);
            }
            else
            {
                return "";
            }
        }
    }
}
