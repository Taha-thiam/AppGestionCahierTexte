namespace AppGestionCahierTexte.Views.Parametre
{
    partial class frmSyllabus
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.DgSyllabus = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblVolumeHoraire = new System.Windows.Forms.Label();
            this.txtVolumeHoraire = new System.Windows.Forms.TextBox();
            this.lblMatiere = new System.Windows.Forms.Label();
            this.cmbMatiere = new System.Windows.Forms.ComboBox();
            this.lblClasse = new System.Windows.Forms.Label();
            this.cmbClasse = new System.Windows.Forms.ComboBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgSyllabus)).BeginInit();
            this.pnlCard.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // ── pnlMain ──────────────────────────────────────────────────────
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(15, 17, 26);
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlCard);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1875, 880);

            // ── pnlHeader ────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(20, 23, 35);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1875, 80);
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(230, 230, 255);
            this.lblTitle.Location = new System.Drawing.Point(30, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "📋  Syllabus";

            // ── pnlCard ──────────────────────────────────────────────────────
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.pnlCard.Controls.Add(this.lblCardTitle);
            this.pnlCard.Controls.Add(this.lblLibelle);
            this.pnlCard.Controls.Add(this.txtLibelle);
            this.pnlCard.Controls.Add(this.lblDescription);
            this.pnlCard.Controls.Add(this.txtDescription);
            this.pnlCard.Controls.Add(this.lblVolumeHoraire);
            this.pnlCard.Controls.Add(this.txtVolumeHoraire);
            this.pnlCard.Controls.Add(this.lblMatiere);
            this.pnlCard.Controls.Add(this.cmbMatiere);
            this.pnlCard.Controls.Add(this.lblClasse);
            this.pnlCard.Controls.Add(this.cmbClasse);
            this.pnlCard.Controls.Add(this.pnlButtons);
            this.pnlCard.Location = new System.Drawing.Point(20, 86);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(494, 720);
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);

            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblCardTitle.Location = new System.Drawing.Point(20, 18);
            this.lblCardTitle.Text = "✦  Saisie";

            // LIBELLÉ
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLibelle.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblLibelle.Location = new System.Drawing.Point(30, 58);
            this.lblLibelle.Text = "LIBELLÉ";

            this.txtLibelle.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.txtLibelle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLibelle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLibelle.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.txtLibelle.Location = new System.Drawing.Point(30, 80);
            this.txtLibelle.MaxLength = 200;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(414, 32);
            this.txtLibelle.TabIndex = 0;

            // DESCRIPTION
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblDescription.Location = new System.Drawing.Point(30, 138);
            this.lblDescription.Text = "DESCRIPTION";

            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.txtDescription.Location = new System.Drawing.Point(30, 160);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(414, 32);
            this.txtDescription.TabIndex = 1;

            // VOLUME HORAIRE
            this.lblVolumeHoraire.AutoSize = true;
            this.lblVolumeHoraire.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVolumeHoraire.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblVolumeHoraire.Location = new System.Drawing.Point(30, 218);
            this.lblVolumeHoraire.Text = "VOLUME HORAIRE (h)";

            this.txtVolumeHoraire.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.txtVolumeHoraire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVolumeHoraire.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtVolumeHoraire.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.txtVolumeHoraire.Location = new System.Drawing.Point(30, 240);
            this.txtVolumeHoraire.MaxLength = 10;
            this.txtVolumeHoraire.Name = "txtVolumeHoraire";
            this.txtVolumeHoraire.Size = new System.Drawing.Size(414, 32);
            this.txtVolumeHoraire.TabIndex = 2;

            // MATIÈRE
            this.lblMatiere.AutoSize = true;
            this.lblMatiere.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMatiere.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblMatiere.Location = new System.Drawing.Point(30, 298);
            this.lblMatiere.Text = "MATIÈRE";

            this.cmbMatiere.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.cmbMatiere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatiere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMatiere.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbMatiere.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.cmbMatiere.Location = new System.Drawing.Point(30, 320);
            this.cmbMatiere.Name = "cmbMatiere";
            this.cmbMatiere.Size = new System.Drawing.Size(414, 38);
            this.cmbMatiere.TabIndex = 3;

            // CLASSE
            this.lblClasse.AutoSize = true;
            this.lblClasse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClasse.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblClasse.Location = new System.Drawing.Point(30, 378);
            this.lblClasse.Text = "CLASSE";

            this.cmbClasse.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.cmbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClasse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbClasse.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.cmbClasse.Location = new System.Drawing.Point(30, 400);
            this.cmbClasse.Name = "cmbClasse";
            this.cmbClasse.Size = new System.Drawing.Size(414, 38);
            this.cmbClasse.TabIndex = 4;

            // ── pnlButtons ───────────────────────────────────────────────────
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnAjouter);
            this.pnlButtons.Controls.Add(this.btnSelectionner);
            this.pnlButtons.Controls.Add(this.btnModifier);
            this.pnlButtons.Controls.Add(this.btnSupprimer);
            this.pnlButtons.Controls.Add(this.btnEffacer);
            this.pnlButtons.Location = new System.Drawing.Point(20, 456);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(432, 230);

            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(56, 139, 253);
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(0, 0);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(429, 44);
            this.btnAjouter.Text = "＋  Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);

            this.btnSelectionner.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.btnSelectionner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectionner.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 70, 100);
            this.btnSelectionner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectionner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSelectionner.ForeColor = System.Drawing.Color.FromArgb(180, 190, 220);
            this.btnSelectionner.Location = new System.Drawing.Point(0, 48);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(429, 44);
            this.btnSelectionner.Text = "⊙  Sélectionner";
            this.btnSelectionner.UseVisualStyleBackColor = false;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);

            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.btnModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifier.Enabled = false;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(255, 170, 50);
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnModifier.ForeColor = System.Drawing.Color.FromArgb(255, 170, 50);
            this.btnModifier.Location = new System.Drawing.Point(0, 96);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(429, 44);
            this.btnModifier.Text = "✎  Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);

            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSupprimer.ForeColor = System.Drawing.Color.FromArgb(220, 80, 80);
            this.btnSupprimer.Location = new System.Drawing.Point(0, 144);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(429, 44);
            this.btnSupprimer.Text = "🗑  Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);

            this.btnEffacer.BackColor = System.Drawing.Color.Transparent;
            this.btnEffacer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEffacer.FlatAppearance.BorderSize = 0;
            this.btnEffacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEffacer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEffacer.ForeColor = System.Drawing.Color.FromArgb(100, 110, 150);
            this.btnEffacer.Location = new System.Drawing.Point(0, 192);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(429, 30);
            this.btnEffacer.Text = "↺  Réinitialiser";
            this.btnEffacer.UseVisualStyleBackColor = false;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);

            // ── pnlGrid ──────────────────────────────────────────────────────
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.pnlGrid.Controls.Add(this.DgSyllabus);
            this.pnlGrid.Controls.Add(this.lblCount);
            this.pnlGrid.Controls.Add(this.lblGridTitle);
            this.pnlGrid.Location = new System.Drawing.Point(540, 86);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1310, 720);
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);

            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblGridTitle.Location = new System.Drawing.Point(20, 20);
            this.lblGridTitle.Text = "✦  Liste des Syllabus";

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 110, 150);
            this.lblCount.Location = new System.Drawing.Point(530, 23);
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "0 entrée(s)";

            this.DgSyllabus.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(26, 30, 48);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(200, 210, 235);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(40, 80, 140);
            this.DgSyllabus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgSyllabus.BackgroundColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.DgSyllabus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgSyllabus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgSyllabus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.DgSyllabus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgSyllabus.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(200, 210, 235);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(40, 80, 140);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.DgSyllabus.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgSyllabus.EnableHeadersVisualStyles = false;
            this.DgSyllabus.GridColor = System.Drawing.Color.FromArgb(35, 42, 65);
            this.DgSyllabus.Location = new System.Drawing.Point(20, 55);
            this.DgSyllabus.MultiSelect = false;
            this.DgSyllabus.Name = "DgSyllabus";
            this.DgSyllabus.ReadOnly = true;
            this.DgSyllabus.RowHeadersVisible = false;
            this.DgSyllabus.RowTemplate.Height = 40;
            this.DgSyllabus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgSyllabus.Size = new System.Drawing.Size(1260, 640);

            // ── Form ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 17, 26);
            this.ClientSize = new System.Drawing.Size(1875, 880);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Name = "frmSyllabus";
            this.Text = "Syllabus";
            this.Load += new System.EventHandler(this.frmSyllabus_Load);

            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgSyllabus)).EndInit();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblVolumeHoraire;
        private System.Windows.Forms.TextBox txtVolumeHoraire;
        private System.Windows.Forms.Label lblMatiere;
        private System.Windows.Forms.ComboBox cmbMatiere;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.ComboBox cmbClasse;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView DgSyllabus;
    }
}