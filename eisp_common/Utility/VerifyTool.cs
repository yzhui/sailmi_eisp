using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Eisp.Common.Utility
{
  public  class VerifyTool
    {
        #region IsLong

        public static bool IsLong(string s)
        {
            return IsLong(s, false, false);
        }

        public static bool IsLong(string s, bool allowZero)
        {
            return IsLong(s, allowZero, false);
        }

        public static bool IsLong(string s, bool allowZero, bool allowNegative)
        {
            long output;
            return IsLong(s, allowZero, allowNegative, out output);
        }

        public static bool IsLong(string s, bool allowZero, bool allowNegative, out long value)
        {
            value = long.MinValue;
            if (string.IsNullOrEmpty(s))
                return false;

            string pattern = @"^";
            if (allowNegative)
                pattern += "-?";

            if (allowZero)
                pattern += @"\d+$";
            else
                pattern += @"[1-9]\d*$";

            Regex reg = new Regex(pattern);
            if (!reg.IsMatch(s))
            {
                value = long.MinValue;
                return false;
            }

            return long.TryParse(s, out value);
        }

        #endregion
        #region IsInt

        /// <summary>
        /// 判断字符串是否为Int型（非负，非零）
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns>True: 字符串是非零正整数 false: 字符串不是非零正整数</returns>
        public static bool IsInt(string s)
        {
            return IsInt(s, false, false);
        }

        /// <summary>
        /// 判断字符串是否为满足条件的Int值（可以判断是否零）
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="allowZero">True: 可以为零 False: 不能为零</param>
        /// <returns>True: 满足判断条件 False:不满足判断条件</returns>
        public static bool IsInt(string s, bool allowZero)
        {
            return IsInt(s, allowZero, false);
        }

        /// <summary>
        /// 判断字符串是否为满足条件的Int值（可以判断是否为负数，是否为零）
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="allowZero">True: 可以为零 False: 不能为零</param>
        /// <param name="allowNegative">True: 可以是负数 False: 不能是负数</param>
        /// <returns>True: 满足判断条件 False:不满足判断条件</returns>
        public static bool IsInt(string s, bool allowZero, bool allowNegative)
        {
            int output;
            return IsInt(s, allowZero, allowNegative, out output);
        }

        /// <summary>
        /// 判断字符串是否为满足条件的Int值（可以判断是否为负数，是否为零，输出Int值）
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="allowZero">True: 可以为零 False: 不能为零</param>
        /// <param name="allowNegative">True: 可以是负数 False: 不能是负数</param>
        /// <param name="value">如果满足条件，则将Int值传出，如果不满足条件返回Int的最小值</param>
        /// <returns>True: 满足判断条件 False:不满足判断条件</returns>
        public static bool IsInt(string s, bool allowZero, bool allowNegative, out int value)
        {
            if (string.IsNullOrEmpty(s))
            {
                value = int.MinValue;
                return false;
            }

            string pattern = @"^";
            if (allowNegative)
                pattern += "-?";

            if (allowZero)
                pattern += @"\d+$";
            else
                pattern += @"[1-9]\d*$";

            Regex reg = new Regex(pattern);
            if (!reg.IsMatch(s))
            {
                value = int.MinValue;
                return false;
            }

            return int.TryParse(s, out value);
        }
        #endregion
        #region IsByte

        /// <summary>
        /// 判断字符串是否为byte值
        /// </summary>
        /// <param name="num">字符串</param>
        /// <returns>True: 字符串是byte值 False: 字符串不是byte值</returns>
        public static bool IsByte(string num)
        {
            byte value;
            return IsByte(num, out value);
        }

        /// <summary>
        /// 判断字符串是否为byte值，如果是则将byte值输出，如果不是则输出byte最小值
        /// </summary>
        /// <param name="num">字符串</param>
        /// <param name="value">如果满足条件则输出byte值，如果不满足条件则输出byte最小值</param>
        /// <returns>True: 字符串是byte值 False: 字符串不是byte值</returns>
        public static bool IsByte(string num, out byte value)
        {
            if (string.IsNullOrEmpty(num))
            {
                value = byte.MinValue;
                return false;
            }

            return byte.TryParse(num, out value);
        }
        #endregion

     

        #region IsDateValid
        /// <summary>
        /// 判断日期是否正确
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>True: 正确日期 False: 非法日期</returns>
        public static bool IsDateValid(int year, int month, int day)
        {
            if (month < 1 || month > 12) return false;
            if (day < 1 || day > 31) return false;
            if (day > DateTime.DaysInMonth(year, month)) return false;
            return true;
        }

        /// <summary>
        /// 判断日期是否正确
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>True: 正确日期 False: 非法日期</returns>
        public static bool IsDateValid(string year, string month, string day)
        {

            int y, m, d;

            if (!VerifyTool.IsInt(year, false, false, out y)) return false;
            if (!VerifyTool.IsInt(month, false, false, out m)) return false;
            if (!VerifyTool.IsInt(day, false, false, out d)) return false;

            return IsDateValid(y, m, d);
        }
        #endregion

        #region IsLengthValid

        /// <summary>
        /// 检查字符串长度是否符合条件
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="max">最大值</param>
        /// <returns>True: 符合长度条件 False: 不符合长度条件</returns>
        public static bool IsLengthValid(string s, int max)
        {
            return IsLengthValid(s, 0, max);
        }

        /// <summary>
        /// 检查字符串长度是否符合条件
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>True: 符合长度条件 False: 不符合长度条件</returns>
        public static bool IsLengthValid(string s, int min, int max)
        {
            if (s == null)
                return false;
            return (s.Length >= min && s.Length <= max);
        }

        #endregion

        /// <summary>
        /// 判断IP地址是否正确
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns>True: 正确 False: 错误</returns>
        public static bool IsIPValid(string ip)
        {
            if (!string.IsNullOrEmpty(ip))
            {
                string pat = @"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$";

                Match m = Regex.Match(ip, pat);
                if (m != null && m.Groups.Count == 5)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        if (!VerifyTool.IsByte(m.Groups[i].Value))
                            return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 判断Email格式是否正确
        /// </summary>
        /// <param name="email">Email地址</param>
        /// <returns>True: 正确 False: 错误</returns>
        public static bool IsEmailValid(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Regex reg = new Regex(@"^\w+(\w|\.|-)*\w*@(\w+(\w|-)*\w*\.)+\w{2,}$");
                return reg.IsMatch(email);
            }
            return false;
        }

      /// <summary>
      /// 判断网址
      /// </summary>
      /// <param name="url"></param>
      /// <returns></returns>
        public static bool IsUrlValid(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Regex reg = new Regex(@"^(http|HTTP)://([\w-]+\.)*[\w-]+(:\d+)?(/[\u4e00-\u9fa5\w- ./?%&=]*)?$");
                return reg.IsMatch(url);
            }
            return false;
        }
      /// <summary>
      /// 过滤script脚本，iframe,frameset
      /// </summary>
      /// <param name="str"></param>
      /// <returns></returns>
        public static string DeleteScript( string str)
        {
            if (str == null) return "";

            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string html = str;
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 

            return html;

        }
      /// <summary>
      /// 过滤html
      /// </summary>
      /// <param name="str"></param>
      /// <returns></returns>
        public static string DeleteHtml(string str)
        {
            string s = System.Text.RegularExpressions.Regex.Replace(str, "<[^>]+>", "");
            return s;
        }
        public static string DeleteAll(string str)
        {

            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);


            string html = System.Text.RegularExpressions.Regex.Replace(str, "<[^>]+>", "");
            html = regex1.Replace(html, ""); //过滤<script></script>标记 
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on事件 
            html = regex4.Replace(html, ""); //过滤iframe 
            html = regex5.Replace(html, ""); //过滤frameset 

            return html;

        }
        public static string CheckStringLength(string stringToCheck, int maxLength, bool key)
        {
            string checkedString = null;

            if (stringToCheck.Length <= maxLength)
                return stringToCheck;

            if ((stringToCheck.Length > maxLength) && (stringToCheck.IndexOf(" ") == -1))
            {
                checkedString = stringToCheck.Substring(0, maxLength);
            }
            else if (stringToCheck.Length > 0)
            {
                if (key)
                {
                    checkedString = stringToCheck.Substring(0, maxLength) + "...";
                }
                else
                {
                    checkedString = stringToCheck.Substring(0, maxLength);
                }

            }
            else
            {
                checkedString = stringToCheck;
            }

            return checkedString;
        }

        /// <summary>
        /// 清除所有HTML标签
        /// </summary>
        /// <param name="html">html代码</param>
        public static string RemoveHtml(string html)
        {
            if (string.IsNullOrEmpty(html))
                return string.Empty;

            return Regex.Replace(html, @"<.+?/?>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline); 
        }
        public static string ConvertUtfToGb(string utfstr) {
            string utfinfo = utfstr;
            string gb2312info = string.Empty;

            Encoding utf8 = Encoding.UTF8;
            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            // Convert the string into a byte[]. 
            byte[] unicodeBytes = utf8.GetBytes(utfinfo);
            // Perform the conversion from one encoding to the other. 
            byte[] asciiBytes = Encoding.Convert(utf8, gb2312, unicodeBytes);

            // Convert the new byte[] into a char[] and then into a string. 
            // This is a slightly different approach to converting to illustrate 
            // the use of GetCharCount/GetChars. 
            char[] asciiChars = new char[gb2312.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
            gb2312.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
            gb2312info = new string(asciiChars);
            return gb2312info;
        }
    }
}
