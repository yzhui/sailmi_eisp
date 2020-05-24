using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;
using System.Data.SqlClient;

namespace Eisp.DAL
{
    public class EispNewsDAL
    {
        /// <summary>
        /// 新闻添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int AddNew(NewsModel a)
        {

            string sql = "insert into T_News(F_Title,F_Content,F_Location,F_ParentID,F_Keywords,F_Lang) values(@F_Title,@F_Content,@F_Location,@F_ParentID,@F_Keyword,@F_Lang)";

            OleDbParameter[] parameter = new OleDbParameter[6];

            parameter[0] = new OleDbParameter("@F_Title", OleDbType.VarChar, 100);
            parameter[1] = new OleDbParameter("@F_Content", OleDbType.VarChar, 8000);
            parameter[2] = new OleDbParameter("@F_Location", OleDbType.VarChar, 50);
            parameter[3] = new OleDbParameter("@F_ParentID",OleDbType.Integer);
            parameter[4] = new OleDbParameter("@F_Keyword", OleDbType.VarChar,500);
            parameter[5] = new OleDbParameter("@F_Lang", OleDbType.Integer);

            parameter[0].Value = a.F_Title;
            parameter[1].Value = a.F_Content;
            parameter[2].Value = a.F_Location;
            parameter[3].Value = a.F_ParentID;
            parameter[4].Value = a.F_Keyword;
            parameter[5].Value = a.F_Lang;

            return AccessorDB.ExecuteNonQuery(sql, parameter);

        }
        /// <summary>
        /// 更新新闻
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int UpdateNewByID(NewsModel a)
        {

            string sql = "update T_News set F_Title=?,F_Content=?,F_Location=?,F_ParentID=? where ID=?";

            OleDbParameter[] parameter = new OleDbParameter[5];

            parameter[0] = new OleDbParameter("@F_Title", OleDbType.VarChar, 100);
            parameter[1] = new OleDbParameter("@F_Content", OleDbType.VarChar, 8000);
            parameter[2] = new OleDbParameter("@F_Location", OleDbType.VarChar, 50);
            parameter[3] = new OleDbParameter("@F_ParentID", OleDbType.Integer);
            parameter[4] = new OleDbParameter("@ID", OleDbType.Integer);

            parameter[0].Value = a.F_Title;
            parameter[1].Value = a.F_Content;
            parameter[2].Value = a.F_Location;
            parameter[3].Value = a.F_ParentID;
            parameter[4].Value = a.ID;

            return AccessorDB.ExecuteNonQuery(sql, parameter);


        }
        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteNewByID(int id)
        {
            string sql = "delete from T_News where ID=?";

            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
            parameter[0].Value = id;

            return AccessorDB.ExecuteNonQuery(sql, parameter);

        }
        /// <summary>
        /// 获取一条新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NewsModel GetNewsByID(int id)
        {
            string sql = "select t1.ID,t1.F_Title,t1.F_Content,t1.F_Date,t1.F_Location,t1.F_ParentID,t1.F_Keywords,t2.F_ClassName from T_News t1,T_NewsClass t2 where t1.F_ParentID=t2.ID And t1.ID=?";
            //throw new Exception(sql);
            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
            parameter[0].Value = id;

            NewsModel a = new NewsModel();

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);

            if (dr.Read())
            {
                a.ID = Convert.ToInt32(dr["ID"]);
                a.F_Title = dr["F_Title"].ToString();
                a.F_Content = dr["F_Content"].ToString();
                a.F_Date = Convert.ToDateTime(dr["F_Date"]);
                a.F_Location = dr["F_Location"].ToString();
                a.F_ParentID = Convert.ToInt32(dr["F_ParentID"]);
                a.F_Keyword = dr["F_Keywords"].ToString();
                a.F_ClassName = dr["F_ClassName"].ToString();
            }

            dr.Close();
            dr.Dispose();

            return a;
        }
        /// <summary>
        /// 获取新闻列表分页
        /// </summary>
        /// <param name="number">总数</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        public static List<NewsModel> GetArticleListPageNo(int number, int pagesize, int classid)
        {
            string sqlpage = "";

            if (classid == 0)
            {
                sqlpage = "select top " + pagesize + " * from (select top " + number + " * from [T_News] order by ID asc)  order by ID desc ";
            }
            else
            {
                sqlpage = "select top " + pagesize + " * from (select top " + number + " * from [T_News] where F_ParentID=" + classid + "  order by ID asc)  order by ID desc ";
            }



            List<NewsModel> list = new List<NewsModel>();

            OleDbDataReader dr = AccessorDB.ExecuteReader(sqlpage);

            NewsModel a = null;

            while (dr.Read())
            {
                a = new NewsModel();
                a.ID = Convert.ToInt32(dr["ID"]);
                a.F_Title = dr["F_Title"].ToString();
                a.F_Content = dr["F_Content"].ToString();
                a.F_Date = Convert.ToDateTime(dr["F_Date"]);
                a.F_Location = dr["F_Location"].ToString();
                a.F_ParentID = Convert.ToInt32(dr["F_ParentID"]);
                list.Add(a);
            }

            dr.Close();
            dr.Dispose();

            return list;


        }
        /// <summary>
        /// 获取新闻列表分页
        /// </summary>
        /// <param name="number">总数</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        public static List<NewsModel> GetArticleListPageNoByLang(int lang,int number, int pagesize, int classid)
        {
            string sqlpage = "";

            if (classid == -1)
            {
                sqlpage = "select top " + pagesize + " * from (select top " + number + " * from [T_News] where F_Lang="+lang+" order by ID asc)  order by ID desc ";
            }
            else
            {
                sqlpage = "select top " + pagesize + " * from (select top " + number + " * from [T_News] where F_Lang=" + lang + " And F_ParentID=" + classid + "  order by ID asc)  order by ID desc ";
            }



            List<NewsModel> list = new List<NewsModel>();

            OleDbDataReader dr = AccessorDB.ExecuteReader(sqlpage);

            NewsModel a = null;

            while (dr.Read())
            {
                a = new NewsModel();
                a.ID = Convert.ToInt32(dr["ID"]);
                a.F_Title = dr["F_Title"].ToString();
                a.F_Content = dr["F_Content"].ToString();
                a.F_Date = Convert.ToDateTime(dr["F_Date"]);
                a.F_Location = dr["F_Location"].ToString();
                a.F_ParentID = Convert.ToInt32(dr["F_ParentID"]);
                list.Add(a);
            }
            dr.Close();
            dr.Dispose();

            return list;


        }
        /// <summary>
        /// 获取文章记录总数
        /// </summary>
        /// <returns></returns>
        public static int GetRecordCountByLang(int lang)
        {
            string sql = "select count(1) from T_News where F_Lang="+lang;
            int res;
            res = AccessorDB.ExecuteScalar(sql);
            return res;
        }

        public static int GetRecordCountByClassid(int classid)
        {
            string sql = "select count(1) from T_News where F_ParentID="+classid;
            int res;
            res = AccessorDB.ExecuteScalar(sql);
            return res;
        }

        public static int GetRecordCountByClassidByLang(int lang,int classid)
        {
            string sql = "select count(1) from T_News where F_ParentID=" + classid+" And F_Lang="+lang;
            if (classid == -1)
            {
                sql = "select count(1) from T_News where  F_Lang=" + lang;
            }
            else {
                sql = "select count(1) from T_News where F_ParentID=" + classid + " And F_Lang=" + lang;
            }
            int res;
            res = AccessorDB.ExecuteScalar(sql);
            return res;
        }
        public static DataTable GetNewTop(int count)
        {
            string sql = "select top " + count + " * from T_News order by ID desc";

            return AccessorDB.ExecuteQuery(sql).Tables[0];
        }
        public static DataTable GetNewTopByLang(int lang,int count)
        {
            string sql = "select top " + count + " * from T_News Where F_Lang="+lang+" order by ID desc";

            return AccessorDB.ExecuteQuery(sql).Tables[0];
        }
    }
}
