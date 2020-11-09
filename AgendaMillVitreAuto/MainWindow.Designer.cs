namespace AgendaMillVitreAuto
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonManageClients = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.setDateLabel = new System.Windows.Forms.Label();
            this.dateUpdateWorker = new System.ComponentModel.BackgroundWorker();
            this.comboBoxModeVue = new System.Windows.Forms.ComboBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxJobInfo = new System.Windows.Forms.RichTextBox();
            this.richTextBoxInfoClient = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerGrid = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonManageClients
            // 
            this.buttonManageClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManageClients.Location = new System.Drawing.Point(12, 645);
            this.buttonManageClients.Name = "buttonManageClients";
            this.buttonManageClients.Size = new System.Drawing.Size(326, 45);
            this.buttonManageClients.TabIndex = 0;
            this.buttonManageClients.Text = "Gerer liste de clients";
            this.buttonManageClients.UseVisualStyleBackColor = true;
            this.buttonManageClients.Click += new System.EventHandler(this.buttonManageClients_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.Location = new System.Drawing.Point(8, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(58, 20);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Date: ";
            // 
            // setDateLabel
            // 
            this.setDateLabel.AutoSize = true;
            this.setDateLabel.BackColor = System.Drawing.SystemColors.Control;
            this.setDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setDateLabel.Location = new System.Drawing.Point(58, 9);
            this.setDateLabel.Name = "setDateLabel";
            this.setDateLabel.Size = new System.Drawing.Size(58, 20);
            this.setDateLabel.TabIndex = 2;
            this.setDateLabel.Text = "Date: ";
            // 
            // dateUpdateWorker
            // 
            this.dateUpdateWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dateUpdateWorker_DoWork);
            this.dateUpdateWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dateUpdateWorker_ProgressChanged);
            // 
            // comboBoxModeVue
            // 
            this.comboBoxModeVue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModeVue.FormattingEnabled = true;
            this.comboBoxModeVue.Items.AddRange(new object[] {
            "Journée",
            "Semaine",
            "Mois"});
            this.comboBoxModeVue.Location = new System.Drawing.Point(829, 659);
            this.comboBoxModeVue.Name = "comboBoxModeVue";
            this.comboBoxModeVue.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModeVue.TabIndex = 5;
            this.comboBoxModeVue.SelectedIndexChanged += new System.EventHandler(this.comboBoxModeVue_SelectedIndexChanged);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hour,
            this.Job,
            this.Client,
            this.Phone,
            this.Vehicle});
            this.dataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGrid.Location = new System.Drawing.Point(299, 12);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.ShowEditingIcon = false;
            this.dataGrid.Size = new System.Drawing.Size(1125, 618);
            this.dataGrid.TabIndex = 6;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGridViewPlanning_SelectionChanged);
            // 
            // Hour
            // 
            this.Hour.HeaderText = "Heure";
            this.Hour.Name = "Hour";
            this.Hour.ReadOnly = true;
            // 
            // Job
            // 
            this.Job.HeaderText = "Job";
            this.Job.Name = "Job";
            this.Job.ReadOnly = true;
            this.Job.Width = 150;
            // 
            // Client
            // 
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            this.Client.Width = 200;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Téléphone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Vehicle
            // 
            this.Vehicle.HeaderText = "Vehicule";
            this.Vehicle.Name = "Vehicle";
            this.Vehicle.ReadOnly = true;
            this.Vehicle.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(715, 659);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mode de vue: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Info sur la job: ";
            // 
            // richTextBoxJobInfo
            // 
            this.richTextBoxJobInfo.Location = new System.Drawing.Point(12, 53);
            this.richTextBoxJobInfo.Name = "richTextBoxJobInfo";
            this.richTextBoxJobInfo.ReadOnly = true;
            this.richTextBoxJobInfo.Size = new System.Drawing.Size(281, 165);
            this.richTextBoxJobInfo.TabIndex = 11;
            this.richTextBoxJobInfo.Text = "";
            // 
            // richTextBoxInfoClient
            // 
            this.richTextBoxInfoClient.Location = new System.Drawing.Point(12, 272);
            this.richTextBoxInfoClient.Name = "richTextBoxInfoClient";
            this.richTextBoxInfoClient.ReadOnly = true;
            this.richTextBoxInfoClient.Size = new System.Drawing.Size(281, 195);
            this.richTextBoxInfoClient.TabIndex = 12;
            this.richTextBoxInfoClient.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Info sur le client: ";
            // 
            // dateTimePickerGrid
            // 
            this.dateTimePickerGrid.CustomFormat = "";
            this.dateTimePickerGrid.Location = new System.Drawing.Point(495, 661);
            this.dateTimePickerGrid.Name = "dateTimePickerGrid";
            this.dateTimePickerGrid.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerGrid.TabIndex = 14;
            this.dateTimePickerGrid.ValueChanged += new System.EventHandler(this.dateTimePickerGrid_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(380, 661);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Date afficher: ";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 702);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxInfoClient);
            this.Controls.Add(this.richTextBoxJobInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.comboBoxModeVue);
            this.Controls.Add(this.setDateLabel);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.buttonManageClients);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(777, 416);
            this.Name = "MainWindow";
            this.Text = "Agenda Mill Vitre Auto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonManageClients;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label setDateLabel;
        private System.ComponentModel.BackgroundWorker dateUpdateWorker;
        private System.Windows.Forms.ComboBox comboBoxModeVue;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxJobInfo;
        private System.Windows.Forms.RichTextBox richTextBoxInfoClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vehicle;
    }
}