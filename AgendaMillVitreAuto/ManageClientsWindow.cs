using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

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
        private DataTable clientDataTable = new DataTable("main");
        private DataTable tempClientDataTable = new DataTable("temp");
        private BindingSource clientDataTableBinding = new BindingSource();
        private System.Windows.Forms.Timer searchBoxTimer = new System.Windows.Forms.Timer();

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
            loadClientsWorker.DoWork += RefreshClientsWorker_DoWork;
            loadClientsWorker.RunWorkerCompleted += RefreshClientsWorker_RunWorkerCompleted;
            loadClientsWorker.RunWorkerAsync();
        }

        private void RefreshClientsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Writing the data from sql to infoGrid
            infoGrid.ClearSelection();
            selectedClient = new Client();
            selectedVehicle = new Vehicle();
            setSelectedClientInfo();
            setSelectedVehicleInfo();
            comboBoxVehicle.Items.Clear();
            updateClientDataTable();
            clientDataTableBinding.DataSource = clientDataTable;
        }

        private void RefreshClientsWorker_DoWork(object sender, DoWorkEventArgs e)
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
                textBoxbusiness.Text = selectedClient.businessName;
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
            //infoGrid.AutoGenerateColumns = false;
            clientDataTable.Columns.Add("Nom");
            clientDataTable.Columns.Add("Prenom");
            clientDataTable.Columns.Add("Telephone");
            clientDataTable.Columns.Add("Adresse");
            clientDataTable.Columns.Add("ID");
            clientDataTable.Columns.Add("Business");
            infoGrid.DataSource = clientDataTableBinding;
            clientDataTableBinding.DataSource = clientDataTable;
            infoGrid.Columns["ID"].Visible = false;
            infoGrid.Columns["Business"].Visible = false;
            tempClientDataTable = clientDataTable.Clone();
            tempClientDataTable.TableName = "temp";
            comboBoxSearch.SelectedIndex = 0;
            //Load client list
            RefreshClients();
            infoGrid.ClearSelection();
            selectedClient = new Client();
            selectedVehicle = new Vehicle();
            setupSearchBoxTimer();
        }
        private void setupSearchBoxTimer()
        {
            searchBoxTimer = new System.Windows.Forms.Timer();
            searchBoxTimer.Interval = 1200;
            searchBoxTimer.Tick += SearchBoxTimer_Tick;
        }

        private void SearchBoxTimer_Tick(object sender, EventArgs e)
        {
            searchBoxTimer.Enabled = false;
            RefreshClients();
        }

        private void textBoxSearch_TextChanged(Object sender, EventArgs e)
        {

            searchBoxTimer.Stop();
            searchBoxTimer.Start();
        }
        //Affiche les resultat de la recherche chaque fois que le text est modifier
        private void updateClientDataTable()
        {
            string clientType = string.Empty;
            string searchBoxText = textBoxSearch.Text.ToLower();
            if (radioAll.Checked)
                clientType = "all";
            else if (radioBusiness.Checked)
                clientType = "business";
            else if (radioPrivate.Checked)
                clientType = "private";
            tempClientDataTable.Rows.Clear();
            
            switch (clientType)
            {
                case "all":
                    foreach (Client client in clientList)
                    {
                        if(searchBoxText != string.Empty)
                        {
                            switch (comboBoxSearch.SelectedIndex)
                            {
                                //FullName Search
                                case 0:
                                    if (client.FullName.ToLower().Contains(searchBoxText))
                                        tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                    break;
                                //Phone Search
                                case 1:
                                    if(client.Phone.ToLower().Contains(searchBoxText))
                                        tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                    break;
                                //Address Search
                                case 2:
                                    if(client.Address.ToLower().Contains(searchBoxText))
                                        tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                    break;
                            }
                        }
                        else
                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                    }
                    break;
                case "private":
                    foreach(Client client in clientList)
                    {
                        if (!client.IsBusiness)
                        {
                            if (searchBoxText != string.Empty)
                            {
                                switch (comboBoxSearch.SelectedIndex)
                                {
                                    //FullName Search
                                    case 0:
                                        if (client.FullName.ToLower().Contains(searchBoxText))
                                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                        break;
                                    //Phone Search
                                    case 1:
                                        if (client.Phone.ToLower().Contains(searchBoxText))
                                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                        break;
                                    //Address Search
                                    case 2:
                                        if (client.Address.ToLower().Contains(searchBoxText))
                                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                        break;
                                }
                            }
                            else
                                tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                        }
                    }
                    break;
                case "business":
                    foreach(Client client in clientList)
                    {
                        if (client.IsBusiness)
                        {
                            if(textBoxSearch.Text != string.Empty)
                            {
                                switch (comboBoxSearch.SelectedIndex)
                                {
                                    default:
                                        break;
                                    //FullName Search
                                    case 0:
                                        if(client.FullName.ToLower().Contains(searchBoxText))
                                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                        break;
                                    //Phone Search
                                    case 1:
                                        if(client.Phone.ToLower().Contains(searchBoxText))
                                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                        break;
                                    //Address Search
                                    case 2:
                                        if(client.Address.ToLower().Contains(searchBoxText))
                                            tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                                        break;
                                }
                            }
                            else
                                tempClientDataTable.Rows.Add(client.SecondName, client.FirstName, client.Phone, client.Address, client.ID, client.IsBusiness);
                        }
                    }
                    break;
            }
            clientDataTable = tempClientDataTable.Copy();
        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshClients();
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
                //for(int i = 0; i<= clientList.Count - 1; i++)
                //{
                //    if (clientList[i].ID == int.Parse(infoGrid["ID", e.RowIndex].Value.ToString()))
                //    {
                //        selectedClient = clientList[i];
                //    }
                //}
                selectedClient = con.SelectClientInfo(int.Parse(infoGrid["ID", e.RowIndex].Value.ToString()));
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
                if(value == DialogResult.OK)
                    selectedClient = con.SelectClientInfo(selectedClient.ID);
                setSelectedClientInfo();
                foreach(DataRow row in clientDataTable.Rows)
                {
                    if (selectedClient.ID.ToString() == row.Field<string>("ID"))
                    {
                        row["Nom"] = selectedClient.SecondName;
                        row["Prenom"] = selectedClient.FirstName;
                        row["Telephone"] = selectedClient.Phone;
                        row["Adresse"] = selectedClient.Address;
                        row["ID"] = selectedClient.ID;
                        row["Business"] = selectedClient.IsBusiness;
                        clientDataTableBinding.ResetBindings(false);
                        break;
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
                if (value == DialogResult.OK)
                {
                    selectedVehicle = con.SelectVehicleInfo(selectedVehicle.ID);
                    setSelectedVehicleInfo();
                }
            }
            else
            {
                ErrorMsg.ChooseVehicleError();
            }
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
            RefreshClients();
        }

        private void radioBusiness_Click(object sender, EventArgs e)
        {
            RefreshClients();
        }

        private void radioPrivate_Click(object sender, EventArgs e)
        {
            RefreshClients();
        }

        private void infoGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            infoGrid_CellClick(sender, e);
            buttonEditSelectedClient_Click(sender, new EventArgs());
        }
    }
}
