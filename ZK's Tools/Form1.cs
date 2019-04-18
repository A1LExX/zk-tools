using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZK_s_Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.weizhaokun.cn");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ZK's Tools \n   当前版本v1.0.0\n  更新时间：2019/04/17");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ZK's Tools \n   当前版本v1.0.0\n  更新时间：2019/04/17");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你确定要退出？取消则最小化到托盘", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
            {
                e.Cancel = true;
                this.Hide();
                int tipShowMilliseconds = 1000;
                string tipTitle = "ZK工具箱已经隐藏";
                string tipContent = "单击击托盘图标以启用";
                ToolTipIcon tipType = ToolTipIcon.Info;
                notifyIcon1.ShowBalloonTip(tipShowMilliseconds, tipTitle, tipContent, tipType);
            }
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
            }
            else
            {
                this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        //进制转换
        private void ten_but_Click(object sender, EventArgs e)
        {
            string t = ten.Text;
            if (t.Contains("-"))
            {                
                t = t.Substring(1, t.Length - 1);
                if (ten_judge(t))
                {                 
                    setChange(t, 101);
                }
            }
            else if (ten_judge(t))
            {
                setChange(t, 10);
            }
        }

        public void setChange(string t, int aa)
        {
            if (aa == 10)
            {
                int a1;
                int.TryParse(t, out a1);
                two.Text = Convert.ToString(a1, 2);
                eight.Text = Convert.ToString(a1, 8);
                sixteen.Text = Convert.ToString(a1, 16);
            }
            else if (aa == 2)
            {
                ten.Text = (Convert.ToInt32(t, 2)).ToString();
                eight.Text = Convert.ToString(Convert.ToInt32(t, 2), 8);
                sixteen.Text = string.Format("{0:x}", Convert.ToInt32(t, 2));
            }
            else if (aa == 8)
            {
                ten.Text = Convert.ToInt32(t, 8).ToString();
                two.Text = Convert.ToString((Convert.ToInt32(t, 8)), 2);
                sixteen.Text = Convert.ToString((Convert.ToInt32(t, 8)), 16);
            }
            else if (aa == 16)
            {
                ten.Text = Convert.ToInt32(t, 16).ToString();
                two.Text = Convert.ToString((Convert.ToInt32(t, 16)), 2);
                eight.Text = Convert.ToString(Convert.ToInt32(t, 16), 8);
            }
            else if (aa == 101)
            {
                int a1;
                int.TryParse(t, out a1);
                two.Text = "-"+Convert.ToString(a1, 2);
                eight.Text = "-"+Convert.ToString(a1, 8);
                sixteen.Text = "-"+Convert.ToString(a1, 16);
            }
            else if (aa == 21)
            {
                ten.Text = "-" + (Convert.ToInt32(t, 2)).ToString();
                eight.Text = "-" + Convert.ToString(Convert.ToInt32(t, 2), 8);
                sixteen.Text = "-" + string.Format("{0:x}", Convert.ToInt32(t, 2));
            }
            else if (aa == 81)
            {
                ten.Text = "-" + Convert.ToInt32(t, 8).ToString();
                two.Text = "-" + Convert.ToString((Convert.ToInt32(t, 8)), 2);
                sixteen.Text = "-" + Convert.ToString((Convert.ToInt32(t, 8)), 16);
            }
            else if (aa == 161)
            {
                ten.Text = "-" + Convert.ToInt32(t, 16).ToString();
                two.Text = "-" + Convert.ToString((Convert.ToInt32(t, 16)), 2);
                eight.Text = "-" + Convert.ToString(Convert.ToInt32(t, 16), 8);
            }

        }

        private void two_but_Click(object sender, EventArgs e)
        {
            String tw = two.Text;
            if (tw.Contains("-"))
            {          
                tw = tw.Substring(1, tw.Length - 1);
                if (two_judge(tw))
                {
                    setChange(tw, 21);
                }
            }
            else if (two_judge(tw))
            {
                
                setChange(tw, 2);
            }
        }

        private void eight_but_Click(object sender, EventArgs e)
        {
            string t = eight.Text;
            if (two.Text.Contains("-"))
            {   
                t = t.Substring(1, t.Length - 1);
                if (eight_judge(t))
                {
                    setChange(t, 81);
                }
            }
            else if (eight_judge(t))
            {
                setChange(t, 8);
            }
        }

        private void sixteen_but_Click(object sender, EventArgs e)
        {
            string t = sixteen.Text;
            if (two.Text.Contains("-"))
            {
                t = t.Substring(1, t.Length - 1);
                if (sixteen_judge(t))
                {
                    setChange(t, 161);
                }
            }
            else if (sixteen_judge(t))
            {
                setChange(t, 16);
            }
        }

        private bool two_judge(string t)
        {
            const string PATTERN = @"[0-1]+$";
            bool s = System.Text.RegularExpressions.Regex.IsMatch(t, PATTERN);
            if (!s)
            {
                MessageBox.Show("请输入正确的二进制数字");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ten_judge(string t)
        {
            const string PATTERN = @"[0-9]+$";
            bool s = System.Text.RegularExpressions.Regex.IsMatch(t, PATTERN);
            if (!s)
            {
                MessageBox.Show("请输入正确的十进制数字");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool eight_judge(string t)
        {
            const string PATTERN = @"[0-7]+$";
            bool s = System.Text.RegularExpressions.Regex.IsMatch(t, PATTERN);
            if (!s)
            {
                MessageBox.Show("请输入正确的八进制数字");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool sixteen_judge(string t)
        {
            const string PATTERN = @"[A-Fa-f0-9]+$";
            bool s = System.Text.RegularExpressions.Regex.IsMatch(t, PATTERN);
            if (!s)
            {
                MessageBox.Show("请输入正确的十六进制数字");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
