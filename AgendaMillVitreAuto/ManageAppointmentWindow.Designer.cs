namespace AgendaMillVitreAuto
{
    partial class ManageAppointmentWindow
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
            this.buttonAddAppointment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxJob = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownHeure = new System.Windows.Forms.NumericUpDown();
            this.radioButtonHeureAM = new System.Windows.Forms.RadioButton();
            this.radioButtonHeurePM = new System.Windows.Forms.RadioButton();
            this.richTextBoxCommentaire = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.textBoxVehicle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeure)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddAppointment
            // 
            this.buttonAddAppointment.Location = new System.Drawing.Point(12, 283);
            this.buttonAddAppointment.Name = "buttonAddAppointment";
            this.buttonAddAppointment.Size = new System.Drawing.Size(131, 42);
            this.buttonAddAppointment.TabIndex = 0;
            this.buttonAddAppointment.Text = "Ajouter";
            this.buttonAddAppointment.UseVisualStyleBackColor = true;
            this.buttonAddAppointment.Click += new System.EventHandler(this.buttonAddAppointment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Job: ";
            // 
            // comboBoxJob
            // 
            this.comboBoxJob.FormattingEnabled = true;
            this.comboBoxJob.Location = new System.Drawing.Point(61, 52);
            this.comboBoxJob.Name = "comboBoxJob";
            this.comboBoxJob.Size = new System.Drawing.Size(245, 21);
            this.comboBoxJob.TabIndex = 2;
            this.comboBoxJob.TextUpdate += new System.EventHandler(this.comboBoxJob_TextUpdate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Client: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vehicule: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(61, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(245, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Heure: ";
            // 
            // numericUpDownHeure
            // 
            this.numericUpDownHeure.DecimalPlaces = 2;
            this.numericUpDownHeure.Location = new System.Drawing.Point(61, 29);
            this.numericUpDownHeure.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownHeure.Name = "numericUpDownHeure";
            this.numericUpDownHeure.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownHeure.TabIndex = 8;
            // 
            // radioButtonHeureAM
            // 
            this.radioButtonHeureAM.AutoSize = true;
            this.radioButtonHeureAM.Checked = true;
            this.radioButtonHeureAM.Location = new System.Drawing.Point(134, 31);
            this.radioButtonHeureAM.Name = "radioButtonHeureAM";
            this.radioButtonHeureAM.Size = new System.Drawing.Size(41, 17);
            this.radioButtonHeureAM.TabIndex = 9;
            this.radioButtonHeureAM.TabStop = true;
            this.radioButtonHeureAM.Text = "AM";
            this.radioButtonHeureAM.UseVisualStyleBackColor = true;
            // 
            // radioButtonHeurePM
            // 
            this.radioButtonHeurePM.AutoSize = true;
            this.radioButtonHeurePM.Location = new System.Drawing.Point(181, 31);
            this.radioButtonHeurePM.Name = "radioButtonHeurePM";
            this.radioButtonHeurePM.Size = new System.Drawing.Size(41, 17);
            this.radioButtonHeurePM.TabIndex = 10;
            this.radioButtonHeurePM.Text = "PM";
            this.radioButtonHeurePM.UseVisualStyleBackColor = true;
            // 
            // richTextBoxCommentaire
            // 
            this.richTextBoxCommentaire.Location = new System.Drawing.Point(12, 153);
            this.richTextBoxCommentaire.Name = "richTextBoxCommentaire";
            this.richTextBoxCommentaire.Size = new System.Drawing.Size(294, 124);
            this.richTextBoxCommentaire.TabIndex = 11;
            this.richTextBoxCommentaire.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Commentaire: ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(175, 283);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(131, 42);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxClient
            // 
            this.textBoxClient.Location = new System.Drawing.Point(61, 77);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(245, 20);
            this.textBoxClient.TabIndex = 16;
            // 
            // textBoxVehicle
            // 
            this.textBoxVehicle.Location = new System.Drawing.Point(61, 101);
            this.textBoxVehicle.Name = "textBoxVehicle";
            this.textBoxVehicle.Size = new System.Drawing.Size(245, 20);
            this.textBoxVehicle.TabIndex = 17;
            // 
            // ManageAppointmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 337);
            this.Controls.Add(this.textBoxVehicle);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxCommentaire);
            this.Controls.Add(this.radioButtonHeurePM);
            this.Controls.Add(this.radioButtonHeureAM);
            this.Controls.Add(this.numericUpDownHeure);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxJob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddAppointment);
            this.Name = "ManageAppointmentWindow";
            this.Text = "Ajouter un rendez-vous";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageAppointmentWindow_FormClosing);
            this.Load += new System.EventHandler(this.ManageAppointmentWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddAppointment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxJob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownHeure;
        private System.Windows.Forms.RadioButton radioButtonHeureAM;
        private System.Windows.Forms.RadioButton radioButtonHeurePM;
        private System.Windows.Forms.RichTextBox richTextBoxCommentaire;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.TextBox textBoxVehicle;
    }
}