namespace FakeNameParser
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelClientCountText = new System.Windows.Forms.Label();
            this.labelClientCount = new System.Windows.Forms.Label();
            this.labelClientToGenerate = new System.Windows.Forms.Label();
            this.labelSQLConnectionStateText = new System.Windows.Forms.Label();
            this.numericUpDownClientToGenerateCount = new System.Windows.Forms.NumericUpDown();
            this.labelDatabaseConnectionState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWebPageConnectionState = new System.Windows.Forms.Label();
            this.progressBarGenerate = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClientToGenerateCount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelClientCountText
            // 
            this.labelClientCountText.AutoSize = true;
            this.labelClientCountText.BackColor = System.Drawing.Color.Transparent;
            this.labelClientCountText.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientCountText.Location = new System.Drawing.Point(13, 13);
            this.labelClientCountText.Name = "labelClientCountText";
            this.labelClientCountText.Size = new System.Drawing.Size(309, 20);
            this.labelClientCountText.TabIndex = 0;
            this.labelClientCountText.Text = "Nombre de client dans la base de donné: ";
            // 
            // labelClientCount
            // 
            this.labelClientCount.AutoSize = true;
            this.labelClientCount.BackColor = System.Drawing.Color.Transparent;
            this.labelClientCount.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientCount.Location = new System.Drawing.Point(328, 13);
            this.labelClientCount.Name = "labelClientCount";
            this.labelClientCount.Size = new System.Drawing.Size(18, 20);
            this.labelClientCount.TabIndex = 1;
            this.labelClientCount.Text = "0";
            // 
            // labelClientToGenerate
            // 
            this.labelClientToGenerate.AutoSize = true;
            this.labelClientToGenerate.BackColor = System.Drawing.Color.Transparent;
            this.labelClientToGenerate.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientToGenerate.Location = new System.Drawing.Point(13, 48);
            this.labelClientToGenerate.Name = "labelClientToGenerate";
            this.labelClientToGenerate.Size = new System.Drawing.Size(214, 20);
            this.labelClientToGenerate.TabIndex = 2;
            this.labelClientToGenerate.Text = "Nombre de client a generer:";
            // 
            // labelSQLConnectionStateText
            // 
            this.labelSQLConnectionStateText.AutoSize = true;
            this.labelSQLConnectionStateText.BackColor = System.Drawing.Color.Transparent;
            this.labelSQLConnectionStateText.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLConnectionStateText.Location = new System.Drawing.Point(13, 85);
            this.labelSQLConnectionStateText.Name = "labelSQLConnectionStateText";
            this.labelSQLConnectionStateText.Size = new System.Drawing.Size(293, 20);
            this.labelSQLConnectionStateText.TabIndex = 3;
            this.labelSQLConnectionStateText.Text = "État de la connection à la base donnée: ";
            // 
            // numericUpDownClientToGenerateCount
            // 
            this.numericUpDownClientToGenerateCount.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.numericUpDownClientToGenerateCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownClientToGenerateCount.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownClientToGenerateCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownClientToGenerateCount.Location = new System.Drawing.Point(233, 49);
            this.numericUpDownClientToGenerateCount.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownClientToGenerateCount.Name = "numericUpDownClientToGenerateCount";
            this.numericUpDownClientToGenerateCount.Size = new System.Drawing.Size(75, 24);
            this.numericUpDownClientToGenerateCount.TabIndex = 4;
            this.numericUpDownClientToGenerateCount.ValueChanged += new System.EventHandler(this.numericUpDownClientToGenerateCount_ValueChanged);
            // 
            // labelDatabaseConnectionState
            // 
            this.labelDatabaseConnectionState.AutoSize = true;
            this.labelDatabaseConnectionState.BackColor = System.Drawing.Color.Red;
            this.labelDatabaseConnectionState.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabaseConnectionState.Location = new System.Drawing.Point(312, 85);
            this.labelDatabaseConnectionState.Name = "labelDatabaseConnectionState";
            this.labelDatabaseConnectionState.Size = new System.Drawing.Size(99, 20);
            this.labelDatabaseConnectionState.TabIndex = 5;
            this.labelDatabaseConnectionState.Text = "Déconnecter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "État de la connection à FakeNameGenerator.com";
            // 
            // labelWebPageConnectionState
            // 
            this.labelWebPageConnectionState.AutoSize = true;
            this.labelWebPageConnectionState.BackColor = System.Drawing.Color.Red;
            this.labelWebPageConnectionState.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWebPageConnectionState.Location = new System.Drawing.Point(380, 121);
            this.labelWebPageConnectionState.Name = "labelWebPageConnectionState";
            this.labelWebPageConnectionState.Size = new System.Drawing.Size(99, 20);
            this.labelWebPageConnectionState.TabIndex = 7;
            this.labelWebPageConnectionState.Text = "Déconnecter";
            // 
            // progressBarGenerate
            // 
            this.progressBarGenerate.Location = new System.Drawing.Point(17, 153);
            this.progressBarGenerate.Name = "progressBarGenerate";
            this.progressBarGenerate.Size = new System.Drawing.Size(462, 23);
            this.progressBarGenerate.TabIndex = 8;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(17, 183);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(462, 23);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "Generate";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(511, 214);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.progressBarGenerate);
            this.Controls.Add(this.labelWebPageConnectionState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDatabaseConnectionState);
            this.Controls.Add(this.numericUpDownClientToGenerateCount);
            this.Controls.Add(this.labelSQLConnectionStateText);
            this.Controls.Add(this.labelClientToGenerate);
            this.Controls.Add(this.labelClientCount);
            this.Controls.Add(this.labelClientCountText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainWindow";
            this.Text = "Database Filler using FakeNameGenerator.com";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClientToGenerateCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClientCountText;
        private System.Windows.Forms.Label labelClientCount;
        private System.Windows.Forms.Label labelClientToGenerate;
        private System.Windows.Forms.Label labelSQLConnectionStateText;
        private System.Windows.Forms.NumericUpDown numericUpDownClientToGenerateCount;
        private System.Windows.Forms.Label labelDatabaseConnectionState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelWebPageConnectionState;
        private System.Windows.Forms.ProgressBar progressBarGenerate;
        private System.Windows.Forms.Button buttonStart;
    }
}

