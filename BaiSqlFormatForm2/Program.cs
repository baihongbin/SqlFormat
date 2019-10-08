using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Threading;
using BaiSqlFormatForm2.Others;

namespace BaiSqlFormatForm2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //添加事件处理程序未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //添加事件处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //添加事件处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                bool isAppRunning = false;
                Mutex mutex = new Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out isAppRunning);
                if (!isAppRunning)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("程序已运行，不能再次打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(1);
                }
                
                BonusSkins.Register();
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + "出现应用程序未处理的异常：\r\n";

                if (ex != null)
                {
                    str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                         ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("应用程序线程错误:{0}", ex);
                }

                //写日志
                WriteLog.WriteErrLog(str);
                DevExpress.XtraEditors.XtraMessageBox.Show("程序发生错误，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 程序异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            string str = "";
            string strDateInfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + "出现应用程序未处理的异常：\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }
            //写日志
            WriteLog.WriteErrLog(str);
            DevExpress.XtraEditors.XtraMessageBox.Show("程序发生错误，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///  处理UI异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = "";
            Exception error = e.ExceptionObject as Exception;
            string strDateInfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + "出现应用程序未处理的异常：\r\n";
            if (error != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", e);
            }
            //写日志
            WriteLog.WriteErrLog(str);
            DevExpress.XtraEditors.XtraMessageBox.Show("程序发生错误，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}