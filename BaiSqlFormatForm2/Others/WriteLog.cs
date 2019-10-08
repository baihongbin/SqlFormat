using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BaiSqlFormatForm2.Others
{
    class WriteLog
    {
        /// <summary>
        /// 记录格式调整错误信息
        /// </summary>
        /// <param name="path">txt文件保存的路径，没有就创建，有内容就覆盖。例："E:\\text.txt"</param>
        /// <param name="contentSrt">要写入的内容</param>
        public static void WriteFormatLog(string path, string fileName, string content)
        {

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(path + "//" + fileName)) File.Create(path + "//" + fileName);
            using (StreamWriter file = new StreamWriter(path + "//" + fileName))
            {
                file.Write(content);
            }
        }


        /// <summary>
        /// 记录程序错误日志
        /// </summary>
        /// <param name="str"></param>
        public static void WriteErrLog(string content)
        {
            if (!Directory.Exists("logs"))
            {
                Directory.CreateDirectory("logs");
            }

            using (var sw = new StreamWriter(@"logs\appErrLog.log", true))
            {
                sw.WriteLine(content);
                sw.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                sw.Close();
            }
        }
    }
}
