
namespace UI
{
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_bottomSetting = new System.Windows.Forms.Panel();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_buttonSetting = new System.Windows.Forms.Panel();
            this.button_quit = new System.Windows.Forms.Button();
            this.button_empty = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.panel_between = new System.Windows.Forms.Panel();
            this.richTextBox_display = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel_bottomSetting.SuspendLayout();
            this.panel_buttonSetting.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_bottomSetting
            // 
            this.panel_bottomSetting.Controls.Add(this.textBox_input);
            this.panel_bottomSetting.Controls.Add(this.panel3);
            this.panel_bottomSetting.Controls.Add(this.panel2);
            this.panel_bottomSetting.Controls.Add(this.panel1);
            this.panel_bottomSetting.Controls.Add(this.panel_buttonSetting);
            this.panel_bottomSetting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottomSetting.Location = new System.Drawing.Point(0, 401);
            this.panel_bottomSetting.Name = "panel_bottomSetting";
            this.panel_bottomSetting.Size = new System.Drawing.Size(837, 151);
            this.panel_bottomSetting.TabIndex = 0;
            // 
            // textBox_input
            // 
            this.textBox_input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_input.Location = new System.Drawing.Point(18, 0);
            this.textBox_input.Margin = new System.Windows.Forms.Padding(20);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(703, 135);
            this.textBox_input.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 135);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(721, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 135);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 16);
            this.panel1.TabIndex = 1;
            // 
            // panel_buttonSetting
            // 
            this.panel_buttonSetting.Controls.Add(this.button_quit);
            this.panel_buttonSetting.Controls.Add(this.button_empty);
            this.panel_buttonSetting.Controls.Add(this.button_send);
            this.panel_buttonSetting.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_buttonSetting.Location = new System.Drawing.Point(738, 0);
            this.panel_buttonSetting.Name = "panel_buttonSetting";
            this.panel_buttonSetting.Size = new System.Drawing.Size(99, 151);
            this.panel_buttonSetting.TabIndex = 0;
            // 
            // button_quit
            // 
            this.button_quit.BackColor = System.Drawing.SystemColors.Control;
            this.button_quit.Location = new System.Drawing.Point(12, 6);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(75, 23);
            this.button_quit.TabIndex = 1;
            this.button_quit.Text = "断开连接";
            this.button_quit.UseVisualStyleBackColor = false;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // button_empty
            // 
            this.button_empty.Location = new System.Drawing.Point(12, 62);
            this.button_empty.Name = "button_empty";
            this.button_empty.Size = new System.Drawing.Size(75, 23);
            this.button_empty.TabIndex = 1;
            this.button_empty.Text = "清除";
            this.button_empty.UseVisualStyleBackColor = true;
            this.button_empty.Click += new System.EventHandler(this.button_empty_Click);
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(12, 112);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // panel_between
            // 
            this.panel_between.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_between.Location = new System.Drawing.Point(0, 368);
            this.panel_between.Name = "panel_between";
            this.panel_between.Size = new System.Drawing.Size(837, 33);
            this.panel_between.TabIndex = 1;
            // 
            // richTextBox_display
            // 
            this.richTextBox_display.BackColor = System.Drawing.Color.White;
            this.richTextBox_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_display.HideSelection = false;
            this.richTextBox_display.Location = new System.Drawing.Point(18, 22);
            this.richTextBox_display.Name = "richTextBox_display";
            this.richTextBox_display.ReadOnly = true;
            this.richTextBox_display.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_display.Size = new System.Drawing.Size(819, 346);
            this.richTextBox_display.TabIndex = 2;
            this.richTextBox_display.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Title);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(837, 22);
            this.panel4.TabIndex = 3;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.SystemColors.Control;
            this.Title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Title.Dock = System.Windows.Forms.DockStyle.Left;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.MinimumSize = new System.Drawing.Size(-1, 23);
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Size = new System.Drawing.Size(668, 23);
            this.Title.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(18, 346);
            this.panel5.TabIndex = 4;
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 552);
            this.Controls.Add(this.richTextBox_display);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel_between);
            this.Controls.Add(this.panel_bottomSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.panel_bottomSetting.ResumeLayout(false);
            this.panel_bottomSetting.PerformLayout();
            this.panel_buttonSetting.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_bottomSetting;
        private TextBox textBox_input;
        private Panel panel_buttonSetting;
        private Button button_empty;
        private Button button_send;
        private Panel panel_between;
        private RichTextBox richTextBox_display;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
        private TextBox Title;
        private Button button_quit;
        private Panel panel5;
    }
}