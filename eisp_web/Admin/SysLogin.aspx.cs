using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;
namespace Eisp.Web.Admin
{
    //
    public partial class syslogin :CommonPage
    {
        public string WWWSite = SystemConfig.WWWSite;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string code = this.Code.Value.Trim().ToString();
            string userName = this.userName.Value.Trim().ToString();
            string passWord = this.PassWord.Value.Trim().ToString();
            if (code.ToUpper() != Request.Cookies["CheckCode"].Value.ToString().ToUpper())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('验证码错误！')", true);
            }
            else
            {
                AdminModel admin = new AdminModel();
                admin.Name = userName;
                admin.Pass = passWord;

                UserResult result = EispAdminBLL.GetAdminInfo(admin);

                //5~1~a~s~p~x
                if (!result.HasError && result.Result.Name != null && result.Result.Name != "")
                {

                    EispAdminSession save = new EispAdminSession();
                    save.SaveSessionTicketInCookie(admin);

                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('用户名或密码错误！')", true);
                }

            }

        }
    }
}
