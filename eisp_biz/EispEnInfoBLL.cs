using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;
namespace Eisp.BLL
{

  
   public class EispEnInfoBLL
    {

  
        /// <summary>
       /// 获取公司简介
       /// </summary>
       /// <param name="id">查询参数</param>
       /// <returns>返回</returns>
       public static EnInfoResult GetEnInfoByLang(int id)
       {

           EnInfoResult result = new EnInfoResult();
           result.HasError = false;
           result.Result = EispEnInfoDAL.GetEnInfoByLang(Convert.ToInt32(id));
           return result;
       }


       public static EnInfoResult UpdateEnInfo(EnInfoModel f)
       {
           EnInfoResult result = new EnInfoResult();
           if (EispEnInfoDAL.GetEnInfoByLang(f.Lang) == null)
           {

               if (EispEnInfoDAL.AddEnInfo(f) > 0)
               {
                   result.HasError = false;
                   return result;
               }
               else
               {
                   result.HasError = true;
                   result.ErrorMessage = "数据库错误，添加企业基础信息失败，请联系管理员。";
                   return result;
               }
           }
           else
           {
               if (EispEnInfoDAL.UpdateEnInfoByLang(f) > 0)
               {
                   result.HasError = false;
                   return result;
               }
               else
               {
                   result.HasError = true;
                   result.ErrorMessage = "数据库错误，修改企业基础信息失败，请联系管理员。参数如下："+f.Lang;
                   return result;
               }
           }
       }

    }

   public class EnInfoResult : IResult<EnInfoModel>
   {

       private bool _hasError;
       public bool HasError
       {
           get
           {
               return _hasError;
           }
           set
           {
               _hasError = value;
           }
       }


       private string _errorMessage;
       public string ErrorMessage
       {
           get
           {
               return _errorMessage;
           }
           set
           {
               _errorMessage = value;
           }
       }

       private string _message;
       public string Message
       {
           get
           {
               return _message;
           }
           set
           {
               _message = value;
           }
       }

       private EnInfoModel _result;
       public EnInfoModel Result
       {
           get
           {
               return _result;
           }
           set
           {
               _result = value;
           }
       }

       private List<EnInfoModel> _list;
       public List<EnInfoModel> ResultList
       {
           get { return _list; }
           set { _list = value; }
       }

   }
}
