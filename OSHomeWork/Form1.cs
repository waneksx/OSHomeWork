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

namespace OSHomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var path = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Policies").OpenSubKey("Explorer", true);
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
                var path2 = path.OpenSubKey("RestrictRun");
                path2.SetValue("1","regedit.exe");
            }
        }


    }
}
