using System;
using System.Collections.Generic;
using System.Web;

namespace Eisp.Web
{
    public class ControlPage : System.Web.UI.UserControl
    {
        protected int lang = 1;
        protected string EN_ONLINECONTACT = string.Empty;
        public String getLangCode(int lang)
        {
            return web.PageBase.LangTools.getLangCode(lang);
           
        }
        public String getTemplateRoot(int lang)
        {
            string ThemeName = Application["theme"].ToString();
            return "Template/" + ThemeName + "/" + getLangCode(lang) + "/";
            
        }
        protected void ChangeLanguage(HttpRequest Request, System.Web.UI.Page page)
        {

            string strLanguage = Request.QueryString.Get("lang");
            if (strLanguage != null)
            {
                page.Session["SYS_LANG"] = strLanguage;
            }
            else
            {
                strLanguage = page.Session["SYS_LANG"] as string;
                if (string.IsNullOrEmpty(strLanguage)) strLanguage = "1";

            }
            lang = Convert.ToInt32(strLanguage.Trim());
        }        
        protected override void OnInit(EventArgs e)
        {
            ChangeLanguage(Request, Page);
            Eisp.BLL.EnInfoResult eir = Eisp.BLL.EispEnInfoBLL.GetEnInfoByLang(lang);
            EN_ONLINECONTACT = eir.Result.EnOnlineContact;
        }
    }
}
