using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    public partial class ManageClientsWindow : Form
    {
        //TODO Optimize client and vehicle querry with a background worker and limit each querry to 1000 - 1500
        ModifyClientWindow modifyClientWindow;
        ModifyVehicleWindow modifyVehicleWindow;
        ManageAppointmentWindow manageAppointmentWindow;
        private SqlConnection con = new SqlConnection();
        private List<Client> clientList = new List<Client>();
        private Client selectedClient = new Client();
        private Vehicle selectedVehicle = new Vehicle();
        private bool isbusiness = false;

        public ManageClientsWindow()
        {
            InitializeComponent();
        }
        public ManageClientsWindow(bool isSelectMode)
        {
            
        }
        private void EnableVehicleInfoBox(bool state)
        {
            //Enable VehicleInfoBoxs
            if (state == true)
            {
                comboBoxVehicle.Items.Clear();
                comboBoxVehicle.Text = "";
                textBoxBrand.Clear();
                textBoxBrand.Enabled = true;
                textBoxModel.Clear();
                textBoxModel.Enabled = true;
                textBoxYear.Clear();
                textBoxYear.Enabled = true;
                textBoxColor.Clear();
                textBoxColor.Enabled = true;
            }
            else if(state == false)
            {
                comboBoxVehicle.Items.Clear();
                comboBoxVehicle.Text = "";
                textBoxBrand.Clear();
                textBoxBrand.Enabled = false;
                textBoxModel.Clear();
                textBoxModel.Enabled = false;
                textBoxYear.Clear();
                textBoxYear.Enabled = false;
                textBoxColor.Clear();
                textBoxColor.Enabled = false;
            }
        }
        //Active ou desactive les box clients
        private void EnableClientInfoBox(bool state)
        {
            if(state == true)
            {
                textBoxFirstName.Clear();
                textBoxFirstName.Enabled = true;
                textBoxSecondName.Clear();
                textBoxSecondName.Enabled = true;
                textBoxPhone.Clear();
                textBoxPhone.Enabled = true;
                textBoxAddress.Clear();
                textBoxAddress.Enabled = true;
                if (isbusiness) { textBoxbusiness.Enabled = true; }
                else { textBoxbusiness.Enabled = false; }
                textBoxbusiness.Clear();
            }
            else
            {
                textBoxFirstName.Clear();
                textBoxFirstName.Enabled = false;
                textBoxSecondName.Clear();
                textBoxSecondName.Enabled = false;
                textBoxPhone.Clear();
                textBoxPhone.Enabled = false;
                textBoxAddress.Clear();
                textBoxAddress.Enabled = false;
                textBoxbusiness.Clear();
                textBoxbusiness.Enabled = false;
            }

        }

        private void RefreshClients()
        {
            //Filtre pour les clients priver et Entreprise
            if (radioPrivate.Checked)
            {
                clientList = con.SelectClientsPrivate();
            }
            else if (radiobusiness.Checked)
            {
                clientList = con.SelectClientsbusiness();
            }
            else if(radioAll.Checked)
            {
                clientList = con.SelectClients();
            }
            //Writing the data from sql to infoGrid
            infoGrid.Rows.Clear();
            for (int i = 0; i <= clientList.Count - 1; i++)
            {
                infoGrid.Rows.Add();
                infoGrid["Nom", i].Value = clientList[i].SecondName;
                infoGrid["Prenom", i].Value = clientList[i].FirstName;
                infoGrid["Telephone", i].Value = clientList[i].Phone;
                infoGrid["Addresse", i].Value = clientList[i].Address;
                infoGrid["ID", i].Value = clientList[i].ID;
            }
            infoGrid.ClearSelection();
            selectedClient = new Client();
            selectedVehicle = new Vehicle();
            setSelectedClientInfo(false);
            setSelectedVehicleInfo(false);
            comboBoxVehicle.Items.Clear();
        }
        
        private void setSelectedVehicleInfo(bool isEnabled)
        {
            if(selectedVehicle != null)
            {
                if(isEnabled)
                {
                    textBoxBrand.Text = selectedVehicle.Brand;
                    textBoxBrand.Enabled = true;
                    textBoxModel.Text = selectedVehicle.Model;
                    textBoxModel.Enabled = true;
                    if (selectedVehicle.Year == 0) { textBoxYear.Text = string.Empty; }
                    else{textBoxYear.Text = selectedVehicle.Year.ToString();}
                    textBoxYear.Enabled = true;
                    textBoxColor.Text = selectedVehicle.Color;
                    textBoxColor.Enabled = true;
                }
                else if(isEnabled == false)
                {
                    textBoxBrand.Text = selectedVehicle.Brand;
                    textBoxBrand.Enabled = false;
                    textBoxModel.Text = selectedVehicle.Model;
                    textBoxModel.Enabled = false;
                    if (selectedVehicle.Year == 0) { textBoxYear.Text = string.Empty; }
                    else { textBoxYear.Text = selectedVehicle.Year.ToString(); }
                    textBoxYear.Enabled = false;
                    textBoxColor.Text = selectedVehicle.Color;
                    textBoxColor.Enabled = false;
                }
            }
            else
            {
                ErrorMsg.ChooseVehicleError();
            }
        }
        
        private void setSelectedClientInfo(bool isEnabled)
        {
            if (selectedClient != null)
            {


                if (isEnabled)
                {
                    EnableClientInfoBox(true);
                    textBoxFirstName.Text = selectedClient.FirstName;
                    textBoxSecondName.Text = selectedClient.SecondName;
                    textBoxPhone.Text = selectedClient.Phone;
                    textBoxAddress.Text = selectedClient.Address;
                    if (selectedClient.Isbusiness)
                        textBoxbusiness.Text = selectedClient.businessName;
                    comboBoxVehicle.Items.Clear();
                    SetVehicleComboBox();
                }
                else
                {
                    EnableClientInfoBox(false);
                    textBoxFirstName.Text = selectedClient.FirstName;
                    textBoxSecondName.Text = selectedClient.SecondName;
                    textBoxPhone.Text = selectedClient.Phone;
                    textBoxAddress.Text = selectedClient.Address;

                }
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
                //Desactive les textBox et cree l'objet Client selectedClient
                EnableClientInfoBox(false);
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
                if (selectedClient.Isbusiness)
                {
                    textBoxbusiness.Text = selectedClient.businessName;
                }
                //Clear selectedVehicle
                selectedVehicle = new Vehicle();
                //ComboBox Vehicle
                EnableVehicleInfoBox(false);
                SetVehicleComboBox();
            }
        }
        //Fenetre de creation de nouveau client
        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            infoGrid.ClearSelection();
            //Clear ClientTextbox
            EnableClientInfoBox(true);

            //Clear Vehicle Info
            selectedVehicle = new Vehicle();//Peut etre besoin detre null a place de new Vehicle
            EnableVehicleInfoBox(false);
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
                setSelectedVehicleInfo(false);
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
                    setSelectedClientInfo(false);
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
                int clientID = selectedClient.ID;
                RefreshClients();
                for (int i = 0; i <= infoGrid.Rows.Count-1; i++)
                {
                    if(infoGrid["ID",i].Value.ToString() == clientID.ToString())
                    {
                        
                        infoGrid.Rows[i].Selected = true;
                        selectedClient = con.SelectClientInfo(clientID);
                        setSelectedClientInfo(false);
                    }
                }
                //setSelectedClientInfo(false);
            }
            else
            {
                ErrorMsg.ChooseClientError();
            }
        }

        private void buttonNewVehicle_Click(object sender, EventArgs e)
        {
            int clientID;
            if (selectedClient != null && selectedClient.ID != -1)
            {
                clientID = selectedClient.ID;
                modifyVehicleWindow = new ModifyVehicleWindow(selectedClient);
                var value = modifyVehicleWindow.ShowDialog();
                RefreshClients();
                for(int i = 0; i <= infoGrid.Rows.Count-1; i++)
                {
                    if (infoGrid["ID", i].Value.ToString() == clientID.ToString())
                    {
                        infoGrid.Rows[i].Selected = true;
                        selectedClient = con.SelectClientInfo(clientID);
                        setSelectedClientInfo(false);
                        SetVehicleComboBox();
                    }
                }
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
                string msg = string.Format("Voulez-vous vraiment effacer {0}, {1}, {2} du client {3}", selectedVehicle.Brand, selectedVehicle.Model, selectedVehicle.Year, selectedClient.FullName);
                var value = MessageBox.Show(msg, "Attention!", MessageBoxButtons.YesNo);
                if (value == DialogResult.Yes)
                {
                    con.DeleteSelectedVehicle(selectedVehicle);
                    selectedVehicle = new Vehicle();
                    setSelectedVehicleInfo(false);
                    int clientID = selectedClient.ID;
                    RefreshClients();
                    for(int i = 0; i<= infoGrid.Rows.Count - 1; i++)
                    {
                        if(infoGrid["ID", i].Value.ToString() == clientID.ToString())
                        {
                            infoGrid.Rows[i].Selected = true;
                            selectedClient = con.SelectClientInfo(clientID);
                            setSelectedClientInfo(false);
                            SetVehicleComboBox();
                        }
                    }
                    //Peut etre besoin de faire un RefreshClients avant de update le comboBox parceque le vehicule est encore dans la liste de vehicule du client
                    //PROBLME DE COMBOBOX!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
        //Si letat de un des radio button est modifier la liste des client est actualiser avec les nouveau parametre
        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshClients();
        }
        //Affiche les resultat de la recherche chaque fois que le text est modifier
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            infoGrid.Rows.Clear();
            //Passe tout les client de clientList
            for (int i = 0; i<= clientList.Count-1; i++)
            {
                //Dependament de la selection de la comboBox affiche les match
                //Nom. prenom
                if(comboBoxSearch.SelectedIndex == 0)
                {
                    if (clientList[i].FullName.ToLower().Contains(textBoxSearch.Text.ToLower()))
                    {
                        infoGrid.Rows.Add();
                        infoGrid["Nom", count].Value = clientList[i].SecondName;
                        infoGrid["Prenom", count].Value = clientList[i].FirstName;
                        infoGrid["Telephone", count].Value = clientList[i].Phone;
                        infoGrid["Addresse", count].Value = clientList[i].Address;
                        infoGrid["ID", count].Value = clientList[i].ID;
                        count += 1;
                    }
                }
                //Recherche par Telephone
                else if(comboBoxSearch.SelectedIndex == 1)
                {
                    if (clientList[i].Phone.ToLower().Contains(textBoxSearch.Text.ToLower()))
                    {
                        infoGrid.Rows.Add();
                        infoGrid["Nom", count].Value = clientList[i].SecondName;
                        infoGrid["Prenom", count].Value = clientList[i].FirstName;
                        infoGrid["Telephone", count].Value = clientList[i].Phone;
                        infoGrid["Addresse", count].Value = clientList[i].Address;
                        infoGrid["ID", count].Value = clientList[i].ID;
                        count += 1;
                    }
                }
                //Recherche par Adresse
                else if (comboBoxSearch.SelectedIndex == 2)
                {
                    if (clientList[i].Address.ToLower().Contains(textBoxSearch.Text.ToLower()))
                    {
                        infoGrid.Rows.Add();
                        infoGrid["Nom", count].Value = clientList[i].SecondName;
                        infoGrid["Prenom", count].Value = clientList[i].FirstName;
                        infoGrid["Telephone", count].Value = clientList[i].Phone;
                        infoGrid["Addresse", count].Value = clientList[i].Address;
                        infoGrid["ID", count].Value = clientList[i].ID;
                        count += 1;
                    }
                }
                //Si la textBox est vide effectue un refresh
                if(textBoxSearch.Text == string.Empty)
                {
                    RefreshClients();
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
    }
}
