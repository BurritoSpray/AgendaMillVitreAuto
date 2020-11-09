using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFiller
{
    public partial class SettingWindow : Form
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void SettingWindow_Load(object sender, EventArgs e)
        {
            textBoxIP.Text = Settings.IP;
            numericUpDownPort.Value = Settings.PORT;
            textBoxUser.Text = Settings.USERNAME;
            textBoxPassword.Text = Settings.PASSWORD;
            textBoxDBName.Text = Settings.DBNAME;
        }

        private void buttonTestAndSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            if (con.TestConnection(textBoxIP.Text, textBoxDBName.Text, textBoxUser.Text, textBoxPassword.Text))
            {
                buttonTestAndSave.Text = "Success!";
                Settings.IP = textBoxIP.Text;
                Settings.PORT = (int)numericUpDownPort.Value;
                Settings.USERNAME = textBoxUser.Text;
                Settings.PASSWORD = textBoxPassword.Text;
                Settings.DBNAME = textBoxDBName.Text;
                Thread.Sleep(3000);
                this.Dispose();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
