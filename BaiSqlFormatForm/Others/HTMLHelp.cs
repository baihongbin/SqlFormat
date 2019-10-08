using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BaiSqlFormatForm.Others
{
    class HTMLHelp
    {
        /// <summary>
        /// 提取HTML中的内容
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string StripHTML(string strHtml)
        {
            string[] aryReg ={
                @"&(nbsp|#160);",
          @"<script[^>]*?>.*?</script>",
          @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
          @"([\r\n])[\s]+",
          @"&(quot|#34);",
          @"&(amp|#38);",
          @"&(lt|#60);",
          @"&(gt|#62);",

          @"&(iexcl|#161);",
          @"&(cent|#162);",
          @"&(pound|#163);",
          @"&(copy|#169);",
          @"&#(\d+);",
          @"-->",
          @"<!--.*\n"

         };

            string[] aryRep = {
                " ",
           "",
           "",
           "\r\n",
           "\"",
           "&",
           "<",
           ">",

           "\xa1",//chr(161),
           "\xa2",//chr(162),
           "\xa3",//chr(163),
           "\xa9",//chr(169),
           "",
           "\r\n",
           ""
          };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryRep[i]);
            }

            strOutput = strOutput.Replace("<", "").Replace(">", "").Replace("\r\n", "");
            strOutput = strOutput.Replace(".SQLCode { font-size: 13px; font-weight: bold; font-family: monospace;; white-space: pre; -o-tab-size: 4; -moz-tab-size: 4; -webkit-tab-size: 4; } .SQLComment { color: #00AA00; } .SQLString { color: #AA0000; } .SQLFunction { color: #AA00AA; } .SQLKeyword { color: #0000AA; } .SQLOperator { color: #777777; } .SQLErrorHighlight { background-color: #FFFF00; }", "");

            return strOutput.Trim();
        }
    }
}
