using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    public partial class ManageAppointmentWindow : Form
    {
        private SqlConnection con = new SqlConnection();
        private Client selectedClient = new Client();
        private Vehicle selectedVehicle = new Vehicle();
        private List<string> jobs = new List<string>();
        public ManageAppointmentWindow()
        {
            InitializeComponent();
            jobs = con.SelectJobs();
            foreach(string job in jobs)
            {
                comboBoxJob.Items.Add(job);
            }
        }
        //When you add an appointment from the ManageClientWindow
        public ManageAppointmentWindow(Object client, Object vehicle) : this()
        {
            selectedClient = client as Client;
            selectedVehicle = vehicle as Vehicle;
            textBoxClient.Text = selectedClient.FullName;
            textBoxVehicle.Text = selectedVehicle.Brand + " " + selectedVehicle.Model + " " + selectedVehicle.Color;
        }
        public ManageAppointmentWindow(Object appointment)
        {
            //TODO FIX THIS SHIT
            Appointment ap = appointment as Appointment;
            selectedClient = ap.Client;
            selectedVehicle = ap.Vehicule;
            dateTimePicker1.Value = ap.Date; //PROBLEME ICI
            numericUpDownHour.Value = ap.Date.Hour;
            //if(ap.Date.tim)

        }
        private DateTime formatDate()
        {
            try
            {
                string date = dateTimePicker1.Value.ToShortDateString();
                decimal hour;
                if(radioButtonHeurePM.Checked == true)
                {
                    hour = numericUpDownHour.Value + 12;
                }
                else
                {
                    hour = numericUpDownHour.Value;
                }
                string formatedHour = hour.ToString().Replace('.', ':') + ":00";
                DateTime newDate = DateTime.Parse(date + " " + formatedHour);
                return newDate;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erreur");
                return DateTime.Now;
            }
        }

        private void ManageAppointmentWindow_Load(object sender, EventArgs e)
        {

        }

        private void addAppoitment(Appointment appointment)
        {

        }

        private void ManageAppointmentWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            var value = MessageBox.Show("Êtes-vous sur?", "Attention!", MessageBoxButtons.YesNo);
            if(value == DialogResult.Yes)
            {
                e.Cancel = true;
                this.Dispose();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxJob_TextUpdate(object sender, EventArgs e)
        {
            Debug.WriteLine(comboBoxJob.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimePicker1.Value.ToLongDateString() + "\n" + dateTimePicker1.Value.ToShortDateString());
            //MessageBox.Show(formatDate().ToString());
        }

        private void buttonAddAppointment_Click(object sender, EventArgs e)
        {
            con.InsertAppointment(new Appointment(formatDate(), comboBoxJob.Text, selectedClient, selectedVehicle, richTextBoxCommentaire.Text));
            this.Dispose();
        }

    }
}
