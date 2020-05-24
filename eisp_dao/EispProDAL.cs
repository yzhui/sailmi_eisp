using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
    public class EispProDAL
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int AddPro(ProModel p)
        {
            string sql = "insert into T_Product(F_ProName,F_Proattributes,F_ProDescription,F_ProWashing,F_ProSize,F_ProClassID,F_ProSizeTable,F_IsTop,F_Sort,F_ProPic,F_Lang,F_IsProvider,F_ProSmallPic,F_ProExtClass) values(@F_ProName,@F_Proattributes,@F_ProDescription,@F_ProWashing,@F_ProSize,@F_ProClassID,@F_ProSizeTable,@F_IsTop,@F_Sort,@F_ProPic,@F_Lang,@F_IsProvider,@F_ProSmallPic,@F_ProExtClass)";
            OleDbParameter[] parameter = new OleDbParameter[14];

            parameter[0] = new OleDbParameter("@F_ProName", OleDbType.VarChar, 50);
            parameter[1] = new OleDbParameter("@F_Proattributes", OleDbType.VarChar, 300);
            parameter[2] = new OleDbParameter("@F_ProDescription", OleDbType.VarChar);
            parameter[3] = new OleDbParameter("@F_ProWashing", OleDbType.VarChar, 250);
            parameter[4] = new OleDbParameter("@F_ProSize", OleDbType.VarChar, 200);
            parameter[5] = new OleDbParameter("@F_ProClassID", OleDbType.Integer);
            parameter[6] = new OleDbParameter("@F_ProSizeTable", OleDbType.VarChar);
            parameter[7] = new OleDbParameter("@F_IsTop", OleDbType.Boolean);
            parameter[8] = new OleDbParameter("@F_Sort", OleDbType.Integer);
            parameter[9] = new OleDbParameter("@F_ProPic", OleDbType.VarChar, 200);
            parameter[10] = new OleDbParameter("@F_Lang", OleDbType.Integer);
            parameter[11] = new OleDbParameter("@F_IsProvider", OleDbType.Boolean);
            parameter[12] = new OleDbParameter("@F_ProSmallPic", OleDbType.VarChar);
            parameter[13] = new OleDbParameter("@F_ProExtClass", OleDbType.VarChar);

            parameter[0].Value = p.F_ProName;
            parameter[1].Value = p.F_Proattributes;
            parameter[2].Value = p.F_ProDescription;
            parameter[3].Value = p.F_ProWashing;
            parameter[4].Value = p.F_ProSize;
            parameter[5].Value = p.F_ProClassID;
            parameter[6].Value = p.F_ProSizeTable;
            parameter[7].Value = p.F_IsTop;
            parameter[8].Value = p.F_Sort;
            parameter[9].Value = p.F_Pic;
            parameter[10].Value = p.F_Lang;
            parameter[11].Value = p.F_IsProvider;
            parameter[12].Value = p.F_SmallPic;
            parameter[13].Value = p.F_ExtClass;

            return AccessorDB.ExecuteInsert(sql, parameter);



        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeletePro(int id)
        {
            string sql = "delete from T_Product where ProID=?";
            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ProID", OleDbType.Integer);
            parameter[0].Value = id;


            return AccessorDB.ExecuteNonQuery(sql,parameter);


        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int UpdatePro(ProModel p)
        {

            string sql = "update T_Product set F_ProName=?,F_Proattributes=?,F_ProDescription=?,F_ProWashing=?,F_ProSize=?,F_ProClassID=?,F_ProSizeTable=?,F_IsTop=?,F_Sort=?,F_IsProvider=?,F_ProPic=?,F_ProSmallPic=?,F_ProExtClass=? where ProID=?";
            OleDbParameter[] parameter = new OleDbParameter[14];

            parameter[0] = new OleDbParameter("@F_ProName", OleDbType.VarChar, 50);
            parameter[1] = new OleDbParameter("@F_Proattributes", OleDbType.VarChar, 300);
            parameter[2] = new OleDbParameter("@F_ProDescription", OleDbType.VarChar);
            parameter[3] = new OleDbParameter("@F_ProWashing", OleDbType.VarChar, 250);
            parameter[4] = new OleDbParameter("@F_ProSize", OleDbType.VarChar, 200);
            parameter[5] = new OleDbParameter("@F_ProClassID", OleDbType.Integer);
            parameter[6] = new OleDbParameter("@F_ProSizeTable", OleDbType.VarChar);
            parameter[7] = new OleDbParameter("@F_IsTop", OleDbType.Boolean);
            parameter[8] = new OleDbParameter("@F_Sort", OleDbType.Integer);
            parameter[9] = new OleDbParameter("@F_IsProvider", OleDbType.Boolean);
            parameter[10] = new OleDbParameter("@F_ProPic", OleDbType.VarChar);
            parameter[11] = new OleDbParameter("@F_ProSmallPic", OleDbType.VarChar);
            parameter[12] = new OleDbParameter("@F_ProExtClass", OleDbType.VarChar);
            parameter[13] = new OleDbParameter("@ProID", OleDbType.Integer);
        

            parameter[0].Value = p.F_ProName;
            parameter[1].Value = p.F_Proattributes;
            parameter[2].Value = p.F_ProDescription;
            parameter[3].Value = p.F_ProWashing;
            parameter[4].Value = p.F_ProSize;
            parameter[5].Value = p.F_ProClassID;
            parameter[6].Value = p.F_ProSizeTable;
            parameter[7].Value = p.F_IsTop;
            parameter[8].Value = p.F_Sort;
            parameter[9].Value =p.F_IsProvider ;
            parameter[10].Value = p.F_Pic;
            parameter[11].Value = p.F_SmallPic;
            parameter[12].Value = p.F_ExtClass;
            parameter[13].Value = p.ProID;
      
            return AccessorDB.ExecuteNonQuery(sql, parameter);

        }
        /// <summary>
        /// 获取一条产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ProModel GetProByID(int id)
        {
            string sql = "select T_Product.*,T_ProClass.F_ClassName from T_Product,T_ProClass where T_Product.F_ProClassID = T_ProClass.ID and T_Product.ProID=?";

            OleDbParameter[] parameter = new OleDbParameter[1];

            parameter[0] = new OleDbParameter("@ProID", OleDbType.Integer);
            parameter[0].Value = id;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);

            ProModel p = new ProModel();

            if (dr.Read())
            {
                p.ProID = Convert.ToInt32(dr["ProID"]);
                p.F_ProName = dr["F_ProName"].ToString();
                p.F_Proattributes = dr["F_Proattributes"].ToString();
                p.F_ProDescription = dr["F_ProDescription"].ToString();
                p.F_ProSize = dr["F_ProSize"].ToString();
                p.F_ProSizeTable = dr["F_ProSizeTable"].ToString();
                p.F_ProWashing = dr["F_ProWashing"].ToString();
                p.F_ProClassID = Convert.ToInt32(dr["F_ProClassID"]);
                p.F_Date = Convert.ToDateTime(dr["F_Date"]);
                p.F_ClassName = dr["F_ClassName"].ToString();
                p.F_IsTop = Convert.ToBoolean(dr["F_IsTop"]);
                p.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                p.F_Pic = dr["F_ProPic"].ToString();
                p.F_IsProvider = Convert.ToBoolean(dr["F_IsProvider"]);
                p.F_ExtClass = dr["F_ProExtClass"].ToString();
                p.F_SmallPic = dr["F_ProSmallPic"].ToString();

            }

            dr.Close();
            dr.Dispose();

            return p;

        }

        /// <summary>
        /// 按类别搜索
        /// </summary>
        /// <param name="proclassid"></param>
        /// <returns></returns>
        public static List<ProModel> SearchProList(string proclassid)
        {




            string sql = "select T_Product.*,T_ProClass.F_ClassName from T_Product,T_ProClass  where T_Product.F_ProClassID = T_ProClass.ID and T_Product.F_ProClassID in(" + proclassid + ") order by  T_Product.F_Sort desc";

            List<ProModel> list = new List<ProModel>();

            ProModel p = null;

            //OleDbParameter[] parameter = new OleDbParameter[1];

            //parameter[0] = new OleDbParameter("@F_ProClassID", OleDbType.VarChar);
            //parameter[0].Value = proclassid;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

           

            while (dr.Read())
            {
                p = new ProModel();

                p.ProID = Convert.ToInt32(dr["ProID"]);
                p.F_ProName = dr["F_ProName"].ToString();
                p.F_Proattributes = dr["F_Proattributes"].ToString();
                p.F_ProDescription = dr["F_ProDescription"].ToString();
                p.F_ProSize = dr["F_ProSize"].ToString();
                p.F_ProSizeTable = dr["F_ProSizeTable"].ToString();
                p.F_ProWashing = dr["F_ProWashing"].ToString();
                p.F_ProClassID = Convert.ToInt32(dr["F_ProClassID"]);
                p.F_Date = Convert.ToDateTime(dr["F_Date"]);
                p.F_ClassName = dr["F_ClassName"].ToString();
                p.F_IsProvider = Convert.ToBoolean(dr["F_IsProvider"]);
                p.F_Pic = dr["F_ProPic"].ToString();
                p.F_ExtClass = dr["F_ProExtClass"].ToString();
                p.F_SmallPic = dr["F_ProSmallPic"].ToString();

                list.Add(p);

            }

            dr.Close();
            dr.Dispose();
            return list;


        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="number">总数</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        public static List<ProModel> GetProListPageNoByLang(int lang,int number, int pagesize)
        {

            string sql = "select  top " + pagesize + " * from( select top " + number + " T_Product.*,T_ProClass.F_ClassName from T_Product,T_ProClass where T_Product.F_Lang="+lang+"  And T_Product.F_ProClassID = T_ProClass.ID order by  T_Product.ProID asc ) order by T_Product.ProID desc";


            List<ProModel> list = new List<ProModel>();

            ProModel p = null;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

            while (dr.Read())
            {
                p = new ProModel();

                p.ProID = Convert.ToInt32(dr["ProID"]);
                p.F_ProName = dr["F_ProName"].ToString();
                p.F_Proattributes = dr["F_Proattributes"].ToString();
                p.F_ProDescription = dr["F_ProDescription"].ToString();
                p.F_ProSize = dr["F_ProSize"].ToString();
                p.F_ProSizeTable = dr["F_ProSizeTable"].ToString();
                p.F_ProWashing = dr["F_ProWashing"].ToString();
                p.F_ProClassID = Convert.ToInt32(dr["F_ProClassID"]);
                p.F_Date = Convert.ToDateTime(dr["F_Date"]);
                p.F_ClassName = dr["F_ClassName"].ToString();
                p.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                p.F_IsTop = Convert.ToBoolean(dr["F_IsTop"]);
                p.F_IsProvider = Convert.ToBoolean(dr["F_IsProvider"]);
                p.F_Pic = dr["F_ProPic"].ToString();
                p.F_ExtClass = dr["F_ProExtClass"].ToString();
                p.F_SmallPic = dr["F_ProSmallPic"].ToString();

                list.Add(p);

            }

            dr.Close();
            dr.Dispose();
            return list;

        }

        /// <summary>
        /// 获取文章记录总数
        /// </summary>
        /// <returns></returns>
        public static int GetRecordCount()
        {
            string sql = "select count(1) from T_Product";
            int res;
            res = AccessorDB.ExecuteScalar(sql);
            return res;
        }
        /// <summary>
        /// 是否存在该类产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int IsPro(int id)
        {
            string sql = "select count(1) from T_Product where F_ProClassID=?";

            OleDbParameter[] parameter = new OleDbParameter[1];
            parameter[0] = new OleDbParameter("@F_ProClassID", OleDbType.Integer);
            parameter[0].Value = id;

            return AccessorDB.ExecuteScalar(sql,parameter);

        }
        /// <summary>
        /// 根据产品类别获取产品分页功能
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pagesize"></param>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static List<ProModel> GetListPageNoByClassID(int number, int pagesize, string classid,int provider,int mainclass)
        {
            string sql = string.Empty;
            string providerstr = "false";
            if (provider == 1) providerstr = "true";
            sql = "select top " + pagesize + " * from (select top " + number + " * from T_Product where  (F_ProClassID in(" + classid + ") Or InStr(F_ProExtClass,'," + mainclass + ",')>0) And F_IsProvider=" + providerstr + " order by ProID asc)  order by ProID desc";
            List<ProModel> list = new List<ProModel>();
            ProModel p = null;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

            while (dr.Read())
            {


                p = new ProModel();

                p.ProID = Convert.ToInt32(dr["ProID"]);
                p.F_ProName = dr["F_ProName"].ToString();
                p.F_Proattributes = dr["F_Proattributes"].ToString();
                p.F_ProDescription = dr["F_ProDescription"].ToString();
                p.F_ProSize = dr["F_ProSize"].ToString();
                p.F_ProSizeTable = dr["F_ProSizeTable"].ToString();
                p.F_ProWashing = dr["F_ProWashing"].ToString();
                p.F_ProClassID = Convert.ToInt32(dr["F_ProClassID"]);
                p.F_Date = Convert.ToDateTime(dr["F_Date"]);
                p.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                p.F_IsProvider = Convert.ToBoolean(dr["F_IsProvider"]);
                p.F_Pic = dr["F_ProPic"].ToString();
                p.F_ExtClass = dr["F_ProExtClass"].ToString();
                p.F_SmallPic = dr["F_ProSmallPic"].ToString();

              //  p.F_ClassName = dr["F_ClassName"].ToString();
                p.F_IsTop = Convert.ToBoolean(dr["F_IsTop"]);
                list.Add(p);

            }

            //throw new Exception("无记录" + sql);

            dr.Close();
            dr.Dispose();
            return list;

        }
        /// <summary>
        /// 获取首页推荐产品
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<ProModel> GetTopRecommended(int count)
        {
            string sql = "select top " + count + " * from T_Product where F_IsTop=true order by F_Sort desc";

            List<ProModel> list = new List<ProModel>();

            ProModel p = null;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

            while (dr.Read())
            {
                p = new ProModel();

                p.ProID = Convert.ToInt32(dr["ProID"]);
                p.F_ProName = dr["F_ProName"].ToString();
                p.F_Proattributes = dr["F_Proattributes"].ToString();
                p.F_ProDescription = dr["F_ProDescription"].ToString();
                p.F_ProSize = dr["F_ProSize"].ToString();
                p.F_ProSizeTable = dr["F_ProSizeTable"].ToString();
                p.F_ProWashing = dr["F_ProWashing"].ToString();
                p.F_ProClassID = Convert.ToInt32(dr["F_ProClassID"]);
                p.F_Date = Convert.ToDateTime(dr["F_Date"]);
                p.F_IsTop = Convert.ToBoolean(dr["F_IsTop"]);
                p.F_IsProvider = Convert.ToBoolean(dr["F_IsProvider"]);
                p.F_SmallPic = dr["F_ProSmallPic"].ToString();
                p.F_Pic = dr["F_ProPic"].ToString();
                p.F_ExtClass = dr["F_ProExtClass"].ToString();
                //  p.F_ClassName = dr["F_ClassName"].ToString();
                p.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                list.Add(p);

            }

            dr.Close();
            dr.Dispose();
            return list;
        }

        /// <summary>
        /// 获取首页推荐产品
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<ProModel> GetTopRecommendedByLang(int lang,int count)
        {
            string sql = "select top " + count + " * from T_Product where F_IsTop=true And F_Lang="+lang+" order by F_Sort desc";

            List<ProModel> list = new List<ProModel>();

            ProModel p = null;

            OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

            while (dr.Read())
            {
                p = new ProModel();

                p.ProID = Convert.ToInt32(dr["ProID"]);
                p.F_ProName = dr["F_ProName"].ToString();
                p.F_Proattributes = dr["F_Proattributes"].ToString();
                p.F_ProDescription = dr["F_ProDescription"].ToString();
                p.F_ProSize = dr["F_ProSize"].ToString();
                p.F_ProSizeTable = dr["F_ProSizeTable"].ToString();
                p.F_ProWashing = dr["F_ProWashing"].ToString();
                p.F_ProClassID = Convert.ToInt32(dr["F_ProClassID"]);
                p.F_Date = Convert.ToDateTime(dr["F_Date"]);
                p.F_IsTop = Convert.ToBoolean(dr["F_IsTop"]);
                p.F_IsProvider = Convert.ToBoolean(dr["F_IsProvider"]);
                p.F_SmallPic = dr["F_ProSmallPic"].ToString();
                p.F_Pic = dr["F_ProPic"].ToString();
                p.F_ExtClass = dr["F_ProExtClass"].ToString();
                //  p.F_ClassName = dr["F_ClassName"].ToString();
                p.F_Sort = Convert.ToInt32(dr["F_Sort"]);
                list.Add(p);

            }

            dr.Close();
            dr.Dispose();
            return list;
        }

        public static int GetRecordCountByClassid(string classid,int provider,int mainclass)
        {
            string sql = string.Empty;
            string providerstr = "false";
            if (provider == 1) providerstr = "true";

            sql = "select count(1) from T_Product where (F_ProClassID in(" + classid + ") Or InStr(F_ProExtClass,',"+mainclass+",')>0) And F_IsProvider="+providerstr;
            //throw new Exception("无记录" + sql); 
            return AccessorDB.ExecuteScalar(sql);
        }

    }
}
