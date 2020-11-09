using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
/*
 * Charger les rendez-vous en une commande selon les dates selectioner
 * Ensuite faire un loop pour faire matcher avec les date selectionner a lecran
 * 
 * 
 * 
 *
 */
namespace AgendaMillVitreAuto
{
    
    public partial class MainWindow : Form
    {
        private ManageClientsWindow clientsWindow = new ManageClientsWindow();
        private ManageAppointmentWindow appointmentWindow = new ManageAppointmentWindow();
        private List<Appointment> appointments;
        private SqlConnection con = new SqlConnection();
        //private Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        public MainWindow()
        {
            InitializeComponent();
        }
        //Demarre le worker au demarage du programme
        private void MainWindow_Load(object sender, EventArgs e)
        {
            dateUpdateWorker.RunWorkerAsync();
            comboBoxModeVue.SelectedIndex = 0;
            appointments = con.SelectAppointments();
            

        }
        //set les valeur 
        private void setViewHoursValues(DataGridView dataGrid, DateTime date)
        {
            //Obtient la liste de rendez-vous a partir du server
            appointments = new List<Appointment>();
            List<Appointment> tempAppointments = con.SelectAppointments();
            foreach(Appointment ap in tempAppointments)
            {
                if (ap.Date.ToShortDateString().Contains(date.ToShortDateString()))
                {
                    appointments.Add(ap);
                }
            }
            int dataGridHeight = dataGrid.Height;
            int dataGridWidth = dataGrid.Width + dataGrid.RowHeadersWidth;
            //Cree les colonnes
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add("AppointmentID", "ID");
            dataGrid.Columns["AppointmentID"].Visible = false;
            dataGrid.Columns.Add("Hour", "Heure");
            dataGrid.Columns.Add("Job", "Job");
            dataGrid.Columns.Add("Client", "Client");
            dataGrid.Columns.Add("Phone", "Téléphone");
            dataGrid.Columns.Add("Vehicle", "Vehicule");
            dataGrid.Columns["Hour"].Width = dataGridWidth /5;
            dataGrid.Columns["Job"].Width = dataGridWidth /5;
            dataGrid.Columns["Client"].Width = dataGridWidth /5;
            dataGrid.Columns["Phone"].Width = dataGridWidth /5;
            dataGrid.Columns["Vehicle"].Width = dataGridWidth /5;
            //Cree les ranger et ajoute les valeurs au cases
            int h = 7;
            DateTime[] dates = new DateTime[12];
            for(int i = 0; i<dates.Length;i++)
            {
                DateTime newDate = new DateTime(dateTimePickerGrid.Value.Year, dateTimePickerGrid.Value.Month, dateTimePickerGrid.Value.Day, h, 0, 0);
                h++;
                dates[i] = newDate;
            }
            for(int i = 0; i<dates.Length;i++)
            {
                dataGrid.Rows.Add();
                //dataGridViewPlanning[0, i].Value = string.Format("{0}:{1}", dates[i].Hour, dates[i].Minute.ToString(""));
                dataGrid["Hour", i].Value = dates[i].ToString("HH:mm");
                foreach(Appointment ap in appointments)
                {
                    if(ap.Date.Hour == dates[i].Hour)
                    {
                        dataGrid["AppointmentID", i].Value = ap.ID;
                        dataGrid["Job", i].Value = ap.Job;
                        dataGrid["Client", i].Value = ap.Client.FullName;
                        dataGrid["Phone", i].Value = ap.Client.Phone;
                        dataGrid["Vehicle", i].Value = ap.Vehicule.Brand + " " + ap.Vehicule.Model + " " + ap.Vehicule.Color;
                    }
                }
            }
        }

        private void setViewWeekValues(DataGridView dataGrid, DateTime date)
        {
            dataGrid.Columns.Clear();
            string[] jourSemaine = new string[] {"Lundi", "Mardi", "Mercredi",
                    "Jeudi", "Vendredi"};

            dataGrid.Columns.Add("cJournee", "Journée");
            dataGrid.Columns.Add("cJobs", "Jobs");
            dataGrid.Columns[1].Width = 500;
            DateTime firstOfWeek = date.StartOfWeek(DayOfWeek.Monday);
            //MessageBox.Show(string.Format("Premiere journee de la semaine est {0}", firstOfWeek));
            for (int i = 0; i < jourSemaine.Length; i++)
            {
                DateTime dt = firstOfWeek.AddDays(i);
                dataGrid.Rows.Add();
                dataGrid[0, i].Value = string.Format("{0}, {1}", jourSemaine[i], dt.ToString("dd, MMMM"));
                dataGrid.Rows[i].Height = 75;
            }
        }
        
        private void buttonManageClients_Click(object sender, EventArgs e)
        {
            if(clientsWindow.IsDisposed == true){clientsWindow = new ManageClientsWindow();
            }
            clientsWindow.Show();
        }


        //Date Worker ---------------------------------------------------------------------------------
        //Mets a jour la data sur la fenetre principale
        private void dateUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dateUpdateWorker.WorkerReportsProgress = true;
            string date;
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                date = DateTime.Now.ToString("F");
                try
                {
                    worker.ReportProgress(0, date);
                    Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Time error on closing with dateUpdateWorker_DoWork\n" + ex.Message.ToString());
                }

            }
        }
        //inscrit la date a jour
        private void dateUpdateWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            setDateLabel.Text = e.UserState.ToString();
        }
        //----------------------------------------------------------------------------------------------


        //Ouvre la fenetre de gestion des rendez-vous
        private void buttonManageAppointment_Click(object sender, EventArgs e)
        {
            if (appointmentWindow.IsDisposed == true) { appointmentWindow = new ManageAppointmentWindow(); }
            appointmentWindow.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            dateUpdateWorker.Dispose();
        }
        //Ajuste les valeur du tableau en fonction de la valeur du comboBoxView
        private void comboBoxModeVue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxModeVue.SelectedIndex)
            {
                //Mode de vue en journee
                //Colonne 0=Heure, 1=Jobs, 2=Client, 3=Vehicule
                case 0:
                    setViewHoursValues(dataGrid, dateTimePickerGrid.Value);
                    break;
                //Mode de vue en Semaine
                case 1:
                    setViewWeekValues(dataGrid, dateTimePickerGrid.Value);
                    break;
                //Mode de vue en Mois
                case 2:
                    break;
            }
        }

        private void dateTimePickerGrid_ValueChanged(object sender, EventArgs e)
        {
            switch(comboBoxModeVue.SelectedIndex)
            {
                //Vue en Journee
                case 0:
                    setViewHoursValues(dataGrid, dateTimePickerGrid.Value);

                    break;
                //Vue en Semaine
                case 1:
                    DateTime dt = dateTimePickerGrid.Value;
                    setViewWeekValues(dataGrid, dt);

                    break;
                //Vue en Mois
                case 2:
                    break;
            }
        }

        private void dataGridViewPlanning_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBoxModeVue.SelectedIndex == 0)
            {
                int selectedAppointmentID = int.Parse(dataGrid["AppointmentID", e.RowIndex].Value.ToString());
                List<Appointment> tempAppointments = con.SelectAppointments();
                foreach (Appointment ap in tempAppointments)
                {
                    if(ap.ID == selectedAppointmentID)
                    {
                        new ManageAppointmentWindow(ap).Show();
                        break;
                    }
                }
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
