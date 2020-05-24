using System;
using System.Collections.Generic;
using System.Text;
using Eisp.Common;
using Eisp.DAL;
using Eisp.Entity;
using Eisp.Common.Utility;
namespace Eisp.BLL
{

    public class EispSysInfo {
        //10000+X为公司的相关配置
        //1000+X为系统的相关配置
        public static string SYS_SYSTEMNAME = "1001";
        public static string SYS_SYSTEMVERSION = "1002";
        public static string SYS_SYSTEMINFO = "1003";
        public static string SYS_SYSTEMCOPYRIGHT = "1004";
        public static string SYS_COMPANYNAME = "10001";
        public static string SYS_COMPANYKEYWORDS = "10002";
    }

   public class EispSysInfoBLL
    {

  
        /// <summary>
       /// 获取公司简介
       /// </summary>
       /// <param name="id">查询参数</param>
       /// <returns>返回</returns>
       public static SysInfoResult GetSysInfoByID(string id)
       {

           SysInfoResult result = new SysInfoResult();
           if (!VerifyTool.IsLong(id))
           {
               result.HasError = true;
               result.ErrorMessage = "参数错误。";
               return result;
           }
           result.HasError = false;
           result.Result = EispSysInfoDAL.GetSysInfoByID(Convert.ToInt32(id));
           return result;
       }

       /// <summary>
       /// 获取公司简介
       /// </summary>
       /// <param name="id">查询参数</param>
       /// <returns>返回</returns>
       public static string GetSysInfoStrByID(string id)
       {

           SysInfoResult result = new SysInfoResult();
           if (!VerifyTool.IsLong(id))
           {
               result.HasError = true;
               result.ErrorMessage = "参数错误。";
               return null;
           }
           result.HasError = false;
           result.Result = EispSysInfoDAL.GetSysInfoByID(Convert.ToInt32(id));
           return result.Result.Content;
       }


       public static SysInfoResult UpdateSysInfoByID(SysInfoModel f)
       {
           SysInfoResult result = new SysInfoResult();
           if (!VerifyTool.IsLong(f.ID.ToString()))
           {
               result.HasError = true;
               result.ErrorMessage = "参数错误。";
               return result;
           }

           if (EispSysInfoDAL.UpdateSysInfoByID(f) > 0)
           {
               result.HasError = false;
               return result;
           }
           else
           {
               result.HasError = true;
               result.ErrorMessage = "数据库错误，请联系管理员。";
               return result;
           }
       }


    }

   public class SysInfoResult : IResult<SysInfoModel>
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

       private SysInfoModel _result;
       public SysInfoModel Result
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

       private List<SysInfoModel> _list;
       public List<SysInfoModel> ResultList
       {
           get { return _list; }
           set { _list = value; }
       }

   }
}
