using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;

namespace Eisp.BLL
{
    public class EispLinkBLL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static int AddLink(LinkModel l)
        {
            return EispLinkDAL.AddLink(l);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static int UpdateLink(LinkModel l)
        {

            return EispLinkDAL.UpdateLink(l);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteLink(int id)
        {
            return EispLinkDAL.DeleteLink(id);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public static List<LinkModel> GetLinkList()
        {
            return EispLinkDAL.GetLinkList();
        }

    }



}
