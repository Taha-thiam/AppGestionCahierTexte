namespace AppGestionCahierTexte.Views.Parametre
{
    partial class frmDetailSyllabus
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
            this.DgDetailSyllabus = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblSeance = new System.Windows.Forms.Label();
            this.txtSeance = new System.Windows.Forms.TextBox();
            this.lblContenue = new System.Windows.Forms.Label();
            this.txtContenue = new System.Windows.Forms.TextBox();
            this.lblDuree = new System.Windows.Forms.Label();
            this.txtDuree = new System.Windows.Forms.TextBox();
            this.lblSyllabus = new System.Windows.Forms.Label();
            this.cmbSyllabus = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.DgDetailSyllabus)).BeginInit();
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
            this.pnlMain.Size = new System.Drawing.Size(1919, 990);

            // ── pnlHeader ────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(20, 23, 35);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(1919, 80);
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(230, 230, 255);
            this.lblTitle.Location = new System.Drawing.Point(32, 14);
            this.lblTitle.Text = "📄  Détails Syllabus";

            // ── pnlCard ──────────────────────────────────────────────────────
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.pnlCard.Controls.Add(this.lblCardTitle);
            this.pnlCard.Controls.Add(this.lblSeance);
            this.pnlCard.Controls.Add(this.txtSeance);
            this.pnlCard.Controls.Add(this.lblContenue);
            this.pnlCard.Controls.Add(this.txtContenue);
            this.pnlCard.Controls.Add(this.lblDuree);
            this.pnlCard.Controls.Add(this.txtDuree);
            this.pnlCard.Controls.Add(this.lblSyllabus);
            this.pnlCard.Controls.Add(this.cmbSyllabus);
            this.pnlCard.Controls.Add(this.pnlButtons);
            this.pnlCard.Location = new System.Drawing.Point(20, 90);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(558, 620);
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCard_Paint);

            this.lblCardTitle.AutoSize = true;
            this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblCardTitle.Location = new System.Drawing.Point(20, 18);
            this.lblCardTitle.Text = "✦  Saisie";

            // SÉANCE
            this.lblSeance.AutoSize = true;
            this.lblSeance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeance.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblSeance.Location = new System.Drawing.Point(30, 58);
            this.lblSeance.Text = "SÉANCE";

            this.txtSeance.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.txtSeance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSeance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSeance.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.txtSeance.Location = new System.Drawing.Point(30, 80);
            this.txtSeance.MaxLength = 20;
            this.txtSeance.Name = "txtSeance";
            this.txtSeance.Size = new System.Drawing.Size(465, 32);
            this.txtSeance.TabIndex = 0;

            // CONTENU
            this.lblContenue.AutoSize = true;
            this.lblContenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContenue.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblContenue.Location = new System.Drawing.Point(30, 138);
            this.lblContenue.Text = "CONTENU";

            this.txtContenue.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.txtContenue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContenue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContenue.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.txtContenue.Location = new System.Drawing.Point(30, 160);
            this.txtContenue.MaxLength = 500;
            this.txtContenue.Name = "txtContenue";
            this.txtContenue.Size = new System.Drawing.Size(465, 32);
            this.txtContenue.TabIndex = 1;

            // DURÉE
            this.lblDuree.AutoSize = true;
            this.lblDuree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDuree.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblDuree.Location = new System.Drawing.Point(30, 218);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Text = "DURÉE (h) — ex: 1.5";

            this.txtDuree.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.txtDuree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDuree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDuree.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.txtDuree.Location = new System.Drawing.Point(30, 240);
            this.txtDuree.MaxLength = 10;
            this.txtDuree.Name = "txtDuree";
            this.txtDuree.Size = new System.Drawing.Size(465, 32);
            this.txtDuree.TabIndex = 2;

            // SYLLABUS
            this.lblSyllabus.AutoSize = true;
            this.lblSyllabus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSyllabus.ForeColor = System.Drawing.Color.FromArgb(140, 150, 180);
            this.lblSyllabus.Location = new System.Drawing.Point(30, 298);
            this.lblSyllabus.Name = "lblSyllabus";
            this.lblSyllabus.Text = "SYLLABUS";

            this.cmbSyllabus.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.cmbSyllabus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSyllabus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSyllabus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbSyllabus.ForeColor = System.Drawing.Color.FromArgb(220, 225, 255);
            this.cmbSyllabus.Location = new System.Drawing.Point(30, 320);
            this.cmbSyllabus.Name = "cmbSyllabus";
            this.cmbSyllabus.Size = new System.Drawing.Size(465, 38);
            this.cmbSyllabus.TabIndex = 3;

            // ── pnlButtons ───────────────────────────────────────────────────
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.Controls.Add(this.btnAjouter);
            this.pnlButtons.Controls.Add(this.btnSelectionner);
            this.pnlButtons.Controls.Add(this.btnModifier);
            this.pnlButtons.Controls.Add(this.btnSupprimer);
            this.pnlButtons.Controls.Add(this.btnEffacer);
            this.pnlButtons.Location = new System.Drawing.Point(20, 376);
            this.pnlButtons.Size = new System.Drawing.Size(483, 230);

            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(56, 139, 253);
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(0, 0);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(475, 44);
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
            this.btnSelectionner.Size = new System.Drawing.Size(475, 44);
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
            this.btnModifier.Size = new System.Drawing.Size(475, 44);
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
            this.btnSupprimer.Size = new System.Drawing.Size(475, 44);
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
            this.btnEffacer.Size = new System.Drawing.Size(475, 30);
            this.btnEffacer.Text = "↺  Réinitialiser";
            this.btnEffacer.UseVisualStyleBackColor = false;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);

            // ── pnlGrid ──────────────────────────────────────────────────────
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.pnlGrid.Controls.Add(this.DgDetailSyllabus);
            this.pnlGrid.Controls.Add(this.lblCount);
            this.pnlGrid.Controls.Add(this.lblGridTitle);
            this.pnlGrid.Location = new System.Drawing.Point(600, 90);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1289, 620);
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);

            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblGridTitle.Location = new System.Drawing.Point(20, 20);
            this.lblGridTitle.Text = "✦  Liste des Détails";

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 110, 150);
            this.lblCount.Location = new System.Drawing.Point(530, 23);
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "0 entrée(s)";

            this.DgDetailSyllabus.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(26, 30, 48);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(200, 210, 235);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(40, 80, 140);
            this.DgDetailSyllabus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgDetailSyllabus.BackgroundColor = System.Drawing.Color.FromArgb(22, 26, 40);
            this.DgDetailSyllabus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgDetailSyllabus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgDetailSyllabus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(30, 35, 55);
            this.DgDetailSyllabus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgDetailSyllabus.ColumnHeadersHeight = 42;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(22, 26, 40);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(200, 210, 235);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(40, 80, 140);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.DgDetailSyllabus.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgDetailSyllabus.EnableHeadersVisualStyles = false;
            this.DgDetailSyllabus.GridColor = System.Drawing.Color.FromArgb(35, 42, 65);
            this.DgDetailSyllabus.Location = new System.Drawing.Point(20, 55);
            this.DgDetailSyllabus.MultiSelect = false;
            this.DgDetailSyllabus.Name = "DgDetailSyllabus";
            this.DgDetailSyllabus.ReadOnly = true;
            this.DgDetailSyllabus.RowHeadersVisible = false;
            this.DgDetailSyllabus.RowTemplate.Height = 40;
            this.DgDetailSyllabus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgDetailSyllabus.Size = new System.Drawing.Size(1240, 540);

            // ── Form ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 17, 26);
            this.ClientSize = new System.Drawing.Size(1919, 990);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Name = "frmDetailSyllabus";
            this.Text = "Détails Syllabus";
            this.Load += new System.EventHandler(this.frmDetailSyllabus_Load);

            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgDetailSyllabus)).EndInit();
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
        private System.Windows.Forms.Label lblSeance;
        private System.Windows.Forms.TextBox txtSeance;
        private System.Windows.Forms.Label lblContenue;
        private System.Windows.Forms.TextBox txtContenue;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.TextBox txtDuree;
        private System.Windows.Forms.Label lblSyllabus;
        private System.Windows.Forms.ComboBox cmbSyllabus;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSelectionner;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView DgDetailSyllabus;
    }
}