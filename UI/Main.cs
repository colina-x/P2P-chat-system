using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{

    //
    public partial class Main : Form
    {
        string myName;      //我的用户名

        Net_class server_NC;    ///服务器连接
        Net_class Sock_connected;   //单人socket连接

        public byte[] buffer_List = new byte[1024];     //用户列表缓冲区
        public byte[] buffer_Chat = new byte[1024];     //聊天消息缓冲区

        int chat_receive_port = Net_class.client_listenChat_port + 1; //下一个聊天可用端口
        List<int> chatting_ports = new List<int>();  //正在运行的聊天窗口所用的端口号集
        //List<Net_class> chatting_socket = new List<Net_class>();    //多个聊天

        //List<Net_class> group_socket = new List<Net_class>(); //群聊人员socket通信列表

        Dictionary<string, string> Friends_ip = new Dictionary<string, string>();   //用户账号-Ip字典
        Dictionary<string, int> Friends_port = new Dictionary<string, int>();   //用户账号-port字典
        Dictionary<string, Form> _Dialogues = new Dictionary<string, Form>();   //用户账号-form字典

        //int groupChat_receive_port = Net_class.client_listenGroupChat_port + 1; //下一个群聊可用端口
        //List<int> group_chatting_ports = new List<int>();  //正在运行的群窗口所用的端口号集

        static List<Users> users = new List<Users>();  //本地储存的好友列表
        //ListView Dialogue = null;   //当前被选中的消息框
        public Main(string in_myName, Net_class NC)
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;                //TODO注释不知道会不会出事
            FormClosing += new FormClosingEventHandler(Main_FormClosing); //注册窗口关闭事件

            myName = in_myName;
            server_NC = NC;

            Listen_message();       //开始监听
            Re_fresh_Lists();       //刷新用户列表

            List_Friends.DoubleClick += new EventHandler(List_Friends_DoubleClick); //注册用户列表双击事件

            foreach(Users u in users)
            {
                if(u.getUsername() == myName)
                {
                    this.Text = u.getNickname() + "(" + myName + ")" + "__用户";        //标题
                }
            }
        }
        //好友列表折叠
        private void Button_FriendList_Click(object sender, EventArgs e)
        {
            List_Friends.Visible = !List_Friends.Visible;
        }
        //群组列表折叠
        private void Button_GroupsList_Click(object sender, EventArgs e)
        {
            List_Groups.Visible = !List_Groups.Visible;
        }
        ///<summary>
        /// 刷新用户列表
        ///</summary>
        public void Re_fresh_Lists()
        {
            List_Friends.Items.Clear();
            //this.List_Groups.Items.Clear();

            foreach (Users u in users)
            {
                if (u.getUsername() != myName)//过滤自己
                {
                    if (u.getState() == 0) this.List_Friends.Items.Add(u.getNickname() + "(" + u.getUsername() + ")");
                    else this.List_Friends.Items.Add(u.getNickname() + "(" + u.getUsername() + ")\t√");
                }
                else continue;
            }
            if (this.List_Friends.Items.Count == 0) //如果无好友在线添加提示
            {
                this.List_Friends.Items.Add("暂无在线好友");
                this.List_Friends.SelectionMode = SelectionMode.None;
            }
            else this.List_Friends.SelectionMode = SelectionMode.One;
        }

        //发起连接按钮点击事件
        private void Button_Connection_Click(object sender, EventArgs e)
        {
            if (!this.List_Friends.Visible) //若好友列表处于折叠状态，则此时点击按钮无响应
            {
                return;
            }
            else
            {
                if (this.List_Friends.SelectedItem != null) //若好友列表有好友被选中
                {
                    P2PConnection((string)List_Friends.SelectedItem);   //与选中好友建立连接
                }
                else
                {
                    return;
                }
            }
        }
        //开启监听
        public void Listen_message()
        {
            try
            {
                if (!server_NC.sock.Connected) return;
                //列表刷新监听
                server_NC.sock.BeginReceive(buffer_List, 0, buffer_List.Length, SocketFlags.None, new AsyncCallback(clientList_accepted), server_NC.sock);

                //聊天的监听
                Net_class listenChat_NC = new Net_class();
                listenChat_NC.bind_ip_port(Net_class.getMy_ip(), Net_class.client_listenChat_port);
                listenChat_NC.sock.Listen(200);
                listenChat_NC.sock.BeginAccept(new AsyncCallback(clientChat_accepted), listenChat_NC.sock);

                ////群聊的监听
                /*Net_class listenGroupChat_NC = new Net_class();
                listenGroupChat_NC.bind_ip_port(myIP, Net_class.client_listenGroupChat_port);
                listenGroupChat_NC.sock.Listen(200);
                listenGroupChat_NC.sock.BeginAccept(new AsyncCallback(clientGroupChat_accepted), listenGroupChat_NC.sock);*/
            }
            catch (SocketException e)
            {
                MessageBox.Show("端口被占用。" + e.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //接收列表刷新的callback
        public void clientList_accepted(IAsyncResult asy_result)
        {
            try
            {
                //获取请求socket并接收消息
                Socket socket = asy_result.AsyncState as Socket;
                Net_class receive_net = new Net_class(socket);
                int receive_len;
                string message = receive_net.Receive_string(asy_result, buffer_List, out receive_len);

                //列表处理
                String[] msg_split = message.Split("_");
                if (msg_split[0] == "l")
                {
                    users.Clear();
                    int num = int.Parse(msg_split[1]);
                    for (int i = 0; i < num; i++)
                    {
                        Users user = new Users(msg_split[3 + i * 4], msg_split[2 + i * 4], msg_split[4 + i * 4]);
                        Friends_ip[msg_split[2 + i * 4]] = msg_split[4 + i * 4];
                        Friends_port[msg_split[2 + i * 4]] = int.Parse(msg_split[5 + i * 4]);
                        users.Add(user);
                        foreach (Form f in Setting_Message.Controls)
                        {
                            if (f.Name == user.getUsername())
                            {
                                user.setState(1);
                                break;
                            }
                        }
                    }
                }
                //这样做可以阻塞到组件创建以后执行刷新列表
                try { IntPtr a = this.Handle; }
                catch (Exception e) { return; }
                this.Invoke((MethodInvoker)delegate ()
                {
                    Re_fresh_Lists();
                });
                //继续接收列表刷新
                server_NC.sock.BeginReceive(buffer_List, 0, buffer_List.Length, SocketFlags.None, new AsyncCallback(clientList_accepted), server_NC.sock);
            }
            catch (SocketException e)
            {
                //MessageBox.Show(e.ToString(), "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //聊天监听的callback
        public void clientChat_accepted(IAsyncResult asy_result)
        {
            Socket listen_socket = (Socket)asy_result.AsyncState;
            Socket receive_socket = listen_socket.EndAccept(asy_result);

            Net_class receive_net = new Net_class(receive_socket);
            int my_receive_port = receive_net.get_my_port();
            //MessageBox.Show(myName+"我的"+my_receive_port+"监听的"+Net_class.client_listenChat_port);

            if (my_receive_port == Net_class.client_listenChat_port) //在聊天的监听端口接收到请求，则给对方返回一个本地可用的端口后并监听该端口号
            {
                chat_receive_port += 1;
                while (Net_class.portInUse(chat_receive_port)) //判断端口chat_receive_port是否被占用，如果是则加1
                {
                    chat_receive_port += 1;
                }
                receive_net.Send_message_asy(chat_receive_port.ToString()); //向对方发送可用端口号
                //在可用端口号开启聊天请求监听
                string myIP = Net_class.getMy_ip();
                Net_class listenChat_custom_NC = new Net_class();
                listenChat_custom_NC.bind_ip_port(myIP, chat_receive_port);
                listenChat_custom_NC.sock.Listen(200);
                listenChat_custom_NC.sock.BeginAccept(new AsyncCallback(clientChat_accepted), listenChat_custom_NC.sock);
            }
            else if (chatting_ports.FindIndex(x => x == my_receive_port) == -1) //不是正在聊天的窗口所发来的连接
            {
                //TODO 开启接收消息  但是收不到信息
                //只有发了消息才能收到

                receive_socket.BeginReceive(buffer_Chat, 0, buffer_Chat.Length, SocketFlags.None, new AsyncCallback(clientChat_receive), receive_socket);
                //MessageBox.Show("开启接收消息" + DateTime.Now.ToString("O"));
            }

            //开始接受下一个聊天请求
            listen_socket.BeginAccept(new AsyncCallback(clientChat_accepted), listen_socket);
        }

        //收到消息
        public void clientChat_receive(IAsyncResult asy_result)
        {
            //MessageBox.Show("收到消息"+ DateTime.Now.ToString("O"));
            Socket receive_socket = (Socket)asy_result.AsyncState;
            Net_class receive_NC = new Net_class(receive_socket);
            int my_receive_port = receive_NC.get_my_port();

            IPEndPoint friend_endP = (IPEndPoint)receive_socket.RemoteEndPoint;
            string friend_ip = friend_endP.Address.ToString();

            try
            {
                int len;
                string message = receive_NC.Receive_string(asy_result, buffer_Chat, out len);
                string his_name = message.Split("_")[1];
                //MessageBox.Show(message);
                //聊天邀请
                if (message.StartsWith("i_"))
                {
                    string his_ip = friend_ip;
                    //MessageBox.Show(myName + "收到" + his_name + ":" + his_ip+"邀请");

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        DialogResult dr = MessageBox.Show(this, "用户:" + his_name + " 请求聊天，是否同意？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        string friend_reply;

                        if (dr == DialogResult.Yes) //接收聊天申请
                        {
                            friend_reply = "y_";
                        }
                        else //拒绝好友申请
                        {
                            friend_reply = "n_";
                        }
                        if (!receive_NC.sock.Connected)
                        {
                            MessageBox.Show(this, "无法连接到对方网络，请稍后重试。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        receive_NC.Send_message(friend_reply + myName);//发送回复
                        if (friend_reply == "y_") //添加到好友列表
                        {
                            chatting_ports.Add(my_receive_port);
                            chatting_ports.Add(my_receive_port);
                            chatting_ports.Add(my_receive_port);
                            Sock_connected = receive_NC;
                            for (int i = 0; i < List_Friends.Items.Count; i++)
                            {
                                if (List_Friends.Items[i].ToString().Split("(")[1].Split(")")[0] == his_name)
                                {
                                    List_Friends.Items[i] += "\t√";
                                    break;
                                }
                            }
                            addChatWin(his_ip, his_name, receive_NC);
                        }
                    });


                }
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.ToString(), "异常",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //在对话框中添加消息


        /// <summary>
        /// 创建群聊与选择好友，第一次点击“创建群聊”按钮，它的文字变为“选择好友”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Setgroup_Click(object sender, EventArgs e)
        {
            /*if (!List_Friends.Visible)  //若好友列表折叠，此按钮无响应
            {
                return;
            }
            else
            {
                if (this.Button_Setgroup.Text == "创建群聊")
                {
                    List_Friends.SelectionMode = SelectionMode.MultiExtended;
                    this.Button_Setgroup.Text = "选择对象";
                    this.Button_Connection.Enabled = false;
                    this.Button_FriendList.Enabled = false;
                }
                else if (this.Button_Setgroup.Text == "选择好友")
                {
                    if (this.List_Friends.SelectedItems.Count <= 1)
                    {
                        MessageBox.Show("群聊至少包括三名用户", "提示");
                        this.Button_Setgroup.Text = "创建群聊";
                        this.Button_Connection.Enabled = true;
                        this.Button_FriendList.Enabled = true;
                        return;
                    }
                    else
                    {
                        foreach (string s in this.List_Friends.SelectedItems)
                        {
                            //依次建立socket连接
                            //group_socket.Add(P2PConnection(s));
                        }
                        //将原本的会话小窗口置为不可见
                        foreach (Control control in this.Panel_Dialogue.Controls)
                        {
                            control.Enabled = false;
                            control.Visible = false;
                        }

                        //改变聊天框样式
                        ListView dialogue = new ListView();
                        dialogue.Visible = true;
                        dialogue.BackColor = Color.White;
                        dialogue.LabelEdit = false;
                        dialogue.Name = myName;
                        Dialogue = dialogue;
                        _Dialogues["g_" + myName] = dialogue;
                        this.Panel_Dialogue.Controls.Add(dialogue);
                    }
                }
            }*/
        }
        private void P2PConnection(string s)
        {
            string account = s.Split('(')[1].Split(')')[0];
            //if (account == myName) return;
            foreach (Form f in Setting_Message.Controls)
            {
                if (f.Name == account) return;
            }

            string his_ip = Friends_ip[account];

            Net_class NC_chat_apply = new Net_class(his_ip, Friends_port[account]);

            NC_chat_apply.try_connect(3000);
            //MessageBox.Show(myName + "请求连接" + account);
            if (!NC_chat_apply.sock.Connected)
            {
                DialogResult dr = MessageBox.Show(this, "连接对方网络失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string new_port_str = NC_chat_apply.Receive_string(); //接收对方传来的端口信息。
            //MessageBox.Show(myName + "接收到端口" + new_port_str);
            Net_class NC_chat_new = new Net_class(his_ip, int.Parse(new_port_str));
            NC_chat_new.try_connect(3000);
            //MessageBox.Show(myName + "请求连接" + account+"端口"+ new_port_str);

            if (!NC_chat_new.sock.Connected)
            {
                DialogResult dr = MessageBox.Show(this, "连接对方网络失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            NC_chat_new.Send_message("i_" + myName);

            Thread th = new Thread(() => MessageBox.Show("连接中。。。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)); //显示提示窗口但不将程序挂起
            th.IsBackground = true;
            th.Start();
            string response = NC_chat_new.Receive_string();
            //MessageBox.Show(response);
            if (response.StartsWith("y_"))
            {
                for (int i = 0; i < List_Friends.Items.Count; i++)
                {
                    if (List_Friends.Items[i].ToString().Split("(")[1].Split(")")[0] == account)
                    {
                        List_Friends.Items[i] += "\t√";
                        break;
                    }
                }
                addChatWin(his_ip, account, NC_chat_new);
                Thread thr = new Thread(() => MessageBox.Show(this, "用户:" + account + " 已接受您的聊天申请。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information));
                thr.IsBackground = true;
                thr.Start();
                chatting_ports.Add(int.Parse(new_port_str));
                Sock_connected = NC_chat_new;
            }
            else
            {
                MessageBox.Show("对方拒绝了您的会话邀请", "提示");
                return;
            }
        }

        void addChatWin(string his_ip, string his_name, Net_class NC)
        {
            foreach (Form f in this.Setting_Message.Controls)
            {
                f.Hide();
            }
            ChatWindow CW = new ChatWindow(his_ip, Net_class.getMy_ip(), his_name, myName, NC, users);
            CW.Name = his_name;
            CW.TopLevel = false;
            CW.WindowState = FormWindowState.Maximized;//将窗体最大化
            CW.FormBorderStyle = FormBorderStyle.None;//设为无边框
            //使用拉姆达表达式创建一个委托，委托里面修改控件的父级
            Action delega1 = () =>
            {
                CW.Parent = null;
                CW.Parent = this.Setting_Message;
            };

            //使用异步多线程更新
            if (this.InvokeRequired)
            {
                //新建一个线程，线程里面调用拉姆达表达式，拉姆达表达式里面使用异步的形式调用委托，委托里面再修改控件的父级
                new Thread(() => this.Invoke(delega1)).Start();
            }
            else
            {
                delega1();
            }
            CW.Dock = DockStyle.Fill;
            foreach (Users u in users)
            {
                if (u.getUsername() == his_name)
                {
                    u.setState(1);
                }
            }
            this.Invoke((MethodInvoker)delegate ()
            {
                Thread Thread_friendList = new Thread(() => Application.Run(CW));
                Thread_friendList.Start();
            });
        }

        private void Button_JoinGroup_Click(object sender, EventArgs e)
        {
            if (!Button_GroupsList.Visible)
            {
                return;
            }
            else
            {
                if (List_Groups.SelectedItem == null)
                {
                    return;
                }
                else
                {

                }
            }
        }

        private void Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                int i = 0;
                server_NC.Send_message("q_" + myName);
                this.Dispose();
                this.Close();
            }
            catch
            { }

            //server_NC.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void List_Friends_DoubleClick(object sender, EventArgs e)
        {
            string account = this.List_Friends.SelectedItem.ToString().Split("(")[1].Split(")")[0];
            foreach (Form f in Setting_Message.Controls)
            {
                f.Hide();
                if (f.Name == account)
                {
                    f.Show();
                }
            }
        }
    }
}