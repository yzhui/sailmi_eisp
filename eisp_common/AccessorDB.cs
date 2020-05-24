using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
namespace Eisp.Common
{
   public class AccessorDB
    {
       private static String connectionString = ConfigurationManager.AppSettings["OLEDBCONNECTIONSTRING"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbPath"]);
       public AccessorDB() { }

       //public static OleDbConnection Access()
       //{
       //    return new OleDbConnection(ConfigurationManager.AppSettings["OLEDBCONNECTIONSTRING"].ToString() + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["dbPath"]));
       //}

       //ִ�е���������䣬������id������Ҫ����id����ExceuteNonQueryִ�С�
       public static int ExecuteInsert(string sql, OleDbParameter[] parameters)
       {
           //Debug.WriteLine(sql);
           using (OleDbConnection connection = new OleDbConnection(connectionString))
           {
               OleDbCommand cmd = new OleDbCommand(sql, connection);
               try
               {
                   connection.Open();
                   if (parameters != null) cmd.Parameters.AddRange(parameters);
                   cmd.ExecuteNonQuery();
                   
                   cmd.CommandText = @"select @@identity";
                   int value = Int32.Parse(cmd.ExecuteScalar().ToString());
                   return value;
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
       }
       public static int ExecuteInsert(string sql)
       {
           return ExecuteInsert(sql, null);
       }

       //ִ�д�������sql���,����Ӱ��ļ�¼����insert,update,delete)
       public static int    ExecuteNonQuery(string sql, OleDbParameter[] parameters)
       {
           //Debug.WriteLine(sql);
           using (OleDbConnection connection = new OleDbConnection(connectionString))
           {
               OleDbCommand cmd = new OleDbCommand(sql, connection);
               try
               {
                   connection.Open();
                   if (parameters != null) cmd.Parameters.AddRange(parameters);
                   int rows = cmd.ExecuteNonQuery();
                   
                   return rows;
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
       }
       //ִ�в���������sql��䣬����Ӱ��ļ�¼��
       //������ʹ��ƴ����SQL
       public static int ExecuteNonQuery(string sql)
       {
           return ExecuteNonQuery(sql, null);
       }

       //ִ�е�����䷵�ص�һ�е�һ��,������������count(*)
       public static int ExecuteScalar(string sql, OleDbParameter[] parameters)
       {
           //Debug.WriteLine(sql);
           using (OleDbConnection connection = new OleDbConnection(connectionString))
           {
               OleDbCommand cmd = new OleDbCommand(sql, connection);
               try
               {
                   connection.Open();
                   if (parameters != null) cmd.Parameters.AddRange(parameters);
                   int value = Int32.Parse(cmd.ExecuteScalar().ToString());
                   
                   return value;
               }
               catch (Exception e)
               {
                   throw e;
               }
           }
       }
       public static int ExecuteScalar(string sql)
       {
           return ExecuteScalar(sql, null);
       }

       //ִ������
       public static void ExecuteTrans(List<string> sqlList, List<OleDbParameter[]> paraList)
       {
           //Debug.WriteLine(sql);
           using (OleDbConnection connection = new OleDbConnection(connectionString))
           {
               OleDbCommand cmd = new OleDbCommand();
               OleDbTransaction transaction = null;
               cmd.Connection = connection;
               try
               {
                   connection.Open();
                   transaction = connection.BeginTransaction();
                   cmd.Transaction = transaction;

                   for (int i = 0; i < sqlList.Count; i++)
                   {
                       cmd.CommandText = sqlList[i];
                       if (paraList != null && paraList[i] != null)
                       {
                           
                           cmd.Parameters.AddRange(paraList[i]);
                       }
                       cmd.ExecuteNonQuery();
                   }
                   transaction.Commit();

               }
               catch (Exception e)
               {
                   try
                   {
                       transaction.Rollback();
                   }
                   catch
                   {

                   }
                   
                   throw e;
               }

           }
       }
       public static void ExecuteTrans(List<string> sqlList)
       {
           ExecuteTrans(sqlList, null);
       }

       //ִ�в�ѯ��䣬����dataset
       public static DataSet ExecuteQuery(string sql, OleDbParameter[] parameters)
       {
           //Debug.WriteLine(sql);
           using (OleDbConnection connection = new OleDbConnection(connectionString))
           {
               DataSet ds = new DataSet();
               try
               {
                   connection.Open();

                   OleDbDataAdapter da = new OleDbDataAdapter(sql, connection);
                   if (parameters != null) da.SelectCommand.Parameters.AddRange(parameters);
                   da.Fill(ds, "ds");
                  // 
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               return ds;
           }
       }
       public static DataSet ExecuteQuery(string sql)
       {
           return ExecuteQuery(sql, null);
       }
       //ִ�в�ѯ��䷵��datareader��ʹ�ú�Ҫע��close
       //���������AccessPageUtils��ʹ�ã�ִ��������ѯʱ��ò�Ҫ��
       public static OleDbDataReader ExecuteReader(string sql)
       {
           //Debug.WriteLine(sql);
           OleDbConnection connection = new OleDbConnection(connectionString);
           OleDbCommand cmd = new OleDbCommand(sql, connection);
           try
           {
               connection.Open();
               return cmd.ExecuteReader(CommandBehavior.CloseConnection);
           }
           catch (Exception e)
           {
               connection.Close();
               throw e;
           }
       }

       public static OleDbDataReader ExecuteReader(string sql, OleDbParameter[] parameters)
       {
           //Debug.WriteLine(sql);

           OleDbConnection connection = new OleDbConnection(connectionString);
          
               OleDbCommand cmd = new OleDbCommand(sql, connection);

               try
               {
                   connection.Open();
                   if (parameters != null) cmd.Parameters.AddRange(parameters);
                   
                   return cmd.ExecuteReader(CommandBehavior.CloseConnection);


               }
               catch(Exception e)
               {
                   connection.Close();
                   throw e;
               }


          
         
       }

    }
}
