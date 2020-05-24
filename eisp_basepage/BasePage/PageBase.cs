using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Eisp.Common
{
   public class PageBase : System.Web.UI.Page
    {
       protected int lang = 1;
       protected string SYSDOMAIN = string.Empty;

       public PageBase()
           : base()
       { 
       }
       //判断是否post提交
       public bool IsHttpPost
       {
           get { return (!string.IsNullOrEmpty(Request.HttpMethod) && Request.HttpMethod.ToUpper() == "POST"); }
       }

       #region 日志记录

       public void WriteLog(LogType type, string log, string code)
       {
           LogTextWriter writer = new LogTextWriter();
           writer.RootFolder = Server.MapPath(SystemConfig.LogPath);
           writer.LogExtension = "log";
           writer.Write(type, Request.Url.AbsoluteUri, DateTime.Now, log, code, "didn't record", Request.ServerVariables["HTTP_COOKIE"], Request.HttpMethod, Request.UserHostAddress, Request.UserAgent);
       }

       protected void WriteError(string message, string code)
       {
           WriteLog(LogType.Error, message, code);
       }

       protected void WriteError(Exception err, string code)
       {
           WriteError(err.ToString(), code);
       }

       protected void WriteError(string message)
       {
           WriteError(message, "");
       }

       protected void WriteError(Exception err)
       {
           WriteError(err, "");
       }
       #endregion

   }
}
