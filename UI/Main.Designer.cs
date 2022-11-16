using System.Runtime.CompilerServices;

namespace UI
{
    partial class Main
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
            this.Setting_List = new System.Windows.Forms.Panel();
            this.Setting_GroupsList = new System.Windows.Forms.Panel();
            this.Panel_GroupsList = new System.Windows.Forms.Panel();
            this.List_Groups = new System.Windows.Forms.ListBox();
            this.setting_list_groups_bottom = new System.Windows.Forms.Panel();
            this.Button_JoinGroup = new System.Windows.Forms.Button();
            this.Button_GroupsList = new System.Windows.Forms.Button();
            this.Setting_FriendsList = new System.Windows.Forms.Panel();
            this.Panel_FriendList = new System.Windows.Forms.Panel();
            this.List_Friends = new System.Windows.Forms.ListBox();
            this.Setting_list_friends_bottom = new System.Windows.Forms.Panel();
            this.Button_Setgroup = new System.Windows.Forms.Button();
            this.Button_Connection = new System.Windows.Forms.Button();
            this.Button_FriendList = new System.Windows.Forms.Button();
            this.Setting_Message = new System.Windows.Forms.Panel();
            this.Setting_List.SuspendLayout();
            this.Setting_GroupsList.SuspendLayout();
            this.Panel_GroupsList.SuspendLayout();
            this.setting_list_groups_bottom.SuspendLayout();
            this.Setting_FriendsList.SuspendLayout();
            this.Panel_FriendList.SuspendLayout();
            this.Setting_list_friends_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // Setting_List
            // 
            this.Setting_List.Controls.Add(this.Setting_GroupsList);
            this.Setting_List.Controls.Add(this.Setting_FriendsList);
            this.Setting_List.Dock = System.Windows.Forms.DockStyle.Left;
            this.Setting_List.Location = new System.Drawing.Point(0, 0);
            this.Setting_List.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Setting_List.Name = "Setting_List";
            this.Setting_List.Size = new System.Drawing.Size(201, 586);
            this.Setting_List.TabIndex = 0;
            // 
            // Setting_GroupsList
            // 
            this.Setting_GroupsList.Controls.Add(this.Panel_GroupsList);
            this.Setting_GroupsList.Controls.Add(this.Button_GroupsList);
            this.Setting_GroupsList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Setting_GroupsList.Location = new System.Drawing.Point(0, 324);
            this.Setting_GroupsList.Margin = new System.Windows.Forms.Padding(0);
            this.Setting_GroupsList.Name = "Setting_GroupsList";
            this.Setting_GroupsList.Size = new System.Drawing.Size(201, 262);
            this.Setting_GroupsList.TabIndex = 1;
            // 
            // Panel_GroupsList
            // 
            this.Panel_GroupsList.Controls.Add(this.List_Groups);
            this.Panel_GroupsList.Controls.Add(this.setting_list_groups_bottom);
            this.Panel_GroupsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_GroupsList.Location = new System.Drawing.Point(0, 25);
            this.Panel_GroupsList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel_GroupsList.Name = "Panel_GroupsList";
            this.Panel_GroupsList.Size = new System.Drawing.Size(201, 235);
            this.Panel_GroupsList.TabIndex = 1;
            // 
            // List_Groups
            // 
            this.List_Groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List_Groups.FormattingEnabled = true;
            this.List_Groups.ItemHeight = 17;
            this.List_Groups.Location = new System.Drawing.Point(0, 0);
            this.List_Groups.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.List_Groups.Name = "List_Groups";
            this.List_Groups.Size = new System.Drawing.Size(201, 210);
            this.List_Groups.TabIndex = 1;
            // 
            // setting_list_groups_bottom
            // 
            this.setting_list_groups_bottom.Controls.Add(this.Button_JoinGroup);
            this.setting_list_groups_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.setting_list_groups_bottom.Location = new System.Drawing.Point(0, 210);
            this.setting_list_groups_bottom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.setting_list_groups_bottom.Name = "setting_list_groups_bottom";
            this.setting_list_groups_bottom.Size = new System.Drawing.Size(201, 25);
            this.setting_list_groups_bottom.TabIndex = 0;
            // 
            // Button_JoinGroup
            // 
            this.Button_JoinGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_JoinGroup.Location = new System.Drawing.Point(0, 0);
            this.Button_JoinGroup.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Button_JoinGroup.Name = "Button_JoinGroup";
            this.Button_JoinGroup.Size = new System.Drawing.Size(201, 25);
            this.Button_JoinGroup.TabIndex = 0;
            this.Button_JoinGroup.Text = "加入群聊";
            this.Button_JoinGroup.UseVisualStyleBackColor = true;
            this.Button_JoinGroup.Click += new System.EventHandler(this.Button_JoinGroup_Click);
            // 
            // Button_GroupsList
            // 
            this.Button_GroupsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_GroupsList.Location = new System.Drawing.Point(0, 0);
            this.Button_GroupsList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Button_GroupsList.Name = "Button_GroupsList";
            this.Button_GroupsList.Size = new System.Drawing.Size(201, 25);
            this.Button_GroupsList.TabIndex = 0;
            this.Button_GroupsList.Text = "群聊房间列表";
            this.Button_GroupsList.UseVisualStyleBackColor = true;
            this.Button_GroupsList.Click += new System.EventHandler(this.Button_GroupsList_Click);
            // 
            // Setting_FriendsList
            // 
            this.Setting_FriendsList.Controls.Add(this.Panel_FriendList);
            this.Setting_FriendsList.Controls.Add(this.Button_FriendList);
            this.Setting_FriendsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.Setting_FriendsList.Location = new System.Drawing.Point(0, 0);
            this.Setting_FriendsList.Margin = new System.Windows.Forms.Padding(0);
            this.Setting_FriendsList.Name = "Setting_FriendsList";
            this.Setting_FriendsList.Size = new System.Drawing.Size(201, 325);
            this.Setting_FriendsList.TabIndex = 0;
            // 
            // Panel_FriendList
            // 
            this.Panel_FriendList.Controls.Add(this.List_Friends);
            this.Panel_FriendList.Controls.Add(this.Setting_list_friends_bottom);
            this.Panel_FriendList.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_FriendList.Location = new System.Drawing.Point(0, 25);
            this.Panel_FriendList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Panel_FriendList.Name = "Panel_FriendList";
            this.Panel_FriendList.Size = new System.Drawing.Size(201, 298);
            this.Panel_FriendList.TabIndex = 1;
            // 
            // List_Friends
            // 
            this.List_Friends.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.List_Friends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.List_Friends.FormattingEnabled = true;
            this.List_Friends.ItemHeight = 17;
            this.List_Friends.Location = new System.Drawing.Point(0, 0);
            this.List_Friends.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.List_Friends.Name = "List_Friends";
            this.List_Friends.Size = new System.Drawing.Size(201, 273);
            this.List_Friends.TabIndex = 3;
            // 
            // Setting_list_friends_bottom
            // 
            this.Setting_list_friends_bottom.Controls.Add(this.Button_Setgroup);
            this.Setting_list_friends_bottom.Controls.Add(this.Button_Connection);
            this.Setting_list_friends_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Setting_list_friends_bottom.Location = new System.Drawing.Point(0, 273);
            this.Setting_list_friends_bottom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Setting_list_friends_bottom.Name = "Setting_list_friends_bottom";
            this.Setting_list_friends_bottom.Size = new System.Drawing.Size(201, 25);
            this.Setting_list_friends_bottom.TabIndex = 0;
            // 
            // Button_Setgroup
            // 
            this.Button_Setgroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_Setgroup.Location = new System.Drawing.Point(101, 0);
            this.Button_Setgroup.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Setgroup.Name = "Button_Setgroup";
            this.Button_Setgroup.Size = new System.Drawing.Size(100, 25);
            this.Button_Setgroup.TabIndex = 1;
            this.Button_Setgroup.Text = "创建群聊";
            this.Button_Setgroup.UseVisualStyleBackColor = true;
            this.Button_Setgroup.Click += new System.EventHandler(this.Button_Setgroup_Click);
            // 
            // Button_Connection
            // 
            this.Button_Connection.Dock = System.Windows.Forms.DockStyle.Left;
            this.Button_Connection.Location = new System.Drawing.Point(0, 0);
            this.Button_Connection.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Connection.Name = "Button_Connection";
            this.Button_Connection.Size = new System.Drawing.Size(100, 25);
            this.Button_Connection.TabIndex = 0;
            this.Button_Connection.Text = "建立连接";
            this.Button_Connection.UseVisualStyleBackColor = true;
            this.Button_Connection.Click += new System.EventHandler(this.Button_Connection_Click);
            // 
            // Button_FriendList
            // 
            this.Button_FriendList.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_FriendList.Location = new System.Drawing.Point(0, 0);
            this.Button_FriendList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Button_FriendList.Name = "Button_FriendList";
            this.Button_FriendList.Size = new System.Drawing.Size(201, 25);
            this.Button_FriendList.TabIndex = 0;
            this.Button_FriendList.Text = "好友列表";
            this.Button_FriendList.UseVisualStyleBackColor = true;
            this.Button_FriendList.Click += new System.EventHandler(this.Button_FriendList_Click);
            // 
            // Setting_Message
            // 
            this.Setting_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Setting_Message.Location = new System.Drawing.Point(201, 0);
            this.Setting_Message.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Setting_Message.Name = "Setting_Message";
            this.Setting_Message.Size = new System.Drawing.Size(712, 586);
            this.Setting_Message.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 586);
            this.Controls.Add(this.Setting_Message);
            this.Controls.Add(this.Setting_List);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Interfave";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Setting_List.ResumeLayout(false);
            this.Setting_GroupsList.ResumeLayout(false);
            this.Panel_GroupsList.ResumeLayout(false);
            this.setting_list_groups_bottom.ResumeLayout(false);
            this.Setting_FriendsList.ResumeLayout(false);
            this.Panel_FriendList.ResumeLayout(false);
            this.Setting_list_friends_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel Setting_List;
        private Panel Setting_GroupsList;
        private Panel Panel_GroupsList;
        private Button Button_GroupsList;
        private Panel Setting_FriendsList;
        private Button Button_FriendList;
        private Panel Setting_Message;
        private Panel Panel_FriendList;
        public ListBox List_Friends;
        private Panel Setting_list_friends_bottom;
        private Button Button_Setgroup;
        private Button Button_Connection;
        private ListBox List_Groups;
        private Panel setting_list_groups_bottom;
        private Button Button_JoinGroup;
    }
}