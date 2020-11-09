using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    public partial class ModifyClientWindow : Form
    {
        private Client selectedClient;
        private SqlConnection con = new SqlConnection();
        bool isNewClient;
        public ModifyClientWindow(Object client, bool newClient)
        {
            InitializeComponent();
            selectedClient = client as Client;
            isNewClient = newClient;
            if (isNewClient) { this.Text = "Nouveau Client"; }
            labelModifyClient.Text += "  ID: " + selectedClient.ID.ToString();
            textBoxSecondName.Text = selectedClient.SecondName;
            textBoxFirstName.Text = selectedClient.FirstName;
            textBoxPhone.Text = selectedClient.Phone;
            textBoxAddress.Text = selectedClient.Address;
            if (selectedClient.Isbusiness)
            {
                textBoxbusiness.Text = selectedClient.businessName;
            }
            else
            {
                textBoxbusiness.Enabled = false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Client client = new Client(selectedClient.ID.ToString(), textBoxSecondName.Text, textBoxFirstName.Text, textBoxPhone.Text, textBoxAddress.Text);
            if (checkBoxIsbusiness.Checked)
            {
                client.Isbusiness = true;
                client.businessName = textBoxbusiness.Text;
            }
            if(isNewClient)
            {
                con.InsertNewClient(client);
            }
            else
            {
                con.UpdateClientInfo(client);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void checkBoxIsbusiness_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsbusiness.Checked == true)
            {
                textBoxbusiness.Enabled = true;
                selectedClient.Isbusiness = true;

            }
            else if (checkBoxIsbusiness.Checked == false)
            {
                textBoxbusiness.Enabled = false;
                selectedClient.Isbusiness = false;
            }
        }
    }
}
