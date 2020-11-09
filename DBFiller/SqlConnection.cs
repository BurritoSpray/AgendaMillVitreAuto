using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFiller
{
    class SqlConnection
    {
        private MySqlConnection con;
        private string unformatedConnectionString = "server={0};database={1};uid={2};pwd={3}";
        private MySqlConnection Connection
        {
            get
            {
                MySqlConnection _connection = new MySqlConnection(string.Format(unformatedConnectionString, Settings.IP, Settings.DBNAME, Settings.USERNAME, Settings.PASSWORD));
                return _connection;
            }
        }

        public SqlConnection()
        {

        }

        //public string ConnectionString { get { return connectionString; } set { connectionString = value; } }
        //Base Functions --------------------------------------
        //Test the connection with the SqlConnection connectionString
        public bool TestConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error!");
                return false;
            }
            finally
            {
                Connection.Close();
            }
            
        }
        //Test the connection with the specified connection string
        public bool TestConnection(string connectionString)
        {
            con = Connection;
            try
            {
                con.Open();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error!");
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        //Test the connection with the parameters for the connectionString
        public bool TestConnection(string IP, string DBName, string UserName, string Password)
        {
            MySqlConnection tmpCon = new MySqlConnection();
            try
            {
                string tmpConnectionString = string.Format(unformatedConnectionString, IP, DBName, UserName, Password);
                tmpCon = new MySqlConnection(tmpConnectionString);
                tmpCon.Open();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error!");
                return false;
            }
            finally
            {
                tmpCon.Close();
            }
        }

        private bool Connect()
        {
            con = Connection;
            try
            {
                con.Open();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error!");
                return false;
            }
        }

        private bool Disconnect()
        {
            try
            {
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error!");
                return false;
            }
        }
        //-----------------------------------------------------
        public void SendAddCommand(string command)
        {
            try
            {
                if (Connect())
                {
                    MySqlCommand sqlCommand = new MySqlCommand(command, con);
                    sqlCommand.ExecuteNonQuery();
                    Disconnect();
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
