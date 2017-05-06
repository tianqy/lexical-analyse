using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace word_analyse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();   //打开文件对话框
        //string source = "";     //待分析字符串

        //导入文件
        private void openFile_Click(object sender, EventArgs e)
        {
            string fname = "";
            openFileDialog.Filter = "文本文件（*.txt)|*.txt";
            openFileDialog.Title = "打开文件";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog.FileName;
            }
            if(fname!="")
                rtb_source.LoadFile(fname, RichTextBoxStreamType.PlainText);
            //source = rtb_source.Text;
        }

        //保存
        private void saveFile_Click(object sender, EventArgs e)
        {
            
            string fname=openFileDialog.FileName;
            rtb_source.SaveFile(fname, RichTextBoxStreamType.PlainText);
        }

        //另存为
        private void saveAs_Click(object sender, EventArgs e)
        {
            string fname;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            fname = saveFileDialog.FileName;
            if (fname != "")
                rtb_source.SaveFile(fname, RichTextBoxStreamType.PlainText);
        }

        //关闭
        private void closeFile_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //设置字体
        private void textFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = rtb_source.SelectionFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
                rtb_source.SelectionFont = fontDialog.Font;
        }

        //词法分析
        private void analysis_Click(object sender, EventArgs e)
        {
            string source = "";
            source = rtb_source.Text;
            rtb_result.Clear();
            string result = "词法分析结果：\r\n";     //首行添加提示
            List<Token> list = new List<Token>();    //创建自定义集合对象
            list=Analysis.analyse(source);  //接受分析结果的返回值
            foreach (Token token in list)   //遍历分析结果
            {
                result = result + "(" + token.Code + "," + token.Value + ")\r\n";   //添加一条记录
            }
            rtb_result.Text = result;    //分析结果在tb_result文本框中显示
        }

        //错误详情
        private void errorInfo_Click(object sender, EventArgs e)
        {
            rtb_errors.Clear();
            string errors = Analysis.error();   //接受分析返回错误信息
            if (errors == "")
                rtb_errors.Text = "词法分析未发现错误";
            else
            {
                
                rtb_errors.Text = "错误信息：\r\n" + errors;  //显示错误信息
                List<int> error_position = Analysis.errorsPosition();
                int error_count = error_position.Count;
                if (error_count > 0)
                {
                    string text = rtb_source.Text;
                    rtb_source.Clear();
                    rtb_source.SelectionColor = Color.Black;
                    rtb_source.AppendText(text.Substring(0,error_position.ElementAt(0)));
                    rtb_source.SelectionColor = Color.Red;
                    rtb_source.AppendText(text[error_position.ElementAt(0)]+"");
                    rtb_source.SelectionColor = Color.Black;
                    rtb_source.AppendText(text.Substring(error_position.ElementAt(0)+1));

                }
            }
        }

        //词法分析结果存入文件
        private void save_result_Click(object sender, EventArgs e)
        {
            string fname;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter="文本文件（*.txt)|*.txt";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            fname = saveFileDialog.FileName;
            if (fname != "")
            {
                rtb_result.SaveFile(fname, RichTextBoxStreamType.PlainText);
            }
        }

        //错误信息导出日志
        private void export_log_Click(object sender, EventArgs e)
        {
            string fname;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "日志文件（*.log)|*.log";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            fname = saveFileDialog.FileName;
            if (fname != ""&&rtb_errors.Text.Trim()!=null)
            {
                rtb_errors.SaveFile(fname, RichTextBoxStreamType.PlainText);
            }
        }

    }

}
