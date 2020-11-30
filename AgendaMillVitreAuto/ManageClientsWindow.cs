using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Drawing;

namespace AgendaMillVitreAuto
{
    public partial class ManageClientsWindow : Form
    {
        ModifyClientWindow modifyClientWindow;
        ModifyVehicleWindow modifyVehicleWindow;
        ManageAppointmentWindow manageAppointmentWindow;
        LoadClientsProgressWindow progressWindow;
        private SqlConnection con = new SqlConnection();
        private List<Client> clientList = new List<Client>();
        private Client selectedClient = new Client();
        private Vehicle selectedVehicle = new Vehicle();
        private DataTable clientDataTable = new DataTable("main");
        private DataTable tempClientDataTable = new DataTable("temp");
        private BindingSource clientDataTableBinding = new BindingSource();
        private System.Windows.Forms.Timer searchBoxTimer = new System.Windows.Forms.Timer();
        private bool isProgressWindowEnabled = true;
        //private bool firstLoad = true;

        private Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                if(value.ID == -1)
                {
                    infoGrid.ClearSelection();
                    ClearClientInfoBox();
                    ClearVehicleInfoBox();
                    comboBoxVehicle.Items.Clear();
                    selectedVehicle = new Vehicle();
                }
                else if(value.ID != 1)
                {
                    for(int i = 0; i>= infoGrid.Rows.Count - 1; i++)
                    {
                        if(int.Parse(infoGrid["ID", i].Value.ToString()) == value.ID)
                        {
                            infoGrid.Rows[i].Selected = true;
                            break;
                        }
                        SetSelectedClientInfo();
                        SetVehicleComboBox();
                    }
                }
                selectedClient = value;
            }
        }

        public ManageClientsWindow()
        {
            InitializeComponent();
        }
        public ManageClientsWindow(bool isSelectMode)
        {
            
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
            setupSearchBoxTimer();
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
            //ProgressWindow
            if (isProgressWindowEnabled)
            {
                if (progressWindow != null)
                {
                    if (!progressWindow.IsDisposed)
                        progressWindow.Dispose();
                }
                progressWindow = new LoadClientsProgressWindow();
                progressWindow.Show();
                progressWindow.Maximum = 100;
            }
            //LoadClientsWorker
            BackgroundWorker loadClientsWorker = new BackgroundWorker();
            loadClientsWorker.DoWork += RefreshClientsWorker_DoWork;
            loadClientsWorker.RunWorkerCompleted += RefreshClientsWorker_RunWorkerCompleted;
            loadClientsWorker.RunWorkerAsync();
            //if (progressWindow != null)
            //{
            //    progressWindow.progressBar.Value = e.ProgressPercentage;
            //    if (e.ProgressPercentage == 100)
            //    {
            //        Thread.Sleep(50);
            //        progressWindow.Dispose();
            //    }
            //}
        }

        private void RefreshClientsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Writing the data from sql to infoGrid
            SelectedClient = new Client();
            selectedVehicle = new Vehicle();
            //comboBoxVehicle.Items.Clear();
            updateClientDataTable();
            clientDataTableBinding.DataSource = clientDataTable;
            clientDataTableBinding.ResetBindings(false);
        }

        private void updateClientDataTable()
        {
            int actualClient = 0;
            if (isProgressWindowEnabled)
            {
                progressWindow.Maximum = 100;
            }
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
                        if (isProgressWindowEnabled)
                        {
                            progressWindow.Progress = (int)((decimal)actualClient / (decimal)clientList.Count * (decimal)100);
                            actualClient += 1;
                        }
                    }
                    break;
                case "private":
                    foreach (Client client in clientList)
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
                        if (isProgressWindowEnabled)
                        {
                            progressWindow.Progress = (int)((decimal)actualClient / (decimal)clientList.Count * (decimal)100);
                            actualClient += 1;
                        }
                    }
                    break;
                case "business":
                    foreach (Client client in clientList)
                    {
                        if (client.IsBusiness)
                        {
                            if (textBoxSearch.Text != string.Empty)
                            {
                                switch (comboBoxSearch.SelectedIndex)
                                {
                                    default:
                                        break;
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
                        if (isProgressWindowEnabled)
                        {
                            progressWindow.Progress = (int)((decimal)actualClient / (decimal)clientList.Count * (decimal)100);
                            actualClient += 1;
                        }
                    }
                    break;
            }
            clientDataTable = tempClientDataTable.Copy();
            if (isProgressWindowEnabled)
            {
                progressWindow.Progress = progressWindow.Maximum;
                //Thread.Sleep(25);
                progressWindow.Close();
            }

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
        
        private void SetSelectedClientInfo()
        {
            if (SelectedClient != null)
            {
                textBoxFirstName.Text = SelectedClient.FirstName;
                textBoxSecondName.Text = SelectedClient.SecondName;
                textBoxPhone.Text = SelectedClient.Phone;
                textBoxAddress.Text = SelectedClient.Address;
                textBoxbusiness.Text = SelectedClient.BusinessName;
            }
        }
        
        private void SetVehicleComboBox()
        {
            if (SelectedClient.ID != -1)
            {
                comboBoxVehicle.Items.Clear();
                SelectedClient.VehicleList = con.SelectClientVehicles(SelectedClient.ID);
                foreach (Vehicle vehicle in SelectedClient.VehicleList)
                {
                    comboBoxVehicle.Items.Add(vehicle.Brand + " " + vehicle.Model + " " + vehicle.Color);
                }
            }
        }


        //Search Timer related functions-------------------------------------------------------------------------
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
        //---------------------------------------------------------------------------------------------------------
        //Affiche les resultat de la recherche chaque fois que le text est modifier

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
                //Test
                //SelectedClient = clientList[e.RowIndex];
                //Clear les textBox et cree l'objet Client SelectedClient
                ClearClientInfoBox();
                SelectedClient = con.SelectClientInfo(int.Parse(infoGrid["ID", e.RowIndex].Value.ToString()));
                textBoxFirstName.Text = SelectedClient.FirstName;
                textBoxSecondName.Text = SelectedClient.SecondName;
                textBoxPhone.Text = SelectedClient.Phone;
                textBoxAddress.Text = SelectedClient.Address;
                if (SelectedClient.IsBusiness)
                {
                    textBoxbusiness.Text = SelectedClient.BusinessName;
                }
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
            SelectedClient = new Client();
            ModifyClientWindow newClientWindow = new ModifyClientWindow(new Client(), true);
            var value = newClientWindow.ShowDialog();
            if(value == DialogResult.OK)
            {
                RefreshClients();
                SelectedClient = con.SelectLastAddedClient();
                ModifyClientWindow clientWindow = new ModifyClientWindow(SelectedClient, false);
                var val = clientWindow.ShowDialog();
                if(val == DialogResult.OK)
                {
                    if (clientWindow.IsUpdateNeeded)
                    {
                        RefreshClients();
                        SelectedClient = con.SelectClientInfo(SelectedClient.ID);
                    }
                }
            }


        }

        private void comboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si une case est selectioner
            if (comboBoxVehicle.SelectedIndex != -1)
            {
                //Obtient les info du vehicule a partir du vehicleID
                selectedVehicle = con.SelectVehicleInfo(SelectedClient.VehicleList[comboBoxVehicle.SelectedIndex].ID);
                setSelectedVehicleInfo();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshClients();
        }

        private void buttonDeleteSelectedClient_Click(object sender, EventArgs e)
        {
            if (SelectedClient.ID != -1)
            {
                string msg = string.Format("Voulez-vous vraiment effacer le client {0}?", SelectedClient.FullName);
                var value = MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo);
                if (value == DialogResult.Yes)
                {
                    //Delete SelectedClient
                    con.DeleteSelectedClient(SelectedClient);
                    SelectedClient = new Client();
                    RefreshClients();
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
            if (SelectedClient.ID != -1)
            {
                modifyClientWindow = new ModifyClientWindow(SelectedClient, false);
                var value = modifyClientWindow.ShowDialog();
                if(value == DialogResult.OK)
                    SelectedClient = con.SelectClientInfo(SelectedClient.ID);
                if (modifyClientWindow.IsUpdateNeeded)
                    RefreshClients();
                modifyClientWindow.Dispose();
                //foreach(DataRow row in clientDataTable.Rows)
                //{
                //    if (SelectedClient.ID.ToString() == row.Field<string>("ID"))
                //    {
                //        row["Nom"] = SelectedClient.SecondName;
                //        row["Prenom"] = SelectedClient.FirstName;
                //        row["Telephone"] = SelectedClient.Phone;
                //        row["Adresse"] = SelectedClient.Address;
                //        row["ID"] = SelectedClient.ID;
                //        row["Business"] = SelectedClient.IsBusiness;
                //        clientDataTableBinding.ResetBindings(false);
                //        break;
                //    }
                //}
            }
            else
            {
                ErrorMsg.ChooseClientError();
            }
        }

        private void buttonNewVehicle_Click(object sender, EventArgs e)
        {
            if (SelectedClient != null && SelectedClient.ID != -1)
            {
                modifyVehicleWindow = new ModifyVehicleWindow(SelectedClient);
                var value = modifyVehicleWindow.ShowDialog();
                SelectedClient.VehicleList = con.SelectClientVehicles(SelectedClient.ID);
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
                string msg = string.Format("Voulez-vous vraiment effacer {0}, {1}, {2} du client {3}", selectedVehicle.Brand, selectedVehicle.Model, selectedVehicle.Year, SelectedClient.FullName);
                var value = MessageBox.Show(msg, "Attention!", MessageBoxButtons.YesNo);
                if (value == DialogResult.Yes)
                {
                    con.DeleteSelectedVehicle(selectedVehicle);
                    selectedVehicle = new Vehicle();
                    setSelectedVehicleInfo();
                    SelectedClient.VehicleList = con.SelectClientVehicles(SelectedClient.ID);
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
            if(SelectedClient.ID != -1 && selectedVehicle.ID != -1)
            {
                modifyVehicleWindow = new ModifyVehicleWindow(selectedVehicle, SelectedClient);
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
            if(SelectedClient.ID != -1)
            {
                if(selectedVehicle.ID != -1)
                {
                    manageAppointmentWindow = new ManageAppointmentWindow(SelectedClient, selectedVehicle);
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
            if(e.RowIndex >= 0)
            {
                infoGrid_CellClick(sender, e);
                buttonEditSelectedClient_Click(sender, new EventArgs());
            }
        }
    }
}
