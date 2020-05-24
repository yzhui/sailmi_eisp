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


    
       // 转向到错误页
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
                               this.ShowErrorInPage("非法请求。禁止从站外POST数据。");
                           }
                       }
                       else
                       {
                           this.ShowErrorInPage("非法请求。禁止从站外POST数据。");
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
               Response.Write("<title>操作成功</title>");
           else
               Response.Write("<title>出错了</title>");
           Response.Write("<link href=\"" + SystemConfig.WWWSite + "TipPage/stlyes/m.css\" rel=\"stylesheet\" type=\"text/css\" />");
           Response.Write("</head>");
           Response.Write("<body>");

           Response.Write("<div class=\"mbox\">");
           if (success)
               Response.Write("<div class=\"mtitle\">操作成功</div>");
           else
               Response.Write("<div class=\"mtitle\">出错了</div>");

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
               Response.Write("<div class=\"mlink\"><a href=\"javascript:history.back();\">返回</a><a href=\"" + SystemConfig.WWWSite + "\">首页</a><a href=\"javascript:window.close();\">关闭</a></div>");
           else
               Response.Write("<div class=\"mlink\"><a href=\"" + url + "\">返回</a><a href=\"" + SystemConfig.WWWSite + "\">首页</a><a href=\"javascript:window.close();\">关闭</a></div>");

           Response.Write("</body>");
           Response.Write("</html>");

           Response.End();
           //Response.Redirect("/index.aspx");
       }


       #endregion

    }
}
