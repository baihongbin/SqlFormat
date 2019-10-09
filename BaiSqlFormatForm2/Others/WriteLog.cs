using System.IO;

namespace BaiSqlFormatForm2.Others
{
    class WriteLog
    {
        static object _formatLogLock = new object();
        static object _errLogLock = new object();

        /// <summary>
        /// 记录格式调整错误信息
        /// </summary>
        /// <param name="path">txt文件保存的路径，没有就创建，有内容就覆盖。例："E:\\text.txt"</param>
        /// <param name="contentSrt">要写入的内容</param>
        public static void WriteFormatLog(string path, string fileName, string content)
        {

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!File.Exists(path + "//" + fileName)) File.Create(path + "//" + fileName);

            lock (_formatLogLock)
            {
                using (StreamWriter file = new StreamWriter(path + "//" + fileName))
                {
                    file.Write(content);
                    file.Close();
                }
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
            lock (_errLogLock)
            {
                using (var sw = new StreamWriter(@"logs\appErrLog.log", true))
                {
                    sw.WriteLine(content);
                    sw.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    sw.Close();
                }
            }
        }
    }
}
