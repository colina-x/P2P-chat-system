using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_server
{
    public class Client
    {
        public string name = null;
        public string account = null;
        public string password = null;
        public Client(string name, string account, string password)
        {
            this.name = name;
            this.account = account;
            this.password = password;
        }
        public Client(string account, string password)
        {
            this.account = account;
            this.password = password;
        }
    }
}
