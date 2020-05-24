using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace Eisp.Common
{
   public class CommonPage:PageBase
   {
       public CommonPage()
       {
          
       }


    
       // ת�򵽴���ҳ
       protected void ShowCustomErrorPage()
       {
           Response.Redirect("/error.aspx");
       }

       protected override void OnInit(EventArgs e)
       {
           try
           {
               base.OnInit(e);
           }
           catch (Exception err)
           {
               if (!(err is System.Threading.ThreadAbortException))
               {
                   this.WriteError(err);
#if DEBUG
                   this.ShowErrorInPage(err.ToString());
#else
                    this.ShowCustomErrorPage();
#endif
               }
           }
       }
       protected override void OnLoad(EventArgs e)
       {
           //Uri url = new Uri(Request.Url);
           SYSDOMAIN = "http://"+Request.Url.Host+":"+Request.Url.Port;
           
           if (!string.IsNullOrEmpty(Request["lang"]))
           {
               lang = Convert.ToInt32(Request["lang"].Trim());
           }

           try
           {
               if (this.IsHttpPost)
               {
                   if (!string.IsNullOrEmpty(SystemConfig.CookieDomain))
                   {
                       if (Request.UrlReferrer != null)
                       {
                           string host = Request.UrlReferrer.Host;
                           Regex reg = new Regex("\b" + SystemConfig.CookieDomain + "$", RegexOptions.IgnoreCase);
                           if (reg.IsMatch(host))
                           {
                               this.ShowErrorInPage("�Ƿ����󡣽�ֹ��վ��POST���ݡ�");
                           }
                       }
                       else
                       {
                           this.ShowErrorInPage("�Ƿ����󡣽�ֹ��վ��POST���ݡ�");
                       }
                   }
               }

               base.OnLoad(e);
           }
           catch (Exception err)
           {
               if (!(err is System.Threading.ThreadAbortException))
               {
                   this.WriteError(err);
#if DEBUG
                   this.ShowErrorInPage(err.ToString());
#else
					this.ShowCustomErrorPage();
                  // this.ShowErrorInPage(err.ToString());
#endif
               }
           }
       }


       #region ShowErrorInPage
       protected void ShowSuccessInPage(string message)
       {
           ShowResultInPage(message, true, "", 0);
       }

       protected void ShowSuccessInPage(string message, string url, int milisec)
       {
           ShowResultInPage(message, true, url, milisec);
       }

       protected void ShowErrorInPage(string message)
       {
           ShowResultInPage(message, false, "", 0);
       }

       protected void ShowErrorInPage(string message, string url, int milisec)
       {
           ShowResultInPage(message, false, url, milisec);
       }

       protected void ShowResultInPage(string message, bool success, string url, int milisec)
       {
           Response.Write("<html>");
           Response.Write("<head>");
           if (success)
               Response.Write("<title>�����ɹ�</title>");
           else
               Response.Write("<title>������</title>");
           Response.Write("<link href=\"" + SystemConfig.WWWSite + "TipPage/stlyes/m.css\" rel=\"stylesheet\" type=\"text/css\" />");
           Response.Write("</head>");
           Response.Write("<body>");

           Response.Write("<div class=\"mbox\">");
           if (success)
               Response.Write("<div class=\"mtitle\">�����ɹ�</div>");
           else
               Response.Write("<div class=\"mtitle\">������</div>");

           Response.Write("<div class=\"mmain\">");
           if (success)
               Response.Write("<div class=\"ml\"><img src=\"" + SystemConfig.WWWSite + "TipPage/images/r.gif\" /></div>");
           else
               Response.Write("<div class=\"ml\"><img src=\"" + SystemConfig.WWWSite + "TipPage/images/w.gif\" /></div>");
           Response.Write("<div class=\"mr\">");
           Response.Write(message);
           Response.Write("</div>");
           Response.Write("</div>");
           if (string.IsNullOrEmpty(url))
               Response.Write("<div class=\"mlink\"><a href=\"javascript:history.back();\">����</a><a href=\"" + SystemConfig.WWWSite + "\">��ҳ</a><a href=\"javascript:window.close();\">�ر�</a></div>");
           else
               Response.Write("<div class=\"mlink\"><a href=\"" + url + "\">����</a><a href=\"" + SystemConfig.WWWSite + "\">��ҳ</a><a href=\"javascript:window.close();\">�ر�</a></div>");

           Response.Write("</body>");
           Response.Write("</html>");

           Response.End();
           //Response.Redirect("/index.aspx");
       }


       #endregion

    }
}
