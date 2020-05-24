using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;

namespace Eisp.BLL
{
   public class EispProClassBLL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0失败，1成功</returns>
        public static int AddProClass(ProClassModel t)
        {
                return EispProClassDAL.AddProClass(t);
        }

       /// <summary>
        /// 更新
        /// </summary>
        /// <param name="n"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateProClass(string n, int id)
        {
            return EispProClassDAL.UpdateProClass(n,id);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteProClass(int id)
        {
            return EispProClassDAL.DeleteProClass(id);
        }

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public static List<ProClassModel> GetProClassListByLang(int lang,int parentid)
        {
            return EispProClassDAL.GetProClassListByLang(lang,parentid);
        }

        public static List<ProClassModel> GetProClassList(int parentid)
        {
            return EispProClassDAL.GetProClassList(parentid);
        }
        /// <summary>
        /// 是否有子类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IsSub(int id)
        {
            return EispProClassDAL.IsSub(id);
        }
       /// <summary>
       /// 排序
       /// </summary>
       /// <param name="id"></param>
       /// <param name="type"></param>
       /// <returns></returns>
        public static int UPSort(int id, int type)
        {
            return EispProClassDAL.UPSort(id,type);
        }
        public static ProClassModel GetParentName(int parentid)
        {
            return EispProClassDAL.GetParentName(parentid);
        }
    }
}
