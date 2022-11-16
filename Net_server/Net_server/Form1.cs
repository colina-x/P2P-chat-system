using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Net_server
{
    public partial class Form1 : Form
    {
        Socket socket_watch;                            

        List<Socket> sock_save = new List<Socket>();    //存储服务端连接的所有客户端socket的列表
        List<userLib> userlib = new List<userLib>();    //存储所有在线用户数据的列表

        // List<userLib> group = new List<userLib>();   //存储所有在线群组的列表
        public Form1()
        {
            InitializeComponent();
            txtMsg.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;

            string myIP = get_my_ip();
            textBox_localIP.Text = myIP;

            IPAddress address = IPAddress.Parse(myIP);
            IPEndPoint endPoint = new IPEndPoint(address, 8000);
            
            socket_watch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket_watch.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socket_watch.Bind(endPoint);
            }
            catch (SocketException se)
            {
                MessageBox.Show("异常：" + se.Message);
                return;
            }

            socket_watch.Listen(1000);
            Thread threadWatch = new Thread(Accept_connect);
            threadWatch.IsBackground = true;
            threadWatch.Start();
            ShowMsg("启动监听");
        }
        public string get_my_ip()   //获取服务器IP
        {
            string myIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    myIP = _IPAddress.ToString();
                }
            }

            return myIP;
        }

        public void Accept_connect()    //接受客户端发送的Socket连接请求
        {
            while (true)
            {
                Socket sokConnection = socket_watch.Accept();
                var ssss = sokConnection.RemoteEndPoint.ToString().Split(':'); //分割IP和端口
                
                ShowMsg("连接：" + ssss[0] + " :" + ssss[1]);

                if (listBox_online.FindString(ssss[0]) < 0)
                {
                    listBox_online.Items.Add(sokConnection.RemoteEndPoint.ToString());
                }
                sock_save.Add(sokConnection);   //将Socket连接存入Socket连接列表内
                Thread thr = new Thread(Get_msg);   //开新线程接受消息
                thr.IsBackground = true;
                thr.Start(sokConnection);
                if (!sokConnection.Connected)       //如果Socket连接断开，关闭该Socket的连接
                {
                    sokConnection.Close();
                }
            }
        }

        void sendList()     //广播给每个客户端目前服务器内活跃用户的信息
        {
            string str = "l_" + userlib.Count + "_";
            foreach (var i in userlib)
            {
                str += i.Getusername() + "_" + i.Getnickname() + "_" + i.Getip() + "_" + i.Getport() + "_";
            }
            foreach (var i in sock_save)
            {
                i.Send(Encoding.ASCII.GetBytes(str));
            }
        }
        void Get_msg(object sokConnectionparn)  //服务端接受客户端发送的消息
        {
            Socket sokClient = sokConnectionparn as Socket;
            string client_ip = sokClient.RemoteEndPoint.ToString().Split('_')[0];   //将用户的IP分割出来

            while (true)    //监听客户端发送的消息
            {
                byte[] arrMsgRec = new byte[1024];
                int length = -1;
                if (sokClient != null && sokClient.Connected)   //如果Socket不为空同时Socket连接没有断开
                {
                    try
                    {
                        length = sokClient.Receive(arrMsgRec);  //接受客户端发送的消息，保存长度
                        if (length > 0)
                        {
                            string msg = System.Text.Encoding.ASCII.GetString(arrMsgRec, 0, length);    //解码消息
                            ShowMsg("Receive:" + msg);
                            string[] msg_split = msg.Split('_');
                            string signal = msg_split[0];   //消息标识头
                            string username = msg_split[1];


                            //注册 
                            if (signal == "r")
                            {
                                string password = msg_split[2];
                                string ip = msg_split[3];
                                string nickname = msg_split[4];
                                Message_servers ms_r = new Message_servers(nickname, username, password);
                                if (ms_r.register_check())  //检查本地数据库是否已经有相同用户名注册过
                                {
                                    //写入文件
                                    ms_r.save_Message();
                                    sokClient.Send(Encoding.ASCII.GetBytes("y"));
                                    ShowMsg("用户注册成功");
                                }
                                else
                                {
                                    sokClient.Send(Encoding.ASCII.GetBytes("n"));
                                    ShowMsg("用户已注册");
                                }
                            }
                            //登陆
                            else if (signal == "l")
                            {
                                string password = msg_split[2];
                                string ip = msg_split[3];
                                string port = msg_split[4];
                                Message_servers ms_l = new Message_servers(username, password);
                                //账号密码比对
                                if (ms_l.login_check())
                                {   //登陆检测
                                    if (!userlib.Exists(t => t.Getusername() == username))
                                    {
                                        ShowMsg("用户登录成功");
                                        userlib.Add(new userLib(ms_l.return_nickname(username), username, "", ip, port));
                                        sokClient.Send(Encoding.ASCII.GetBytes("Y"));
                                        sendList();
                                    }
                                    else
                                    {
                                        ShowMsg("用户已登陆");
                                        sokClient.Send(Encoding.ASCII.GetBytes("T"));
                                    }
                                }
                                else
                                {
                                    ShowMsg("账户密码错误");
                                    sokClient.Send(Encoding.ASCII.GetBytes("N"));
                                }
                            }
                            //登出
                            else if (signal == "q")
                            {
                                for (int i = userlib.Count - 1; i >= 0; i--)
                                {
                                    if (username == userlib[i].Getusername())
                                    {
                                        userlib.Remove(userlib[i]);
                                        ShowMsg("用户已登出");
                                    }
                                }
                                sock_save.Remove(sokClient);
                                sokClient.Close();
                                sendList();
                            }
                        }
                        else
                        {
                            userlib.RemoveAt(sock_save.IndexOf(sokClient));
                            sock_save.Remove(sokClient);
                            listBox_online.Items.Remove(sokClient.RemoteEndPoint.ToString());
                            sendList();
                            ShowMsg("" + sokClient.RemoteEndPoint.ToString() + "断开连接\r\n");
                            break;
                        }
                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        userlib.RemoveAt(sock_save.IndexOf(sokClient));
                        sock_save.Remove(sokClient);
                        listBox_online.Items.Remove(sokClient.RemoteEndPoint.ToString());
                        sendList();
                        ShowMsg("" + sokClient.RemoteEndPoint.ToString() + "断开,异常消息：用户异常退出");
                        break;
                    }
    
                }
            }
        }

        void ShowMsg(string str)
        {
            txtMsg.AppendText(str + "\r\n");
        }

        public class userLib    //用户类
        {
            string nickname;
            string username;
            string password;
            string ip;
            string port;

            public string Getnickname()
            {
                return this.nickname;
            }

            public string Getusername()
            {
                return this.username;
            }

            public string Getpassword()
            {
                return this.password;
            }

            public string Getip()
            {
                return this.ip;
            }

            public string Getport()
            {
                return this.port;
            }

            public void Setnickname(string nickname)
            {
                this.nickname = nickname;
            }

            public void Setusername(string username)
            {
                this.username = username;
            }

            public void Setpassword(string password)
            {
                this.password = password;
            }

            public void Setip(string ip)
            {
                this.ip = ip;
            }

            public void Setport(string port)
            {
                this.port = port;
            }

            public userLib(string nickname, string username, string password, string ip, string port)
            {
                this.nickname = nickname;
                this.username = username;
                this.password = password;
                this.ip = ip;
                this.port = port;
            }

        }
    }
}