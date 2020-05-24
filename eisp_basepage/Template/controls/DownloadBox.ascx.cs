using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using System.Collections.Generic;
namespace Eisp.Web.Controls.biz
{
    public partial class DownloadBox : ControlPage
    {
        protected string downloadlist = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            List<DownloadsModel> list = EispDownloadsBLL.GetDownloadsListByLang(lang,5,5);

            StringBuilder sb = new StringBuilder();

            foreach(DownloadsModel d in list)
            {
                string TitleStr = string.Empty;
                TitleStr = d.F_Title;
                if (TitleStr.Length > 20) TitleStr = TitleStr.Substring(0,18)+"...";
                sb.Append("<div class=\"DownloadRow\"><a target=\"_blank\" alt=\""+d.F_Title+"\" href=\""+ d.F_Content +"\">"+TitleStr+"</a></div>");
            }
            downloadlist = sb.ToString();
        }
    }
}