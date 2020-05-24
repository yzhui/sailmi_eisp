using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
    public class EispNewsClassDAL
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0失败，1成功</returns>
        public static int AddNewsClass(NewsClassModel t)
        {
            string sql = "insert into T_NewsClass(F_ClassName,F_ParentID,F_Sort,F_Lang) values(@F_ClassName,@F_ParentID,@F_Sort,@F_Lang)";

            OleDbParameter[] parameter = new OleDbParameter[4];

            parameter[0] = new OleDbParameter("@F_ClassName", OleDbType.VarChar, 50);
            parameter[1] = new OleDbParameter("@F_ParentID", OleDbType.Integer);
            parameter[2] = new OleDbParameter("@F_Sort", OleDbType.Integer);
            parameter[3] = new OleDbParameter("@F_Sort", OleDbType.Integer);
            parameter[0].Value = t.F_ClassName;
            parameter[1].Value = t.F_ParentID;
            parameter[2].Value = t.F_Sort;
            parameter[3].Value = t.F_Lang;

            return AccessorDB.ExecuteNonQuery(sql, parameter);

        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="n"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateNewsClass(string n, int id)
        {

            string sql = "update T_NewsClass set F_ClassName=? where ID=?";

            OleDbParameter[] parameter = new OleDbParameter[2];

            parameter[0] = new OleDbParameter("@F_ClassName", OleDbType.VarChar, 50);
            parameter[1] = new OleDbParameter("@ID", OleDbType.Integer);

            parameter[0].Value = n;
            parameter[1].Value = id;


            return AccessorDB.ExecuteNonQuery(sql, parameter);


        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteNewsClass(int id)
        {
            string sql = "delete from T_NewsClass where ID=?";

            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
            parameter[0].Value = id;

            return AccessorDB.ExecuteNonQuery(sql, parameter);


        }

        /// <summary>
        /// 获取类别
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public static List<NewsClassModel> GetNewsClassListByLang(int lang,int parentid)
        {
            string sql = "select * from T_NewsClass where F_ParentID = ? And F_Lang=? order by F_Sort desc";
            OleDbParameter[] parameter = new OleDbParameter[2];

            parameter[0] = new OleDbParameter("@F_ParentID", OleDbType.Integer);
            parameter[0].Value = parentid;
            parameter[1] = new OleDbParameter("@F_ParentID", OleDbType.Integer);
            parameter[1].Value = lang;

            List<NewsClassModel> list = new List<NewsClassModel>();

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);

            NewsClassModel proclass = null;
            while (dr.Read())
            {
                proclass = new NewsClassModel();

                proclass.ID = Convert.ToInt32(dr["ID"].ToString());
                proclass.F_ClassName = dr["F_ClassName"].ToString();
                proclass.F_ParentID = Convert.ToInt32(dr["F_ParentID"]);
                proclass.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                list.Add(proclass);

            }

         

            dr.Close();
            dr.Dispose();
            return list;

        }

        public static List<NewsClassModel> GetNewsClassList(int parentid)
        {
            string sql = "select * from T_NewsClass where F_ParentID = ? order by F_Sort desc";
            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@F_ParentID", OleDbType.Integer);
            parameter[0].Value = parentid;

            List<NewsClassModel> list = new List<NewsClassModel>();

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);

            NewsClassModel proclass = null;
            while (dr.Read())
            {
                proclass = new NewsClassModel();

                proclass.ID = Convert.ToInt32(dr["ID"].ToString());
                proclass.F_ClassName = dr["F_ClassName"].ToString();
                proclass.F_ParentID = Convert.ToInt32(dr["F_ParentID"]);
                proclass.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                list.Add(proclass);

            }



            dr.Close();
            dr.Dispose();
            return list;

        }

        /// <summary>
        /// 降序升序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int UPSort(int id,int type)
        {
            string sql = string.Empty;

            if(type==0)
            {
                sql = "update T_NewsClass set F_Sort=F_Sort+1 where ID=?";
            }
            else
            {
                sql = "update T_NewsClass set F_Sort=F_Sort-1 where ID=?";
            }


            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
            parameter[0].Value = id;

            return AccessorDB.ExecuteNonQuery(sql, parameter);


        }
        /// <summary>
        /// 是否有子类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IsSub(int id)
        {
            string sql = "select count(*) from T_NewsClass where F_ParentID=?";

            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@F_ParentID", OleDbType.Integer);
            parameter[0].Value = id;

            return AccessorDB.ExecuteScalar(sql, parameter);
        }

        public static NewsClassModel GetParentName(int parentid)
        {
            string sql = "select * from T_NewsClass where ID=?";

            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
            parameter[0].Value = parentid;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql,parameter);

            NewsClassModel proclass = null;
            if (dr.Read())
            {
                proclass = new NewsClassModel();

                proclass.ID = Convert.ToInt32(dr["ID"].ToString());
                proclass.F_ClassName = dr["F_ClassName"].ToString();
                proclass.F_ParentID = Convert.ToInt32(dr["F_ParentID"]);
                proclass.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                

            }
            dr.Close();
            dr.Dispose();

            return proclass;

        }

    }
}
