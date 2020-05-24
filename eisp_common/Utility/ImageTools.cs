using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Drawing;
namespace Eisp.Common.Utility
{
   public class ImageTools
    {
        //上传文件
        public static string UpLoad(HtmlInputFile file, string saveFile)
        {
            
            //获取文件路径
            string fileName = file.PostedFile.FileName;
            //获取文件的后缀
            string extendName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
            string newName = null;
            //过滤文件的后缀
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

           //删除文件
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
       /// 生成缩略图
       /// </summary>
       /// <param name="originalImagePath">源图路径（物理路径）</param>
       /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
       /// <param name="width">缩略图宽度</param>
       /// <param name="height">缩略图高度</param>
       /// <param name="mode">生成缩略图的方式</param>    
       public static string MakeThumbnail(string  originalImagePath, string thumbnailPath, int width, int height, string mode)
       {
           //获取文件的后缀
           string extendName = originalImagePath.Substring(originalImagePath.LastIndexOf(".") + 1).ToLower();

             //过滤文件的后缀
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
                   case "HW"://指定高宽缩放（可能变形）                
                       break;
                   case "W"://指定宽，高按比例                    
                       toheight = originalImage.Height * width / originalImage.Width;
                       break;
                   case "H"://指定高，宽按比例
                       towidth = originalImage.Width * height / originalImage.Height;
                       break;
                   case "Cut"://指定高宽裁减（不变形）                
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

               //新建一个bmp图片
               Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

               //新建一个画板
               Graphics g = System.Drawing.Graphics.FromImage(bitmap);

               //设置高质量插值法
               g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

               //设置高质量,低速度呈现平滑程度
               g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

               //清空画布并以透明背景色填充
               g.Clear(Color.Transparent);

               //在指定位置并且按指定大小绘制原图片的指定部分
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
                   //以jpg格式保存缩略图
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

       //上传文件
       public static string UpLoadDoc(HtmlInputFile file, string saveFile)
       {
           //文件原名称
           string oldName = System.IO.Path.GetFileName(file.PostedFile.FileName);
           //获取文件路径
           string fileName = file.PostedFile.FileName;
           //获取文件的后缀
           string extendName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();
           //string newName = null;
           //过滤文件的后缀
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
