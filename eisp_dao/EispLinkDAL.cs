using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
  public  class EispLinkDAL
    {
      /// <summary>
      /// 添加
      /// </summary>
      /// <param name="l"></param>
      /// <returns></returns>
      public static int AddLink(LinkModel l)
      {

          string sql = "insert into T_Link(F_LinkName,F_LinkUrl) values(?,?)";

          OleDbParameter[] parameter = new OleDbParameter[2];
          parameter[0] = new OleDbParameter("@F_LinkName", OleDbType.VarChar, 50);
          parameter[1] = new OleDbParameter("@F_LinkUrl", OleDbType.VarChar, 50);
          parameter[0].Value = l.F_LinkName;
          parameter[1].Value = l.F_LinkUrl;

          return AccessorDB.ExecuteNonQuery(sql,parameter);

      }

      /// <summary>
      /// 更新
      /// </summary>
      /// <param name="l"></param>
      /// <returns></returns>
      public static int UpdateLink(LinkModel l)
      {
          string sql = "update T_Link set F_LinkName=?,F_LinkUrl=? where ID=?";


          OleDbParameter[] parameter = new OleDbParameter[3];
          parameter[0] = new OleDbParameter("@F_LinkName", OleDbType.VarChar, 50);
          parameter[1] = new OleDbParameter("@F_LinkUrl", OleDbType.VarChar, 50);
          parameter[2] = new OleDbParameter("@ID",OleDbType.Integer);
          parameter[0].Value = l.F_LinkName;
          parameter[1].Value = l.F_LinkUrl;
          parameter[2].Value = l.ID;

          return AccessorDB.ExecuteNonQuery(sql, parameter);


      }
      /// <summary>
      /// 删除
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int DeleteLink(int id)
      {
          string sql = "delete from T_Link where ID=?";

          OleDbParameter[] parameter = new OleDbParameter[1];
          parameter[0] = new OleDbParameter("@ID",OleDbType.Integer);
          parameter[0].Value = id;

          return AccessorDB.ExecuteNonQuery(sql, parameter);
               
      }
      /// <summary>
      /// 获取
      /// </summary>
      /// <returns></returns>
      public static List<LinkModel> GetLinkList()
      {
          string sql = "select * from T_Link";

          OleDbDataReader dr = AccessorDB.ExecuteReader(sql);
          List<LinkModel> list = new List<LinkModel>();
          LinkModel l = null;
          while(dr.Read())
          {
              l = new LinkModel();
              l.ID = Convert.ToInt32(dr["ID"]);
              l.F_LinkName = dr["F_LinkName"].ToString();
              l.F_LinkUrl = dr["F_LinkUrl"].ToString();
              list.Add(l);
             
          }
          dr.Close();
          dr.Dispose();
          return list;

      }

    }
}
