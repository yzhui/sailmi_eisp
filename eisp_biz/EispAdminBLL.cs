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
       /// ��ӹ���Ա
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public static UserResult Add(AdminModel model)
       {
           UserResult result = new UserResult();
           // ��������Ƿ�Ϸ�
           if (!CheckName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "�û�����ʽ����";
               result.Message = "name";
               return result;
           }

           if(AdminDAL.CheckEqualName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "�û����ظ�";
               result.Message = "name";
               return result;
           }

           if (!CheckPassword(model.Pass))
           {
               result.HasError = true;
               result.ErrorMessage = "�����ʽ����";
               result.Message = "password";
               return result;
           }
           //���ü�������
           model.Pass = Encrypt(model.Pass);
           // �������ݲ㱣��
           int res = AdminDAL.Add(model);

           if (res > 0)
           {
               result.HasError = false;
               return result;
           }
           else
           {
               result.HasError = true;
               result.ErrorMessage = "���ʧ�ܣ�";
               return result;
           }

       }
       /// <summary>
       /// �޸Ĺ���Ա����
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
               result.ErrorMessage = "�û���ݴ���";
               return result;
           }

           if (!CheckPassword(pass))
           {
               result.HasError = true;
               result.ErrorMessage = "�����ʽ����";
               result.Message = "password";
               return result;
           }
           //���ü��ܱ���
           pass = Encrypt(pass);


           if (AdminDAL.UpdateAdminByID(id, pass))
           {
               result.HasError = false;
               return result;
           }
           else
           {
               result.HasError = true;
               result.ErrorMessage = "��������æ��";
               result.Message = "password";
               return result;
           }

       }
       /// <summary>
       /// ����Աɾ��
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static UserResult DeleteAdminByID(string id)
       {
           UserResult result = new UserResult();
           if(!VerifyTool.IsLong(id))
           {
               result.HasError = true;
               result.ErrorMessage = "��������";
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
               result.ErrorMessage = "�����˺Ž�ֹɾ����";
               result.Message = "password";
               return result;
           }


       }
       /// <summary>
       /// ��ȡ����Ա��Ϣ
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public static UserResult GetAdminInfo(AdminModel model)
       {
           UserResult result = new UserResult();
           // ��������Ƿ�Ϸ�
           if (!CheckName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "�û�����ʽ����";
               result.Message = "name";
               return result;
           }

           if (!AdminDAL.CheckEqualName(model.Name))
           {
               result.HasError = true;
               result.ErrorMessage = "�û�������";
               result.Message = "name";
               return result;
           }

           if (!CheckPassword(model.Pass))
           {
               result.HasError = true;
               result.ErrorMessage = "�����ʽ����";
               result.Message = "password";
               return result;
           }
           //���ü�������
           model.Pass = Encrypt(model.Pass);

           result.Result = AdminDAL.GetAdminInfo(model);

           result.HasError = false;

           return result;
       }

       // ���ƽ̨�û�����ʽ
       public static bool CheckName(string name)
       {
           if (string.IsNullOrEmpty(name)) return false;
           Regex reg = new Regex(@"^[a-zA-Z0-9_][_a-zA-Z0-9]{1,17}$", RegexOptions.IgnoreCase);
           return reg.IsMatch(name);
       }


       // ��������ʽ
       public static bool CheckPassword(string password)
       {
           if (string.IsNullOrEmpty(password)) return false;
           Regex reg = new Regex(@"^[^\u0081-\uffff\s]{6,32}$");
           return reg.IsMatch(password);
       }

       // ��������������һ������
       public static string Encrypt(string value)
       {
           return MD5.HashString(value, Encoding.GetEncoding("GB2312"));
       }
       /// <summary>
       /// ��ȡ����Ա
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
