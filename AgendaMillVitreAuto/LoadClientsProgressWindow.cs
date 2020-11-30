using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaMillVitreAuto
{
    public partial class LoadClientsProgressWindow : Form
    {
        public LoadClientsProgressWindow()
        {
            InitializeComponent();
            progressBar.Minimum = 0;
        }
        

        public int Progress { get { return progressBar.Value; } set
            {
                if (value <= 0)
                    progressBar.Value = 0;
                else if (value >= progressBar.Maximum)
                    progressBar.Value = progressBar.Maximum;
                else
                    progressBar.Value = value;
            }
        }

        public int Maximum { get { return progressBar.Maximum; } set
            {
                if (value <= progressBar.Minimum)
                    progressBar.Maximum = progressBar.Minimum + 1;
                else if (value > progressBar.Minimum)
                    progressBar.Maximum = value;
            } }
    }
}
