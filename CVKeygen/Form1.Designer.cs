
namespace CVKeygen
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_hwid = new System.Windows.Forms.TextBox();
            this.txt_lifetime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_createkey = new System.Windows.Forms.Button();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.txt_decrypt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "UUID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_hwid
            // 
            this.txt_hwid.Location = new System.Drawing.Point(16, 32);
            this.txt_hwid.Name = "txt_hwid";
            this.txt_hwid.Size = new System.Drawing.Size(326, 26);
            this.txt_hwid.TabIndex = 1;
            this.txt_hwid.Text = "0";
            this.txt_hwid.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_lifetime
            // 
            this.txt_lifetime.Location = new System.Drawing.Point(16, 86);
            this.txt_lifetime.Name = "txt_lifetime";
            this.txt_lifetime.Size = new System.Drawing.Size(326, 26);
            this.txt_lifetime.TabIndex = 3;
            this.txt_lifetime.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "LifeTime (Day)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn_createkey
            // 
            this.btn_createkey.Location = new System.Drawing.Point(16, 118);
            this.btn_createkey.Name = "btn_createkey";
            this.btn_createkey.Size = new System.Drawing.Size(326, 33);
            this.btn_createkey.TabIndex = 4;
            this.btn_createkey.Text = "Create License Key";
            this.btn_createkey.UseVisualStyleBackColor = true;
            this.btn_createkey.Click += new System.EventHandler(this.btn_createkey_Click);
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(16, 157);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(326, 89);
            this.txt_output.TabIndex = 5;
            // 
            // txt_decrypt
            // 
            this.txt_decrypt.Location = new System.Drawing.Point(16, 252);
            this.txt_decrypt.Multiline = true;
            this.txt_decrypt.Name = "txt_decrypt";
            this.txt_decrypt.Size = new System.Drawing.Size(326, 89);
            this.txt_decrypt.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 248);
            this.Controls.Add(this.txt_decrypt);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.btn_createkey);
            this.Controls.Add(this.txt_lifetime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_hwid);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CVPro License Key Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_hwid;
        private System.Windows.Forms.TextBox txt_lifetime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_createkey;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.TextBox txt_decrypt;
    }
}

