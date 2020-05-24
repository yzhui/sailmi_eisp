using System;
using System.Configuration;

namespace Eisp.Common
{
  public  class SystemConfig
    {
      private SystemConfig()
      {
      }
      //读取日志记录路径
      public static string LogPath
      {
          get
          {
              return ConfigurationManager.AppSettings["LogPath"];
          }
      }

      public static string LoginPage
      {
         get
          {
            return ConfigurationManager.AppSettings["LoginPage"];
          }
      }

      public static string TicketCookieName
      {
          get { return "Colo"; }
      }

      public static string CookieDomain
      {
          get
          {
              return ConfigurationManager.AppSettings["CookieDomain"];
          }
      }

      public static string CookieCacheTime
      {
          get
          {
              return ConfigurationManager.AppSettings["CookieCacheTime"];
          }
      }

      #region 导航地址
      public static string WWWSite
      {
          get { return ConfigurationManager.AppSettings["WWWSite"]; }
      }
      #endregion
  }
}
