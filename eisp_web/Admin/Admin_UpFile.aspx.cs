using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.Web;
using Eisp.Common.Utility;
namespace Eisp.Web.Admin
{
    public partial class Admin_UpFile : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filePath = "Upload/" + ImageTools.UpLoad(this.File1, Server.MapPath("/UpLoad"));
            this.panel1.Visible = false;
            this.panel2.Visible = true;
            this.CopyTxt.Value = filePath;
        }

    }
}
