using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.BLL;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Web;
using System.IO;
namespace Eisp.Web.Admin.Downloads
{
    public partial class DownloadAdd : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string fpath = Path.Combine(Request.PhysicalApplicationPath, "Upload/doc");
            if (!Directory.Exists(fpath))
                Directory.CreateDirectory(fpath);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtTitle.Text))
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('标题不能为空！')", true);
                return;

            }


            string smallfileurl = txtImgPath.Text;
            smallfileurl = smallfileurl.ToLower();
            smallfileurl = smallfileurl.Replace("userfiles", "userfiles/_thumbs");
            long filesize = 0;

            DownloadsModel s = new DownloadsModel();
            string filePath = txtFilePath.Text;
            s.F_Size = filesize.ToString();
            s.F_FileType = Convert.ToInt16(drpFileClass.SelectedValue); //Convert.ToInt32(this.txtRegion.SelectedValue);
            s.F_Content = filePath; //VerifyTool.DeleteScript(this.content.Value);
            s.F_Desc = txtDesc.Text;
            s.F_Lang = lang;
            s.F_Title = txtTitle.Text;
            s.F_Keywords = txtKeywords.Text;
            s.F_FileImage = txtImgPath.Text;
            s.F_FileSmallImage = smallfileurl;
            int res = EispDownloadsBLL.ADD(s);

            if (res > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('添加成功！');location.href='DownloadAdmin.aspx?lang=" + lang+"'", true);
            }
      }
    }
}
