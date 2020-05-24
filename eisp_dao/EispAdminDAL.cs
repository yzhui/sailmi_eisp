using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Eisp.Common;
using Eisp.Entity;

namespace Eisp.DAL
{
   public class AdminDAL
    {
       /// <summary>
       /// 添加管理员
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public static int Add(AdminModel model)
       {
           string sql = "insert into T_Admin(F_Name,F_Pass,F_Authority) values(?,?,?)";

           OleDbParameter[] parameters = new OleDbParameter[3];
           parameters[0] = new OleDbParameter("@F_Name", OleDbType.VarChar, 12);
           parameters[0].Value = model.Name;
           parameters[1] = new OleDbParameter("@F_Pass",OleDbType.VarChar,32);
           parameters[1].Value = model.Pass;
           parameters[2] = new OleDbParameter("F_Authority",OleDbType.Integer);
           parameters[2].Value = model.Authority;

           return AccessorDB.ExecuteInsert(sql,parameters);
       }
      /// <summary>
      /// 检查用户名是否重复
      /// </summary>
      /// <param name="name"></param>
      /// <returns></returns>
       public static bool CheckEqualName(string name)
       {
           string sql = "select count(1) from T_Admin where F_Name=?";
           int res;
           OleDbParameter[] parameters = new OleDbParameter[1];
           parameters[0] = new OleDbParameter("@F_Name",OleDbType.VarChar,12);
           parameters[0].Value = name;
           res= AccessorDB.ExecuteScalar(sql,parameters);
           if(res>0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }

       public static List<AdminModel> GetAdminList()
       {
           string sql = "select * from T_Admin ";
          // OleDbParameter[] parameters = new OleDbParameter[0];
           List<AdminModel> list = new List<AdminModel>();
         OleDbDataReader dr = AccessorDB.ExecuteReader(sql);
             while(dr.Read())
              {
                  AdminModel u = new AdminModel();
                 u.UID =Convert.ToInt32( dr["ID"]);
                  u.Name = dr["F_Name"].ToString();
                  u.Pass = dr["F_Pass"].ToString();
                  u.Authority = Convert.ToInt32(dr["F_Authority"]);
                  u.Date = Convert.ToDateTime(dr["F_Date"]);
                  list.Add(u);
              }
              dr.Close();
              dr.Dispose();
              return list;
       }

       /// <summary>
       /// 修改管理员密码
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static bool UpdateAdminByID(string id,string pass)
       {
           int res;
           string sql = "update T_Admin set F_Pass=? where ID=?";
           OleDbParameter[] parameters = new OleDbParameter[2];
           parameters[0] = new OleDbParameter("@F_Pass", OleDbType.VarChar, 32);
           parameters[0].Value = pass;
           parameters[1] = new OleDbParameter("@UID",OleDbType.Integer,8 );
           parameters[1].Value =Convert.ToInt32(id);


           res = AccessorDB.ExecuteNonQuery(sql, parameters);
           if (res > 0)
           {
               return true;
           }
           else
           {
               return false;
           }

       }
       /// <summary>
       /// 删除管理员
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static bool DeleteAdminByID(string id)
       {
           int res;
           string sql = "delete from T_Admin where ID=? and F_Name<>'mygood'";
           OleDbParameter[] parameters = new OleDbParameter[1];
           parameters[0] = new OleDbParameter("@UID", OleDbType.Integer, 8);
           parameters[0].Value = Convert.ToInt32(id);


           res = AccessorDB.ExecuteNonQuery(sql, parameters);
           if (res > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       /// <summary>
       /// 获取管理员信息
       /// </summary>
       /// <param name="u"></param>
       /// <returns></returns>
       public static AdminModel GetAdminInfo(AdminModel u)
       {

           string sql = "select * from T_Admin where F_Name=? and F_Pass=?";
           OleDbParameter[] parameter = new OleDbParameter[2];

           parameter[0] = new OleDbParameter("@F_Name",OleDbType.VarChar,12);
           parameter[0].Value = u.Name;
           parameter[1] = new OleDbParameter("@F_Pass",OleDbType.VarChar,32);
           parameter[1].Value = u.Pass;

           OleDbDataReader dr = AccessorDB.ExecuteReader(sql,parameter);
           AdminModel admin = new AdminModel();
           if(dr.Read())
           {
               admin.Name = dr["F_Name"].ToString();
               admin.Pass = dr["F_Pass"].ToString();
               admin.Date = Convert.ToDateTime( dr["F_Date"]);
               admin.Authority =Convert.ToInt32(dr["F_Authority"]);
           }
           return admin;

          // dr.Close();
          // dr.Dispose();



       }

    }
}
