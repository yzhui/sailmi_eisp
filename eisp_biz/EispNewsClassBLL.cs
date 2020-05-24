using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;

namespace Eisp.BLL
{
   public class EispNewsClassBLL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0失败，1成功</returns>
        public static int AddNewsClass(NewsClassModel t)
        {
                return EispNewsClassDAL.AddNewsClass(t);
        }

       /// <summary>
        /// 更新
        /// </summary>
        /// <param name="n"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateNewsClass(string n, int id)
        {
            return EispNewsClassDAL.UpdateNewsClass(n,id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteNewsClass(int id)
        {
            return EispNewsClassDAL.DeleteNewsClass(id);
        }

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public static List<NewsClassModel> GetNewsClassListByLang(int lang,int parentid)
        {
            return EispNewsClassDAL.GetNewsClassListByLang(lang,parentid);
        }

        public static List<NewsClassModel> GetNewsClassList(int parentid)
        {
            return EispNewsClassDAL.GetNewsClassList(parentid);
        }
        /// <summary>
        /// 是否有子类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IsSub(int id)
        {
            return EispNewsClassDAL.IsSub(id);
        }
       /// <summary>
       /// 排序
       /// </summary>
       /// <param name="id"></param>
       /// <param name="type"></param>
       /// <returns></returns>
        public static int UPSort(int id, int type)
        {
            return EispNewsClassDAL.UPSort(id,type);
        }
        public static NewsClassModel GetParentName(int parentid)
        {
            return EispNewsClassDAL.GetParentName(parentid);
        }
    }
}
