using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    class ErrorMsg
    {
        public static void ChooseVehicleError()
        {
            MessageBox.Show("Veullier choisir un véhicule!", "Erreur");
        }
        public static void ChooseClientError()
        {
            MessageBox.Show("Veuiller selectionner un client!", "Erreur");
        }

    }
}
