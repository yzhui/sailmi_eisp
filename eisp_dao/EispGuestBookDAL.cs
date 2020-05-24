using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
    public class EispGuestBookDAL
    {
        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int AddGuestBook(GuestBookModel g)
        {
            string sql = "insert into T_GuestBook(F_Contacts,F_Way,F_Content,F_IP,F_Lang) values(?,?,?,?,?)";
            OleDbParameter[] parameter = new OleDbParameter[5];
            parameter[0] = new OleDbParameter("@F_Contacts", OleDbType.VarChar, 50);
            parameter[1] = new OleDbParameter("@F_Way", OleDbType.VarChar, 50);
            parameter[2] = new OleDbParameter("@F_Content", OleDbType.VarChar, 200);
            parameter[3] = new OleDbParameter("@F_IP", OleDbType.VarChar, 50);
            parameter[4] = new OleDbParameter("@F_Lang", OleDbType.Integer);

            parameter[0].Value = g.F_Contacts;
            parameter[1].Value = g.F_Way;
            parameter[2].Value = g.F_Content;
            parameter[3].Value = g.F_IP;
            parameter[4].Value = g.F_Lang;

            return AccessorDB.ExecuteNonQuery(sql, parameter);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteGuestBookByID(int id)
        {
            string sql = "delete from T_GuestBook where ID=? ";

            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ID",OleDbType.Integer);
            parameter[0].Value = id;
            return AccessorDB.ExecuteNonQuery(sql,parameter);
        }
        /// <summary>
        /// 获取留言，分页
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public static List<GuestBookModel> GetGuestBookListByLang(int lang,int number,int pagesize)
        {
            string sql = "select top " + pagesize + " * from (select top " + number + " * from [T_GuestBook] where F_Lang="+lang+"  order by ID asc)  order by ID desc";


            List<GuestBookModel> list = new List<GuestBookModel>();

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

            GuestBookModel g = null;

            while (dr.Read())
            {
                g = new GuestBookModel();

                g.ID = Convert.ToInt32(dr["ID"]);
                g.F_Contacts = dr["F_Contacts"].ToString();
                g.F_Way = dr["F_Way"].ToString();
                g.F_Content = dr["F_Content"].ToString();
                g.F_IP = dr["F_IP"].ToString();
                g.F_Date = Convert.ToDateTime(dr["F_Date"]);
                g.F_Replay = dr["F_Replay"].ToString();
                g.F_Lang = Convert.ToInt32(dr["F_Lang"]);
                list.Add(g);
            }

            dr.Close();
            dr.Dispose();

            return list;
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <returns></returns>
        public static int GetRecordCount()
        {
            string sql = "select count(1) from T_GuestBook";
            int res;
            res = AccessorDB.ExecuteScalar(sql);
            return res;
        }
    }
}
