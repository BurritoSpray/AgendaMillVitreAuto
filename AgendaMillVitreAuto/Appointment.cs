using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{

    class Appointment
    {
        private int appointmentID;
        private string mJob;
        private string mDescription;
        private Vehicle mVehicule;
        private Client mClient;
        private string mStringDate;
        private DateTime mDate;
        private bool mIsDone = false;
        SqlConnection con = new SqlConnection();
        public Appointment(DateTime date, string job, Client client, Vehicle vehicle, string description)
        {
            mDate = date;
            //mDate = DateTime.Parse(stringDate);
            mJob = job;
            mDescription = description;
            mClient = client;
            mVehicule = vehicle;
        }
        public Appointment(DateTime date, string job, Client client, Vehicle vehicle, string description, int ID):this(date, job, client, vehicle, description)
        {
            appointmentID = ID;
        }

        public string Job { get { return mJob; } set { mJob = value; } }
        public string Description { get { return mDescription; } set { mDescription = value; } }
        public Client Client { get { return mClient; } set { mClient = value; } }
        public Vehicle Vehicule { get { return mVehicule; } set { mVehicule = value; } }
        public DateTime Date { get { return mDate; } set { mDate = value; } }
        public bool isDone { get { return mIsDone; } set { mIsDone = value; } }
        public int ID { get { return appointmentID; } }

    }
}
