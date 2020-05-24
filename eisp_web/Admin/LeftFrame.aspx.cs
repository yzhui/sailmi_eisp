using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.Web;
namespace Eisp.Web.Admin
{
    public partial class LeftFrame : AdminPage
    {
        protected string cn_bgcolor="green";
        protected string en_bgcolor="";
        protected string cn_fontcolor = "red";
        protected string en_fontcolor = "white";
        protected string lang = "1";
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            if(lang!=null){
                lang=lang.ToString().Trim();

            }else{
                lang="1";
            }
            if (lang.Equals("1"))
            {
                cn_bgcolor = "green";
                en_bgcolor = "";
                cn_fontcolor = "red";
                en_fontcolor = "white";
            }
            else if (lang.Equals("2"))
            {
                cn_bgcolor = "";
                en_bgcolor = "green";
                cn_fontcolor = "white";
                en_fontcolor = "red";

            }
            else {
                lang = "1";
                cn_bgcolor = "green";
                en_bgcolor = "";
                cn_fontcolor = "red";
                en_fontcolor = "white";
            }
        }
    }
}
