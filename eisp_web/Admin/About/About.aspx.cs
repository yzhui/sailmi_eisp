using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.Entity;
using Eisp.BLL;
using Eisp.Web;

namespace Eisp.Web.Admin.About
{
    public partial class About : AdminPage
    {
        protected string title = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                EnInfoBind(lang);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EnInfoModel f = new EnInfoModel();
            f.EnName = txtEnName.Text;
            f.EnAddr = txtEnAddr.Text;
            f.EnContact = txtEnContact.Value ;
            f.EnKeywords = txtEnKeywords.Text;
            f.EnDesc = txtEnDesc.Value;
            f.EnDetail = content.Value;
            f.Lang = Convert.ToInt32(lang);
            f.EnOnlineContact = txtEnOnlineContact.Value;
            EnInfoResult result = EispEnInfoBLL.UpdateEnInfo(f);
            if (!result.HasError)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('操作成功!');location.href='about.aspx?lang=" + lang + "'", true);
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('操作失败!原因："+result.ErrorMessage+"');location.href='about.aspx?lang=" + lang + "'", true);
            }

        }

        private void EnInfoBind(int lang)
        {
            EnInfoResult result = EispEnInfoBLL.GetEnInfoByLang(lang);
            if (!result.HasError&&result.Result!=null)
            {
                this.txtEnName.Text = result.Result.EnName;
                this.txtEnAddr.Text = result.Result.EnAddr;
                this.txtEnContact.Value = result.Result.EnContact;
                this.txtEnKeywords.Text = result.Result.EnKeywords;
                this.txtEnDesc.Value = result.Result.EnDesc;
                this.content.Value = result.Result.EnDetail ;
                this.txtEnOnlineContact.Value = result.Result.EnOnlineContact;

            }
            else
            {
                title = result.ErrorMessage;
                this.content.Value = result.ErrorMessage;
            }

        }

    }
}
