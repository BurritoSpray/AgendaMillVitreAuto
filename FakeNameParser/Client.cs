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
        private string mBussinessName = "";
        private string mPhone;
        private List<Vehicle> mVehicles = new List<Vehicle>();
        private string mAddress;
        private bool isBussiness = false;
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
            mBussinessName = client.BussinessName;
            mVehicles = client.VehicleList;
            IsCompagnie = client.IsCompagnie;

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
        public Client(string ID, string nom, string prenom, string telephone, string addresse, string compagnie) : this(ID, nom, prenom, telephone, addresse)
        {
            mBussinessName = compagnie;
            isBussiness = true;
        }
        ////Creation d'un client de base sans Address;
        //public Client(string nom, string prenom, string telephone)
        //{
        //    mSecondName = nom;
        //    mFirstName = prenom;
        //    mPhone = telephone;
        //}
        ////Creation d'un client Compagnie
        //public Client(string compagnie, string telephone)
        //{
        //    isBussiness = true;
        //    mBussinessName = compagnie;
        //    mPhone = telephone;
        //}
        public int ID { get { return mID; } }
        public bool IsCompagnie{ get { return isBussiness; } set { isBussiness = value; } }
        public string SecondName{ get { return mSecondName; } }
        public string FirstName{ get { return mFirstName; } }
        public string FullName{ get { return string.Format("{0} {1}", mFirstName, mSecondName); } }
        public List<Vehicle> VehicleList{ get { return mVehicles; } }
        public string Phone{ get { return mPhone; } }
        public string Address{ get { return mAddress; } }
        public string BussinessName { 
            get
            {
                if (isBussiness == true)
                {
                    return mBussinessName;
                }
                else
                {
                    return "";
                }
            }
            set { mBussinessName = value; }
        }
    }
}
