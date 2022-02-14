
namespace CVPro
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txt_license = new System.Windows.Forms.TextBox();
            this.lb_license = new System.Windows.Forms.Label();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_demo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_license
            // 
            this.txt_license.Location = new System.Drawing.Point(17, 43);
            this.txt_license.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_license.Name = "txt_license";
            this.txt_license.Size = new System.Drawing.Size(337, 26);
            this.txt_license.TabIndex = 0;
            // 
            // lb_license
            // 
            this.lb_license.AutoSize = true;
            this.lb_license.Location = new System.Drawing.Point(13, 18);
            this.lb_license.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_license.Name = "lb_license";
            this.lb_license.Size = new System.Drawing.Size(94, 20);
            this.lb_license.TabIndex = 1;
            this.lb_license.Text = "LicenseKey:";
            // 
            // btn_register
            // 
            this.btn_register.Location = new System.Drawing.Point(17, 77);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(160, 36);
            this.btn_register.TabIndex = 2;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_demo
            // 
            this.btn_demo.Location = new System.Drawing.Point(194, 77);
            this.btn_demo.Name = "btn_demo";
            this.btn_demo.Size = new System.Drawing.Size(160, 36);
            this.btn_demo.TabIndex = 3;
            this.btn_demo.Text = "Free Trial";
            this.btn_demo.UseVisualStyleBackColor = true;
            this.btn_demo.Click += new System.EventHandler(this.btn_demo_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 130);
            this.Controls.Add(this.btn_demo);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.lb_license);
            this.Controls.Add(this.txt_license);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CVPro Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_license;
        private System.Windows.Forms.Label lb_license;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Button btn_demo;
    }
}

