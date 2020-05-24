using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Drawing;
namespace Eisp.Common.Utility
{
   public class ImageTools
    {
        //�ϴ��ļ�
        public static string UpLoad(HtmlInputFile file, string saveFile)
        {
            
            //��ȡ�ļ�·��
            string fileName = file.PostedFile.FileName;
            //��ȡ�ļ��ĺ�׺
            string extendName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
            string newName = null;
            //�����ļ��ĺ�׺
            if (extendName == "jpg" || extendName == "bmp" || extendName == "gif")
            {
               // int iSeed = 10;
                Random ro = new Random(100);
                long tick = DateTime.Now.Ticks;
                Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

                int iResult;
                int iUp = 100;
                iResult = ro.Next(iUp);

            
                newName = System.Guid.NewGuid().ToString();
                file.PostedFile.SaveAs(saveFile + "/" + newName + "." + extendName);
            }
            return newName + "." + extendName;
        }

       public static int DeleteImg(string path)
       {

           //ɾ���ļ�
           string delFile =System.Web.HttpContext.Current.Server.MapPath("/"+path) ;
        //   string delImg = Server.MapPath("../" + newsData.TitleImg.ToString());
           if (File.Exists(delFile))
           {
               File.Delete(delFile);
               return 1;
           }
           else
           {
               return 0;
           }
        

       }

       /// <summary>
       /// ��������ͼ
       /// </summary>
       /// <param name="originalImagePath">Դͼ·��������·����</param>
       /// <param name="thumbnailPath">����ͼ·��������·����</param>
       /// <param name="width">����ͼ���</param>
       /// <param name="height">����ͼ�߶�</param>
       /// <param name="mode">��������ͼ�ķ�ʽ</param>    
       public static string MakeThumbnail(string  originalImagePath, string thumbnailPath, int width, int height, string mode)
       {
           //��ȡ�ļ��ĺ�׺
           string extendName = originalImagePath.Substring(originalImagePath.LastIndexOf(".") + 1).ToLower();

             //�����ļ��ĺ�׺
           if (extendName == "jpg" || extendName == "bmp" || extendName == "gif")
           {

               Image originalImage = Image.FromFile(originalImagePath);

               int towidth = width;
               int toheight = height;

               int x = 0;
               int y = 0;
               int ow = originalImage.Width;
               int oh = originalImage.Height;

               switch (mode)
               {
                   case "HW"://ָ���߿����ţ����ܱ��Σ�                
                       break;
                   case "W"://ָ�����߰�����                    
                       toheight = originalImage.Height * width / originalImage.Width;
                       break;
                   case "H"://ָ���ߣ�������
                       towidth = originalImage.Width * height / originalImage.Height;
                       break;
                   case "Cut"://ָ���߿�ü��������Σ�                
                       if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                       {
                           oh = originalImage.Height;
                           ow = originalImage.Height * towidth / toheight;
                           y = 0;
                           x = (originalImage.Width - ow) / 2;
                       }
                       else
                       {
                           ow = originalImage.Width;
                           oh = originalImage.Width * height / towidth;
                           x = 0;
                           y = (originalImage.Height - oh) / 2;
                       }
                       break;
                   default:
                       break;
               }

               //�½�һ��bmpͼƬ
               Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

               //�½�һ������
               Graphics g = System.Drawing.Graphics.FromImage(bitmap);

               //���ø�������ֵ��
               g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

               //���ø�����,���ٶȳ���ƽ���̶�
               g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

               //��ջ�������͸������ɫ���
               g.Clear(Color.Transparent);

               //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
               g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                   new Rectangle(x, y, ow, oh),
                   GraphicsUnit.Pixel);

               try
               {
                   string filePath = thumbnailPath.Substring(0,thumbnailPath.LastIndexOf("\\"));
                   if (!Directory.Exists(filePath))
                       Directory.CreateDirectory(filePath);

                 string  newName = System.Guid.NewGuid().ToString();
                 newName = newName.Replace("-","");
                   //��jpg��ʽ��������ͼ
                 bitmap.Save(thumbnailPath , System.Drawing.Imaging.ImageFormat.Jpeg);

                 return thumbnailPath;
               }
               catch (System.Exception e)
               {
                   throw new Exception(e.Message+";"+thumbnailPath) ;
               }
               finally
               {
                   originalImage.Dispose();
                   bitmap.Dispose();
                   g.Dispose();
               }
           }
           return "";
       }

       //�ϴ��ļ�
       public static string UpLoadDoc(HtmlInputFile file, string saveFile)
       {
           //�ļ�ԭ����
           string oldName = System.IO.Path.GetFileName(file.PostedFile.FileName);
           //��ȡ�ļ�·��
           string fileName = file.PostedFile.FileName;
           //��ȡ�ļ��ĺ�׺
           string extendName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
           //string newName = null;
           //�����ļ��ĺ�׺
           if (extendName == "rar" || extendName == "doc" || extendName == "txt")
           {
               if (!Directory.Exists(saveFile))
                   Directory.CreateDirectory(saveFile);
               //newName = System.Guid.NewGuid().ToString();
               file.PostedFile.SaveAs(saveFile + "/" + oldName + "");
           }
           return oldName;
       }


    }
}
