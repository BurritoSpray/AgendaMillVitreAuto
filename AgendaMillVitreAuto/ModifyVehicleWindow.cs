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
    public partial class ModifyVehicleWindow : Form
    {
        Client selectedClient;
        Vehicle selectedVehicle;
        bool isNew;
        SqlConnection con = new SqlConnection();
        public ModifyVehicleWindow(Object client)
        {
            InitializeComponent();
            selectedClient = client as Client;
            isNew = true;
            if (selectedClient.IsBusiness)
            {
                textBoxVehicleNumber.Enabled = true;
            }
            else
            {
                textBoxVehicleNumber.Enabled = false;
            }
            numericUpDownYear.Value = DateTime.Now.Year;
        }
        public ModifyVehicleWindow(Object vehicle, Object client)
        {
            InitializeComponent();
            selectedClient = client as Client;
            selectedVehicle = vehicle as Vehicle;
            isNew = false;
            textBoxVehicleBrand.Text = selectedVehicle.Brand;
            textBoxVehicleColor.Text = selectedVehicle.Color;
            textBoxVehicleModel.Text = selectedVehicle.Model;
            numericUpDownYear.Value = selectedVehicle.Year;
            if(selectedClient.IsBusiness)
            {
                textBoxVehicleNumber.Enabled = true;
                textBoxVehicleNumber.Text = selectedVehicle.VehicleNumber;
            }
            else if(selectedClient.IsBusiness == false)
            {
                textBoxVehicleNumber.Text = String.Empty;
                textBoxVehicleNumber.Enabled = false;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                Vehicle vehicle = new Vehicle(selectedClient.ID.ToString(), textBoxVehicleBrand.Text, textBoxVehicleModel.Text, textBoxVehicleColor.Text, numericUpDownYear.Value.ToString(), textBoxVehicleNumber.Text);
                con.InsertVehicle(vehicle);
            }
            else if(isNew == false)
            {
                Vehicle vehicle = new Vehicle(selectedClient.ID.ToString(), selectedVehicle.ID.ToString(), textBoxVehicleBrand.Text, textBoxVehicleModel.Text, textBoxVehicleColor.Text, numericUpDownYear.Value.ToString(), textBoxVehicleNumber.Text);
                con.UpdateVehicle(vehicle);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
