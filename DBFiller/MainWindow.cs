using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFiller
{
    public partial class MainWindow : Form
    {
        private SettingWindow settingWindow;
        private bool SettingWindowIsActive = false;
        private string filePath = string.Empty;
        private int _lineCount = 0;
        private SqlConnection con = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!SettingWindowIsActive)
            {
                settingWindow = new SettingWindow();
                settingWindow.Disposed += SettingWindowClosed;
                SettingWindowIsActive = true;
                settingWindow.Show();
            }
        }
        private void SettingWindowClosed(Object sender, EventArgs e)
        {
            SettingWindowIsActive = false;
        }

        private void buttonFileDialog_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Data File Browser";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                ofd.Filter = "csv file (*.csv)|*.csv";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = ofd.FileName;
                    filePath = ofd.FileName;
                    try
                    {
                        using (StreamReader reader = new StreamReader(ofd.FileName))
                        {
                            dataGridViewCSV.Columns.Clear();
                            dataGridViewCSV.Rows.Clear();
                            int lineCount = 0;
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                line = line.Replace('"', ' ');
                                line = line.Trim();
                                if(lineCount == 0)
                                {
                                    string[] columns = line.Split(',');
                                    int columnCount = 0;
                                    foreach(string column in columns)
                                    {
                                        dataGridViewCSV.Columns.Add(column, column);
                                        dataGridViewCSV.Columns[columnCount].Width = dataGridViewCSV.Width / columns.Length;
                                        columnCount++;
                                    }
                                }
                                else if(lineCount > 0)
                                {
                                    string[] splitedData = line.Split(',');
                                    dataGridViewCSV.Rows.Add(splitedData);
                                    
                                }
                                lineCount++;
                            }
                            labelNumberOfLine.Text = lineCount.ToString();
                            _lineCount = lineCount;
                        }
                    }
                    catch(Exception ex)
                    {
                        var value = MessageBox.Show(ex.Message, "File error!");
                        buttonFileDialog_Click(this, new EventArgs());
                    }
                    buttonStart.Enabled = true;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void backgroundWorkerAddClient_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (con.TestConnection())
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        int lineCount = 0;
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            line = line.Replace('"', ' ');
                            line = line.Trim();
                            if (lineCount > 0)
                            {

                                string[] splitedLine = line.Split(',');
                                if (splitedLine.Length != 4)
                                {
                                    MessageBox.Show("Invalid format!", "File error!");
                                    break;
                                }
                                else
                                {
                                    con.SendAddCommand(SqlCommands.AddClientCommand(splitedLine[0], splitedLine[1], splitedLine[2], splitedLine[3], "0"));
                                    decimal progress = 100m / (decimal)_lineCount * (decimal)lineCount;
                                    backgroundWorkerAddClient.ReportProgress((int)progress + 1);
                                }
                            }
                            lineCount++;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection error!");
                bool result = false;
                backgroundWorkerAddClient.ReportProgress(100, result);
            }
        }

        private void backgroundWorkerAddClient_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarWorker.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                if ((bool)e.UserState == false)
                {
                    backgroundWorkerAddClient_RunWorkerCompleted(this, new RunWorkerCompletedEventArgs(e.UserState, new Exception(), false));
                }
            }
        }

        private void backgroundWorkerAddClient_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    if ((bool)e.Result != false)
                    {
                        progressBarWorker.Value = 100;
                        MessageBox.Show("Filling completed with success!", "success");
                        buttonClose.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("An error occured!", "Error");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonClose.Enabled = false;
            backgroundWorkerAddClient.RunWorkerAsync();
        }
    }
}
