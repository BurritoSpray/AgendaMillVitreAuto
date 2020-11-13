using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    public partial class ManageClientsWindow : Form
    {
        ModifyClientWindow modifyClientWindow;
        ModifyVehicleWindow modifyVehicleWindow;
        ManageAppointmentWindow manageAppointmentWindow;
        private SqlConnection con = new SqlConnection();
        private List<Client> clientList = new List<Client>();
        private Client selectedClient = new Client();
        private Vehicle selectedVehicle = new Vehicle();
        private bool isBusiness = true;
        private bool isPrivate = true;

        public ManageClientsWindow()
        {
            InitializeComponent();
        }
        public ManageClientsWindow(bool isSelectMode)
        {
            
        }
        private void ClearVehicleInfoBox()
        {
            //Clear VehicleInfoBoxs
            comboBoxVehicle.Items.Clear();
            comboBoxVehicle.Text = "";
            textBoxBrand.Clear();
            textBoxModel.Clear();
            textBoxYear.Clear();
            textBoxColor.Clear();
        }
        //Active ou desactive les box clients
        private void ClearClientInfoBox()
        {
            textBoxFirstName.Clear();
            textBoxSecondName.Clear();
            textBoxPhone.Clear();
            textBoxAddress.Clear();
            textBoxbusiness.Clear();
        }

        private void RefreshClients()
        {
            BackgroundWorker loadClientsWorker = new BackgroundWorker();
            loadClientsWorker.DoWork += LoadClientsWorker_DoWork;
            loadClientsWorker.RunWorkerCompleted += LoadClientsWorker_RunWorkerCompleted;
            loadClientsWorker.RunWorkerAsync();
        }

        private void LoadClientsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Writing the data from sql to infoGrid
            textBoxSearch_TextChanged(this, new EventArgs());
            infoGrid.ClearSelection();
            selectedClient = new Client();
            selectedVehicle = new Vehicle();
            setSelectedClientInfo();
            setSelectedVehicleInfo();
            comboBoxVehicle.Items.Clear();

        }

        private void LoadClientsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            con = new SqlConnection();
            clientList = con.SelectClients();
        }

        private void setSelectedVehicleInfo()
        {
            if(selectedVehicle != null)
            {
                textBoxBrand.Text = selectedVehicle.Brand;
                textBoxModel.Text = selectedVehicle.Model;
                if (selectedVehicle.Year == 0) { textBoxYear.Text = string.Empty; }
                else { textBoxYear.Text = selectedVehicle.Year.ToString(); }
                textBoxColor.Text = selectedVehicle.Color;
            }
            else
            {
                ErrorMsg.ChooseVehicleError();
            }
        }
        
        private void setSelectedClientInfo()
        {
            if (selectedClient != null)
            {
                textBoxFirstName.Text = selectedClient.FirstName;
                textBoxSecondName.Text = selectedClient.SecondName;
                textBoxPhone.Text = selectedClient.Phone;
                textBoxAddress.Text = selectedClient.Address;
            }
        }
        
        private void SetVehicleComboBox()
        {
            if (selectedClient != new Client())
            {
                comboBoxVehicle.Items.Clear();
                foreach (Vehicle vehicle in selectedClient.VehicleList)
                {
                    comboBoxVehicle.Items.Add(vehicle.Brand + " " + vehicle.Model + " " + vehicle.Color);
                }
            }
        }

        private void ManageClientsWindow_Load(object sender, EventArgs e)
        {
            comboBoxSearch.SelectedIndex = 0;
            //Load client list
            RefreshClients();
            infoGrid.ClearSelection();
            selectedClient = new Client();
            selectedVehicle = new Vehicle();
        }
        
        private void ManageClientsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //this.Hide();
        }

        private void infoGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectedClient = clientList[e.RowIndex];
                //Clear les textBox et cree l'objet Client selectedClient
                ClearClientInfoBox();
                for(int i = 0; i<= clientList.Count - 1; i++)
                {
                    if (clientList[i].ID == int.Parse(infoGrid["ID", e.RowIndex].Value.ToString()))
                    {
                        selectedClient = clientList[i];
                    }
                }
                infoGrid.Rows[e.RowIndex].Selected = true;
                textBoxFirstName.Text = selectedClient.FirstName;
                textBoxSecondName.Text = selectedClient.SecondName;
                textBoxPhone.Text = selectedClient.Phone;
                textBoxAddress.Text = selectedClient.Address;
                if (selectedClient.IsBusiness)
                {
                    textBoxbusiness.Text = selectedClient.businessName;
                }
                selectedClient.VehicleList = con.SelectClientVehicles(selectedClient.ID);
                //Clear selectedVehicle
                selectedVehicle = new Vehicle();
                //ComboBox Vehicle
                ClearVehicleInfoBox();
                //Remplie le ComboBox avec la liste de vehicule du client
                SetVehicleComboBox();
            }
        }
        //Fenetre de creation de nouveau client
        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            infoGrid.ClearSelection();
            //Clear ClientTextbox
            ClearClientInfoBox();
            //Clear Vehicle Info
            selectedVehicle = new Vehicle();//Peut etre besoin detre null a place de new Vehicle
            ClearVehicleInfoBox();
            ModifyClientWindow newClientWindow = new ModifyClientWindow(new Client(), true);
            var value = newClientWindow.ShowDialog();
            RefreshClients();


        }

        private void comboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si une case est selectioner
            if (comboBoxVehicle.SelectedIndex != -1)
            {
                //Obtient les info du vehicule a partir du vehicleID
                selectedVehicle = con.SelectVehicleInfo(selectedClient.VehicleList[comboBoxVehicle.SelectedIndex].ID);
                setSelectedVehicleInfo();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshClients();
        }

        private void buttonDeleteSelectedClient_Click(object sender, EventArgs e)
        {
            if (selectedClient.ID != -1)
            {
                string msg = string.Format("Voulez-vous vraiment effacer le client {0}?", selectedClient.FullName);
                var value = MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo);
                if (value == DialogResult.Yes)
                {
                    //Delete selectedClient
                    con.DeleteSelectedClient(selectedClient.ID);
                    selectedClient = new Client();
                    RefreshClients();
                    setSelectedClientInfo();
                }
            }
            else
            {
                ErrorMsg.ChooseClientError();
            }
        }
        //Edit client window
        private void buttonEditSelectedClient_Click(object sender, EventArgs e)
        {
            if (selectedClient.ID != -1)
            {
                modifyClientWindow = new ModifyClientWindow(selectedClient, false);
                var value = modifyClientWindow.ShowDialog();
                selectedClient = con.SelectClientInfo(selectedClient.ID);
                for (int i = 0; i <= infoGrid.Rows.Count-1; i++)
                {
                    if(infoGrid["ID",i].Value.ToString() == selectedClient.ID.ToString())
                    {

                        editLine(selectedClient, i);
                        infoGrid.Rows[i].Selected = true;
                        setSelectedClientInfo();
                    }
                }
            }
            else
            {
                ErrorMsg.ChooseClientError();
            }
        }

        private void buttonNewVehicle_Click(object sender, EventArgs e)
        {
            if (selectedClient != null && selectedClient.ID != -1)
            {
                modifyVehicleWindow = new ModifyVehicleWindow(selectedClient);
                var value = modifyVehicleWindow.ShowDialog();
                selectedClient.VehicleList = con.SelectClientVehicles(selectedClient.ID);
                SetVehicleComboBox();
            }
            else
            {
                ErrorMsg.ChooseClientError();
            }
        }

        private void buttonDeleteSelectedVehicle_Click(object sender, EventArgs e)
        {
            if (selectedVehicle.ID != -1)
            {
                //Show messageBox to confirm if user really want to delete the selected vehicle
                string msg = string.Format("Voulez-vous vraiment effacer {0}, {1}, {2} du client {3}", selectedVehicle.Brand, selectedVehicle.Model, selectedVehicle.Year, selectedClient.FullName);
                var value = MessageBox.Show(msg, "Attention!", MessageBoxButtons.YesNo);
                if (value == DialogResult.Yes)
                {
                    con.DeleteSelectedVehicle(selectedVehicle);
                    selectedVehicle = new Vehicle();
                    setSelectedVehicleInfo();
                    selectedClient.VehicleList = con.SelectClientVehicles(selectedClient.ID);
                    SetVehicleComboBox();
                }
            }
            else
            {
                ErrorMsg.ChooseVehicleError();
            }
        }
        
        private void buttonEditSelectedVehicle_Click(object sender, EventArgs e)
        {
            if(selectedClient.ID != -1 && selectedVehicle.ID != -1)
            {
                modifyVehicleWindow = new ModifyVehicleWindow(selectedVehicle, selectedClient);
                var value = modifyVehicleWindow.ShowDialog();

            }
            else
            {
                ErrorMsg.ChooseVehicleError();
            }
        }

        //Affiche les resultat de la recherche chaque fois que le text est modifier
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            infoGrid.Rows.Clear();
            //Si la textBox est vide effectue un refresh
            if (textBoxSearch.Text == string.Empty)
            {
                //TODO Fix search bar loop when erasing text it tryes to refresh like 100 times
                infoGrid.Rows.Clear();
                for (int i = 0; i <= clientList.Count - 1; i++)
                {
                    addLine(clientList[i]);
                }
            }
            else
            {
                //Passe tout les client de clientList
                for (int i = 0; i <= clientList.Count - 1; i++)
                {
                    //Dependament de la selection de la comboBox affiche les match
                    //Nom. prenom
                    if (comboBoxSearch.SelectedIndex == 0)
                    {
                        if (clientList[i].FullName.ToLower().Contains(textBoxSearch.Text.ToLower()))
                        {
                            addLine(clientList[i]);
                        }
                    }
                    //Recherche par Telephone
                    else if (comboBoxSearch.SelectedIndex == 1)
                    {
                        if (clientList[i].Phone.ToLower().Contains(textBoxSearch.Text.ToLower()))
                        {
                            addLine(clientList[i]);
                        }
                    }
                    //Recherche par Adresse
                    else if (comboBoxSearch.SelectedIndex == 2)
                    {
                        if (clientList[i].Address.ToLower().Contains(textBoxSearch.Text.ToLower()))
                        {
                            addLine(clientList[i]);
                        }
                    }
                }
            }

        }

        private void addLine(Client client)
        {
            if (radioAll.Checked)
            {
                infoGrid.Rows.Add();
                int lineNumber = infoGrid.Rows.Count - 1;
                infoGrid["Nom", lineNumber].Value = client.SecondName;
                infoGrid["Prenom", lineNumber].Value = client.FirstName;
                infoGrid["Telephone", lineNumber].Value = client.Phone;
                infoGrid["Addresse", lineNumber].Value = client.Address;
                infoGrid["ID", lineNumber].Value = client.ID;
                infoGrid["Business", lineNumber].Value = client.IsBusiness;
            }
            else if (radioBusiness.Checked)
            {
                if (client.IsBusiness)
                {
                    infoGrid.Rows.Add();
                    int lineNumber = infoGrid.Rows.Count - 1;
                    infoGrid["Nom", lineNumber].Value = client.SecondName;
                    infoGrid["Prenom", lineNumber].Value = client.FirstName;
                    infoGrid["Telephone", lineNumber].Value = client.Phone;
                    infoGrid["Addresse", lineNumber].Value = client.Address;
                    infoGrid["ID", lineNumber].Value = client.ID;
                    infoGrid["Business", lineNumber].Value = client.IsBusiness;
                }
            }
            else if (radioPrivate.Checked)
            {
                if (!client.IsBusiness)
                {
                    infoGrid.Rows.Add();
                    int lineNumber = infoGrid.Rows.Count - 1;
                    infoGrid["Nom", lineNumber].Value = client.SecondName;
                    infoGrid["Prenom", lineNumber].Value = client.FirstName;
                    infoGrid["Telephone", lineNumber].Value = client.Phone;
                    infoGrid["Addresse", lineNumber].Value = client.Address;
                    infoGrid["ID", lineNumber].Value = client.ID;
                    infoGrid["Business", lineNumber].Value = client.IsBusiness;
                }
            }
        }
        private void editLine(Client client, int lineNumber)
        {
            if (radioAll.Checked)
            {
                infoGrid["Nom", lineNumber].Value = client.SecondName;
                infoGrid["Prenom", lineNumber].Value = client.FirstName;
                infoGrid["Telephone", lineNumber].Value = client.Phone;
                infoGrid["Addresse", lineNumber].Value = client.Address;
                infoGrid["ID", lineNumber].Value = client.ID;
                infoGrid["Business", lineNumber].Value = client.IsBusiness;
            }
            else if (radioBusiness.Checked)
            {
                if (client.IsBusiness)
                {
                    infoGrid["Nom", lineNumber].Value = client.SecondName;
                    infoGrid["Prenom", lineNumber].Value = client.FirstName;
                    infoGrid["Telephone", lineNumber].Value = client.Phone;
                    infoGrid["Addresse", lineNumber].Value = client.Address;
                    infoGrid["ID", lineNumber].Value = client.ID;
                    infoGrid["Business", lineNumber].Value = client.IsBusiness;
                }
            }
            else if (radioPrivate.Checked)
            {
                if (!client.IsBusiness)
                {
                    infoGrid["Nom", lineNumber].Value = client.SecondName;
                    infoGrid["Prenom", lineNumber].Value = client.FirstName;
                    infoGrid["Telephone", lineNumber].Value = client.Phone;
                    infoGrid["Addresse", lineNumber].Value = client.Address;
                    infoGrid["ID", lineNumber].Value = client.ID;
                    infoGrid["Business", lineNumber].Value = client.IsBusiness;
                }
            }
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(sender, e);
        }

        private void buttonAddAppointment_Click(object sender, EventArgs e)
        {
            if(selectedClient.ID != -1)
            {
                if(selectedVehicle.ID != -1)
                {
                    manageAppointmentWindow = new ManageAppointmentWindow(selectedClient, selectedVehicle);
                    manageAppointmentWindow.Show();
                }
                else
                {
                    ErrorMsg.ChooseVehicleError();
                }
            }
            else
            {
                ErrorMsg.ChooseClientError();
            }
        }

        private void radioAll_Click(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(this, new EventArgs());
        }

        private void radioBusiness_Click(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(this, new EventArgs());
        }

        private void radioPrivate_Click(object sender, EventArgs e)
        {
            textBoxSearch_TextChanged(this, new EventArgs());
        }
    }
}
