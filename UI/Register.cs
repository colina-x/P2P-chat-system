using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Register : Form
    {
        //服务器ip地址
        string ip;
        public Register(string ip)
        {
            InitializeComponent();
            this.ip = ip;
        }
        //注册按钮绑定事件
        private void RG_RegisterButton_Click(object sender, EventArgs e)
        {
            Net_class NC = ConnectToSever();
            Users user = new Users();

            user.setNickname(this.RG_NameTextbox.Text);
            user.setUsername(this.RG_AccountTextbox.Text);
            user.setPassword(this.RG_PasswordTextbox.Text);
            user.setIp(Net_class.getMy_ip());
            string repassword = this.RG_RepasswordTextbox.Text;
            //判断表单是否完整
            if (user.getNickname().Equals("") || user.getUsername().Equals("") || user.getPassword().Equals("") || repassword.Equals(""))
            {
                MessageBox.Show("输入不能为空！");
            }
            else
            {
                //判断两次密码是否相同
                if (user.getPassword() != repassword)
                {
                    MessageBox.Show("两次输入的密码不相同！");
                    this.RG_PasswordTextbox.Text = null;
                    this.RG_RepasswordTextbox.Text = null;
                    this.RG_PasswordTextbox.Focus();
                }
                else
                {
                    //向服务器发送注册信息
                    NC.Send_message("r_" + user.getUsername() + "_" + user.getPassword() + "_" + user.getIp() + "_" + user.getNickname());
                    string s = NC.Receive_string();
                    if (s == "y")       //注册成功
                    {
                        MessageBox.Show("注册成功！", "提示");
                        this.Dispose();
                        this.Close();
                    }
                    else if (s == "n")      //注册失败
                    {
                        MessageBox.Show("该账号已存在", "提示");
                        this.RG_AccountTextbox.Text = null;
                        this.RG_PasswordTextbox.Text = null;
                        this.RG_RepasswordTextbox.Text = null;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("发生了一个意料外的错误，注册失败", "提示");
                    }
                }
            }
        }

        /// <summary>
        /// Enter快捷键
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    RG_RegisterButton.PerformClick();//处理给指定的键位
                    return true;//返回已处理信息
            }
            return base.ProcessCmdKey(ref msg, keyData);//其余键位默认处理
        }
        /// <summary>
        /// 连接到服务器
        /// </summary>
        public Net_class ConnectToSever()
        {
            Net_class NC = new Net_class(ip, 8000); //自定义类，处理网络事件

            NC.try_connect(6000);
            if (!NC.sock.Connected)
            {
                DialogResult dr = MessageBox.Show("无法连接到服务器，请检查服务器信息。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NC.Close();
                return null;
            }
            return NC;
        }
    }
}
