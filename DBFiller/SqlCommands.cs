﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFiller
{
    class SqlCommands
    {
        public static string AddClientCommand(string firstname, string secondname, string phone, string address, string isBussiness)
        {
            string unformatedCommand = "INSERT INTO client SET FirstName='{0}',SecondName='{1}',Phone='{2}',Address='{3}',IsBussiness={4}";
            if (int.TryParse(isBussiness, out int parsed))
            {
                string command = string.Format(unformatedCommand, firstname, secondname, phone, address, parsed);
                return command;
            }
            else
            {
                string command = string.Format(unformatedCommand, firstname, secondname, phone, address, '0');
                return command;
            }
        }
    }
}
