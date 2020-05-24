using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
    public class EispAdDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Add(AdModel a)
        {
            string sql = "insert into T_AD(F_Pic,F_Url) values(?,?)";

            OleDbParameter[] parameter = new OleDbParameter[2];

            parameter[0] = new OleDbParameter("@F_Pic", OleDbType.VarChar, 100);
            parameter[1] = new OleDbParameter("@F_Url", OleDbType.VarChar, 200);

            parameter[0].Value = a.F_Pic;
            parameter[1].Value = a.F_Url;

            return AccessorDB.ExecuteNonQuery(sql, parameter);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteByID(int id)
        {
            string sql = "delete from T_AD where ID=?";
            OleDbParameter[] parameter = new OleDbParameter[1];
            parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
            parameter[0].Value = id;

            return AccessorDB.ExecuteNonQuery(sql, parameter);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int UpdateByID(AdModel a)
        {
            string sql = "update T_AD set F_Pic=?,F_Url=? where ID=? ";

            OleDbParameter[] parameter = new OleDbParameter[3];

            parameter[0] = new OleDbParameter("@F_Pic", OleDbType.VarChar, 100);
            parameter[1] = new OleDbParameter("@F_Url", OleDbType.VarChar, 200);
            parameter[2] = new OleDbParameter("@ID", OleDbType.Integer);

            parameter[0].Value = a.F_Pic;
            parameter[1].Value = a.F_Url;
            parameter[2].Value = a.ID;

            return AccessorDB.ExecuteNonQuery(sql, parameter);
        }
        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <returns></returns>
        public static List<AdModel> GetAdList()
        {
            string sql = "select * from T_AD";

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);
            List<AdModel> list = new List<AdModel>();
            AdModel a = null;
            while (dr.Read())
            {
                a = new AdModel();

                a.F_Pic = dr["F_Pic"].ToString();
                a.F_Url = dr["F_Url"].ToString();
                a.ID = Convert.ToInt32(dr["ID"]);
                list.Add(a);


            }

            dr.Close();
            dr.Dispose();
            return list;

        }

    }
}
