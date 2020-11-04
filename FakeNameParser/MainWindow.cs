using AgendaMillVitreAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeNameParser
{
    public partial class MainWindow : Form
    {
        SqlConnection con = new SqlConnection();
        BackgroundWorker worker = new BackgroundWorker();
        List<Client> clientsFromFile = new List<Client>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.Connect())
            {
                labelDatabaseConnectionState.BackColor = Color.Green;
                labelDatabaseConnectionState.Text = "Connected";
                List<Client> clientList = con.SelectClients();
                labelClientCount.Text = clientList.Count.ToString();
                worker.DoWork += Worker_DoWork;
                worker.ProgressChanged += Worker_ProgressChanged;
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                using(OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    openFileDialog.Filter = "csv files (*.csv)|*.csv";
                    if(openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            while (!reader.EndOfStream)
                            {
                                var data = reader.ReadLine();
                                string[] splitedData = data.Split(';');
                                //Client client = new Client(nom: splitedData[0], prenom: "test");
                            }
                        }
                    }
                }
            }
            else
            {
                Thread.Sleep(5000);
                this.Close();
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void numericUpDownClientToGenerateCount_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDownClientToGenerateCount.Value < 0)
            {
                numericUpDownClientToGenerateCount.Value = 0;
            }
        }
    }
}
