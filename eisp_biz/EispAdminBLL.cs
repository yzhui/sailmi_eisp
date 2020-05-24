using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Eisp.DAL;
using Eisp.Common;
using Eisp.Entity;
using Eisp.Common.Utility;
using Eisp.Common.Security;

namespace Eisp.BLL
{
   public class EispAdminBLL
    {
       /// <summary>
       /// 添加管理员
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public static UserResult Add(AdminModel model)
       {
           UserResult result = new UserResult();
           // 检查输入是否合法
           if (!CheckName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "用户名格式错误。";
               result.Message = "name";
               return result;
           }

           if(AdminDAL.CheckEqualName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "用户名重复";
               result.Message = "name";
               return result;
           }

           if (!CheckPassword(model.Pass))
           {
               result.HasError = true;
               result.ErrorMessage = "密码格式错误。";
               result.Message = "password";
               return result;
           }
           //调用加密密码
           model.Pass = Encrypt(model.Pass);
           // 调用数据层保存
           int res = AdminDAL.Add(model);

           if (res > 0)
           {
               result.HasError = false;
               return result;
           }
           else
           {
               result.HasError = true;
               result.ErrorMessage = "添加失败！";
               return result;
           }

       }
       /// <summary>
       /// 修改管理员密码
       /// </summary>
       /// <param name="id"></param>
       /// <param name="pass"></param>
       /// <returns></returns>
       public static UserResult UpdateAdminByID(string id, string pass)
       {
           UserResult result = new UserResult();
           if (!VerifyTool.IsLong(id))
           {
               result.HasError = true;
               result.ErrorMessage = "用户身份错误。";
               return result;
           }

           if (!CheckPassword(pass))
           {
               result.HasError = true;
               result.ErrorMessage = "密码格式错误。";
               result.Message = "password";
               return result;
           }
           //调用加密保护
           pass = Encrypt(pass);


           if (AdminDAL.UpdateAdminByID(id, pass))
           {
               result.HasError = false;
               return result;
           }
           else
           {
               result.HasError = true;
               result.ErrorMessage = "服务器繁忙！";
               result.Message = "password";
               return result;
           }

       }
       /// <summary>
       /// 管理员删除
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static UserResult DeleteAdminByID(string id)
       {
           UserResult result = new UserResult();
           if(!VerifyTool.IsLong(id))
           {
               result.HasError = true;
               result.ErrorMessage = "参数错误。";
               return result;
           }

           if(AdminDAL.DeleteAdminByID(id))
           {
               result.HasError = false;
               return result;
           }
           else
           {
               result.HasError = true;
               result.ErrorMessage = "保留账号禁止删除！";
               result.Message = "password";
               return result;
           }


       }
       /// <summary>
       /// 获取管理员信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public static UserResult GetAdminInfo(AdminModel model)
       {
           UserResult result = new UserResult();
           // 检查输入是否合法
           if (!CheckName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "用户名格式错误。";
               result.Message = "name";
               return result;
           }

           if (!AdminDAL.CheckEqualName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "用户名错误";
               result.Message = "name";
               return result;
           }

           if (!CheckPassword(model.Pass))
           {
               result.HasError = true;
               result.ErrorMessage = "密码格式错误。";
               result.Message = "password";
               return result;
           }
           //调用加密密码
           model.Pass = Encrypt(model.Pass);

           result.Result = AdminDAL.GetAdminInfo(model);

           result.HasError = false;

           return result;
       }

       // 检查平台用户名格式
       public static bool CheckName(string name)
       {
           if (string.IsNullOrEmpty(name)) return false;
           Regex reg = new Regex(@"^[a-zA-Z0-9_][_a-zA-Z0-9]{1,17}$", RegexOptions.IgnoreCase);
           return reg.IsMatch(name);
       }


       // 检查密码格式
       public static bool CheckPassword(string password)
       {
           if (string.IsNullOrEmpty(password)) return false;
           Regex reg = new Regex(@"^[^\u0081-\uffff\s]{6,32}$");
           return reg.IsMatch(password);
       }

       // 加密密码和密码找回问题答案
       public static string Encrypt(string value)
       {
           return MD5.HashString(value, Encoding.GetEncoding("GB2312"));
       }
       /// <summary>
       /// 获取管理员
       /// </summary>
       /// <returns></returns>
       public static List<AdminModel> GetAdminList()
       {
           return AdminDAL.GetAdminList();
       }

    }

    public class UserResult : IResult<AdminModel>
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

        private AdminModel _result;
        public AdminModel Result
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

        private List<AdminModel> _list;
        public List<AdminModel> ResultList
        {
            get { return _list; }
            set { _list = value; }
        }
    }
}
