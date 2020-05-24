using System;
using System.Collections.Generic;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common;

namespace Eisp.Web
{
    public class AdminPage :CommonPage
    {
        // 当前线程
        private EispAdminSession _currentUser;
        public EispAdminSession CurrentUser
        {
            get
            {
                if (_currentUser == null)
                    _currentUser = new EispAdminSession();
                return _currentUser;
            }
        }
        public String getLangDesc(int lang){
            return web.PageBase.LangTools.getLangDesc(lang);
        }


        // 获取当前线程
        protected void RefreshCurrentUser()
        {
            _currentUser = new EispAdminSession();
        }


        protected override void OnLoad(EventArgs e)
        {
            this.CheckLogin();

            base.OnLoad(e);
        }


        public void CheckLogin()
        {

            if (!this.CurrentUser.IsLogined)
            {
                Response.Write("无法确定你身份，请点击<a href=\"" + SystemConfig.LoginPage + "\" target=\"_parent\">登陆</a>");
                Response.End();
            }



        }

    }
}
