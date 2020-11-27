namespace AgendaMillVitreAuto
{
    partial class ModifyVehicleWindow
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
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxVehicleColor = new System.Windows.Forms.TextBox();
            this.textBoxVehicleBrand = new System.Windows.Forms.TextBox();
            this.textBoxVehicleModel = new System.Windows.Forms.TextBox();
            this.labelVehicleYear = new System.Windows.Forms.Label();
            this.labelVehicleColor = new System.Windows.Forms.Label();
            this.labelVehicleBrand = new System.Windows.Forms.Label();
            this.labelVehicleModel = new System.Windows.Forms.Label();
            this.labelModifyVehicle = new System.Windows.Forms.Label();
            this.textBoxVehicleNumber = new System.Windows.Forms.TextBox();
            this.labelVehicleNumber = new System.Windows.Forms.Label();
            this.numericUpDownYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(16, 173);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 40);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "Confirmer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(161, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 40);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxVehicleColor
            // 
            this.textBoxVehicleColor.Location = new System.Drawing.Point(134, 90);
            this.textBoxVehicleColor.Name = "textBoxVehicleColor";
            this.textBoxVehicleColor.Size = new System.Drawing.Size(129, 20);
            this.textBoxVehicleColor.TabIndex = 3;
            // 
            // textBoxVehicleBrand
            // 
            this.textBoxVehicleBrand.Location = new System.Drawing.Point(134, 38);
            this.textBoxVehicleBrand.Name = "textBoxVehicleBrand";
            this.textBoxVehicleBrand.Size = new System.Drawing.Size(129, 20);
            this.textBoxVehicleBrand.TabIndex = 1;
            // 
            // textBoxVehicleModel
            // 
            this.textBoxVehicleModel.Location = new System.Drawing.Point(134, 64);
            this.textBoxVehicleModel.Name = "textBoxVehicleModel";
            this.textBoxVehicleModel.Size = new System.Drawing.Size(129, 20);
            this.textBoxVehicleModel.TabIndex = 2;
            // 
            // labelVehicleYear
            // 
            this.labelVehicleYear.AutoSize = true;
            this.labelVehicleYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleYear.Location = new System.Drawing.Point(12, 114);
            this.labelVehicleYear.Name = "labelVehicleYear";
            this.labelVehicleYear.Size = new System.Drawing.Size(60, 20);
            this.labelVehicleYear.TabIndex = 28;
            this.labelVehicleYear.Text = "Année:";
            // 
            // labelVehicleColor
            // 
            this.labelVehicleColor.AutoSize = true;
            this.labelVehicleColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleColor.Location = new System.Drawing.Point(12, 88);
            this.labelVehicleColor.Name = "labelVehicleColor";
            this.labelVehicleColor.Size = new System.Drawing.Size(68, 20);
            this.labelVehicleColor.TabIndex = 27;
            this.labelVehicleColor.Text = "Couleur:";
            // 
            // labelVehicleBrand
            // 
            this.labelVehicleBrand.AutoSize = true;
            this.labelVehicleBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleBrand.Location = new System.Drawing.Point(12, 36);
            this.labelVehicleBrand.Name = "labelVehicleBrand";
            this.labelVehicleBrand.Size = new System.Drawing.Size(67, 20);
            this.labelVehicleBrand.TabIndex = 25;
            this.labelVehicleBrand.Text = "Marque:";
            // 
            // labelVehicleModel
            // 
            this.labelVehicleModel.AutoSize = true;
            this.labelVehicleModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleModel.Location = new System.Drawing.Point(12, 62);
            this.labelVehicleModel.Name = "labelVehicleModel";
            this.labelVehicleModel.Size = new System.Drawing.Size(65, 20);
            this.labelVehicleModel.TabIndex = 24;
            this.labelVehicleModel.Text = "Modèle:";
            // 
            // labelModifyVehicle
            // 
            this.labelModifyVehicle.AutoSize = true;
            this.labelModifyVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModifyVehicle.Location = new System.Drawing.Point(12, 9);
            this.labelModifyVehicle.Name = "labelModifyVehicle";
            this.labelModifyVehicle.Size = new System.Drawing.Size(172, 20);
            this.labelModifyVehicle.TabIndex = 23;
            this.labelModifyVehicle.Text = "Modification du véhicle:";
            // 
            // textBoxVehicleNumber
            // 
            this.textBoxVehicleNumber.Location = new System.Drawing.Point(134, 142);
            this.textBoxVehicleNumber.Name = "textBoxVehicleNumber";
            this.textBoxVehicleNumber.Size = new System.Drawing.Size(129, 20);
            this.textBoxVehicleNumber.TabIndex = 5;
            // 
            // labelVehicleNumber
            // 
            this.labelVehicleNumber.AutoSize = true;
            this.labelVehicleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicleNumber.Location = new System.Drawing.Point(12, 140);
            this.labelVehicleNumber.Name = "labelVehicleNumber";
            this.labelVehicleNumber.Size = new System.Drawing.Size(116, 20);
            this.labelVehicleNumber.TabIndex = 36;
            this.labelVehicleNumber.Text = "No de véhicule:";
            // 
            // numericUpDownYear
            // 
            this.numericUpDownYear.Location = new System.Drawing.Point(134, 116);
            this.numericUpDownYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownYear.Name = "numericUpDownYear";
            this.numericUpDownYear.Size = new System.Drawing.Size(129, 20);
            this.numericUpDownYear.TabIndex = 4;
            this.numericUpDownYear.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // ModifyVehicleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 218);
            this.Controls.Add(this.numericUpDownYear);
            this.Controls.Add(this.textBoxVehicleNumber);
            this.Controls.Add(this.labelVehicleNumber);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxVehicleColor);
            this.Controls.Add(this.textBoxVehicleBrand);
            this.Controls.Add(this.textBoxVehicleModel);
            this.Controls.Add(this.labelVehicleYear);
            this.Controls.Add(this.labelVehicleColor);
            this.Controls.Add(this.labelVehicleBrand);
            this.Controls.Add(this.labelVehicleModel);
            this.Controls.Add(this.labelModifyVehicle);
            this.Name = "ModifyVehicleWindow";
            this.Text = "ModifyVehicleWindow";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxVehicleColor;
        private System.Windows.Forms.TextBox textBoxVehicleBrand;
        private System.Windows.Forms.TextBox textBoxVehicleModel;
        private System.Windows.Forms.Label labelVehicleYear;
        private System.Windows.Forms.Label labelVehicleColor;
        private System.Windows.Forms.Label labelVehicleBrand;
        private System.Windows.Forms.Label labelVehicleModel;
        private System.Windows.Forms.Label labelModifyVehicle;
        private System.Windows.Forms.TextBox textBoxVehicleNumber;
        private System.Windows.Forms.Label labelVehicleNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
    }
}