using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace OSHomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static RegistryKey pathForChange = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var path = pathForChange;
            if (checkBox1.Checked)
            {
                path.SetValue("RestrictRun", 0);
                path.SetValue("DisallowRun", 1);
                path.CreateSubKey("DisallowRun", true);
                var path2 = path.OpenSubKey("DisallowRun", true);
                path2.SetValue("1", "calc.exe");
            }
            else
            {
                path.SetValue("DisallowRun", 0);
                path.SetValue("RestrictRun", 1);
                path.CreateSubKey("RestrictRun", true);
                var path2 = path.OpenSubKey("RestrictRun", true);
                path2.SetValue("1","regedit.exe");
                path2.SetValue("2", "OSHomeWork.exe");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = pathForChange;
            if (path.GetSubKeyNames().Where(x => x == "RestrictRun").FirstOrDefault()!= null)
                path.DeleteSubKey("RestrictRun");
            if (path.GetSubKeyNames().Where(x => x == "DisallowRun").FirstOrDefault() != null)
                path.DeleteSubKey("DisallowRun");
            var path2 = path;
            if (path2.GetValue("RestrictRun") != null)
             path2.DeleteValue("RestrictRun");
            if (path2.GetValue("DisallowRun") != null)
                path2.DeleteValue("DisallowRun");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //to check - run Services.msc
            ProcessStartInfo pf = new ProcessStartInfo(Path.Combine(Environment.SystemDirectory, "dfrgui.exe"));
            pf.Verb = "runas";
            Process.Start(pf);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();

            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = "ChkDsk.exe";
            process.StartInfo.Arguments = string.Concat("e:", " /f");
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;

            process.Start();
        }
    }
}
