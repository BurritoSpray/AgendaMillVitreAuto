namespace DBFiller
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
            this.buttonFileDialog = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNumberOfLine = new System.Windows.Forms.Label();
            this.dataGridViewCSV = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerAddClient = new System.ComponentModel.BackgroundWorker();
            this.buttonStart = new System.Windows.Forms.Button();
            this.progressBarWorker = new System.Windows.Forms.ProgressBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCSV)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFileDialog
            // 
            this.buttonFileDialog.Location = new System.Drawing.Point(264, 39);
            this.buttonFileDialog.Name = "buttonFileDialog";
            this.buttonFileDialog.Size = new System.Drawing.Size(75, 23);
            this.buttonFileDialog.TabIndex = 0;
            this.buttonFileDialog.Text = "Browse Files";
            this.buttonFileDialog.UseVisualStyleBackColor = true;
            this.buttonFileDialog.Click += new System.EventHandler(this.buttonFileDialog_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(12, 41);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(246, 20);
            this.textBoxFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Source:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(87, 22);
            this.toolStripButton1.Text = "Server settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of lines in the file:";
            // 
            // labelNumberOfLine
            // 
            this.labelNumberOfLine.AutoSize = true;
            this.labelNumberOfLine.Location = new System.Drawing.Point(147, 75);
            this.labelNumberOfLine.Name = "labelNumberOfLine";
            this.labelNumberOfLine.Size = new System.Drawing.Size(83, 13);
            this.labelNumberOfLine.TabIndex = 5;
            this.labelNumberOfLine.Text = "No file selected!";
            // 
            // dataGridViewCSV
            // 
            this.dataGridViewCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCSV.Location = new System.Drawing.Point(12, 91);
            this.dataGridViewCSV.Name = "dataGridViewCSV";
            this.dataGridViewCSV.ReadOnly = true;
            this.dataGridViewCSV.RowHeadersVisible = false;
            this.dataGridViewCSV.Size = new System.Drawing.Size(776, 182);
            this.dataGridViewCSV.TabIndex = 6;
            // 
            // backgroundWorkerAddClient
            // 
            this.backgroundWorkerAddClient.WorkerReportsProgress = true;
            this.backgroundWorkerAddClient.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddClient_DoWork);
            this.backgroundWorkerAddClient.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerAddClient_ProgressChanged);
            this.backgroundWorkerAddClient.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAddClient_RunWorkerCompleted);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(12, 279);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(164, 48);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Fill with data";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // progressBarWorker
            // 
            this.progressBarWorker.Location = new System.Drawing.Point(12, 333);
            this.progressBarWorker.Name = "progressBarWorker";
            this.progressBarWorker.Size = new System.Drawing.Size(776, 34);
            this.progressBarWorker.TabIndex = 8;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(624, 279);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 48);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.progressBarWorker);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.dataGridViewCSV);
            this.Controls.Add(this.labelNumberOfLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.buttonFileDialog);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "DBFiller";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileDialog;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNumberOfLine;
        private System.Windows.Forms.DataGridView dataGridViewCSV;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddClient;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ProgressBar progressBarWorker;
        private System.Windows.Forms.Button buttonClose;
    }
}

