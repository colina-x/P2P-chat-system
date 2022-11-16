using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace UI
{
    public partial class Login : Form
    {
        //������ip��ַ
        string ip = "";
        public Login()
        {
            InitializeComponent();

        }
        // ��¼��ť
        private void LoginButton_Click(object sender, EventArgs e)
        {
            Net_class NC=ConnectToSever();

            //1. ��ȡ����
            //��TextBox�л�ȡ�û�������Ϣ
            string userName = this.AccountTextbox.Text;         //�û���
            string userPassword = this.PasswordTextbox.Text;    //����
            string userIp=Net_class.getMy_ip();                 //�û�ip
            while (Net_class.portInUse(Net_class.client_listenChat_port))   //�����õ���������˿�
            {
                Net_class.client_listenChat_port++;
            }

            //2. ��֤����
            // ��֤�û������Ƿ�Ϊ�գ���Ϊ�գ���ʾ�û���Ϣ
            if (userName.Equals("") || userPassword.Equals(""))
            {
                MessageBox.Show("�û��������벻��Ϊ�գ�","��ʾ");
            }
            else    // ����Ϊ�գ���֤�û����������Ƿ������ݿ�ƥ��
            {
                NC.Send_message("l_" + userName + "_" + userPassword + "_" + userIp+"_"+Net_class.client_listenChat_port);
                string receive_string = NC.Receive_string();
                //�û�����������֤��ȷ����ת���档
                if (receive_string == "Y")
                {
                    Thread Thread_friendList = new Thread(() => Application.Run(new Main(userName, NC)));
                    Thread_friendList.Start();
                    this.Close();
                }
                else if (receive_string == "N")         //�û�����������֤ʧ�ܣ���ʾ�û������������
                {
                    MessageBox.Show("�û������������", "��ʾ");
                }
                else if (receive_string == "T")     //�û�������һ�ص��½��
                {
                    MessageBox.Show("���˺�������һ�ص��½����ֹ�ظ���¼��", "��ʾ");
                }
            }
        }

        /// <summary>
        /// Enter��ݼ�
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    LoginButton.PerformClick();//�����ָ���ļ�λ
                    return true;//�����Ѵ�����Ϣ
            }
            return base.ProcessCmdKey(ref msg, keyData);//�����λĬ�ϴ���
        }
        //ע�ᰴť
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ip = this.Textbox_Ip.Text != "" ? Textbox_Ip.Text : Net_class.getMy_ip();
            Form register = new Register(ip);
            register.Show();
        }

        /// <summary>
        /// ���ӵ�������
        /// </summary>
        private Net_class ConnectToSever()
        {
            ip = this.Textbox_Ip.Text != "" ? Textbox_Ip.Text : Net_class.getMy_ip();
            Net_class NC = new Net_class(ip, 8000); //�Զ����࣬���������¼�

            NC.try_connect(6000);
            if (!NC.sock.Connected)
            {
                DialogResult dr = MessageBox.Show("�޷����ӵ��������������������Ϣ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NC.Close();
                return null;
            }
            return NC;
        } 
    }
}