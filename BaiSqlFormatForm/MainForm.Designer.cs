namespace BaiSqlFormatForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webBrowser_output = new BaiSqlFormatForm.FrameworkClassReplacements.CustomContentWebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_maxWidth = new System.Windows.Forms.TextBox();
            this.txt_asMaxWidth = new System.Windows.Forms.TextBox();
            this.chk_default = new System.Windows.Forms.CheckBox();
            this.chk_asAlign = new System.Windows.Forms.CheckBox();
            this.chk_conditionNewline = new System.Windows.Forms.CheckBox();
            this.chk_uppercaseKeywords = new System.Windows.Forms.CheckBox();
            this.chk_allUpper = new System.Windows.Forms.CheckBox();
            this.chk_keywordAlign = new System.Windows.Forms.CheckBox();
            this.chk_columnNotNewline = new System.Windows.Forms.CheckBox();
            this.chk_allIndent = new System.Windows.Forms.CheckBox();
            this.chk_expandCase = new System.Windows.Forms.CheckBox();
            this.chk_coloring = new System.Windows.Forms.CheckBox();
            this.chk_custom = new System.Windows.Forms.CheckBox();
            this.chk_expandOn = new System.Windows.Forms.CheckBox();
            this.chk_expandIn = new System.Windows.Forms.CheckBox();
            this.chk_expandBetween = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_input = new BaiSqlFormatForm.FrameworkClassReplacements.SelectableTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addFormatErrLog = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_TextChangeDelay = new System.Windows.Forms.Timer();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser_output);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 591);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出SQL";
            // 
            // webBrowser_output
            // 
            this.webBrowser_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_output.Location = new System.Drawing.Point(3, 17);
            this.webBrowser_output.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_output.Name = "webBrowser_output";
            this.webBrowser_output.Size = new System.Drawing.Size(883, 571);
            this.webBrowser_output.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_maxWidth);
            this.splitContainer1.Panel2.Controls.Add(this.txt_asMaxWidth);
            this.splitContainer1.Panel2.Controls.Add(this.chk_default);
            this.splitContainer1.Panel2.Controls.Add(this.chk_asAlign);
            this.splitContainer1.Panel2.Controls.Add(this.chk_conditionNewline);
            this.splitContainer1.Panel2.Controls.Add(this.chk_uppercaseKeywords);
            this.splitContainer1.Panel2.Controls.Add(this.chk_allUpper);
            this.splitContainer1.Panel2.Controls.Add(this.chk_keywordAlign);
            this.splitContainer1.Panel2.Controls.Add(this.chk_columnNotNewline);
            this.splitContainer1.Panel2.Controls.Add(this.chk_allIndent);
            this.splitContainer1.Panel2.Controls.Add(this.chk_expandCase);
            this.splitContainer1.Panel2.Controls.Add(this.chk_coloring);
            this.splitContainer1.Panel2.Controls.Add(this.chk_custom);
            this.splitContainer1.Panel2.Controls.Add(this.chk_expandOn);
            this.splitContainer1.Panel2.Controls.Add(this.chk_expandIn);
            this.splitContainer1.Panel2.Controls.Add(this.chk_expandBetween);
            this.splitContainer1.Size = new System.Drawing.Size(1198, 591);
            this.splitContainer1.SplitterDistance = 889;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "格式调整选项";
            // 
            // txt_maxWidth
            // 
            this.txt_maxWidth.Location = new System.Drawing.Point(226, 125);
            this.txt_maxWidth.Name = "txt_maxWidth";
            this.txt_maxWidth.Size = new System.Drawing.Size(39, 21);
            this.txt_maxWidth.TabIndex = 7;
            this.txt_maxWidth.Text = "170";
            this.txt_maxWidth.TextChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // txt_asMaxWidth
            // 
            this.txt_asMaxWidth.Location = new System.Drawing.Point(210, 542);
            this.txt_asMaxWidth.Name = "txt_asMaxWidth";
            this.txt_asMaxWidth.Size = new System.Drawing.Size(39, 21);
            this.txt_asMaxWidth.TabIndex = 17;
            this.txt_asMaxWidth.Text = "35";
            this.txt_asMaxWidth.TextChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_default
            // 
            this.chk_default.AutoSize = true;
            this.chk_default.Location = new System.Drawing.Point(40, 48);
            this.chk_default.Name = "chk_default";
            this.chk_default.Size = new System.Drawing.Size(132, 16);
            this.chk_default.TabIndex = 0;
            this.chk_default.Text = "智能选择(推荐使用)";
            this.chk_default.UseVisualStyleBackColor = true;
            this.chk_default.CheckedChanged += new System.EventHandler(this.chk_default_CheckedChanged);
            // 
            // chk_asAlign
            // 
            this.chk_asAlign.AutoSize = true;
            this.chk_asAlign.Location = new System.Drawing.Point(61, 544);
            this.chk_asAlign.Name = "chk_asAlign";
            this.chk_asAlign.Size = new System.Drawing.Size(150, 16);
            this.chk_asAlign.TabIndex = 15;
            this.chk_asAlign.Text = "AS 对齐，字段最大长度";
            this.chk_asAlign.UseVisualStyleBackColor = true;
            this.chk_asAlign.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_conditionNewline
            // 
            this.chk_conditionNewline.AutoSize = true;
            this.chk_conditionNewline.Location = new System.Drawing.Point(61, 200);
            this.chk_conditionNewline.Name = "chk_conditionNewline";
            this.chk_conditionNewline.Size = new System.Drawing.Size(72, 16);
            this.chk_conditionNewline.TabIndex = 2;
            this.chk_conditionNewline.Text = "条件换行";
            this.chk_conditionNewline.UseVisualStyleBackColor = true;
            this.chk_conditionNewline.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_uppercaseKeywords
            // 
            this.chk_uppercaseKeywords.AutoSize = true;
            this.chk_uppercaseKeywords.Location = new System.Drawing.Point(61, 235);
            this.chk_uppercaseKeywords.Name = "chk_uppercaseKeywords";
            this.chk_uppercaseKeywords.Size = new System.Drawing.Size(84, 16);
            this.chk_uppercaseKeywords.TabIndex = 14;
            this.chk_uppercaseKeywords.Text = "关键字大写";
            this.chk_uppercaseKeywords.UseVisualStyleBackColor = true;
            this.chk_uppercaseKeywords.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_allUpper
            // 
            this.chk_allUpper.AutoSize = true;
            this.chk_allUpper.Location = new System.Drawing.Point(61, 275);
            this.chk_allUpper.Name = "chk_allUpper";
            this.chk_allUpper.Size = new System.Drawing.Size(90, 16);
            this.chk_allUpper.TabIndex = 4;
            this.chk_allUpper.Text = "SQL全部大写";
            this.chk_allUpper.UseVisualStyleBackColor = true;
            this.chk_allUpper.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_keywordAlign
            // 
            this.chk_keywordAlign.AutoSize = true;
            this.chk_keywordAlign.Location = new System.Drawing.Point(61, 165);
            this.chk_keywordAlign.Name = "chk_keywordAlign";
            this.chk_keywordAlign.Size = new System.Drawing.Size(72, 16);
            this.chk_keywordAlign.TabIndex = 13;
            this.chk_keywordAlign.Text = "字段对齐";
            this.chk_keywordAlign.UseVisualStyleBackColor = true;
            this.chk_keywordAlign.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_columnNotNewline
            // 
            this.chk_columnNotNewline.AutoSize = true;
            this.chk_columnNotNewline.Location = new System.Drawing.Point(61, 127);
            this.chk_columnNotNewline.Name = "chk_columnNotNewline";
            this.chk_columnNotNewline.Size = new System.Drawing.Size(168, 16);
            this.chk_columnNotNewline.TabIndex = 5;
            this.chk_columnNotNewline.Text = "字段不换行，单行最大长度";
            this.chk_columnNotNewline.UseVisualStyleBackColor = true;
            this.chk_columnNotNewline.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_allIndent
            // 
            this.chk_allIndent.AutoSize = true;
            this.chk_allIndent.Location = new System.Drawing.Point(61, 507);
            this.chk_allIndent.Name = "chk_allIndent";
            this.chk_allIndent.Size = new System.Drawing.Size(72, 16);
            this.chk_allIndent.TabIndex = 12;
            this.chk_allIndent.Text = "整体缩进";
            this.chk_allIndent.UseVisualStyleBackColor = true;
            this.chk_allIndent.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_expandCase
            // 
            this.chk_expandCase.AutoSize = true;
            this.chk_expandCase.Location = new System.Drawing.Point(61, 312);
            this.chk_expandCase.Name = "chk_expandCase";
            this.chk_expandCase.Size = new System.Drawing.Size(108, 16);
            this.chk_expandCase.TabIndex = 6;
            this.chk_expandCase.Text = "展开 CASE 语句";
            this.chk_expandCase.UseVisualStyleBackColor = true;
            this.chk_expandCase.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_coloring
            // 
            this.chk_coloring.AutoSize = true;
            this.chk_coloring.Location = new System.Drawing.Point(61, 468);
            this.chk_coloring.Name = "chk_coloring";
            this.chk_coloring.Size = new System.Drawing.Size(72, 16);
            this.chk_coloring.TabIndex = 11;
            this.chk_coloring.Text = "启用着色";
            this.chk_coloring.UseVisualStyleBackColor = true;
            this.chk_coloring.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_custom
            // 
            this.chk_custom.AutoSize = true;
            this.chk_custom.Location = new System.Drawing.Point(40, 89);
            this.chk_custom.Name = "chk_custom";
            this.chk_custom.Size = new System.Drawing.Size(60, 16);
            this.chk_custom.TabIndex = 1;
            this.chk_custom.Text = "自定义";
            this.chk_custom.UseVisualStyleBackColor = true;
            this.chk_custom.CheckedChanged += new System.EventHandler(this.chk_custom_CheckedChanged);
            // 
            // chk_expandOn
            // 
            this.chk_expandOn.AutoSize = true;
            this.chk_expandOn.Location = new System.Drawing.Point(61, 430);
            this.chk_expandOn.Name = "chk_expandOn";
            this.chk_expandOn.Size = new System.Drawing.Size(108, 16);
            this.chk_expandOn.TabIndex = 10;
            this.chk_expandOn.Text = "关键字 ON 换行";
            this.chk_expandOn.UseVisualStyleBackColor = true;
            this.chk_expandOn.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_expandIn
            // 
            this.chk_expandIn.AutoSize = true;
            this.chk_expandIn.Location = new System.Drawing.Point(61, 391);
            this.chk_expandIn.Name = "chk_expandIn";
            this.chk_expandIn.Size = new System.Drawing.Size(96, 16);
            this.chk_expandIn.TabIndex = 9;
            this.chk_expandIn.Text = "展开 IN 列表";
            this.chk_expandIn.UseVisualStyleBackColor = true;
            this.chk_expandIn.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // chk_expandBetween
            // 
            this.chk_expandBetween.AutoSize = true;
            this.chk_expandBetween.Location = new System.Drawing.Point(61, 352);
            this.chk_expandBetween.Name = "chk_expandBetween";
            this.chk_expandBetween.Size = new System.Drawing.Size(126, 16);
            this.chk_expandBetween.TabIndex = 8;
            this.chk_expandBetween.Text = "展开 BETWEEN 条件";
            this.chk_expandBetween.UseVisualStyleBackColor = true;
            this.chk_expandBetween.CheckedChanged += new System.EventHandler(this.FormatSettingsControlChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1198, 894);
            this.splitContainer2.SplitterDistance = 299;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_input);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1198, 274);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输入SQL";
            // 
            // txt_input
            // 
            this.txt_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_input.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.txt_input.Location = new System.Drawing.Point(3, 17);
            this.txt_input.Multiline = true;
            this.txt_input.Name = "txt_input";
            this.txt_input.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_input.Size = new System.Drawing.Size(1192, 254);
            this.txt_input.TabIndex = 0;
            this.txt_input.WordWrap = false;
            this.txt_input.TextChanged += new System.EventHandler(this.txt_input_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFormatErrLog,
            this.ToolStripMenuItemAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1198, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addFormatErrLog
            // 
            this.addFormatErrLog.Name = "addFormatErrLog";
            this.addFormatErrLog.Size = new System.Drawing.Size(104, 21);
            this.addFormatErrLog.Text = "添加到错误日志";
            this.addFormatErrLog.Click += new System.EventHandler(this.addFormatErrLog_Click);
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItemAbout.Text = "关于";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // timer_TextChangeDelay
            // 
            this.timer_TextChangeDelay.Interval = 500;
            this.timer_TextChangeDelay.Tick += new System.EventHandler(this.timer_TextChangeDelay_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 894);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SQL代码格式调整工具 v1.0";
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private BaiSqlFormatForm.FrameworkClassReplacements.CustomContentWebBrowser webBrowser_output;
        private BaiSqlFormatForm.FrameworkClassReplacements.SelectableTextBox txt_input;
        private System.Windows.Forms.CheckBox chk_coloring;
        private System.Windows.Forms.CheckBox chk_expandOn;
        private System.Windows.Forms.CheckBox chk_expandIn;
        private System.Windows.Forms.CheckBox chk_expandBetween;
        private System.Windows.Forms.TextBox txt_maxWidth;
        private System.Windows.Forms.CheckBox chk_custom;
        private System.Windows.Forms.CheckBox chk_expandCase;
        private System.Windows.Forms.CheckBox chk_default;
        private System.Windows.Forms.CheckBox chk_columnNotNewline;
        private System.Windows.Forms.CheckBox chk_allUpper;
        private System.Windows.Forms.CheckBox chk_conditionNewline;
        private System.Windows.Forms.Timer timer_TextChangeDelay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
        private System.Windows.Forms.CheckBox chk_allIndent;
        private System.Windows.Forms.CheckBox chk_keywordAlign;
        private System.Windows.Forms.CheckBox chk_uppercaseKeywords;
        private System.Windows.Forms.CheckBox chk_asAlign;
        private System.Windows.Forms.TextBox txt_asMaxWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem addFormatErrLog;
    }
}

