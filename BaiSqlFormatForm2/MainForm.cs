using BaiSqlFormatForm2.FrameworkClassReplacements;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaiSqlFormatLib.Interfaces;
using BaiSqlFormatForm2.Others;
using BaiSqlFormatLib;

namespace BaiSqlFormatForm2
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        XtraUserControl formatUserControl;
        XtraUserControl parseLogUserControl;

        SelectableTextBox txt_input;
        CustomContentWebBrowser webBrowser;

        SelectableTextBox txt_tokenized;
        SelectableTextBox txt_parsed;


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

            formatUserControl = CreateUserControl("SQL格式调整");
            parseLogUserControl = CreateUserControl("SQL解析记录");
            accordionControl.SelectedElement = formatAccordionControlElement;

            _tokenizer = new BaiSqlFormatLib.Tokenizers.TSqlStandardTokenizer();
            _parser = new BaiSqlFormatLib.Parsers.TSqlStandardParser();

            if (Properties.Settings.Default.chkdefault)
            {
                ts_default.EditValue = true;

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
                ts_custom.EditValue = true;

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
                NewClauseLineBreaks = 1,//遇到关键字 换行数
                AllIndent = Properties.Settings.Default.AllIndent, //整体缩进一个IndentString
                AsAlign = Properties.Settings.Default.AsAlign, //true as对齐
                KeywordLengthOfAs = Properties.Settings.Default.KeywordLengthOfAs //as字段的最大长度
            });

            _formatter = new BaiSqlFormatLib.Formatters.HtmlPageWrapper(innerFormatter);
        }

        private void SaveFormatSettings()
        {
            //设置默认选项
            if (ts_default.IsOn)
            {
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
            else if (ts_custom.IsOn)
            {
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

        public void TryToDoFormatting()
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

        public void DoFormatting()
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
            string SqlTokenized = string.Empty;
            string SqlParsed = string.Empty;
            int index = 0;

            foreach (var sql in sqlInput)
            {
                if (sql.Trim() != "")
                {
                    index++;
                    var tokenizedSql = _tokenizer.TokenizeSQL(sql + ";", sql.Length);
                    string subSqlTokenized = tokenizedSql.PrettyPrint();
                    var parsedSql = _parser.ParseSQL(tokenizedSql);
                    string subSqlParsed = parsedSql.ToXmlDoc().OuterXml;
                    string subSqlHtml = _formatter.FormatSQLTree(parsedSql);

                    if (!subSqlHtml.ToLower().Contains(">comment<")
                         && !subSqlHtml.ToLower().Contains(">comment<") && !subSqlHtml.ToLower().Contains(">string<")
                        && !subSqlHtml.ToLower().Contains(">int<") && !subSqlHtml.ToLower().Contains(">bigint<")
                        && !subSqlHtml.ToLower().Contains(">partitioned<") &&
                        ts_default.IsOn && SubstringCount(subSqlHtml, "\r\n") > 110)
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
                    errorReturn.Append("第 " + index + " 个子SQL字段标记结果：\r\n" + subSqlTokenized + txtNewLine);
                    errorReturn.Append("第 " + index + " 个子SQL解析结果：\r\n" + subSqlParsed + txtNewLine);
                    errorReturn.Append("第 " + index + " 个子SQL生成html结果：\r\n" + subSqlHtml + txtNewLine);
                    SqlHtml += subSqlHtml;
                    if(index > 1)
                        SqlTokenized += "------------------------分割线------------------------\r\n";
                    SqlTokenized += subSqlTokenized;
                    SqlParsed += subSqlParsed;
                }
            }

            if (!chk_coloring.Checked)
                SqlHtml = SqlHtml.Replace("#00AA00;", "#000000;").Replace("#AA0000;", "#000000;").Replace("#AA00AA;", "#000000;").Replace("#0000AA;", "#000000;").Replace("#777777;", "#000000;");

            webBrowser.SetHTML(SqlHtml);
            txt_tokenized.Text = SqlTokenized;
            txt_parsed.Text = SqlParsed;

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

        public void txt_input_TextChanged(object sender, EventArgs e)
        {
            TryToDoFormatting();
        }

        private void FormatSettingsControlChanged(object sender, EventArgs e)
        {
            if (!_settingsLoaded)
                return;

            if (chk_columnNotNewline.Checked && ts_custom.IsOn)
                txt_maxWidth.Enabled = true;
            else
                txt_maxWidth.Enabled = false;
            if (chk_asAlign.Checked && ts_custom.IsOn)
                txt_asMaxWidth.Enabled = true;
            else
                txt_asMaxWidth.Enabled = false;
            int maxWidth = 0;
            int asMaxWidth = 0;
            if (!int.TryParse(txt_maxWidth.Text, out maxWidth))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请在【单行最大长度】中输入数字！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_maxWidth.Text = "170";
                return;
            }
            else if (maxWidth < 0 || maxWidth > 800)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("【单行最大长度】超出范围！最大值800 ", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txt_asMaxWidth.Text, out asMaxWidth))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请在【字段最大长度】中输入数字！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_asMaxWidth.Text = "35";
                return;
            }
            else if (asMaxWidth < 0 || asMaxWidth > 500)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("【字段最大长度】超出范围！最大值500 ", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_asMaxWidth.Text = "35";
                return;
            }
            SaveFormatSettings();
            SetFormatter();
            TryToDoFormatting();
        }

        private void ts_default_Toggled(object sender, EventArgs e)
        {
            if (!_settingsLoaded)
                return;

            if (ts_default.IsOn)
            {
                ts_custom.EditValue = false;

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
                ts_custom.EditValue = true;

            FormatSettingsControlChanged(sender, e);
        }

        private void ts_custom_Toggled(object sender, EventArgs e)
        {
            if (!_settingsLoaded)
                return;

            if (ts_custom.IsOn)
            {
                ts_default.EditValue = false;
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

            }
            else
                ts_default.EditValue = true;
        }




        XtraUserControl CreateUserControl(string text)
        {
            XtraUserControl result = new XtraUserControl();
            result.Name = text.ToLower() + "UserControl";
            result.Text = text;
            LabelControl label = new LabelControl();
            label.Parent = result;
            label.Appearance.Font = new Font("Tahoma", 25.25F);
            label.Appearance.ForeColor = Color.Gray;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.AutoSizeMode = LabelAutoSizeMode.None;
            label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;


            SplitContainerControl scc = new SplitContainerControl();
            scc.Parent = label;
            scc.Dock = System.Windows.Forms.DockStyle.Fill;
            scc.Appearance.ForeColor = Color.Gray;
            scc.PanelVisibility = SplitPanelVisibility.Both;
            scc.SplitterPosition = 500;

            GroupControl control1 = new GroupControl();
            control1.Parent = scc.Panel1;
            control1.Dock = System.Windows.Forms.DockStyle.Fill;

            GroupControl control2 = new GroupControl();
            control2.Parent = scc.Panel2;
            control2.Dock = System.Windows.Forms.DockStyle.Fill;

            if (text == "SQL格式调整")
            {
                control1.Text = "输入SQL";
                control2.Text = "输出SQL";

                txt_input = new SelectableTextBox();
                txt_input.Parent = control1;
                txt_input.Dock = System.Windows.Forms.DockStyle.Fill;
                txt_input.Multiline = true;
                txt_input.Font = new Font("Consolas", 8.5F);
                txt_input.ScrollBars = ScrollBars.Both;
                this.txt_input.TextChanged += new System.EventHandler(this.txt_input_TextChanged);

                webBrowser = new CustomContentWebBrowser();
                webBrowser.Parent = control2;
                webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            else if (text == "SQL解析记录")
            {
                control1.Text = "SQL字段标记结果";
                control2.Text = "SQL解析结果(XML)";

                scc.SplitterPosition = 570;
                txt_tokenized = new SelectableTextBox();
                txt_tokenized.Parent = control1;
                txt_tokenized.Dock = System.Windows.Forms.DockStyle.Fill;
                txt_tokenized.Multiline = true;
                txt_tokenized.ReadOnly = true;
                txt_tokenized.ScrollBars = ScrollBars.Both;

                txt_parsed = new SelectableTextBox();
                txt_parsed.Parent = control2;
                txt_parsed.Dock = System.Windows.Forms.DockStyle.Fill;
                txt_parsed.Multiline = true;
                txt_parsed.ReadOnly = true;
                txt_parsed.ScrollBars = ScrollBars.Both;
            }

            return result;
        }
        void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            if (e.Element == null) return;
            XtraUserControl userControl = e.Element.Text == "SQL格式调整" ? formatUserControl : parseLogUserControl;
            tabbedView.AddDocument(userControl);
            tabbedView.ActivateDocument(userControl);
        }
        void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            int barItemIndex = barSubItem1.ItemLinks.IndexOf(e.Link);
            accordionControl.SelectedElement = mainAccordionGroup.Elements[barItemIndex];
        }
        void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            RecreateUserControls(e);
            SetAccordionSelectedElement(e);
        }
        void SetAccordionSelectedElement(DocumentEventArgs e)
        {
            if (tabbedView.Documents.Count != 0)
            {
                if (e.Document.Caption == "SQL格式调整") accordionControl.SelectedElement = parseLogAccordionControlElement;
                else accordionControl.SelectedElement = formatAccordionControlElement;
            }
            else
            {
                accordionControl.SelectedElement = null;
            }
        }
        void RecreateUserControls(DocumentEventArgs e)
        {
            if (e.Document.Caption == "SQL格式调整") formatUserControl = CreateUserControl("SQL格式调整");
            else parseLogUserControl = CreateUserControl("SQL解析记录");
        }

        private void btn_addFormatErrLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_input.Text) || string.IsNullOrEmpty(strErrorReturn))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("添加失败，输入信息为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(strErrorReturn))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("添加失败，格式调整日志为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "logs";
            WriteLog.WriteFormatLog(path, "formatErrLog.log", strErrorReturn);
            DevExpress.XtraEditors.XtraMessageBox.Show("已添加到错误日志！如有疑问，请联系作者", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_about_ItemClick(object sender, ItemClickEventArgs e)
        {
            AboutBox about = new BaiSqlFormatForm2.AboutBox();
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
        }
    }
}
