using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;

namespace Eisp.BLL
{
  public  class EispAdBLL
    {

       /// <summary>
        /// 添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
      public static int Add(AdModel a)
      {
          return EispAdDAL.Add(a);
      }

       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      public static int DeleteByID(int id)
      {
          return EispAdDAL.DeleteByID(id);
      }

       /// <summary>
        /// 更新
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
      public static int UpdateByID(AdModel a)
      {
          return EispAdDAL.UpdateByID(a);
      }

      /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <returns></returns>
      public static List<AdModel> GetAdList()
      {
          return EispAdDAL.GetAdList();
      }
    }
}
