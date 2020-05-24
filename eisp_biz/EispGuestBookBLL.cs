using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;

namespace Eisp.BLL
{
   public class EispGuestBookBLL
    {

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
       public static int AddGuestBook(GuestBookModel g)
       {
           return EispGuestBookDAL.AddGuestBook(g);
       }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public static int DeleteGuestBookByID(int id)
       {
           return EispGuestBookDAL.DeleteGuestBookByID(id);
       }

        /// <summary>
        /// 获取留言，分页
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
       public static List<GuestBookModel> GetGuestBookListByLang(int lang,int number, int pagesize)
       {
           return EispGuestBookDAL.GetGuestBookListByLang(lang,number,pagesize);
       }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <returns></returns>
       public static int GetRecordCount()
       {
           return EispGuestBookDAL.GetRecordCount();
       }
    }
}
