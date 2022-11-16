using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace UI
{
    public partial class Login : Form
    {
        //服务器ip地址
        string ip = "";
        public Login()
        {
            InitializeComponent();

        }
        // 登录按钮
        private void LoginButton_Click(object sender, EventArgs e)
        {
            Net_class NC=ConnectToSever();

            //1. 获取数据
            //从TextBox中获取用户输入信息
            string userName = this.AccountTextbox.Text;         //用户名
            string userPassword = this.PasswordTextbox.Text;    //密码
            string userIp=Net_class.getMy_ip();                 //用户ip
            while (Net_class.portInUse(Net_class.client_listenChat_port))   //检测可用的聊天监听端口
            {
                Net_class.client_listenChat_port++;
            }

            //2. 验证数据
            // 验证用户输入是否为空，若为空，提示用户信息
            if (userName.Equals("") || userPassword.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空！","提示");
            }
            else    // 若不为空，验证用户名和密码是否与数据库匹配
            {
                NC.Send_message("l_" + userName + "_" + userPassword + "_" + userIp+"_"+Net_class.client_listenChat_port);
                string receive_string = NC.Receive_string();
                //用户名和密码验证正确，跳转界面。
                if (receive_string == "Y")
                {
                    Thread Thread_friendList = new Thread(() => Application.Run(new Main(userName, NC)));
                    Thread_friendList.Start();
                    this.Close();
                }
                else if (receive_string == "N")         //用户名和密码验证失败，提示用户名或密码错误。
                {
                    MessageBox.Show("用户名或密码错误！", "提示");
                }
                else if (receive_string == "T")     //用户已在另一地点登陆。
                {
                    MessageBox.Show("此账号已在另一地点登陆，禁止重复登录！", "提示");
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
                    LoginButton.PerformClick();//处理给指定的键位
                    return true;//返回已处理信息
            }
            return base.ProcessCmdKey(ref msg, keyData);//其余键位默认处理
        }
        //注册按钮
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ip = this.Textbox_Ip.Text != "" ? Textbox_Ip.Text : Net_class.getMy_ip();
            Form register = new Register(ip);
            register.Show();
        }

        /// <summary>
        /// 连接到服务器
        /// </summary>
        private Net_class ConnectToSever()
        {
            ip = this.Textbox_Ip.Text != "" ? Textbox_Ip.Text : Net_class.getMy_ip();
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