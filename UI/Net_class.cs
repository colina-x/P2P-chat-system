using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace UI
{
    public class Net_class
    {
        public static int client_listenF_port = 11000; //监听好友请求的端口
        public static int client_listenChat_port = 12000;
        public static int client_listenGroupChat_port = 13000;

        public string his_ip;
        public int his_port;
        public IPAddress his_ip_a;
        public IPEndPoint his_ipPort_e;
        public Socket sock;

        public Net_class()
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="in_his_ip">ip</param>
        /// <param name="in_his_port">端口</param>
        public Net_class(string in_his_ip, int in_his_port)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            his_ip = in_his_ip;
            his_port = in_his_port;

            his_ip_a = IPAddress.Parse(his_ip);
            his_ipPort_e = new IPEndPoint(his_ip_a, his_port);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="in_sock">sock</param>
        public Net_class(Socket in_sock)
        {
            sock = in_sock;
        }
        /// <summary>
        /// 检查端口占用
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public static bool portInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            
            return inUse;
        }

        /// <summary>
        /// 获取本机ip
        /// </summary>
        /// <returns></returns>
        public static string getMy_ip()
        {
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        public void bind_ip_port(string ip, int port)
        {
            IPAddress ip_address = IPAddress.Parse(ip);
            IPEndPoint ip_end = new IPEndPoint(ip_address, port);
            sock.Bind(ip_end);
        }
        
        public void Send_message(string msg)
        {
            byte[] byte_info = Encoding.UTF8.GetBytes(msg);
            sock.Send(byte_info);
         
        }

        public void Send_message_NumByte(int num, byte[] bytes_msg, int msg_len)
        {
            byte[] byte_num = new byte[1 + msg_len];
            byte_num[0] = (byte)num;
            Buffer.BlockCopy(bytes_msg, 0, byte_num, 1, msg_len);
            sock.Send(byte_num,byte_num.Length, SocketFlags.None);
        }

        public void Send_message_NumByte_asy(int num, byte[] bytes_msg, int msg_len)
        {
            byte[] byte_num = new byte[1 + msg_len];
            byte_num[0] = (byte)num;
            Buffer.BlockCopy(bytes_msg, 0, byte_num, 1, msg_len);
            sock.BeginSend(byte_num, 0, byte_num.Length, SocketFlags.None, null, null);
        }

        public void Send_message_NumString(int num, string msg)
        {
            byte[] byte_msg = Encoding.UTF8.GetBytes(msg);
            byte[] byte_num = new byte[1 + byte_msg.Length];
            byte_num[0] = (byte)num;
            Buffer.BlockCopy(byte_msg, 0, byte_num, 1, byte_msg.Length);
            sock.Send(byte_num, byte_num.Length, SocketFlags.None);
        }

        public void Send_message_NumString_asy(int num, string msg)
        {
            byte[] byte_msg = Encoding.UTF8.GetBytes(msg);
            byte[] byte_num = new byte[1+byte_msg.Length];
            byte_num[0] = (byte)num;
            Buffer.BlockCopy(byte_msg, 0, byte_num, 1, byte_msg.Length);
            sock.BeginSend(byte_num, 0, byte_num.Length, SocketFlags.None, null, null);
        }

        public void Send_message_asy(string msg)
        {
            byte[] byte_info = Encoding.UTF8.GetBytes(msg);

            sock.BeginSend(byte_info, 0, byte_info.Length, SocketFlags.None, null, null);
        }

        public byte[] Receive_bytes(out int receive_len)
        {
            byte[] receive_info = new byte[1024*1024*20];

            receive_len = sock.Receive(receive_info);
            return receive_info;
        }

        public string Receive_string()
        {
            byte[] receive_info = new byte[1024];
            string receive_string;

            int receive_len = sock.Receive(receive_info);
            receive_string = Encoding.UTF8.GetString(receive_info, 0, receive_len);
            return receive_string;
        }

        //异步接收消息
        public string Receive_string(IAsyncResult asy_result, byte[] receive_info, out int receive_len)
        {
            string receive_string;
            try
            {
                receive_len = sock.EndReceive(asy_result);
                receive_string = Encoding.UTF8.GetString(receive_info, 0, receive_len);
                return receive_string;
            }
            catch
            {   
                receive_len = 0;
                return null;
            }
        }

        //尝试连接，wait_time是等待时长
        public IAsyncResult try_connect(int wait_time)
        {
            IAsyncResult connResult = sock.BeginConnect(his_ipPort_e, null, null);
            connResult.AsyncWaitHandle.WaitOne(wait_time, true);
            return connResult;
        }

        public void Close()
        {
            sock.Close();
        }

        public void try_connect()
        {
            sock.Connect(his_ipPort_e);
        }
        
        //异步发送开始
        public void Asyn_send(string message)
        {
            byte[] byte_info = Encoding.ASCII.GetBytes(message);
            sock.BeginSend(byte_info, 0, message.Length, SocketFlags.None, new AsyncCallback(asyn_send_callback), sock);
        }

        void asyn_send_callback(IAsyncResult iar)
        {
            try
            {
                sock = (Socket)iar.AsyncState;
                sock.EndSend(iar);
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.ToString(), "异常",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int get_my_port()
        {
            string endpoint = sock.LocalEndPoint.ToString();
            string[] endP_pieces = endpoint.Split(':');
            string port_str = endP_pieces[1];
            int port;
            int.TryParse(port_str, out port);
            return port;
        }
    }
}
