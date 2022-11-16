using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Users
    {
        string username;
        string nickname;
        string ip;
        string password;

        int state;

        public Users()
        {
        }

        public Users(string nickname, string username, string ip)
        {
            this.username = username;
            this.nickname = nickname;
            this.ip = ip;
        }

        public Users(string nickname, string username, string ip, string password, int state = 0)
        {
            this.username = username;
            this.nickname = nickname;
            this.ip = ip;
            this.password = password;
            this.state = state;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setNickname(string nickname)
        {
            this.nickname = nickname;
        }

        public void setIp(string ip)
        {
            this.ip = ip;
        }
        public void setPassword(string password) { this.password = password; }
        public string getUsername()
        {
            return this.username;
        }

        public string getNickname()
        {
            return this.nickname;
        }
        
        public string getIp()
        {
            return this.ip;
        }
        public string getPassword() { return this.password; }

        public int getState() { return state; }
        public void setState(int state) { this.state = state; }
    }
}
