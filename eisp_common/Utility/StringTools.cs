using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Eisp.Common.Utility
{
    public class StringTools
    {

        public static int GetStrLength(string str)
        {
            return System.Text.Encoding.Default.GetByteCount(str);
        }

        public static string InterceptStr(string p_SrcString, int p_Length)
        {
            string myResult = p_SrcString;
            if (p_Length >= 0)
            {
                byte[] bsSrcString = System.Text.Encoding.GetEncoding("GB2312").GetBytes(p_SrcString);
                if (bsSrcString.Length >= p_Length)
                {
                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;
                    int nFlag = 0;
                    for (int i = 0; i < p_Length; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                                nFlag = 1;
                        }
                        else
                            nFlag = 0;
                        anResultFlag[i] = nFlag;
                    }
                    if ((bsSrcString[p_Length - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                        nRealLength = p_Length + 1;
                    bsResult = new byte[nRealLength];
                    Array.Copy(bsSrcString, bsResult, nRealLength);
                    myResult = System.Text.Encoding.GetEncoding("GB2312").GetString(bsResult) ;
                }
            }
            return myResult;
        }

    }
}
