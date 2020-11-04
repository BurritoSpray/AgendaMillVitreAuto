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
            if (selectedClient.IsCompagnie)
            {
                textBoxBussiness.Text = selectedClient.BussinessName;
            }
            else
            {
                textBoxBussiness.Enabled = false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Client client = new Client(selectedClient.ID.ToString(), textBoxSecondName.Text, textBoxFirstName.Text, textBoxPhone.Text, textBoxAddress.Text);
            if (checkBoxIsBussiness.Checked)
            {
                client.IsCompagnie = true;
                client.BussinessName = textBoxBussiness.Text;
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

        private void checkBoxIsBussiness_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsBussiness.Checked == true)
            {
                textBoxBussiness.Enabled = true;
                selectedClient.IsCompagnie = true;

            }
            else if (checkBoxIsBussiness.Checked == false)
            {
                textBoxBussiness.Enabled = false;
                selectedClient.IsCompagnie = false;
            }
        }
    }
}
