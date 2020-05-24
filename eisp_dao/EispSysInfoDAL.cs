using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
   public class EispSysInfoDAL
    {
       /// <summary>
       /// 获取公司简介
       /// </summary>
       /// <param name="id">查询参数</param>
       /// <returns>返回公司简介实体</returns>
       public static SysInfoModel GetSysInfoByID(int id)
       {
           string sql = "select * from T_SysInfo where ID=@ID";
           OleDbParameter[] parameter = new OleDbParameter[1];
           parameter[0] = new OleDbParameter("@ID", OleDbType.Integer);
           parameter[0].Value = id;

           OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);
           SysInfoModel f = new SysInfoModel();
           if (dr.Read())
           {
               f.ID      = Convert.ToInt32(dr["ID"]);
               f.Content = dr["F_Content"].ToString();
               f.InfoType = Convert.ToInt32(dr["F_InfoType"].ToString());
               f.Lang = Convert.ToInt32(dr["F_Lang"].ToString());
               f.Title = dr["F_InfoTitle"].ToString();
           }
           dr.Close();
           dr.Dispose();
           return f;
       }

       public static SysInfoModel GetSysInfoByType(int type,int lang)
       {
           string sql = "select * from T_SysInfo where F_InfoType=@InfoType And F_Lang=@Lang";
           OleDbParameter[] parameter = new OleDbParameter[2];
           parameter[0] = new OleDbParameter("@InfoType", OleDbType.Integer);
           parameter[1] = new OleDbParameter("@Lang", OleDbType.Integer);
           parameter[0].Value = type;
           parameter[1].Value = lang;

           OleDbDataReader dr = AccessorDB.ExecuteReader(sql, parameter);
           SysInfoModel f = new SysInfoModel();
           if (dr.Read())
           {
               f.ID = Convert.ToInt32(dr["ID"]);
               f.Content = dr["F_Content"].ToString();
               f.InfoType = Convert.ToInt32(dr["F_InfoType"].ToString());
               f.Lang = Convert.ToInt32(dr["F_Lang"].ToString());
               f.Title = dr["F_InfoTitile"].ToString();
           }
           dr.Close();
           dr.Dispose();
           return f;
       }

       public static int UpdateSysInfoByID(SysInfoModel f)
       {

           string sql = "update T_SysInfo set F_Content=@F_Content,F_InfoType=@F_InfoType,F_Lang=@F_Lang,F_InfoTitle=@F_Title where ID=@ID";
           OleDbParameter[] parameter = new OleDbParameter[5];
           parameter[0] = new OleDbParameter("@F_Content",OleDbType.VarChar);
           parameter[0].Value = f.Content;
           parameter[1] = new OleDbParameter("@ID",OleDbType.Integer);
           parameter[1].Value = f.ID;
           parameter[2] = new OleDbParameter("@F_InfoType", OleDbType.Integer);
           parameter[2].Value = f.InfoType;
           parameter[3] = new OleDbParameter("@F_Lang", OleDbType.Integer);
           parameter[3].Value = f.Lang;
           parameter[4] = new OleDbParameter("@F_Title", OleDbType.VarChar);
           parameter[4].Value = f.Title;
           return AccessorDB.ExecuteNonQuery(sql, parameter);

       }
       public static int AddSysInfo(SysInfoModel f)
       {
           string sql = "insert into T_SysInfo(F_Content,F_InfoType,F_Lang,F_InfoTitle) values(@F_Content,@F_InfoType,@F_Lang,@F_Title)";
           OleDbParameter[] parameter = new OleDbParameter[4];
           parameter[0] = new OleDbParameter("@F_Content", OleDbType.VarChar);
           parameter[0].Value = f.Content;
           parameter[2] = new OleDbParameter("@F_InfoType", OleDbType.Integer);
           parameter[2].Value = f.InfoType;
           parameter[3] = new OleDbParameter("@F_Lang", OleDbType.Integer);
           parameter[3].Value = f.Lang;
           parameter[4] = new OleDbParameter("@F_Title", OleDbType.VarChar);
           parameter[4].Value = f.Title;
           return AccessorDB.ExecuteNonQuery(sql, parameter);

       }

    }
}
