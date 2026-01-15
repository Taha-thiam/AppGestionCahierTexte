namespace AppGestionCahierTexte.Views.Parametre
{
    partial class frmAnneeAcademique
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.DgAnneAcademique = new System.Windows.Forms.DataGridView();
            this.txtAnneAcademique = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgAnneAcademique)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "Annee Academique";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Libelle";
            // 
            // txtLibelle
            // 
            this.txtLibelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLibelle.Location = new System.Drawing.Point(62, 208);
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(226, 35);
            this.txtLibelle.TabIndex = 26;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(103, 619);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(226, 55);
            this.btnSupprimer.TabIndex = 25;
            this.btnSupprimer.Text = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(103, 555);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(226, 55);
            this.btnModifier.TabIndex = 24;
            this.btnModifier.Text = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(103, 491);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(226, 52);
            this.btnAjouter.TabIndex = 23;
            this.btnAjouter.Text = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectionner.Location = new System.Drawing.Point(62, 94);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(226, 52);
            this.btnSelectionner.TabIndex = 22;
            this.btnSelectionner.Text = "&Selectionner";
            this.btnSelectionner.UseVisualStyleBackColor = true;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // DgAnneAcademique
            // 
            this.DgAnneAcademique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgAnneAcademique.Location = new System.Drawing.Point(355, 35);
            this.DgAnneAcademique.Name = "DgAnneAcademique";
            this.DgAnneAcademique.RowHeadersWidth = 62;
            this.DgAnneAcademique.RowTemplate.Height = 28;
            this.DgAnneAcademique.Size = new System.Drawing.Size(883, 689);
            this.DgAnneAcademique.TabIndex = 21;
            // 
            // txtAnneAcademique
            // 
            this.txtAnneAcademique.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnneAcademique.Location = new System.Drawing.Point(62, 317);
            this.txtAnneAcademique.Name = "txtAnneAcademique";
            this.txtAnneAcademique.Size = new System.Drawing.Size(226, 35);
            this.txtAnneAcademique.TabIndex = 29;
            // 
            // frmAnneeAcademique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 813);
            this.ControlBox = false;
            this.Controls.Add(this.txtAnneAcademique);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.DgAnneAcademique);
            this.Name = "frmAnneeAcademique";
            this.Text = "Annee Academique";
            this.Load += new System.EventHandler(this.frmAnneeAcademique_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgAnneAcademique)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.DataGridView DgAnneAcademique;
        private System.Windows.Forms.TextBox txtAnneAcademique;
    }
}