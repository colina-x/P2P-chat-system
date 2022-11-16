using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    internal class Response
    {
        int code;
        string data;
        string msg;
        int timestamp;

        public Response()
        {

        }

        public Response(int code, string data, string msg, int timestamp)
        {
            this.code = code;
            this.data = data;
            this.msg = msg;
            this.timestamp = timestamp;
        }
        public int getCode() { return code; }
        public string getData() { return data; }
        public string getMsg() { return msg; }
        public int getTimestamp() { return timestamp; }
        public void setCode(int code) { this.code = code; }
        public void setData(string data) { this.data = data; }
        public void setMsg(string msg) { this.msg = msg; }
        public void setTimestamp(int timestamp) { this.timestamp = timestamp; }
    }
}
