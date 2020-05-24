using System;
using System.Configuration;

namespace Eisp.Common
{
  public  class SystemConfig
    {
      private SystemConfig()
      {
      }
      //��ȡ��־��¼·��
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

      #region ������ַ
      public static string WWWSite
      {
          get { return ConfigurationManager.AppSettings["WWWSite"]; }
      }
      #endregion
  }
}
