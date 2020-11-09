using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DBFiller
{
    class Settings
    {
        private static string _IP = "192.168.11.195";
        private static int _PORT = 0;
        private static string _Username = "program";
        private static string _Password = "Qazwsx2020!!";
        private static string _DBName = "mill_vitre_auto";
        public static string IP 
        { 
            get { return _IP; } 
            set 
            {
                try
                {
                    IPAddress.Parse(value);
                    _IP = value;
                }
                catch
                {
                    throw new Exception("Invalid ip");
                }
            } 
        }
        public static int PORT { get { return _PORT; } set { _PORT = value; } }
        public static string USERNAME { get { return _Username; } set { _Username = value; } }
        public static string PASSWORD { get { return _Password; } set { _Password = value; } }
        public static string DBNAME { get { return _DBName; } set { _DBName = value; } }
    }
}
