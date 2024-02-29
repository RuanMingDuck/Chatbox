namespace DoAn
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listview_MessagesBox = new System.Windows.Forms.ListView();
            this.lb_name = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listview_FriendList = new System.Windows.Forms.ListView();
            this.txt_MessageSend = new System.Windows.Forms.TextBox();
            this.btnMessageSend = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnEmoji = new System.Windows.Forms.PictureBox();
            this.btn_Attachment = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIncrese = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmoji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Attachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 406);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.btnDecrease);
            this.panel2.Controls.Add(this.btnIncrese);
            this.panel2.Controls.Add(this.listview_MessagesBox);
            this.panel2.Location = new System.Drawing.Point(207, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 326);
            this.panel2.TabIndex = 1;
            // 
            // listview_MessagesBox
            // 
            this.listview_MessagesBox.HideSelection = false;
            this.listview_MessagesBox.Location = new System.Drawing.Point(14, 24);
            this.listview_MessagesBox.Name = "listview_MessagesBox";
            this.listview_MessagesBox.Size = new System.Drawing.Size(518, 290);
            this.listview_MessagesBox.TabIndex = 2;
            this.listview_MessagesBox.UseCompatibleStateImageBehavior = false;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(3, 4);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(57, 20);
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listview_FriendList);
            this.panel3.Controls.Add(this.lb_name);
            this.panel3.Location = new System.Drawing.Point(40, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 405);
            this.panel3.TabIndex = 1;
            // 
            // listview_FriendList
            // 
            this.listview_FriendList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listview_FriendList.AutoArrange = false;
            this.listview_FriendList.BackColor = System.Drawing.Color.White;
            this.listview_FriendList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_FriendList.ForeColor = System.Drawing.Color.Black;
            this.listview_FriendList.HideSelection = false;
            this.listview_FriendList.Location = new System.Drawing.Point(0, 24);
            this.listview_FriendList.Margin = new System.Windows.Forms.Padding(2);
            this.listview_FriendList.Name = "listview_FriendList";
            this.listview_FriendList.Size = new System.Drawing.Size(163, 379);
            this.listview_FriendList.TabIndex = 2;
            this.listview_FriendList.UseCompatibleStateImageBehavior = false;
            // 
            // txt_MessageSend
            // 
            this.txt_MessageSend.Location = new System.Drawing.Point(209, 361);
            this.txt_MessageSend.Multiline = true;
            this.txt_MessageSend.Name = "txt_MessageSend";
            this.txt_MessageSend.Size = new System.Drawing.Size(448, 50);
            this.txt_MessageSend.TabIndex = 3;
            // 
            // btnMessageSend
            // 
            this.btnMessageSend.Location = new System.Drawing.Point(663, 362);
            this.btnMessageSend.Name = "btnMessageSend";
            this.btnMessageSend.Size = new System.Drawing.Size(63, 49);
            this.btnMessageSend.TabIndex = 4;
            this.btnMessageSend.Text = "Send";
            this.btnMessageSend.UseVisualStyleBackColor = true;
            this.btnMessageSend.Click += new System.EventHandler(this.btnMessageSend_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(735, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(38, 25);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btnEmoji
            // 
            this.btnEmoji.Image = global::DoAn.Properties.Resources.icons8_anime_emoji_50;
            this.btnEmoji.Location = new System.Drawing.Point(251, 336);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(22, 19);
            this.btnEmoji.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnEmoji.TabIndex = 7;
            this.btnEmoji.TabStop = false;
            this.btnEmoji.Click += new System.EventHandler(this.btnEmoji_Click);
            // 
            // btn_Attachment
            // 
            this.btn_Attachment.Image = global::DoAn.Properties.Resources.attach_file;
            this.btn_Attachment.Location = new System.Drawing.Point(211, 336);
            this.btn_Attachment.Name = "btn_Attachment";
            this.btn_Attachment.Size = new System.Drawing.Size(22, 19);
            this.btn_Attachment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Attachment.TabIndex = 6;
            this.btn_Attachment.TabStop = false;
            this.btn_Attachment.Click += new System.EventHandler(this.btn_Attachment_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnIncrese
            // 
            this.btnIncrese.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrese.Location = new System.Drawing.Point(304, -3);
            this.btnIncrese.Name = "btnIncrese";
            this.btnIncrese.Size = new System.Drawing.Size(40, 27);
            this.btnIncrese.TabIndex = 3;
            this.btnIncrese.Text = "+";
            this.btnIncrese.UseVisualStyleBackColor = true;
            this.btnIncrese.Click += new System.EventHandler(this.btnIncrese_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrease.Location = new System.Drawing.Point(264, -3);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(40, 27);
            this.btnDecrease.TabIndex = 4;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(783, 413);
            this.Controls.Add(this.btnEmoji);
            this.Controls.Add(this.btn_Attachment);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btnMessageSend);
            this.Controls.Add(this.txt_MessageSend);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_Main";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmoji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Attachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listview_FriendList;
        private System.Windows.Forms.TextBox txt_MessageSend;
        private System.Windows.Forms.Button btnMessageSend;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.ListView listview_MessagesBox;
        private System.Windows.Forms.Button btn_Close;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox btn_Attachment;
        private System.Windows.Forms.PictureBox btnEmoji;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnIncrese;
    }
}