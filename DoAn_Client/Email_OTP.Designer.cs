namespace DoAn
{
    partial class Email_OTP
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
            this.components = new System.ComponentModel.Container();
            this.lb_OTPNOTIFICATION = new System.Windows.Forms.Label();
            this.txt_OTPCONFIRM = new System.Windows.Forms.TextBox();
            this.btn_OTPCONFIRM = new System.Windows.Forms.Button();
            this.btn_OTPSEND = new System.Windows.Forms.Button();
            this.lb_OTPEMAIL = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_OTP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_OTPNOTIFICATION
            // 
            this.lb_OTPNOTIFICATION.AutoSize = true;
            this.lb_OTPNOTIFICATION.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_OTPNOTIFICATION.Location = new System.Drawing.Point(152, 36);
            this.lb_OTPNOTIFICATION.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OTPNOTIFICATION.Name = "lb_OTPNOTIFICATION";
            this.lb_OTPNOTIFICATION.Size = new System.Drawing.Size(271, 25);
            this.lb_OTPNOTIFICATION.TabIndex = 0;
            this.lb_OTPNOTIFICATION.Text = "Check Your Email For OTP";
            // 
            // txt_OTPCONFIRM
            // 
            this.txt_OTPCONFIRM.Location = new System.Drawing.Point(181, 118);
            this.txt_OTPCONFIRM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_OTPCONFIRM.MaxLength = 6;
            this.txt_OTPCONFIRM.Name = "txt_OTPCONFIRM";
            this.txt_OTPCONFIRM.Size = new System.Drawing.Size(203, 22);
            this.txt_OTPCONFIRM.TabIndex = 1;
            // 
            // btn_OTPCONFIRM
            // 
            this.btn_OTPCONFIRM.Location = new System.Drawing.Point(229, 170);
            this.btn_OTPCONFIRM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_OTPCONFIRM.Name = "btn_OTPCONFIRM";
            this.btn_OTPCONFIRM.Size = new System.Drawing.Size(100, 28);
            this.btn_OTPCONFIRM.TabIndex = 2;
            this.btn_OTPCONFIRM.Text = "CONFIRM";
            this.btn_OTPCONFIRM.UseVisualStyleBackColor = true;
            this.btn_OTPCONFIRM.Click += new System.EventHandler(this.btn_OTPCONFIRM_Click);
            // 
            // btn_OTPSEND
            // 
            this.btn_OTPSEND.Location = new System.Drawing.Point(413, 118);
            this.btn_OTPSEND.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_OTPSEND.Name = "btn_OTPSEND";
            this.btn_OTPSEND.Size = new System.Drawing.Size(100, 28);
            this.btn_OTPSEND.TabIndex = 3;
            this.btn_OTPSEND.Text = "SEND";
            this.btn_OTPSEND.UseVisualStyleBackColor = true;
            this.btn_OTPSEND.Click += new System.EventHandler(this.btn_OTPSEND_Click);
            // 
            // lb_OTPEMAIL
            // 
            this.lb_OTPEMAIL.AutoSize = true;
            this.lb_OTPEMAIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_OTPEMAIL.Location = new System.Drawing.Point(177, 84);
            this.lb_OTPEMAIL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OTPEMAIL.Name = "lb_OTPEMAIL";
            this.lb_OTPEMAIL.Size = new System.Drawing.Size(56, 20);
            this.lb_OTPEMAIL.TabIndex = 4;
            this.lb_OTPEMAIL.Text = "Email";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_OTP
            // 
            this.lb_OTP.AutoSize = true;
            this.lb_OTP.Location = new System.Drawing.Point(16, 118);
            this.lb_OTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OTP.Name = "lb_OTP";
            this.lb_OTP.Size = new System.Drawing.Size(44, 16);
            this.lb_OTP.TabIndex = 5;
            this.lb_OTP.Text = "label1";
            this.lb_OTP.Visible = false;
            // 
            // Email_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 242);
            this.Controls.Add(this.lb_OTP);
            this.Controls.Add(this.lb_OTPEMAIL);
            this.Controls.Add(this.btn_OTPSEND);
            this.Controls.Add(this.btn_OTPCONFIRM);
            this.Controls.Add(this.txt_OTPCONFIRM);
            this.Controls.Add(this.lb_OTPNOTIFICATION);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Email_OTP";
            this.Text = "Email_OTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_OTPNOTIFICATION;
        private System.Windows.Forms.TextBox txt_OTPCONFIRM;
        private System.Windows.Forms.Button btn_OTPCONFIRM;
        private System.Windows.Forms.Button btn_OTPSEND;
        private System.Windows.Forms.Label lb_OTPEMAIL;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_OTP;
    }
}