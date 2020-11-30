using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace AgendaMillVitreAuto
{
    class SqlConnection
    {
        //TODO: Ajouter des description de chaque fonction!!
        //LOGIN DU SERVEUR MYSQL--------------------------------------------------------------------------------------------------------
        private string connectionString = "server=ec2-18-220-146-6.us-east-2.compute.amazonaws.com;database=mill_vitre_auto;uid=program;pwd=Qazwsx2020!!;";
        private MySqlConnection con;
        MySqlDateTime date;
        //MySql-DateTime-Format YYYY-MM-DD HH:MI:SS
        //ManageClient Commands---------------------------------------------------------------------------------------------------------
        private string clientListCommand = "SELECT * FROM mill_vitre_auto.client";
        private string clientListPCommand = "SELECT * FROM mill_vitre_auto.client WHERE Isbusiness = '0'";
        private string clientListBCommand = "SELECT * FROM mill_vitre_auto.client WHERE Isbusiness = '1'";
        private string insertNewClient = "INSERT INTO client SET FirstName='{0}',SecondName='{1}',Phone='{2}',Address='{3}',Isbusiness='0',businessName=''";
        private string insertNewBClient = "INSERT INTO client SET FirstName='{0}',SecondName='{1}',Phone='{3}',Address='{3}',Isbusiness='1',businessName='{4}'";
        private string selectClientVehiclesCommand = "SELECT vehicle.* FROM mill_vitre_auto.vehicle WHERE clientID = {0}";
        private string selectClientIDCommand = "SELECT client.idclient From client WHERE client.FirstName = '{0}' AND client.SecondName = '{1}'";
        private string selectClientInfoCommand = "SELECT client.* FROM client WHERE client.idclient = {0}";
        private string selectLastAddedClientCommand = "SELECT * FROM mill_vitre_auto.client WHERE idclient=(SELECT MAX(idclient) FROM mill_vitre_auto.client)";
        private string selectVehicleInfoCommand = "SELECT vehicle.* From vehicle where vehicle.idvehicle = {0}";
        private string deleteSelectedClientCommand = "DELETE vehicle.* FROM mill_vitre_auto.vehicle WHERE vehicle.clientID = '{0}';DELETE client.* FROM mill_vitre_auto.client WHERE client.idclient = '{0}';";
        private string deleteSelectedVehicleCommand = "DELETE vehicle.* FROM mill_vitre_auto.vehicle WHERE idvehicle = '{0}'";
        private string insertVehicleCommand = "INSERT INTO vehicle (clientID,brand,model,year,color,vehicleNumber) VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}')";
        private string updateVehicleCommand = "UPDATE vehicle SET brand = '{0}', model = '{1}', year = {2}, color = '{3}', vehicleNumber = '{4}' WHERE vehicle.idvehicle = {5}";
        private string updateClientInfoCommand = "UPDATE client SET FirstName = '{0}', SecondName = '{1}', Phone = '{2}', Address = '{3}', Isbusiness = '0' WHERE client.idclient = {4}";
        private string updateBClientInfoCommand = "UPDATE client SET FirstName = '{0}', SecondName = '{1}', Phone = '{2}', Address = '{3}', Isbusiness = '1', BusinessName = '{4}' WHERE client.idclient = {5}";
        //--------------------------------------------------------------------------------------------------------------------------------
        //ManageAppointment Commands------------------------------------------------------------------------------------------------------
        private string insertAppointmentCommand = "INSERT INTO appointment SET Date='{0}', Job='{1}', ClientID='{2}', VehicleID='{3}', Description='{4}'";
        private string selectAppointmentsCommand = "SELECT * FROM mill_vitre_auto.appointment";
        private string selectJobsCommand = "SELECT * FROM mill_vitre_auto.job";
        //--------------------------------------------------------------------------------------------------------------------------------
        //MainWindow Commands-------------------------------------------------------------------------------------------------------------
        private string selectAppointmentsByDateCommand = "SELECT * FROM mill_vitre_auto.appointment WHERE Date = '{0}'";

        //Cree un connecteur avec les fonction pour aller chercher les donner
        public SqlConnection()
        {
            con = new MySqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Cant reach MySqlServer: " + connectionString.Split(';')[0]);
            }
            finally
            {
                con.Close();
            }
        }
        public MySqlConnection Connection { get { return con; } }
        //Retourne true si la connection est etablie
        public bool Connect()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Deconnecte du serveur
        public bool Disconnect()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disconnect error!\n" + ex.Message);
                return false;
            }
        }
        public List<Client> SelectClientsPrivate()
        {
            List<Client> clientsList = new List<Client>();
            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(clientListPCommand, Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientsList.Add(new Client(reader["idclient"].ToString(), reader["SecondName"].ToString(), reader["FirstName"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString()));
                }
                reader.Close();
                Disconnect();
                return clientsList;
            }
            else
            {
                return clientsList;
            }
        }
        public List<Client> SelectClientsbusiness()
        {
            List<Client> clientsList = new List<Client>();
            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(clientListBCommand, Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    clientsList.Add(new Client(reader["idclient"].ToString(), reader["SecondName"].ToString(), reader["FirstName"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString(), reader["businessName"].ToString()));
                }
                reader.Close();
                Disconnect();
                return clientsList;
            }
            else
            {
                return clientsList;
            }
        }
        //Retourne une liste des clients sous forme d'objet Client
        public List<Client> SelectClients()
        {
            List<Client> clientList = new List<Client>();
            if (Connect())
            {
                MySqlCommand cmd = new MySqlCommand(clientListCommand, Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client(reader["idclient"].ToString(), reader["SecondName"].ToString(), reader["FirstName"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString());
                    if (reader["Isbusiness"].ToString() == "1")
                    {
                        client.IsBusiness = true;
                        client.BusinessName = reader["businessName"].ToString();
                    }
                    clientList.Add(client);
                }
                Disconnect();
                reader.Close();
                return clientList;
            }
            else
            {
                return clientList;
            }
        }

        public Client SelectLastAddedClient()
        {
            MySqlCommand command = new MySqlCommand(selectLastAddedClientCommand, Connection);
            Client client = new Client();
            if (Connect())
            {

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    client = new Client(reader["idclient"].ToString(), reader["SecondName"].ToString(), reader["FirstName"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString());
                    if (reader["IsBusiness"].ToString() == "1")
                    {
                        client.IsBusiness = true;
                        client.BusinessName = reader["BusinessName"].ToString();
                    }
                }
                Disconnect();
                reader.Close();
                return client;
            }
            else
            {
                return client;
            }
        }

        public void InsertNewClient(Client client)
        {
            string insertNewClientFormated = string.Empty;
            if (client.IsBusiness == true)
            {
                //insert business client
                insertNewClientFormated = string.Format(insertNewBClient, client.FirstName, client.SecondName, client.Phone, client.Address, client.BusinessName);
            }
            else if(client.IsBusiness == false)
            {
                insertNewClientFormated = string.Format(insertNewClient, client.FirstName, client.SecondName, client.Phone, client.Address);
            }
            else { insertNewClientFormated = string.Empty; }
            MySqlCommand command = new MySqlCommand(insertNewClientFormated, Connection);
            if (Connect())
            {
                command.ExecuteNonQuery();
                Disconnect();
            }
        }
        public Client SelectClientInfo(int clientID)
        {
            Client client = new Client();
            if (Connect())
            {
                string selectClientInfoFormated = string.Format(selectClientInfoCommand, clientID);
                MySqlCommand command = new MySqlCommand(selectClientInfoFormated, Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if(reader["IsBusiness"].ToString() == "1")
                        client = new Client(reader["idclient"].ToString(), reader["SecondName"].ToString(), reader["FirstName"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString(), reader["BusinessName"].ToString());
                    else
                        client = new Client(reader["idclient"].ToString(), reader["SecondName"].ToString(), reader["FirstName"].ToString(), reader["Phone"].ToString(), reader["Address"].ToString());
                }
                reader.Close();
                Disconnect();
                return client;
            }
            else
            {
                return client;
            }
        }
        //Retourne la liste des vehicle du client a partir du ID //Peut etre remplacer le int par un objet Client
        public List<Vehicle> SelectClientVehicles(int clientID)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string selectClientVehiclesFormated = string.Format(selectClientVehiclesCommand, clientID);
            MySqlCommand command = new MySqlCommand(selectClientVehiclesFormated, Connection);
            if (Connect())
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle(clientID.ToString(), reader["idvehicle"].ToString(), reader["brand"].ToString(), reader["model"].ToString(), reader["color"].ToString(), reader["year"].ToString(), reader["vehicleNumber"].ToString());
                    vehicles.Add(vehicle);
                }
                reader.Close();
                Disconnect();
                return vehicles;
            }
            else
            {
                return vehicles;
            }
        }
        //Retourne les info du vehicule a partir de l'ID
        public Vehicle SelectVehicleInfo(int vehicleID)
        {
            Vehicle vehicle = new Vehicle();
            if (Connect() == true)
            {
                string selectVehicleInfoFormated = string.Format(selectVehicleInfoCommand, vehicleID);
                MySqlCommand command = new MySqlCommand(selectVehicleInfoFormated, Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    vehicle = new Vehicle(reader["clientID"].ToString(), reader["idvehicle"].ToString(), reader["brand"].ToString(), reader["model"].ToString(), reader["color"].ToString(), reader["year"].ToString(), reader["vehicleNumber"].ToString());
                }
                Disconnect();
                reader.Close();
                return vehicle;
            }
            else
            {
                return vehicle;
            }

        }
        //Delete le client et tout ses vehicules
        public void DeleteSelectedClient(Client client)
        {
            string deleteSelectedClientFormated = string.Format(deleteSelectedClientCommand, client.ID);
            MySqlCommand command = new MySqlCommand(deleteSelectedClientFormated, Connection);
            if (Connect())
            {
                command.ExecuteNonQuery();
                Disconnect();
            }
        }
        //Delete le vehicule selectioner
        public void DeleteSelectedVehicle(Vehicle vehicle)
        {
            string deleteSelectedVehicleFormated = string.Format(deleteSelectedVehicleCommand, vehicle.ID);
            MySqlCommand command = new MySqlCommand(deleteSelectedVehicleFormated, Connection);
            if (Connect())
            {
                command.ExecuteNonQuery();
                Disconnect();
            }
            
        }
        //Ajoute un vehicule a un client
        public void InsertVehicle(Vehicle vehicle)
        {
            string addVehicleFormated = addVehicleFormated = string.Format(insertVehicleCommand, vehicle.OwnerID, vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.Color, vehicle.VehicleNumber);
            //string addVehicleFormated = string.Format(insertVehicleCommand, clientID, vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.Color);
            //Rendu ICI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(addVehicleFormated, Connection);
                command.ExecuteNonQuery();
                Disconnect();
            }

        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            string updateVehicleFormated = string.Format(updateVehicleCommand, vehicle.Brand, vehicle.Model, vehicle.Year, vehicle.Color, vehicle.VehicleNumber, vehicle.ID);
            MySqlCommand command = new MySqlCommand(updateVehicleFormated, Connection);
            if (Connect())
            {
                command.ExecuteNonQuery();
                Disconnect();
            }
        }
        public void UpdateClientInfo(Client client)
        {
            string updateClientInfoFormated;
            if(client.IsBusiness == true)
            {
                updateClientInfoFormated = string.Format(updateBClientInfoCommand, client.FirstName, client.SecondName, client.Phone, client.Address, client.BusinessName, client.ID);
            }
            else if(client.IsBusiness == false)
            {
                updateClientInfoFormated = string.Format(updateClientInfoCommand, client.FirstName, client.SecondName, client.Phone, client.Address, client.ID);
            }
            else { updateClientInfoFormated = ""; }
            if (Connect())
            {
                MySqlCommand command = new MySqlCommand(updateClientInfoFormated, Connection);
                command.ExecuteNonQuery();
                Disconnect();
            }
        }
        //Retourne la liste de Rendez-vous
        public List<Appointment> SelectAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            MySqlCommand command = new MySqlCommand(selectAppointmentsCommand, Connection);
            if (Connect())
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //ERREUR ICI A Cause que la connection est deja utiliser probablement deja reparer mais pas sur...
                    Appointment appointment = new Appointment(DateTime.Parse(reader["Date"].ToString()), reader["Job"].ToString(), new Client(int.Parse(reader["ClientID"].ToString())), new Vehicle(int.Parse(reader["VehicleID"].ToString())), reader["Description"].ToString(), int.Parse(reader["idappointment"].ToString()));
                    appointments.Add(appointment);
                }
                reader.Close();
                Disconnect();
                return appointments;
            }
            else
            {
                return appointments;
            }
        }
        //Retourne la liste de Job
        public List<string> SelectJobs()
        {
            List<string> jobs = new List<string>();
            MySqlCommand command = new MySqlCommand(selectJobsCommand, Connection);
            if (Connect())
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    jobs.Add(reader["Job"].ToString());
                }
                reader.Close();
                Disconnect();
                return jobs;
            }
            else
            {
                return jobs;
            }
        }
        public bool InsertAppointment(Appointment appointment)
        {
            string insertAppointmentFormated = string.Format(insertAppointmentCommand, appointment.Date, appointment.Job, appointment.Client.ID, appointment.Vehicule.ID, appointment.Description);
            MySqlCommand command = new MySqlCommand(insertAppointmentFormated, Connection);
            if (Connect())
            {
                try
                {
                    command.ExecuteNonQuery();
                    Disconnect();
                    return true;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                finally
                {
                    Disconnect();

                }
            }
            else
            {

                return false;
            }

        }
        //Retourne les Rendez-vous a partir d'une liste de date selectionner
        public List<Appointment> SelectAppointmensByDate(List<DateTime> dates)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach(DateTime date in dates)
            {
                string selectAppointmentsByDateFormated = string.Format(selectAppointmentsByDateCommand, date.ToShortTimeString());
                MySqlCommand command = new MySqlCommand(selectAppointmentsByDateFormated, Connection);
                if (Connect())
                {
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime nDate = DateTime.Parse(reader["Date"].ToString());
                        Vehicle vehicle = this.SelectVehicleInfo(int.Parse(reader["VehicleID"].ToString()));
                        Client client = this.SelectClientInfo(int.Parse(reader["ClientID"].ToString()));
                        string job = reader["Job"].ToString();
                        string description = reader["Description"].ToString();
                        appointments.Add(new Appointment(nDate, job, client, vehicle, description));
                    }
                    reader.Close();
                    Disconnect();
                    return appointments;
                }
                else
                {
                    return appointments;
                }
            }
            return appointments;
        }

    }
}
