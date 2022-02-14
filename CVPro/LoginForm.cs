using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVPro
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        public static DateTimeOffset? GetCurrentTime()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var result = client.GetAsync("https://google.com",
                          HttpCompletionOption.ResponseHeadersRead).Result;
                    return result.Headers.Date;
                }
                catch
                {
                    return null;
                }
            }
        }

        private string get_uuid = string.Empty;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            debuggercheck();
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
            ManagementObjectCollection moc = mos.Get();
            foreach (ManagementObject mo in moc)
            {
                get_uuid = (string)mo["UUID"];
            }
            if (File.Exists(Application.StartupPath + @"/CVLicense.license"))
            {
                txt_license.Text = File.ReadAllText(Application.StartupPath + @"/CVLicense.license");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            var decryptkey = Decrypt(txt_license.Text, "P@$$W0RD!@#$%123456");
            var splitkey = decryptkey.Split('|');
            if(splitkey[0] != null && splitkey[0] == get_uuid)
            {
                var date = (Convert.ToDateTime(splitkey[1]) - Convert.ToDateTime(GetCurrentTime().Value.ToLocalTime().Date.ToShortDateString())).TotalDays;
                if (date <= 0)
                {
                    MessageBox.Show("วันใช้งานเหลือ 0 กรุณาติดต่อแอดมิน!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Welcome " + Environment.UserName + "!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.WriteAllText(Application.StartupPath + @"/CVLicense.license",txt_license.Text);
                    this.Hide();
                    Main main = new Main();
                    main.login_check = "login success!";
                    main.get_uuid = splitkey[0];
                    main.get_day = date;
                    main.Show();
                }
            }
            else
            {
                MessageBox.Show("หมายเลขเครื่องไม่ถูกต้อง กรุณาติดต่อแอดมิน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string Decrypt(string CipherText, string Password,
              string Salt = "h00Sch~|^:><i3]HLp+u`@xcc|r4KUeG#ve%OCr`U2TP]J[y!;I9.&9_VS|u*G", string HashAlgorithm = "SHA256",
              int PasswordIterations = 2, string InitialVector = "CodeVirtual*12!+",
              int KeySize = 256)
        {
            if (string.IsNullOrEmpty(CipherText))
                return "";
            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
            byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] CipherTextBytes = Convert.FromBase64String(CipherText);
            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
            byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;
            byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
            int ByteCount = 0;
            using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                    {

                        ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            SymmetricKey.Clear();
            return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"/CVLicense.license"))
            {
                var read_key = Decrypt(File.ReadAllText(Application.StartupPath + @"/CVLicense.license"), "P@$$W0RD!@#$%123456");
                var splitkey = read_key.Split('|');
                if (splitkey[0] != null && splitkey[0] == get_uuid)
                {
                    var date = (Convert.ToDateTime(splitkey[1]) - Convert.ToDateTime(GetCurrentTime().Value.ToLocalTime().Date.ToShortDateString())).TotalDays;
                    if (date <= 0)
                    {
                        MessageBox.Show("วันใช้งานเหลือ 0 กรุณาติดต่อแอดมิน!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (date <= 3)
                    {
                        MessageBox.Show("วันใช้งานของคุณใกล้หมดแล้ว กรุณาติดต่อแอดมินเพื่อต่ออายุ" + Environment.NewLine + "เหลือเวลาใช้งานอีก " + (Convert.ToDateTime(splitkey[1]) - Convert.ToDateTime(GetCurrentTime().Value.ToLocalTime().Date.ToShortDateString())).TotalDays.ToString() + " วัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Main main = new Main();
                        main.login_check = "login success!";
                        main.get_uuid = splitkey[0];
                        main.get_day = date;
                        main.Show();
                    }
                    else
                    {
                        this.Hide();
                        Main main = new Main();
                        main.login_check = "login success!";
                        main.get_uuid = splitkey[0];
                        main.get_day = date;
                        main.Show();
                    }
                }
                else
                {
                    MessageBox.Show("หมายเลขเครื่องไม่ถูกต้อง กรุณาติดต่อแอดมิน!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Code by XenocodeRCE
        private void debuggercheck()
        {
            IntPtr kernel32 = LoadLibrary("kernel32.dll");
            IntPtr GetProcessId = GetProcAddress(kernel32, "IsDebuggerPresent");

            byte[] data = new byte[1];
            System.Runtime.InteropServices.Marshal.Copy(GetProcessId, data, 0, 1);


            if (data[0] == 0xE9)
            {
                MessageBox.Show("Debugger Tools Detected!");
                Application.Exit();
            }

            GetProcessId = GetProcAddress(kernel32, "CheckRemoteDebuggerPresent");
            data = new byte[1];
            System.Runtime.InteropServices.Marshal.Copy(GetProcessId, data, 0, 1);

            if (data[0] == 0xE9)
            {
                MessageBox.Show("Debugger Tools Detected!");
                Application.Exit();
            }
        }

        private void btn_demo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.login_check = "free";
            main.Show();
        }
    }
}
