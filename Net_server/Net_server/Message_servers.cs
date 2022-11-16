using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_server

{
    public class Message_servers    // 两个构造函数，登录时用只有两个参数的函数，注册时用三个参数的函数。
    {
        public Client client;
        string path = AppDomain.CurrentDomain.BaseDirectory + "//p2p.txt";

        public Message_servers(string name, string account, string password)
        {
            client = new Client(name, account, password);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public Message_servers(string account, string password)
        {
            client = new Client(account, password);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

        }


        public bool register_check()    // 注册检测是否有同用户名
        {
            string[] tempt;
            string message = $"{client.name} {client.account} {client.password}";
            List<string> data = new List<string>();
            string[] strArray = File.ReadAllLines(path);
            for (int i = 0; i < strArray.Length; i++)
            {
                Console.WriteLine(strArray[i]);
                data.Add(strArray[i]);
            }
            for (int i = 0; i < data.Count; i++)
            {
                tempt = data[i].Split(' ');
                if (client.account == tempt[1])
                {
                    return false;
                }
            }
            return true;
        }

        public void save_Message()  // 账户密码保存至本地
        {

            StreamWriter sw_message = File.AppendText(path);   // 文件path
            sw_message.Write($"{client.name} {client.account} {client.password}\n");
            sw_message.Flush();
            sw_message.Close();
        }

        public bool login_check()   // 登录检测账户密码是否正确
        {
            string[] tempt;
            string message;
            List<string> data = new List<string>();
            string[] strArray = File.ReadAllLines(path);
            for (int i = 0; i < strArray.Length; i++)
            {
                data.Add(strArray[i]);
            }
            for (int i = 0; i < data.Count; i++)
            {
                tempt = data[i].Split(' ');
                if (client.account == tempt[1])
                {
                    if (client.password == tempt[2])
                        return true;
                }
            }
            return false;
        }

        public string return_nickname(string account)   //根据用户名查找用户昵称
        {
            string[] tempt;
            string message;
            List<string> data = new List<string>();
            string[] strArray = File.ReadAllLines(path);
            for (int i = 0; i < strArray.Length; i++)
            {
                data.Add(strArray[i]);
            }
            for (int i = 0; i < data.Count; i++)
            {
                tempt = data[i].Split(' ');
                if (client.account == tempt[1])
                {
                    client.name = tempt[0];
                    return client.name;
                }
            }
            return null;
        }
    }
}