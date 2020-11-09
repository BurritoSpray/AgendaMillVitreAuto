using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    class Client
    {
        private int mID;
        private string mSecondName;
        private string mFirstName;
        private string mbusinessName = "";
        private string mPhone;
        private List<Vehicle> mVehicles = new List<Vehicle>();
        private string mAddress;
        private bool isbusiness = false;
        private SqlConnection con = new SqlConnection();
        //Creation d'un client vide
        public Client()
        {
            mID = -1;
            mSecondName = "";
            mFirstName = "";
            mPhone = "";
            mAddress = "";
        }
        public Client(int clientID)
        {
            SqlConnection conn = new SqlConnection();
            Client client = conn.SelectClientInfo(clientID);
            mFirstName = client.FirstName;
            mSecondName = client.SecondName;
            mAddress = client.Address;
            mPhone = client.Phone;
            mbusinessName = client.businessName;
            mVehicles = client.VehicleList;
            Isbusiness = client.Isbusiness;

        }
        //Creation d'un client de base
       public Client(string ID, string nom, string prenom, string telephone, string addresse)
        {
            mID = int.Parse(ID);
            mSecondName = nom;
            mFirstName = prenom;
            mPhone = telephone;
            mAddress = addresse;
            mVehicles = con.SelectClientVehicles(mID);
        }
        public Client(string ID, string secondName, string name, string phone, string address, string business) : this(ID, secondName, name, phone, address)
        {
            mbusinessName = business;
            isbusiness = true;
        }

        public int ID { get { return mID; } }
        public bool Isbusiness{ get { return isbusiness; } set { isbusiness = value; } }
        public string SecondName{ get { return mSecondName; } }
        public string FirstName{ get { return mFirstName; } }
        public string FullName{ get { return string.Format("{0} {1}", mFirstName, mSecondName); } }
        public List<Vehicle> VehicleList{ get { return mVehicles; } }
        public string Phone{ get { return mPhone; } }
        public string Address{ get { return mAddress; } }
        public string businessName { 
            get
            {
                if (isbusiness == true)
                {
                    return mbusinessName;
                }
                else
                {
                    return "";
                }
            }
            set { mbusinessName = value; }
        }
    }
}
