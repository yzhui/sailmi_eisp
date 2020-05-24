using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Eisp.Common;

namespace Eisp.Web
{
    public class ServicePage : CommonPage
    {
        private StringBuilder sb = new StringBuilder(500);
        public string ModuleName = string.Empty;
        public string ThemeName = "default";
        protected override void OnPreInit(EventArgs e)
        {
            if (Application["theme"] == null)
            {
                Application["theme"] = "default";
            }
            
            ThemeName = Application["theme"].ToString();
            
            ChangeLanguage(Request,Page);
            InitTemplate(Page);
        }
        public void InitTemplate(System.Web.UI.Page page)
        {
            string cultureStr = lang.ToString();
            //通过语言获取资源代号，如zh-CN,en-US等
            string strUICulture = cultureStr;
            string strMasterPage = "~/Template/" + ThemeName + "/" + getLangCode(lang) + "/" + ModuleName + ".master";
            page.MasterPageFile = strMasterPage;
            page.Master.Attributes.Add("theme",ThemeName);
            page.Master.Attributes.Add("lang",getLangCode(lang));
            page.Master.Attributes.Add("root","/Template/" + ThemeName + "/" + getLangCode(lang) + "/");
        }

        protected void ChangeLanguage(HttpRequest Request, Page page)
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
        //主要就是在ChangeLanguage方法中首先改变页面的母版页，然后再改变页面的区域 
        protected override void OnInit(EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "text/html";
            Response.Charset = "GB2312";
            FromWeb = true;
            base.OnInit(e);
        }

        protected String getLangCode(int lang) {
            return web.PageBase.LangTools.getLangCode(lang);
        
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(SystemConfig.CookieDomain) && FromWeb)
                {
                    if (Request.UrlReferrer != null)
                    {
                        string host = Request.UrlReferrer.Host;
                        Regex reg = new Regex("\b" + SystemConfig.CookieDomain + "$", RegexOptions.IgnoreCase);
                        if (reg.IsMatch(host))
                        {
                            this.ShowWrongResult("非法请求。");
                            return;
                        }
                    }
                    else
                    {
                        this.ShowWrongResult("非法请求。");
                        return;
                    }
                }

                base.OnLoad(e);
            }
            catch (Exception err)
            {
                if (!(err is System.Threading.ThreadAbortException))
                {
                    this.ShowWrongResult("发生无法预知的错误。操作失败。");
                    this.WriteError(err);
                }
            }
        }

        #region show result
        protected void ShowWrongResult(string message)
        {
            ShowResult(1, message, "");
        }

        protected void ShowSuccessResult(string result)
        {
            ShowResult(0, "", result);
        }

        protected void ShowSuccessResult()
        {
            ShowResult(0, "", "");
        }

        protected void ShowResult(int error, string message, string result)
        {
            if (error == 1)
                this.SaveInFile = false;

            sb.Append("<?xml version=\"1.0\" encoding=\"GB2312\" ?>");
            sb.Append("<response>");
            sb.Append("<error>");
            sb.Append(error);
            sb.Append("</error>");
            sb.Append("<message><![CDATA[");
            sb.Append(message);
            sb.Append("]]></message>");
            sb.Append("<responsebody><![CDATA[");

            sb.Append(result);

            sb.Append("]]></responsebody>");
            sb.Append("</response>");
            Response.Write(sb.ToString());
            Response.End();
        }
        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            try
            {
                Response.ClearContent();
                string xml = sb.ToString();
                xml = Regex.Replace(xml, @">\s+<", "><");
                writer.Write(xml);
                base.Render(writer);

                if (this.SaveInFile)
                {
                    string dir = Server.MapPath(this.SavePath);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    StreamWriter stream = new StreamWriter(dir + this.FileName);
                    stream.Write(xml);
                    stream.Close();
                }
            }
            catch (Exception err)
            {
                base.Render(writer);
                this.WriteError(err);
            }
        }

        #region Property
        private bool _fromWeb;
        protected bool FromWeb
        {
            get { return _fromWeb; }
            set { _fromWeb = value; }
        }

        private bool _saveInFile = false;
        public bool SaveInFile
        {
            get { return _saveInFile; }
            set { _saveInFile = value; }
        }

        private string _savePath;
        public string SavePath
        {
            get { return _savePath; }
            set { _savePath = value; }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        #endregion
    }
}
