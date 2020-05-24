using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eisp.Common;
using Eisp.Entity;
using Eisp.BLL;
using Eisp.Web;
namespace Eisp.Web.Admin
{
    public partial class Admin_Main : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            #region
            if (!Page.IsPostBack)
            {


                DateTime nowtime = DateTime.Now;
                // SERVER_NAME.Text = Request.ServerVariables["SERVER_NAME"];
                SERVER_NAME.Text = Request.ServerVariables["SERVER_NAME"];
                MachineName.Text = Server.MachineName;
                LOCAL_ADDR.Text = Request.ServerVariables["LOCAL_ADDR"];
                SERVER_PORT.Text = Request.ServerVariables["SERVER_PORT"];
                ServerDateTime.Text = DateTime.Now.ToString();
                SERVER_SOFTWARE.Text = Request.ServerVariables["SERVER_SOFTWARE"];
                ScriptTimeout.Text = Server.ScriptTimeout.ToString();
                APPL_PHYSICAL_PATH.Text = Request.ServerVariables["APPL_PHYSICAL_PATH"];

                char[] de = { ';' };
                string allhttp = Request.ServerVariables["HTTP_USER_AGENT"].ToString();
                string[] myFilename = allhttp.Split(de);
                runtime.Text = myFilename[myFilename.Length - 1].Replace(")", " ");
                OS.Text = myFilename[2];
                ServerView.Text = myFilename[1];
                PATH_TRANSLATED.Text = Request.ServerVariables["PATH_TRANSLATED"];

                if (checkobj("ADODB.RecordSet"))
                {
                    access.Text = "已安装";
                }
                else
                {
                    access.Text = "未安装";
                }

                if (checkobj("Scripting.FileSystemObject"))
                {
                    fso.Text = "已安装";
                }
                else
                {
                    fso.Text = "未安装";
                }

                if (checkobj("CDONTS.NewMail"))
                {
                    sendmail.Text = "已安装";
                }
                else
                {
                    sendmail.Text = "未安装";
                }

                if (checkobj("JMail.SMTPMail"))
                {
                    jmail.Text = "已安装";
                }
                else
                {
                    jmail.Text = "未安装";
                }

                if (checkobj("LyfUpload.UploadFile"))
                {
                    lyupload.Text = "已安装";
                }
                else
                {
                    lyupload.Text = "未安装";
                }

                if (checkobj("Persits.Upload"))
                {
                    aspupload.Text = "已安装";
                }
                else
                {
                    aspupload.Text = "未安装";
                }

                if (checkobj("Persits.MailSender"))
                {
                    aspemail.Text = "已安装";
                }
                else
                {
                    aspemail.Text = "未安装";
                }

                if (checkobj("aspcn.Upload"))
                {
                    aspcn.Text = "已安装";
                }
                else
                {
                    aspcn.Text = "未安装";
                }

                sessioncount.Text = Session.Contents.Count.ToString();
                appcount.Text = Application.Contents.Count.ToString();

                DateTime passtime = DateTime.Now;
                fast.Text = ((passtime - nowtime).TotalMilliseconds).ToString();
            }
            #endregion

        }

        bool checkobj(string obj)
        {
            try
            {
                object meobj = Server.CreateObject(obj);
                return (true);
            }
            catch (Exception)
            {
                return (false);
            }
        }
        public void checkinput(Object sender, EventArgs e)
        {
            try
            {
                string obj = other.Text;
                object meobj = Server.CreateObject(obj);
                checkok.Text = "检测结果：" + obj + " 组件存在";
            }
            catch (Exception)
            {
                checkok.Text = "检测结果：" + other.Text + " 组件不存在";
            }
        }

    }
}
