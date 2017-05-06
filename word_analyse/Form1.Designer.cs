namespace word_analyse
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rtb_source = new System.Windows.Forms.RichTextBox();
            this.rtb_result = new System.Windows.Forms.RichTextBox();
            this.rtb_errors = new System.Windows.Forms.RichTextBox();
            this.file_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFile = new System.Windows.Forms.ToolStripMenuItem();
            this.textFont = new System.Windows.Forms.ToolStripMenuItem();
            this.analysis = new System.Windows.Forms.ToolStripMenuItem();
            this.errorInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.export_log = new System.Windows.Forms.ToolStripMenuItem();
            this.save_result = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_menu,
            this.textFont,
            this.analysis,
            this.errorInfo,
            this.save_result});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(740, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rtb_source
            // 
            this.rtb_source.Location = new System.Drawing.Point(12, 41);
            this.rtb_source.Name = "rtb_source";
            this.rtb_source.Size = new System.Drawing.Size(357, 422);
            this.rtb_source.TabIndex = 4;
            this.rtb_source.Text = "";
            // 
            // rtb_result
            // 
            this.rtb_result.Location = new System.Drawing.Point(450, 41);
            this.rtb_result.Name = "rtb_result";
            this.rtb_result.Size = new System.Drawing.Size(278, 207);
            this.rtb_result.TabIndex = 5;
            this.rtb_result.Text = "";
            // 
            // rtb_errors
            // 
            this.rtb_errors.Location = new System.Drawing.Point(450, 267);
            this.rtb_errors.Name = "rtb_errors";
            this.rtb_errors.Size = new System.Drawing.Size(278, 196);
            this.rtb_errors.TabIndex = 6;
            this.rtb_errors.Text = "";
            // 
            // file_menu
            // 
            this.file_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile,
            this.saveAs,
            this.closeFile});
            this.file_menu.Image = global::word_analyse.Properties.Resources.ffpic13051620466815_32;
            this.file_menu.Name = "file_menu";
            this.file_menu.Size = new System.Drawing.Size(60, 21);
            this.file_menu.Text = "文件";
            // 
            // openFile
            // 
            this.openFile.Image = global::word_analyse.Properties.Resources.Boomy_061;
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(152, 22);
            this.openFile.Text = "打开";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Image = global::word_analyse.Properties.Resources.ffpic1305160141633_32;
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(152, 22);
            this.saveFile.Text = "保存";
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // saveAs
            // 
            this.saveAs.Image = global::word_analyse.Properties.Resources.ffpic1305160141635_32;
            this.saveAs.Name = "saveAs";
            this.saveAs.Size = new System.Drawing.Size(152, 22);
            this.saveAs.Text = "另存为";
            this.saveAs.Click += new System.EventHandler(this.saveAs_Click);
            // 
            // closeFile
            // 
            this.closeFile.Image = global::word_analyse.Properties.Resources.chinaz24;
            this.closeFile.Name = "closeFile";
            this.closeFile.Size = new System.Drawing.Size(152, 22);
            this.closeFile.Text = "关闭";
            this.closeFile.Click += new System.EventHandler(this.closeFile_Click);
            // 
            // textFont
            // 
            this.textFont.Image = global::word_analyse.Properties.Resources.Boomy_032;
            this.textFont.Name = "textFont";
            this.textFont.Size = new System.Drawing.Size(60, 21);
            this.textFont.Text = "字体";
            this.textFont.Click += new System.EventHandler(this.textFont_Click);
            // 
            // analysis
            // 
            this.analysis.Image = global::word_analyse.Properties.Resources.Boomy_034;
            this.analysis.Name = "analysis";
            this.analysis.Size = new System.Drawing.Size(84, 21);
            this.analysis.Text = "词法分析";
            this.analysis.Click += new System.EventHandler(this.analysis_Click);
            // 
            // errorInfo
            // 
            this.errorInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.export_log});
            this.errorInfo.Image = global::word_analyse.Properties.Resources.Boomy_076;
            this.errorInfo.Name = "errorInfo";
            this.errorInfo.Size = new System.Drawing.Size(84, 21);
            this.errorInfo.Text = "错误信息";
            this.errorInfo.Click += new System.EventHandler(this.errorInfo_Click);
            // 
            // export_log
            // 
            this.export_log.Image = global::word_analyse.Properties.Resources.Boomy_031;
            this.export_log.Name = "export_log";
            this.export_log.Size = new System.Drawing.Size(148, 22);
            this.export_log.Text = "导出错误日志";
            this.export_log.Click += new System.EventHandler(this.export_log_Click);
            // 
            // save_result
            // 
            this.save_result.Image = global::word_analyse.Properties.Resources.Boomy_020;
            this.save_result.Name = "save_result";
            this.save_result.Size = new System.Drawing.Size(108, 21);
            this.save_result.Text = "保存分析结果";
            this.save_result.Click += new System.EventHandler(this.save_result_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(740, 475);
            this.Controls.Add(this.rtb_errors);
            this.Controls.Add(this.rtb_result);
            this.Controls.Add(this.rtb_source);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "词法分析器";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file_menu;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripMenuItem saveAs;
        private System.Windows.Forms.ToolStripMenuItem closeFile;
        private System.Windows.Forms.ToolStripMenuItem textFont;
        private System.Windows.Forms.ToolStripMenuItem analysis;
        private System.Windows.Forms.ToolStripMenuItem errorInfo;
        private System.Windows.Forms.RichTextBox rtb_source;
        private System.Windows.Forms.ToolStripMenuItem save_result;
        private System.Windows.Forms.RichTextBox rtb_result;
        private System.Windows.Forms.RichTextBox rtb_errors;
        private System.Windows.Forms.ToolStripMenuItem export_log;
    }
}

