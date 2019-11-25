using BaiSqlFormatForm.Others;
using BaiSqlFormatLib;
using BaiSqlFormatLib.Interfaces;
using System;
using System.Text;
using System.Windows.Forms;

namespace BaiSqlFormatForm
{
    public partial class MainForm : Form
    {

        bool _queuedRefresh = false;
        object _refreshLock = new object();
        bool _settingsLoaded = false;

        ISqlTokenizer _tokenizer;
        ISqlTokenParser _parser;
        ISqlTreeFormatter _formatter;

        public MainForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _tokenizer = new BaiSqlFormatLib.Tokenizers.TSqlStandardTokenizer();
            _parser = new BaiSqlFormatLib.Parsers.TSqlStandardParser();

            if (Properties.Settings.Default.chkdefault)
            {
                chk_default.CheckState = CheckState.Checked;

                chk_addSemicolon.Enabled = false;
                txt_maxWidth.Enabled = false;
                chk_columnNotNewline.Enabled = false;
                chk_keywordAlign.Enabled = false;
                chk_conditionNewline.Enabled = false;
                chk_expandCase.Enabled = false;
                chk_expandBetween.Enabled = false;
                chk_expandIn.Enabled = false;
                chk_expandOn.Enabled = false;
                chk_uppercaseKeywords.Enabled = false;
                chk_allUpper.Enabled = false;
                chk_coloring.Enabled = false;
                chk_allIndent.Enabled = false;
                chk_asAlign.Enabled = false;
                txt_asMaxWidth.Enabled = false;
            }
            else
                chk_custom.CheckState = CheckState.Checked;

            txt_maxWidth.Text = Properties.Settings.Default.MaxLineWidth.ToString();
            chk_columnNotNewline.Checked = !Properties.Settings.Default.ExpandCommaLists;
            chk_keywordAlign.Checked = Properties.Settings.Default.KeywordAlign;
            chk_conditionNewline.Checked = Properties.Settings.Default.ExpandBooleanExpressions;
            chk_expandCase.Checked = Properties.Settings.Default.ExpandCaseStatements;
            chk_expandBetween.Checked = Properties.Settings.Default.ExpandBetweenConditions;
            chk_expandIn.Checked = Properties.Settings.Default.ExpandInLists;
            chk_expandOn.Checked = Properties.Settings.Default.BreakJoinOnSections;
            chk_uppercaseKeywords.Checked = Properties.Settings.Default.UppercaseKeywords;
            chk_allUpper.Checked = Properties.Settings.Default.AllUpper;
            chk_coloring.Checked = Properties.Settings.Default.HTMLColoring;
            chk_allIndent.Checked = Properties.Settings.Default.AllIndent;
            chk_asAlign.Checked = Properties.Settings.Default.AsAlign;
            txt_asMaxWidth.Text = Properties.Settings.Default.KeywordLengthOfAs.ToString();
            chk_addSemicolon.Checked =  Properties.Settings.Default.addSemicolon;

            SetFormatter();
            _settingsLoaded = true;
        }


        private void SetFormatter()
        {
            ISqlTreeFormatter innerFormatter;
            innerFormatter = new BaiSqlFormatLib.Formatters.TSqlStandardFormatter(new BaiSqlFormatLib.Formatters.TSqlStandardFormatterOptions
            {
                IndentString = "\\s\\s\\s\\s", //缩进内容
                SpacesPerTab = 4,
                MaxLineWidth = Properties.Settings.Default.MaxLineWidth, //单行字符串最大长度
                ExpandCommaLists = Properties.Settings.Default.ExpandCommaLists,  //false 字段换行 
                KeywordAlign = Properties.Settings.Default.KeywordAlign,     //字段对齐
                TrailingCommas = true,   //true 逗号在字段之后
                SpaceAfterExpandedComma = true,  //true 逗号后追加空格
                ExpandBooleanExpressions = Properties.Settings.Default.ExpandBooleanExpressions,  //true 条件换行
                ExpandCaseStatements = Properties.Settings.Default.ExpandCaseStatements,      //true case when换行
                ExpandBetweenConditions = Properties.Settings.Default.ExpandBetweenConditions,  //true between 换行
                ExpandInLists = Properties.Settings.Default.ExpandInLists,   //true in 内容换行
                BreakJoinOnSections = Properties.Settings.Default.BreakJoinOnSections, //true join on中on 条件换行
                UppercaseKeywords = Properties.Settings.Default.UppercaseKeywords, //true 关键字大写
                AllUpper = Properties.Settings.Default.AllUpper, //true 全部大写
                HTMLColoring = true, //true HTML颜色标记 默认为true
                KeywordStandardization = true,//true 关键字标准化
                NewStatementLineBreaks = 2, //新语句换行数
                NewClauseLineBreaks =1,//遇到关键字 换行数
                AllIndent = Properties.Settings.Default.AllIndent, //整体缩进一个IndentString
                AsAlign = Properties.Settings.Default.AsAlign, //true as对齐
                KeywordLengthOfAs = Properties.Settings.Default.KeywordLengthOfAs //as字段的最大长度
            });

            _formatter = new BaiSqlFormatLib.Formatters.HtmlPageWrapper(innerFormatter);
        }


        private void SaveFormatSettings()
        {
            //设置默认选项
            if (chk_default.Checked)
            {
                Properties.Settings.Default.addSemicolon = true;
                Properties.Settings.Default.chkdefault = true;
                Properties.Settings.Default.MaxLineWidth = 170;
                Properties.Settings.Default.ExpandCommaLists = true;  
                Properties.Settings.Default.KeywordAlign = true; 
                Properties.Settings.Default.ExpandBooleanExpressions = true;
                Properties.Settings.Default.ExpandCaseStatements = true;
                Properties.Settings.Default.ExpandBetweenConditions = false;
                Properties.Settings.Default.ExpandInLists = false;
                Properties.Settings.Default.BreakJoinOnSections = true;
                Properties.Settings.Default.UppercaseKeywords = false;
                Properties.Settings.Default.AllUpper = false;
                Properties.Settings.Default.HTMLColoring = true;
                Properties.Settings.Default.AllIndent = true;
                Properties.Settings.Default.AsAlign = true;
                Properties.Settings.Default.KeywordLengthOfAs = 35;
            }
            else if(chk_custom.Checked)
            {
                Properties.Settings.Default.addSemicolon = chk_addSemicolon.Checked;
                Properties.Settings.Default.chkdefault = false;
                Properties.Settings.Default.MaxLineWidth = int.Parse(txt_maxWidth.Text);
                Properties.Settings.Default.ExpandCommaLists = !chk_columnNotNewline.Checked; 
                Properties.Settings.Default.KeywordAlign = chk_keywordAlign.Checked;     
                Properties.Settings.Default.ExpandBooleanExpressions = chk_conditionNewline.Checked;  
                Properties.Settings.Default.ExpandCaseStatements = chk_expandCase.Checked;      
                Properties.Settings.Default.ExpandBetweenConditions = chk_expandBetween.Checked;  
                Properties.Settings.Default.ExpandInLists = chk_expandIn.Checked;   
                Properties.Settings.Default.BreakJoinOnSections = chk_expandOn.Checked; 
                Properties.Settings.Default.AllUpper = chk_allUpper.Checked;
                if (chk_allUpper.Checked)
                    Properties.Settings.Default.UppercaseKeywords = true;
                else
                    Properties.Settings.Default.UppercaseKeywords = chk_uppercaseKeywords.Checked;
                Properties.Settings.Default.HTMLColoring = chk_coloring.Checked; 
                Properties.Settings.Default.AllIndent = chk_allIndent.Checked; 
                Properties.Settings.Default.AsAlign = chk_asAlign.Checked; 
                Properties.Settings.Default.KeywordLengthOfAs = int.Parse(txt_asMaxWidth.Text);
            }
            Properties.Settings.Default.Save();
        }

        private void TryToDoFormatting()
        {
            lock (_refreshLock)
            {
                if (timer_TextChangeDelay.Enabled)
                    _queuedRefresh = true;
                else
                {
                    DoFormatting();
                    timer_TextChangeDelay.Start();
                }
            }
        }



        //记录SQL格式调整信息
        string strErrorReturn = string.Empty;

        private void DoFormatting()
        {
            strErrorReturn = "";
            const string txtNewLine = "\r\n---------------------------------------------------------------------------------------------------------------------------------------------------------\r\n\r\n";
            StringBuilder errorReturn = new StringBuilder();
            errorReturn.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            errorReturn.Append("输入SQL：\r\n" + txt_input.Text + txtNewLine);

            string _inputSql = txt_input.Text.ToLower();
            if (Properties.Settings.Default.AllUpper)
                _inputSql = _inputSql.ToUpper();

            string[] sqlInput = _inputSql.Split(new string[] { ";" }, StringSplitOptions.None);
            string SqlHtml = string.Empty;
            int index = 0;
            
            foreach (var sql in sqlInput)
            {
                string sql_new = string.Empty;
                if (sql.Trim() != "")
                {
                    index++;
                    sql_new = sql;
                    if (Properties.Settings.Default.addSemicolon)
                        sql_new += ";";
                    var tokenizedSql = _tokenizer.TokenizeSQL(sql_new, sql_new.Length);
                    var parsedSql = _parser.ParseSQL(tokenizedSql);
                    string subSqlHtml = _formatter.FormatSQLTree(parsedSql);

                    if (!subSqlHtml.ToLower().Contains(">comment<") 
                         && !subSqlHtml.ToLower().Contains(">comment<") && !subSqlHtml.ToLower().Contains(">string<")
                        && !subSqlHtml.ToLower().Contains(">int<") && !subSqlHtml.ToLower().Contains(">bigint<")
                        && !subSqlHtml.ToLower().Contains(">partitioned<") &&
                        chk_default.Checked && SubstringCount(subSqlHtml, "\r\n") > 110)
                    {
                        Properties.Settings.Default.ExpandCommaLists = false;
                        Properties.Settings.Default.ExpandCaseStatements = false;
                        Properties.Settings.Default.AsAlign = false;
                        SetFormatter();

                        subSqlHtml = _formatter.FormatSQLTree(parsedSql);

                        Properties.Settings.Default.ExpandCommaLists = true;
                        Properties.Settings.Default.ExpandCaseStatements = true;
                        Properties.Settings.Default.AsAlign = true;
                        SetFormatter();
                    }
                    errorReturn.Append("第 " + index + " 个子SQL字段标记结果：\r\n" + tokenizedSql.PrettyPrint() + txtNewLine);
                    errorReturn.Append("第 " + index + " 个子SQL解析结果：\r\n" + parsedSql.ToXmlDoc().OuterXml + txtNewLine);
                    errorReturn.Append("第 " + index + " 个子SQL生成html结果：\r\n" + subSqlHtml + txtNewLine);
                    SqlHtml += subSqlHtml;
                }
            }

            if (!chk_coloring.Checked)
                SqlHtml = SqlHtml.Replace("#00AA00;", "#000000;").Replace("#AA0000;", "#000000;").Replace("#AA00AA;", "#000000;").Replace("#0000AA;", "#000000;").Replace("#777777;", "#000000;");

            webBrowser_output.SetHTML(SqlHtml);
            errorReturn.Append("最终生成html：\r\n" + SqlHtml);
            strErrorReturn = errorReturn.ToString();

            if (errorReturn.ToString().Contains(MessagingConstants.FormatErrorDefaultMessage))
            {
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "logs";
                WriteLog.WriteFormatLog(path, "formatErrLog.log", strErrorReturn);
            }
        }

        /// <summary>
        /// 判断子字符串在字符串中出现的次数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="substring">子字符串</param>
        /// <returns></returns>
        private int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }
            return 0;
        }


        private void timer_TextChangeDelay_Tick(object sender, EventArgs e)
        {
            timer_TextChangeDelay.Enabled = false;
            lock (_refreshLock)
            {
                if (_queuedRefresh)
                {
                    DoFormatting();
                    timer_TextChangeDelay.Start();
                    _queuedRefresh = false;
                }
            }
        }

        private void txt_input_TextChanged(object sender, EventArgs e)
        {
            TryToDoFormatting();
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            using (AboutBox about = new AboutBox())
                about.ShowDialog();
        }

        private void FormatSettingsControlChanged(object sender, EventArgs e)
        {
            if (!_settingsLoaded)
                return;

            if (chk_columnNotNewline.Checked && chk_custom.Checked)
                txt_maxWidth.Enabled = true;
            else
                txt_maxWidth.Enabled = false;
            if (chk_asAlign.Checked && chk_custom.Checked)
                txt_asMaxWidth.Enabled = true;
            else
                txt_asMaxWidth.Enabled = false;
            int maxWidth = 0;
            int asMaxWidth = 0;
            if (!int.TryParse(txt_maxWidth.Text, out maxWidth))
            {
                MessageBox.Show("请在【单行最大长度】中输入数字！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_maxWidth.Text = "170";
                return;
            }
            else if (maxWidth < 0 || maxWidth > 800)
            {
                MessageBox.Show("【单行最大长度】超出范围！最大值800 ", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txt_asMaxWidth.Text, out asMaxWidth))
            {
                MessageBox.Show("请在【字段最大长度】中输入数字！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_asMaxWidth.Text = "35";
                return;
            }
            else if (asMaxWidth < 0 || asMaxWidth > 500)
            {
                MessageBox.Show("【字段最大长度】超出范围！最大值500 ", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_asMaxWidth.Text = "35";
                return;
            }
            SaveFormatSettings();
            SetFormatter();
            TryToDoFormatting();
        }

        private void chk_default_CheckedChanged(object sender, EventArgs e)
        {
            if (!_settingsLoaded)
                return;

            if (chk_default.Checked)
            { 
                chk_custom.CheckState = CheckState.Unchecked;

                txt_maxWidth.Text = "170";
                chk_columnNotNewline.CheckState = CheckState.Unchecked;
                chk_keywordAlign.CheckState = CheckState.Checked;
                chk_conditionNewline.CheckState = CheckState.Checked;
                chk_expandCase.CheckState = CheckState.Checked;
                chk_expandBetween.CheckState = CheckState.Unchecked;
                chk_expandIn.CheckState = CheckState.Unchecked;
                chk_expandOn.CheckState = CheckState.Checked;
                chk_uppercaseKeywords.CheckState = CheckState.Unchecked;
                chk_allUpper.CheckState = CheckState.Unchecked;
                chk_coloring.CheckState = CheckState.Checked;
                chk_allIndent.CheckState = CheckState.Checked;
                chk_asAlign.CheckState = CheckState.Checked;
                txt_asMaxWidth.Text = "35";
                chk_addSemicolon.CheckState = CheckState.Checked;

                txt_maxWidth.Enabled = false;
                chk_columnNotNewline.Enabled = false;
                chk_keywordAlign.Enabled = false;
                chk_conditionNewline.Enabled = false;
                chk_expandCase.Enabled = false;
                chk_expandBetween.Enabled = false;
                chk_expandIn.Enabled = false;
                chk_expandOn.Enabled = false;
                chk_uppercaseKeywords.Enabled = false;
                chk_allUpper.Enabled = false;
                chk_coloring.Enabled = false;
                chk_allIndent.Enabled = false;
                chk_asAlign.Enabled = false;
                txt_asMaxWidth.Enabled = false;
                chk_addSemicolon.Enabled = false;
            }
            else
                chk_custom.CheckState = CheckState.Checked;

            FormatSettingsControlChanged(sender, e);
        }

        private void chk_custom_CheckedChanged(object sender, EventArgs e)
        {
            if (!_settingsLoaded)
                return;

            if (chk_custom.Checked)
            { 
                chk_default.CheckState = CheckState.Unchecked;
                chk_columnNotNewline.Enabled = true;
                chk_keywordAlign.Enabled = true;
                chk_conditionNewline.Enabled = true;
                chk_expandCase.Enabled = true;
                chk_expandBetween.Enabled = true;
                chk_expandIn.Enabled = true;
                chk_expandOn.Enabled = true;
                chk_uppercaseKeywords.Enabled = true;
                chk_allUpper.Enabled = true;
                chk_coloring.Enabled = true;
                chk_allIndent.Enabled = true;
                chk_asAlign.Enabled = true;
                chk_addSemicolon.Enabled = true;
                
            }
            else
                chk_default.CheckState = CheckState.Checked;
        }

        private void addFormatErrLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_input.Text) || string.IsNullOrEmpty(strErrorReturn))
            {
                MessageBox.Show("添加失败，输入信息为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(strErrorReturn))
            {
                MessageBox.Show("添加失败，格式调整日志为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "logs";
            WriteLog.WriteFormatLog(path, "formatErrLog.log", strErrorReturn);
            MessageBox.Show("已添加到错误日志！如有疑问，请联系作者", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
