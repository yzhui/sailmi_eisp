using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;
using System.Data;

namespace Eisp.BLL
{
    public class EispNewsBLL
    {

        /// <summary>
        /// 新闻添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int AddNew(NewsModel a)
        {
            return EispNewsDAL.AddNew(a);
        }

         /// <summary>
        /// 更新新闻
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int UpdateNewByID(NewsModel a)
        {
            return EispNewsDAL.UpdateNewByID(a);
        }

           /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteNewByID(int id)
        {
            return EispNewsDAL.DeleteNewByID(id);
        }

             /// <summary>
        /// 获取一条新闻
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static NewsModel GetNewsByID(int id)
        {
            return EispNewsDAL.GetNewsByID(id);
        }

         /// <summary>
        /// 获取新闻列表分页
        /// </summary>
        /// <param name="number">总数</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        public static List<NewsModel> GetArticleListPageNo(int number, int pagesize, int classid)
        {
            return EispNewsDAL.GetArticleListPageNo(number,pagesize,classid);
        }


        /// <summary>
        /// 获取新闻列表分页
        /// </summary>
        /// <param name="number">总数</param>
        /// <param name="pagesize">页大小</param>
        /// <returns></returns>
        public static List<NewsModel> GetArticleListPageNoByLang(int lang,int number, int pagesize, int classid)
        {
            return EispNewsDAL.GetArticleListPageNoByLang(lang,number, pagesize, classid);
        }

          /// <summary>
        /// 获取文章记录总数
        /// </summary>
        /// <returns></returns>
        public static int GetRecordCountByLang(int lang)
        {
            return EispNewsDAL.GetRecordCountByLang(lang);
        }

        public static int GetRecordCountByClassid(int lang,int classid)
        {
            return EispNewsDAL.GetRecordCountByClassidByLang(lang,classid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static DataTable GetNewTop(int count)
        {
           return EispNewsDAL.GetNewTop(count);
        }

        public static int HasNews(int newsclass) {
            return EispNewsDAL.GetRecordCountByClassid(newsclass);
        
        }

    }
}
