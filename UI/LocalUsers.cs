using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class LocalUsers
    {
        public static List<LocalUsers> localUsers=new List<LocalUsers>();
        string nickname;
        string username;
        string ip;

        public LocalUsers()
        {
        }

        public LocalUsers(string nickname, string username, string ip)
        {
            this.nickname = nickname;
            this.username = username;
            this.ip = ip;
        }
        public string getNickname()
        {
            return nickname;
        }
        public string getUsername()
        {
            return username;
        }
        public string getIp()
        {
            return ip; 
        }
        public void setNickname(string nickname) { this.nickname = nickname; }
        public void setUsername(string username) { this.username = username; }
        public void setIp(string ip) { this.ip = ip; }
    }
}
