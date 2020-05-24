using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;
using System.Reflection;
using System.Collections;

namespace Eisp.BLL
{
  public  class EispProBLL
    {

       /// <summary>
        /// 添加
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
      public static int AddPro(ProModel p)
      {
          return EispProDAL.AddPro(p);
      }
      /// <summary>
      /// 是否存在该类别产品
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public static int IsPro(int id)
      {
          return EispProDAL.IsPro(id);
      }
       /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      public static int DeletePro(int id)
      {
          return EispProDAL.DeletePro(id);
      }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
      public static int UpdatePro(ProModel p)
      {
          return EispProDAL.UpdatePro(p);

      }

      /// <summary>
        /// 获取一条产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      public static ProModel GetProByID(int id)
      {
          return EispProDAL.GetProByID(id);

      }

       /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="number">总数</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
      public static List<ProModel> GetProListPageNoByLang(int lang,int number, int pagesize)
      {
          List<ProModel> list = EispProDAL.GetProListPageNoByLang(lang,number, pagesize);
          ProModel p = new ProModel();
          Reverser<ProModel> reverser = new Reverser<ProModel>(p.GetType(), "F_Sort", ReverserInfo.Direction.DESC);
          list.Sort(reverser);
          return list;
      }

        /// <summary>
        /// 获取文章记录总数
        /// </summary>
        /// <returns></returns>
      public static int GetRecordCount()
      {
          return EispProDAL.GetRecordCount();
      }

       /// <summary>
        /// 按类别搜索
        /// </summary>
        /// <param name="proclassid"></param>
        /// <returns></returns>
      public static List<ProModel> SearchProList(int lang,int proclassid)
      {
          string strid="";
       GetClassSubAll(proclassid,ref  strid);




       return EispProDAL.SearchProList(strid + proclassid.ToString());
      }

        /// <summary>
        /// 根据产品类别获取产品分页功能
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pagesize"></param>
        /// <param name="classid"></param>
        /// <returns></returns>
      public static List<ProModel> GetListPageNoByClassID(int number, int pagesize, int classid,int provider)
      {

          string strid = "";
          GetClassSubAllByClass(classid, ref  strid);
          List<ProModel> list = EispProDAL.GetListPageNoByClassID(number, pagesize, strid,provider,classid);
          ProModel p = new ProModel();
          Reverser<ProModel> reverser = new Reverser<ProModel>(p.GetType(), "F_Sort", ReverserInfo.Direction.DESC);
          list.Sort(reverser);
          return list;
      }
      public static List<ProModel> GetListPageNoByClassIDByLang(int lang, int number, int pagesize, int classid, int provider)
      {

          string strid = "";
          if (classid == -1)
          {
              GetClassSubAllByLang(lang, ref  strid);
          }
          else
          {
              GetClassSubAllByClass(classid, ref  strid);
          }

          List<ProModel> list = EispProDAL.GetListPageNoByClassID(number, pagesize, strid, provider,classid);
          ProModel p = new ProModel();
          Reverser<ProModel> reverser = new Reverser<ProModel>(p.GetType(), "F_Sort", ReverserInfo.Direction.DESC);
          list.Sort(reverser);


          //  ColoProModel n = new ColoProModel();
          //  list.Sort(n.F_Sort);
          return list;
      }

      public static void GetClassSubAllByClass(int classid,ref string strid){
        GetClassSubAll(classid, ref  strid);
        strid = strid + classid;
      }
      public static int GetRecordCountByClassidByLang(int lang, int classid,int provider)
      {
          string strid = "";
          if (classid == -1)
          {
              GetClassSubAllByLang(lang, ref  strid);
          }
          else {
              GetClassSubAll(classid, ref  strid);
          }
          return EispProDAL.GetRecordCountByClassid(strid + classid.ToString(),provider,classid);
      }

      public static int GetRecordCountByClassid(int classid,int provider)
      {
          string strid = "";
          GetClassSubAll(classid, ref  strid);
          return EispProDAL.GetRecordCountByClassid(strid+classid.ToString(),provider,classid);
      }
      public static void GetClassSubAllByLang(int lang, ref string str)
      {
          List<ProClassModel> list = EispProClassBLL.GetProClassListByLang(lang,0);

          // string cid=string.Empty;

          foreach (ProClassModel proclass in list)
          {
              str += proclass.ID.ToString() + ",";
              GetClassSubAll(proclass.ID, ref str);
          }
          str += "0";
      }

      public static void GetClassSubAll(int proclassid,ref string str)
      {
          List<ProClassModel> list = EispProClassBLL.GetProClassList(proclassid);
          // string cid=string.Empty;
          foreach (ProClassModel proclass in list)
          {
             str += proclass.ID.ToString() + ",";
             GetClassSubAll(proclass.ID,ref str);
          }
          //str += proclassid;
      }
       /// <summary>
        /// 获取首页推荐产品
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
      public static List<ProModel> GetTopRecommended(int count)
      {
          return EispProDAL.GetTopRecommended(count);
      }
      public static List<ProModel> GetTopRecommendedByLang(int lang,int count)
      {
          return EispProDAL.GetTopRecommendedByLang(lang,count);
      }

    }

  /**/
  /// <summary>
  /// 继承IComparer<T>接口，实现同一自定义类型　对象比较
  /// </summary>
  /// <typeparam name="T">T为泛用类型</typeparam>
  public class Reverser<T> : IComparer<T>
  {
      private Type type = null;
      private ReverserInfo info;

      /**/
      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="type">进行比较的类类型</param>
      /// <param name="name">进行比较对象的属性名称</param>
      /// <param name="direction">比较方向(升序/降序)</param>
      public Reverser(Type type, string name, ReverserInfo.Direction direction)
      {
          this.type = type;
          this.info.name = name;
          if (direction != ReverserInfo.Direction.ASC)
              this.info.direction = direction;
      }

      /**/
      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="className">进行比较的类名称</param>
      /// <param name="name">进行比较对象的属性名称</param>
      /// <param name="direction">比较方向(升序/降序)</param>
      public Reverser(string className, string name, ReverserInfo.Direction direction)
      {
          try
          {
              this.type = Type.GetType(className, true);
              this.info.name = name;
              this.info.direction = direction;
          }
          catch (Exception e)
          {
              throw new Exception(e.Message);
          }
      }

      /**/
      /// <summary>
      /// 构造函数
      /// </summary>
      /// <param name="t">进行比较的类型的实例</param>
      /// <param name="name">进行比较对象的属性名称</param>
      /// <param name="direction">比较方向(升序/降序)</param>
      public Reverser(T t, string name, ReverserInfo.Direction direction)
      {
          this.type = t.GetType();
          this.info.name = name;
          this.info.direction = direction;
      }

      //必须！实现IComparer<T>的比较方法。
      int IComparer<T>.Compare(T t1, T t2)
      {
          object x = this.type.InvokeMember(this.info.name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, t1, null);
          object y = this.type.InvokeMember(this.info.name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, t2, null);
          if (this.info.direction != ReverserInfo.Direction.ASC)
              Swap(ref x, ref y);
          return (new CaseInsensitiveComparer()).Compare(x, y);
      }

      //交换操作数
      private void Swap(ref object x, ref object y)
      {
          object temp = null;
          temp = x;
          x = y;
          y = temp;
      }
  }

  /**/
  /// <summary>
  /// 对象比较时使用的信息类
  /// </summary>
  public struct ReverserInfo
  {
      /**/
      /// <summary>
      /// 比较的方向，如下：
      /// ASC：升序
      /// DESC：降序
      /// </summary>
      public enum Direction
      {
          ASC = 0,
          DESC,
      }

      public enum Target
      {
          CUSTOMER = 0,
          FORM,
          FIELD,
          SERVER,
      }

      public string name;
      public Direction direction;
      public Target target;
  }






}
