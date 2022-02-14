using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVPro
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        public string login_check = string.Empty;
        public string get_uuid = string.Empty;
        public double get_day = 0;

        private string uuid()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
            ManagementObjectCollection moc = mos.Get();
            string uuid_ = "";
            foreach (ManagementObject mo in moc)
            {
               uuid_ = (string)mo["UUID"];
            }
            return uuid_;
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            if (login_check == "free")
            {
                this.Text = "CVPro - Main (Free Version)";
            }else if (login_check != "login success!")
            {
                Environment.FailFast("0");
            }
            else
            {
                if(get_uuid != uuid())
                {
                    Environment.FailFast("0");
                }
                else
                {
                    if(get_day > 0)
                    {
                        this.Text = "CVPro - Main (remaining time " + get_day.ToString() + " day)";
                    }
                    else
                    {
                        Environment.FailFast("0");
                    }
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            debuggercheck();
            if(login_check == "free")
            {
                this.Text = "CVPro - Main (Free Version)";
            }
            else if (login_check != "login success!")
            {
                Environment.FailFast("0");
            }
            else
            {
                if (get_uuid == uuid())
                {
                    if (get_day > 0)
                    {
                        this.Text = "CVPro - Main (remaining time " + get_day.ToString() + " day)";
                    }
                    else
                    {
                        Environment.FailFast("0");
                    }
                }
                else
                {
                    Environment.FailFast("0");
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
    }
}
