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
            registryKey = Registry.CurrentConfig;
        }
        private readonly RegistryKey registryKey;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Text = String.Empty;
                foreach (var item in Registry.CurrentUser.GetSubKeyNames())
                {
                    label1.Text = label1.Text + "\n " + item;
                }
            }
            else
            {
                label1.Text = registryKey.Name;
            }
        }


    }
}
