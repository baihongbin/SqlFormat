using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;

namespace BaiSqlFormatForm2
{
    public partial class AboutBox : XtraForm
    {
        public AboutBox()
        {
            InitializeComponent();
            this.me_info.ReadOnly = true;
            this.me_explain.ReadOnly = true;
            this.me_info.Text = "产品名称：SQL代码格式调整工具\r\n\r\n"+
                                "版    本：v2.0\r\n\r\n" +
                                "作    者：Bai\r\n\r\n" +
                                "框    架：.NET Framework 4.0";
            this.me_explain.Text = AssemblyDescription;
        }

        public string AssemblyDescription
        {
            get
            {
                return "1) 本程序理论上支持所有SQL/HQL语句的格式调整，包括但不限于普通数据库DDL、DML、DCL，" +
                    "理论上也支持存储过程、视图等语句格式调整。但不能保证效果完美（由于时间原因，" +
                    "只针对部分大数据ETL涉及到的HQL语法进行了测试）" + "\r\n\r\n" +
                    "2) 疑似格式调整错误的日志（只保留最后一个错误日期）将会记录到本地文件夹，文件位置：本程序所在位置\\logs\\formatErrLog.log" + "\r\n\r\n" +
                    "3) 程序错误日志也会记录在本地文件夹（所有错误信息全部保留），文件位置：本程序所在位置\\logs\\appErrLog.log";
            }
        }

        private void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.ToString())
            {
                case "Caption = '确认'":
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }
}
