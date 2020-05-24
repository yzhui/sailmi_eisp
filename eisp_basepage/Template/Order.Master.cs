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
using System.Collections.Generic;
using Eisp.Common.Utility;
using Eisp.BLL;
using Eisp.Entity;
using System.Text;
namespace Eisp.Web.Controls.biz
{ 
    public partial class Order: Eisp.Web.TemplatePage
    {
        protected int isprovider = 0;
        public string ProductTitle = "";
        protected void OnInit(object sender, EventArgs e)
        {
          
        }

    }
}
