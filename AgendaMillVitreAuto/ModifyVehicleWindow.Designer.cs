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
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelBrand = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
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
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(134, 90);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(129, 20);
            this.textBoxColor.TabIndex = 3;
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(134, 38);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(129, 20);
            this.textBoxBrand.TabIndex = 1;
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(134, 64);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(129, 20);
            this.textBoxModel.TabIndex = 2;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.Location = new System.Drawing.Point(12, 114);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(60, 20);
            this.labelYear.TabIndex = 28;
            this.labelYear.Text = "Année:";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.Location = new System.Drawing.Point(12, 88);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(68, 20);
            this.labelColor.TabIndex = 27;
            this.labelColor.Text = "Couleur:";
            // 
            // labelBrand
            // 
            this.labelBrand.AutoSize = true;
            this.labelBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBrand.Location = new System.Drawing.Point(12, 36);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(67, 20);
            this.labelBrand.TabIndex = 25;
            this.labelBrand.Text = "Marque:";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModel.Location = new System.Drawing.Point(12, 62);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(65, 20);
            this.labelModel.TabIndex = 24;
            this.labelModel.Text = "Modèle:";
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
            this.Controls.Add(this.textBoxColor);
            this.Controls.Add(this.textBoxBrand);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelBrand);
            this.Controls.Add(this.labelModel);
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
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelModifyVehicle;
        private System.Windows.Forms.TextBox textBoxVehicleNumber;
        private System.Windows.Forms.Label labelVehicleNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownYear;
    }
}