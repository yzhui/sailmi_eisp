using System;
using System.Collections.Generic;
using System.Web;

namespace Eisp.Web
{
    public class TemplatePage : System.Web.UI.MasterPage
    {
        protected string ENINFO_ENKEYWORDS = string.Empty;//系统关键词
        protected string ENINFO_ENNAME = string.Empty;//公司名称
        protected string ENINFO_ENDESC = string.Empty;
        protected string ENINFO_ENDETAIL = string.Empty;
        protected int lang = 1;
        
        public String getLangCode(int lang)
        {
            return web.PageBase.LangTools.getLangCode(lang);
        }

        public String getTemplateRoot(int lang) {
            string ThemeName = Application["theme"].ToString();
            return web.PageBase.WebTools.getTemplateRoot(ThemeName, getLangCode(lang));
        }
        protected void ChangeLanguage(HttpRequest Request)
        {

            string strLanguage = Request.QueryString.Get("lang");
            if (strLanguage != null)
            {
                Session["SYS_LANG"] = strLanguage;
            }
            else
            {
                strLanguage = Session["SYS_LANG"] as string;
                if (string.IsNullOrEmpty(strLanguage)) strLanguage = "1";

            }
            lang = Convert.ToInt32(strLanguage.Trim());
        }       
        protected override void OnLoad(EventArgs e) {
            ChangeLanguage(Request);

            Eisp.BLL.EnInfoResult eir=Eisp.BLL.EispEnInfoBLL.GetEnInfoByLang(lang);

            ENINFO_ENKEYWORDS = eir.Result.EnKeywords;
            ENINFO_ENNAME = eir.Result.EnName;
            ENINFO_ENDESC = eir.Result.EnDesc;
            ENINFO_ENDETAIL = eir.Result.EnDetail;
        }
    }
}
