using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Text;
namespace Eisp.Common.Utility
{
    public class WebTools
    {
        private StringBuilder sb = new StringBuilder();
        public static string GetRegionName(int num)
        {

            
            switch (num)
            {
                case 1: return "华北地区";
                case 2: return "西北地区";
                case 3: return "东北地区";
                case 4: return "西南地区";
                case 5: return "华东地区";
                case 6: return "华南地区";
                case 7: return "京沪地区";
                case 8: return "华中地区";
                default: return "暂无资料";
            }



        }

        //站点名称
        public static string SiteName
        {
            get { return ConfigurationManager.AppSettings["SiteName"]; }
        }


        public static string SiteIcp
        {
            get { return ConfigurationManager.AppSettings["SiteIcp"]; }
        }
        public static string SiteKeyWord
        {
            get { return ConfigurationManager.AppSettings["SiteKeyWord"]; }
        }

        public static string SiteDesription
        {
            get { return ConfigurationManager.AppSettings["SiteDesription"]; }
        }
        public static string SiteSupport
        {
            get { return ConfigurationManager.AppSettings["SiteSupport"]; }
        }

        public static string GetRealIP()
        {
            string ip = "";
            HttpRequest request = HttpContext.Current.Request;

            if (request.Headers["X-Forwarded-For"] != null && request.Headers["X-Forwarded-For"].ToString() != string.Empty)
            {
                string[] ips = request.Headers["X-Forwarded-For"].ToString().Split(',');
                if (ips[0] == "")
                {
                    if (ips.Length > 1)
                        ip = ips[1].Trim();
                }
                else
                {
                    ip = ips[0].Trim();
                }
            }
            if (string.IsNullOrEmpty(ip))
                ip = request.UserHostAddress;
            return ip;
        }

    }

}
