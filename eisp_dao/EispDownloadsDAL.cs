using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
  public  class EispDownloadsDAL
    {

      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="s"></param>
      /// <returns></returns>
      public static int ADD(DownloadsModel s)
      {

          string sql = "insert into T_Downloads(F_FileType,F_Content,F_Size,F_Desc,F_Keywords,F_Lang,F_Title,F_FileImage,F_FileSmallImage) values(?,?,?,?,?,?,?,?,?)";

          OleDbParameter[] parameter = new OleDbParameter[9];

          parameter[0] = new OleDbParameter("@F_FileType", OleDbType.Integer);
          parameter[1] = new OleDbParameter("@F_Content", OleDbType.VarChar);
          parameter[2] = new OleDbParameter("@F_Size", OleDbType.VarChar, 200);
          parameter[3] = new OleDbParameter("@F_Desc", OleDbType.VarChar, 500);
          parameter[4] = new OleDbParameter("@F_Keywords", OleDbType.VarChar);
          parameter[5] = new OleDbParameter("@F_Lang", OleDbType.Integer);
          parameter[6] = new OleDbParameter("@F_Title", OleDbType.VarChar);
          parameter[7] = new OleDbParameter("@F_FileImage", OleDbType.VarChar);
          parameter[8] = new OleDbParameter("@F_FileSmallImage", OleDbType.VarChar);

          parameter[0].Value = s.F_FileType;
          parameter[1].Value = s.F_Content;
          parameter[2].Value = s.F_Size;
          parameter[3].Value = s.F_Desc;
          parameter[4].Value = s.F_Keywords;
          parameter[5].Value = s.F_Lang;
          parameter[6].Value = s.F_Title;
          parameter[7].Value = s.F_FileImage;
          parameter[8].Value = s.F_FileSmallImage;



          return AccessorDB.ExecuteNonQuery(sql, parameter);

      }

      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int Delete(int id)
      {
          string sql = "delete from T_Downloads where ID=?";

          OleDbParameter[] parameter = new OleDbParameter[1];

          parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
          parameter[0].Value = id;

          return AccessorDB.ExecuteNonQuery(sql, parameter);
      }


      /// <summary>
      /// 获取1条信息资料
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static DownloadsModel GetDownLoadsByID(int downid)
      {

          string sql = "select * from T_Downloads where ID=?";

          OleDbParameter[] parameter = new OleDbParameter[1];

          parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
          parameter[0].Value = downid;

          OleDbDataReader dr = AccessorDB.ExecuteReader(sql,parameter);

          DownloadsModel s = new DownloadsModel();
          if(dr.Read())
          {
              s.F_Size = dr["F_Size"].ToString();
              s.F_Desc= dr["F_Desc"].ToString();
              s.F_Keywords = dr["F_Keywords"].ToString();
              s.F_Content = dr["F_Content"].ToString();
              s.F_FileType = Convert.ToInt32(dr["F_FileType"]);
              s.F_Date = Convert.ToDateTime(dr["F_Date"]);
              s.ID = Convert.ToInt32(dr["ID"]);
              s.F_Title = dr["F_Title"].ToString();
              s.F_FileImage = dr["F_FileImage"].ToString();
              s.F_FileSmallImage = dr["F_FileSmallImage"].ToString();

          }

          dr.Close();
          dr.Dispose();

          return s;

      }

      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="s"></param>
      /// <returns></returns>
      public static int UpdateByid(DownloadsModel s)
      {
          string sql = "update T_Downloads set F_FileType=?,F_Content=?,F_Size=?,F_Desc=?,F_Keywords=?,F_Title=?,F_FileImage=?,F_FileSmallImage=? where ID=?";

          OleDbParameter[] parameter = new OleDbParameter[9];

          parameter[0] = new OleDbParameter("@F_FileType", OleDbType.Integer);
          parameter[1] = new OleDbParameter("@F_Content", OleDbType.VarChar);
          parameter[2] = new OleDbParameter("@F_Size", OleDbType.VarChar, 200);
          parameter[3] = new OleDbParameter("@F_Desc", OleDbType.VarChar, 500);
          parameter[4] = new OleDbParameter("@F_Keywords", OleDbType.VarChar);
          parameter[5] = new OleDbParameter("@F_Title", OleDbType.VarChar);
          parameter[6] = new OleDbParameter("@F_FileImage", OleDbType.VarChar);
          parameter[7] = new OleDbParameter("@F_FileSmallImage", OleDbType.VarChar);
          parameter[8] = new OleDbParameter("@ID", OleDbType.Integer);

          parameter[0].Value = s.F_FileType;
          parameter[1].Value = s.F_Content;
          parameter[2].Value = s.F_Size;
          parameter[3].Value = s.F_Desc;
          parameter[4].Value = s.F_Keywords;
          parameter[5].Value = s.F_Title;
          parameter[6].Value = s.F_FileImage;
          parameter[7].Value = s.F_FileSmallImage;
          parameter[8].Value = s.ID;

          return AccessorDB.ExecuteNonQuery(sql, parameter);

      }
      /// <summary>
      /// 获取所有销售网络数据
      /// </summary>
      /// <returns></returns>
      public static List<DownloadsModel> GetDownloadsListByLang(int lang,int number, int pagesize)
      {
          if (number == 0)
              number = 1;
          string sql = "select top " + pagesize + " * from (select top " + number + " * from T_Downloads where F_Lang="+lang+" order by ID asc) order by ID desc";

          List<DownloadsModel> list = new List<DownloadsModel>();

          DownloadsModel s = null;

          OleDbDataReader dr = AccessorDB.ExecuteReader(sql);

          while(dr.Read())
          {
              s = new DownloadsModel();
              s.F_Size = dr["F_Size"].ToString();
              s.F_Desc = dr["F_Desc"].ToString();
              s.F_Keywords = dr["F_Keywords"].ToString();
              s.F_Content = dr["F_Content"].ToString();
              s.F_FileType = Convert.ToInt32(dr["F_FileType"]);
              s.F_Date = Convert.ToDateTime(dr["F_Date"]);
              s.ID = Convert.ToInt32(dr["ID"]);
              s.F_Title = dr["F_Title"].ToString();
              s.F_FileImage = dr["F_FileImage"].ToString();
              s.F_FileSmallImage = dr["F_FileSmallImage"].ToString();

              list.Add(s);
          }

          dr.Close();
          dr.Dispose();
          return list;
      }
      /// <summary>
      /// 是否有
      /// </summary>
      /// <param name="regionid"></param>
      /// <returns>true:有，false:没有</returns>
      public static Boolean IsHave(string regionid)
      {
          string sql = "select count(1) from T_Downloads where F_Content=?";

          OleDbParameter[] parameter = new OleDbParameter[1];

          parameter[0] = new OleDbParameter("@F_Content", OleDbType.VarChar);
          parameter[0].Value = regionid;

          int res = AccessorDB.ExecuteScalar(sql,parameter);

          if(res>0)
          {
              return true;
          }
          else
          {
              return false;
          }

      }
      /// <summary>
      /// 获取文章记录总数
      /// </summary>
      /// <returns></returns>
      public static int GetRecordCountByLang(int lang)
      {
          string sql = "select count(1) from T_Downloads where F_Lang="+lang;
          int res;
          res = AccessorDB.ExecuteScalar(sql);
          return res;
      }

    }
}
