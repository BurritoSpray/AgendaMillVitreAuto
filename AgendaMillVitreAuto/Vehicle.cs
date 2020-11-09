using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMillVitreAuto
{
    class Vehicle
    {
        private int mID;
        private int mOwnerID;
        private string mBrand;
        private string mModel;
        private string mColor;
        private int mYear;
        private bool mIsbusiness;
        private string mVehicleNumber;
        //Creation de Vehicule de base vide
        public Vehicle()
        {
            mOwnerID = -1;
            mID = -1;
            mBrand = "";
            mModel = "";
            mColor = "";
            mYear = 0;
            mIsbusiness = false;
            mVehicleNumber = "";
        }
        //Creation Vehicle de base sans numero de compagnie
        public Vehicle(int vehicleID)
        {
            SqlConnection con = new SqlConnection();
            Vehicle vehicle = con.SelectVehicleInfo(vehicleID);
            mOwnerID = vehicle.OwnerID;
            mID = vehicle.ID;
            mBrand = vehicle.Brand;
            mModel = vehicle.Model;
            mColor = vehicle.Color;
            mYear = vehicle.Year;
            mIsbusiness = vehicle.IsbusinessVehicle;
            mVehicleNumber = vehicle.VehicleNumber;
        }
        public Vehicle(string ownerID, string brand, string model, string color, string year, string vehicleNumber)
        {
            mID = -1;
            mOwnerID = int.Parse(ownerID);
            mBrand = brand;
            mModel = model;
            mColor = color;
            mYear = int.Parse(year);
            mIsbusiness = false;
            mVehicleNumber = vehicleNumber;
        }
        public Vehicle(string ownerID, string vehicleID, string brand, string model, string color, string year, string vehicleNumber)
        {
            mID = int.Parse(vehicleID);
            mOwnerID = int.Parse(ownerID);
            mBrand = brand;
            mModel = model;
            mColor = color;
            mYear = int.Parse(year);
            mVehicleNumber = vehicleNumber;

        }
        public string[] VehiculeInfo()
        {
            string[] info = { mBrand, mModel, mColor, mYear.ToString() };
            return info;
        }
        public string Brand{ get { return mBrand; } set { mBrand = value; } }
        public string Model { get { return mModel; } set { mModel = value; } }
        public string Color { get { return mColor; } set { mColor = value; } }
        public int Year { get { return mYear; } set { mYear = value; } }
        public int ID { get { return mID; } }
        public bool IsbusinessVehicle { get { return mIsbusiness; } set { mIsbusiness = value; } }
        public string VehicleNumber { get { return mVehicleNumber; } set { mVehicleNumber = value; } }
        public int OwnerID { get { return mOwnerID; } set { mOwnerID = value; } }
        public string[] VehicleInfo
        {
            get
            {
                string[] info = { ID.ToString(), Brand, Model, Year.ToString(), Color };
                return info;
            }
        }

    }
}
