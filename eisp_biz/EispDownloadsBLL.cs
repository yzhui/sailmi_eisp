using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;
using System;
using System.Collections.Generic;

namespace Eisp.BLL
{
    public class EispDownloadsBLL
    {
         /// <summary>
      /// 添加
      /// </summary>
      /// <param name="s"></param>
      /// <returns></returns>
        public static int ADD(DownloadsModel s)
        {
            return EispDownloadsDAL.ADD(s);
        }

        
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public static int Delete(int id)
        {
            return EispDownloadsDAL.Delete(id);
        }

         /// <summary>
      /// 获取1条信息资料
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
        public static DownloadsModel GetDownLoadsByID(int downid)
        {
            return EispDownloadsDAL.GetDownLoadsByID(downid);
        }

         /// <summary>
      /// 更新
      /// </summary>
      /// <param name="s"></param>
      /// <returns></returns>
        public static int UpdateByid(DownloadsModel s)
        {
            return EispDownloadsDAL.UpdateByid(s);
        }

         /// <summary>
      /// 获取所有销售网络数据
      /// </summary>
      /// <returns></returns>
        public static List<DownloadsModel> GetDownloadsListByLang(int lang,int number, int pagesize)
        {
            return EispDownloadsDAL.GetDownloadsListByLang(lang,number,pagesize);
        }

         /// <summary>
      /// 是否有
      /// </summary>
      /// <param name="regionid"></param>
      /// <returns>true:有，false:没有</returns>
        public static Boolean IsHave(string regionid)
        {
            return EispDownloadsDAL.IsHave(regionid);
        }

           /// <summary>
      /// 获取文章记录总数
      /// </summary>
      /// <returns></returns>
        public static int GetRecordCountByLang(int lang)
        {
            return EispDownloadsDAL.GetRecordCountByLang(lang);
        }
    }
}
