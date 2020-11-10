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
        private int _ID;
        private string _SecondName;
        private string _FirstName;
        private string _BusinessName = "";
        private string _Phone;
        private List<Vehicle> _Vehicles = new List<Vehicle>();
        private string _Address;
        private bool _IsBusiness = false;
        private SqlConnection con = new SqlConnection();
        //Creation d'un client vide
        public Client()
        {
            _ID = -1;
            _SecondName = "";
            _FirstName = "";
            _Phone = "";
            _Address = "";
        }
        public Client(int clientID)
        {
            SqlConnection conn = new SqlConnection();
            Client client = conn.SelectClientInfo(clientID);
            _FirstName = client.FirstName;
            _SecondName = client.SecondName;
            _Address = client.Address;
            _Phone = client.Phone;
            _BusinessName = client.businessName;
            _Vehicles = client.VehicleList;
            Isbusiness = client.Isbusiness;

        }
        //Creation d'un client de base
       public Client(string ID, string nom, string prenom, string telephone, string addresse)
        {
            _ID = int.Parse(ID);
            _SecondName = nom;
            _FirstName = prenom;
            _Phone = telephone;
            _Address = addresse;
            //TODO trouver un moyen de charger dynamiquement la liste des vehicule parceque sinon sa ralentit considerablement le program...
            //_Vehicles = con.SelectClientVehicles(_ID);
        }
        public Client(string ID, string secondName, string name, string phone, string address, string business) : this(ID, secondName, name, phone, address)
        {
            _BusinessName = business;
            _IsBusiness = true;
        }

        public int ID { get { return _ID; } }
        public bool Isbusiness{ get { return _IsBusiness; } set { _IsBusiness = value; } }
        public string SecondName{ get { return _SecondName; } }
        public string FirstName{ get { return _FirstName; } }
        public string FullName{ get { return string.Format("{0} {1}", _FirstName, _SecondName); } }
        public List<Vehicle> VehicleList{ get { return _Vehicles; } set { _Vehicles = value; } }
        public string Phone{ get { return _Phone; } }
        public string Address{ get { return _Address; } }
        public string businessName { 
            get
            {
                if (_IsBusiness == true)
                {
                    return _BusinessName;
                }
                else
                {
                    return "";
                }
            }
            set { _BusinessName = value; }
        }
    }
}
