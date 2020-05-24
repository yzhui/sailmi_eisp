using System;
using System.Collections.Generic;

using System.Text;

namespace web.PageBase
{
    public class WebTools
    {

        public static String getTemplateRoot(string theme,string  langcode)
        {
            return "Template/" + theme + "/" + langcode + "/";
        }

    }

    public class LangTools
    {
        public static String getLangCode(int lang)
        {
            if (lang == 2) return "en";
            return "cn";
        }

        public static String getLangDesc(int lang)
        {
            if (lang == 2) return "英文版";
            else return "中文版";
        }

    }
}
