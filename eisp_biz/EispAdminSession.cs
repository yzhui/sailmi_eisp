using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using Eisp.Entity;
using Eisp.BLL;
using Eisp.Common;
namespace Eisp.BLL
{

   public class EispAdminSession
    {

       private AdminModel online = null;
       private HttpContext context = null;
       /// <summary>
       /// 实例化，开始跟踪
       /// </summary>
       public EispAdminSession()
       {
           context = HttpContext.Current;

           Refresh();
       }

       /// <summary>
       /// 退出，清空服务器端数据和Cookie
       /// </summary>
       public void Logout()
       {
           if (online != null)
           {
               ClearSessionTicket();
               this.online = null;

           }
       }

       public void Refresh()
       {
      
               online = GetSessionFromCookie();
               if (online != null)
               {
              
                       // 读取Cookie
                       //online.LastActionTime = DateTime.Now;
                       FromCache = true;
              }        
           
       }

       public void Save()
       {
           SaveSessionTicketInCookie(this.online);
       }

       public void SaveSessionTicketInCookie(AdminModel session)
       {
           context = HttpContext.Current;
           HttpCookie cookie = new HttpCookie(SystemConfig.TicketCookieName);
           cookie.Values["sessionname"] = HttpUtility.UrlEncode(session.Name);
           cookie.Values["pass"] = HttpUtility.UrlEncode(session.Pass);
           cookie.Values["au"] = HttpUtility.UrlEncode(session.Authority.ToString());

           if (!string.IsNullOrEmpty(SystemConfig.CookieDomain))
               cookie.Domain = SystemConfig.CookieDomain;

           cookie.Expires.AddMinutes(Convert.ToDouble(SystemConfig.CookieCacheTime));
          context.Response.Cookies.Add(cookie);
          context.Request.Cookies.Add(cookie);

       }

       private AdminModel GetSessionFromCookie()
       {
           if (context.Request.Cookies[SystemConfig.TicketCookieName] != null)
           {
               HttpCookie cookie = context.Request.Cookies[SystemConfig.TicketCookieName];

               AdminModel session = new AdminModel();
               session.Name = HttpUtility.UrlDecode(cookie.Values["sessionname"].ToString());
               session.Authority = Convert.ToInt32(HttpUtility.UrlDecode(cookie.Values["au"]));
               return session;
           }
           return null;
       }

       private void ClearSessionTicket()
       {
           if (this.IsLogined)
           {
               // 服务器端清除
               

               // 客户端清除
               HttpCookie cookie = new HttpCookie(SystemConfig.TicketCookieName);
               cookie.Value = null;
               cookie.Expires = DateTime.Now.AddDays(-1);
               if (!string.IsNullOrEmpty(SystemConfig.CookieDomain))
                   cookie.Domain = SystemConfig.CookieDomain;

               context.Request.Cookies.Add(cookie);
               context.Response.Cookies.Add(cookie);
           }
       }


       public bool IsLogined
       {
          
           get
           {
               return (this.online != null && EispAdminBLL.CheckName(this.Name) );
       
           }
       }


       public string Name
       {
           get { return (online == null) ? "" : online.Name; }
           set {
               if(online!=null)
                   online.Name=value;
           }
       }

       public int Authority
       {
           get { return (online == null) ? -1 : online.Authority; }
           set { 
               if(online!=null)
               {
                   online.Authority = value;
               }
           }
       }

       private bool _fromCache;
       public bool FromCache
       {
           get { return _fromCache; }
           set { _fromCache = value; }
       }

    }
}
