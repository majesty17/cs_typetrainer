using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_typetrainer
{
    public partial class Form1 : Form
    {

        private DateTime st;
        private Boolean ingame;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ingame = false;
        }
        private void textBox_input_TextChanged(object sender, EventArgs e)
        {
            string current_text = textBox_input.Text;
            string model_text = richTextBox_show.Text;
            //是前缀否
            if (model_text.IndexOf(current_text) == 0)
            {
                Console.Out.WriteLine("sub index !");
                int len = current_text.Length;
                //先重置当前颜色
                richTextBox_show.SelectAll();
                richTextBox_show.SelectionColor = Color.Black;
                //已经打印的设置红色
                richTextBox_show.SelectionStart = 0;
                richTextBox_show.SelectionLength = len;
                richTextBox_show.SelectionColor = Color.Red;
                //从第一次匹配算游戏开始
                if (ingame == false)
                {
                    ingame = true;
                    st = DateTime.UtcNow;
                }
            }


            //是否全部完成
            if (model_text == current_text)
            {
                //打印耗时，速度
                var diff = DateTime.UtcNow - st;//.TotalSeconds;
                var sec = diff.TotalSeconds + diff.Milliseconds / 1000.0;
                MessageBox.Show("total sec:        <" + sec +
                            "> \ntotal characters: <" + model_text.Length +
                            "> \nspeed:            <" + String.Format("{0:0.00}> c/min",
                    (model_text.Length / sec * 60)));
                //恢复颜色
                richTextBox_show.SelectAll();
                richTextBox_show.SelectionColor = Color.Black;
                //置为非游戏状态
                ingame = false;

            }
        }


    }
}
