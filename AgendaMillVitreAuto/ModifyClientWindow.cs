﻿using System;
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
        private Vehicle selectedVehicle;
        private SqlConnection con = new SqlConnection();
        private DataTable vehicleDataTable = new DataTable();
        private BindingSource vehicleGridBinding = new BindingSource();
        private BackgroundWorker vehicleGridWorker = new BackgroundWorker();
        bool isNewClient;
        public ModifyClientWindow(Object client, bool newClient)
        {
            InitializeComponent();
            selectedClient = client as Client;
            isNewClient = newClient;
            if (isNewClient) 
            { 
                this.Text = "Nouveau Client";

            }
            //labelModifyClient.Text += "  ID: " + selectedClient.ID.ToString();
            textBoxSecondName.Text = selectedClient.SecondName;
            textBoxFirstName.Text = selectedClient.FirstName;
            textBoxPhone.Text = selectedClient.Phone;
            textBoxAddress.Text = selectedClient.Address;
            if (selectedClient.IsBusiness)
            {
                textBoxbusiness.Text = selectedClient.businessName;
                checkBoxIsbusiness.Checked = true;
            }
            else
            {
                textBoxbusiness.Enabled = false;
            }
            //VehicleGridWorker setup
            vehicleGridWorker.DoWork += VehicleGridWorker_DoWork;
            vehicleGridWorker.RunWorkerCompleted += VehicleGridWorker_RunWorkerCompleted;
            //VehicleListGrid setup
            vehicleDataTable.Columns.Add("Brand");
            vehicleDataTable.Columns.Add("Model");
            vehicleDataTable.Columns.Add("Color");
            vehicleDataTable.Columns.Add("Year");
            vehicleDataTable.Columns.Add("VehicleNumber");
            vehicleDataTable.Columns.Add("ID");
            dataGridViewVehicleList.DataSource = vehicleGridBinding;
            vehicleGridBinding.DataSource = vehicleDataTable;
            vehicleGridBinding.ResetBindings(true);
            if (!selectedClient.IsBusiness)
                dataGridViewVehicleList.Columns["VehicleNumber"].Visible = false;
            dataGridViewVehicleList.Columns["ID"].Visible = false;
            vehicleGridWorker.RunWorkerAsync();

        }

        private void VehicleGridWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            vehicleGridBinding.ResetBindings(false);
        }

        private void VehicleGridWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            updateVehicleDataTable();
        }

        private void updateVehicleDataTable()
        {
            vehicleDataTable.Rows.Clear();
            List<Vehicle> vehicleList = con.SelectClientVehicles(selectedClient.ID);
            foreach(Vehicle vehicle in vehicleList)
            {
                vehicleDataTable.Rows.Add(vehicle.Brand, vehicle.Model, vehicle.Color, vehicle.Year, vehicle.VehicleNumber, vehicle.ID);
            }


        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Client client = new Client(selectedClient.ID.ToString(), textBoxSecondName.Text, textBoxFirstName.Text, textBoxPhone.Text, textBoxAddress.Text);
            if (checkBoxIsbusiness.Checked)
            {
                client.IsBusiness = true;
                client.businessName = textBoxbusiness.Text;
            }
            else
            {
                client.IsBusiness = false;
                textBoxbusiness.Text = string.Empty;
            }
            if(isNewClient)
            {
                con.InsertNewClient(client);
            }
            else
                con.UpdateClientInfo(client);
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
                selectedClient.IsBusiness = true;

            }
            else if (checkBoxIsbusiness.Checked == false)
            {
                textBoxbusiness.Enabled = false;
                selectedClient.IsBusiness = false;
            }
        }

        private void dataGridViewVehicleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedVehicle = con.SelectVehicleInfo(int.Parse(dataGridViewVehicleList["ID", e.RowIndex].Value.ToString()));
            textBoxVehicleBrand.Text = selectedVehicle.Brand;
            textBoxVehicleColor.Text = selectedVehicle.Color;
            textBoxVehicleModel.Text = selectedVehicle.Model;
            numericUpDownVehicleYear.Value = selectedVehicle.Year;
            if(selectedClient.IsBusiness)
            {
                textBoxVehicleNumber.Enabled = true;
                textBoxVehicleNumber.Text = selectedVehicle.VehicleNumber;
            }
            else
            {
                textBoxVehicleNumber.Enabled = false;
                textBoxVehicleNumber.Clear();
            }


        }

        private void buttonModifyVehicle_Click(object sender, EventArgs e)
        {
            if(selectedVehicle.ID != -1)
            {
                ModifyVehicleWindow vehicleWindow = new ModifyVehicleWindow(selectedVehicle, selectedClient);
                var value = vehicleWindow.ShowDialog();
            }
            else
            {
                ErrorMsg.ChooseVehicleError();
            }
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            ModifyVehicleWindow vehicleWindow = new ModifyVehicleWindow(selectedClient);
            var value = vehicleWindow.ShowDialog();
            updateVehicleDataTable();
        }

        private void dataGridViewVehicleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewVehicleList_CellClick(sender, e);
            buttonModifyVehicle_Click(sender, new EventArgs());

        }
    }
}
