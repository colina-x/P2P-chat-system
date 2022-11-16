using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UI
{
    public partial class ChatWindow : Form
    {
        public ChatWindow()
        {
            InitializeComponent();
        }

        public byte[] buffer_Chat_receive = new byte[1024 * 1024 * 110];//110M缓存
        string his_ip;
        string my_ip;
        string his_name;
        string my_name;
        string file_name;

        List<Users> Users;
        Net_class Sock_connected;

        public ChatWindow(string in_his_ip, string in_my_ip, string in_his_name, string in_my_name, Net_class sock, List<Users> main_users)
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(chatWindow_FormClosing); //注册窗口关闭事件

            his_ip = in_his_ip;
            my_ip = in_my_ip;
            his_name = in_his_name;
            my_name = in_my_name;
            Sock_connected = sock;
            Users = main_users;
            this.Text = "与" + his_name + "的聊天";
            this.Title.Text = "to\t" + his_name;
            sock.sock.BeginReceive(buffer_Chat_receive, 0, buffer_Chat_receive.Length, SocketFlags.None, new AsyncCallback(clientChat_receive), sock.sock); //异步接收
        }

        //发送消息
        private void button_send_Click(object sender, EventArgs e)
        {
            if (!Sock_connected.sock.Connected)
            {
                MessageBox.Show("对方已退出聊天窗口，聊天结束。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sock_connected.Close();
                Close();
                return;
            }

            string text_send = textBox_input.Text;
            if (text_send == "")
            {
                MessageBox.Show("输入不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Sock_connected.Send_message_asy("_m"+my_name+"_"+text_send);
            Sock_connected.Send_message_NumString_asy(1, my_name + "_" + text_send);

            add_msg2list("我", text_send, Color.Green);
            textBox_input.Text = "";//清空消息输入框



        }

        //收到消息
        public void clientChat_receive(IAsyncResult asy_result)
        {
            Net_class receive_NC;
            Socket receive_socket;

            if (!Sock_connected.sock.Connected)
            {
                Sock_connected.Close();
                Close();
                return;
            }

            try
            {
                receive_socket = (Socket)asy_result.AsyncState;
                receive_NC = new Net_class(receive_socket);

                IPEndPoint friend_endP = (IPEndPoint)receive_socket.RemoteEndPoint;
                string friend_ip = friend_endP.Address.ToString();
            }
            catch
            {
                return;
            }

            try
            {
                int receive_len;
                string message = receive_NC.Receive_string(asy_result, buffer_Chat_receive, out receive_len);

                //聊天信息
                if (message.Length > 1 && message[0] == 1)
                {
                    //MessageBox.Show(message);

                    message = message.Substring(1);
                    string his_name = (message.Split('_')[0]);
                    add_msg2list(his_name, message.Split('_')[1], Color.Black);
                }

                receive_socket.BeginReceive(buffer_Chat_receive, 0, buffer_Chat_receive.Length, SocketFlags.None, new AsyncCallback(clientChat_receive), receive_socket);
            }
            catch (SocketException e)
            {
                //MessageBox.Show(e.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //在对话框中添加消息
        public void add_msg2list(string name, string content, Color color)
        {
            richTextBox_display.SelectionStart = richTextBox_display.TextLength;
            richTextBox_display.SelectionLength = 0;
            richTextBox_display.SelectionColor = color;
            if (name == "我")
            {
                richTextBox_display.SelectionAlignment=HorizontalAlignment.Right;
            }
            else richTextBox_display.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox_display.AppendText(name + "\t" + DateTime.Now + "\r\n" + content + "\r\n");
            richTextBox_display.SelectionColor = richTextBox_display.ForeColor;
        }

       

        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        //窗口关闭前关闭连接
        private void chatWindow_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e = null)
        {
            Sock_connected.Close();
            foreach(Users u in Users)
            {
                if (u.getUsername() == this.Name && u.getState() == 1)
                {
                    u.setState(0);
                    Main temp = new(my_name, Sock_connected);
                    foreach(Form f in Application.OpenForms)//刷新主窗口的好友列表
                    {
                        if (f.Name == "Main") temp = (Main)f;
                        temp.Re_fresh_Lists();
                        break;
                    }
                    break;
                }
            }
            //释放内存
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    button_send.PerformClick();//处理给指定的键位
                    textBox_input.Focus();
                    return true;//返回已处理信息
            }
            return base.ProcessCmdKey(ref msg, keyData);//其余键位默认处理
        }

        private void button_empty_Click(object sender, EventArgs e)
        {
            this.textBox_input.Text = null;
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
