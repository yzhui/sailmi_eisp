using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
   public class EispEnInfoDAL
    {
       /// <summary>
       /// 获取公司简介
       /// </summary>
       /// <param name="id">查询参数</param>
       /// <returns>返回公司简介实体</returns>
       public static EnInfoModel GetEnInfoByLang(int Lang)
       {
           string sql = "select * from T_EnInfo where F_Lang=@F_Lang";
           OleDbParameter[] parameter = new OleDbParameter[1];
           parameter[0] = new OleDbParameter("@F_Lang", OleDbType.Integer);
           parameter[0].Value = Lang;

           OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);
           EnInfoModel f = null;
           if (dr.Read())
           {
               f = new EnInfoModel();
               f.ID      = Convert.ToInt32(dr["ID"]);
               f.EnName = dr["F_EnName"].ToString();
               f.EnAddr = dr["F_EnAddr"].ToString();
               f.Lang = Convert.ToInt32(dr["F_Lang"].ToString());
               f.EnContact = dr["F_EnContact"].ToString();
               f.EnKeywords = dr["F_Keywords"].ToString();
               f.EnDesc = dr["F_EnDesc"].ToString();
               f.EnDetail = dr["F_EnContent"].ToString();
               f.EnOnlineContact = dr["F_EnOnline"].ToString();
           }
           dr.Close();
           dr.Dispose();
           return f;
       }


       public static int UpdateEnInfoByID(EnInfoModel f)
       {

           string sql = "update T_EnInfo set F_EnName=@F_EnName,F_EnAddr=@F_EnAddr,F_Lang=@F_Lang,F_EnContact=@F_EnContact,F_Keywords=@F_Keywords,F_EnDesc=@F_EnDesc,F_EnContent=@F_EnContent,F_EnOnline=@F_EnOnline where ID=@ID";
           OleDbParameter[] parameter = new OleDbParameter[8];
           parameter[0] = new OleDbParameter("@F_EnName", OleDbType.VarChar);
           parameter[0].Value = f.EnName;
           parameter[1] = new OleDbParameter("@F_EnAddr", OleDbType.VarChar);
           parameter[1].Value = f.EnAddr;
           parameter[2] = new OleDbParameter("@F_Lang", OleDbType.Integer);
           parameter[2].Value = f.Lang;
           parameter[3] = new OleDbParameter("@F_EnContact", OleDbType.VarChar);
           parameter[3].Value = f.EnContact;
           parameter[4] = new OleDbParameter("@F_Keywords", OleDbType.VarChar);
           parameter[4].Value = f.EnKeywords;
           parameter[5] = new OleDbParameter("@F_EnDesc", OleDbType.VarChar);
           parameter[5].Value = f.EnDesc;
           parameter[6] = new OleDbParameter("@F_EnContent", OleDbType.VarChar);
           parameter[6].Value = f.EnDetail;
           parameter[7] = new OleDbParameter("@F_EnOnline", OleDbType.VarChar);
           parameter[7].Value = f.EnOnlineContact;
           parameter[8] = new OleDbParameter("@ID", OleDbType.Integer);
           parameter[8].Value = f.ID;
           return AccessorDB.ExecuteNonQuery(sql, parameter);

       }
       public static int UpdateEnInfoByLang(EnInfoModel f)
       {
           try {
               string sql = "update T_EnInfo set F_EnName=@F_EnName,F_EnAddr=@F_EnAddr,F_EnContact=@F_EnContact,F_Keywords=@F_Keywords,F_EnDesc=@F_EnDesc,F_EnContent=@F_EnContent,F_EnOnline=@F_EnOnline where F_Lang=@F_Lang";
               OleDbParameter[] parameter = new OleDbParameter[8];
               parameter[0] = new OleDbParameter("@F_EnName", OleDbType.VarChar);
               parameter[0].Value = f.EnName;
               parameter[1] = new OleDbParameter("@F_EnAddr", OleDbType.VarChar);
               parameter[1].Value = f.EnAddr;
               parameter[2] = new OleDbParameter("@F_EnContact", OleDbType.VarChar);
               parameter[2].Value = f.EnContact;
               parameter[3] = new OleDbParameter("@F_Keywords", OleDbType.VarChar);
               parameter[3].Value = f.EnKeywords;
               parameter[4] = new OleDbParameter("@F_EnDesc", OleDbType.VarChar);
               parameter[4].Value = f.EnDesc;
               parameter[5] = new OleDbParameter("@F_EnContent", OleDbType.VarChar);
               parameter[5].Value = f.EnDetail;
               parameter[6] = new OleDbParameter("@F_EnOnline", OleDbType.VarChar);
               parameter[6].Value = f.EnOnlineContact;
               parameter[7] = new OleDbParameter("@F_Lang", OleDbType.Integer);
               parameter[7].Value = f.Lang;

               return AccessorDB.ExecuteNonQuery(sql, parameter);
           }catch(Exception es){
               throw new Exception(es.Message+f.EnName+","+f.EnAddr+","+f.EnContact+","+f.EnDesc+","+f.EnKeywords+","+f.Lang+","+f.ID);
           }

       }
       public static int AddEnInfo(EnInfoModel f)
       {
           string sql = "insert into T_EnInfo(F_EnName,F_EnAddr,F_Lang,F_EnContact,F_Keywords,F_EnDesc,F_EnContent,F_EnOnline) values(@F_EnName,@F_EnAddr,@F_Lang,@F_EnContact,@F_Keywords,@F_EnDesc,@F_EnContent,@F_EnOnline)";
           OleDbParameter[] parameter = new OleDbParameter[8];
           parameter[0] = new OleDbParameter("@F_EnName", OleDbType.VarChar);
           parameter[0].Value = f.EnName;
           parameter[1] = new OleDbParameter("@F_EnAddr", OleDbType.VarChar);
           parameter[1].Value = f.EnAddr;
           parameter[2] = new OleDbParameter("@F_Lang", OleDbType.Integer);
           parameter[2].Value = f.Lang;
           parameter[3] = new OleDbParameter("@F_EnContact", OleDbType.VarChar);
           parameter[3].Value = f.EnContact;
           parameter[4] = new OleDbParameter("@F_Keywords", OleDbType.VarChar);
           parameter[4].Value = f.EnKeywords;
           parameter[5] = new OleDbParameter("@F_EnDesc", OleDbType.VarChar);
           parameter[5].Value = f.EnDesc;
           parameter[6] = new OleDbParameter("@F_EnContent", OleDbType.VarChar);
           parameter[6].Value = f.EnDetail;
           parameter[7] = new OleDbParameter("@F_EnOnline", OleDbType.VarChar);
           parameter[7].Value = f.EnOnlineContact;

           return AccessorDB.ExecuteNonQuery(sql, parameter);

       }

    }
}
