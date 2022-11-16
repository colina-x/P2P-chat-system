namespace Net_server
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.listBox_online = new System.Windows.Forms.ListBox();
            this.textBox_localIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地IP：";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(20, 56);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(348, 274);
            this.txtMsg.TabIndex = 2;
            // 
            // listBox_online
            // 
            this.listBox_online.FormattingEnabled = true;
            this.listBox_online.ItemHeight = 12;
            this.listBox_online.Location = new System.Drawing.Point(393, 56);
            this.listBox_online.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_online.Name = "listBox_online";
            this.listBox_online.Size = new System.Drawing.Size(188, 268);
            this.listBox_online.TabIndex = 3;
            // 
            // textBox_localIP
            // 
            this.textBox_localIP.Location = new System.Drawing.Point(90, 22);
            this.textBox_localIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_localIP.Name = "textBox_localIP";
            this.textBox_localIP.Size = new System.Drawing.Size(128, 21);
            this.textBox_localIP.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.textBox_localIP);
            this.Controls.Add(this.listBox_online);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "P2P_服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.ListBox listBox_online;
        private System.Windows.Forms.TextBox textBox_localIP;
    }
}

