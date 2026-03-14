namespace AppGestionCahierTexte
{
    partial class frmMDI
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblSep1 = new System.Windows.Forms.Label();
            this.btnMatiere = new System.Windows.Forms.Button();
            this.btnClasse = new System.Windows.Forms.Button();
            this.btnAnneeAcademique = new System.Windows.Forms.Button();
            this.btnSyllabus = new System.Windows.Forms.Button();
            this.btnDetailSyllabus = new System.Windows.Forms.Button();
            this.lblSep2 = new System.Windows.Forms.Label();
            this.btnCahierTexte = new System.Windows.Forms.Button();
            this.lblSep3 = new System.Windows.Forms.Label();
            this.btnProfesseur = new System.Windows.Forms.Button();
            this.btnResponsableClasse = new System.Windows.Forms.Button();
            this.lblSep4 = new System.Windows.Forms.Label();
            this.btnDeconnecter = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblUserIcon = new System.Windows.Forms.Label();
            this.lblUserProfil = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.pnlSidebar.Controls.Add(this.lblAppTitle);
            this.pnlSidebar.Controls.Add(this.btnDetailSyllabus);
            this.pnlSidebar.Controls.Add(this.btnCahierTexte);
            this.pnlSidebar.Controls.Add(this.btnSyllabus);
            this.pnlSidebar.Controls.Add(this.lblSep1);
            this.pnlSidebar.Controls.Add(this.btnMatiere);
            this.pnlSidebar.Controls.Add(this.btnClasse);
            this.pnlSidebar.Controls.Add(this.btnAnneeAcademique);
            this.pnlSidebar.Controls.Add(this.lblSep2);
            this.pnlSidebar.Controls.Add(this.lblSep3);
            this.pnlSidebar.Controls.Add(this.btnProfesseur);
            this.pnlSidebar.Controls.Add(this.btnResponsableClasse);
            this.pnlSidebar.Controls.Add(this.lblSep4);
            this.pnlSidebar.Controls.Add(this.btnDeconnecter);
            this.pnlSidebar.Controls.Add(this.btnQuitter);
            this.pnlSidebar.Controls.Add(this.pnlUser);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(1920, 111);
            this.pnlSidebar.TabIndex = 1;
            this.pnlSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSidebar_Paint);
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblAppTitle.Location = new System.Drawing.Point(0, 1);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(160, 95);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "  📓 CahierTexte";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSep1
            // 
            this.lblSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.lblSep1.Location = new System.Drawing.Point(164, 10);
            this.lblSep1.Name = "lblSep1";
            this.lblSep1.Size = new System.Drawing.Size(1, 36);
            this.lblSep1.TabIndex = 2;
            // 
            // btnMatiere
            // 
            this.btnMatiere.BackColor = System.Drawing.Color.Transparent;
            this.btnMatiere.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMatiere.FlatAppearance.BorderSize = 0;
            this.btnMatiere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatiere.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMatiere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnMatiere.Location = new System.Drawing.Point(593, 16);
            this.btnMatiere.Name = "btnMatiere";
            this.btnMatiere.Size = new System.Drawing.Size(90, 64);
            this.btnMatiere.TabIndex = 4;
            this.btnMatiere.Text = "📚 Matière";
            this.btnMatiere.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatiere.UseVisualStyleBackColor = false;
            this.btnMatiere.Click += new System.EventHandler(this.btnMatiere_Click);
            // 
            // btnClasse
            // 
            this.btnClasse.BackColor = System.Drawing.Color.Transparent;
            this.btnClasse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClasse.FlatAppearance.BorderSize = 0;
            this.btnClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClasse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnClasse.Location = new System.Drawing.Point(727, 18);
            this.btnClasse.Name = "btnClasse";
            this.btnClasse.Size = new System.Drawing.Size(80, 61);
            this.btnClasse.TabIndex = 5;
            this.btnClasse.Text = "🏫 Classe";
            this.btnClasse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClasse.UseVisualStyleBackColor = false;
            this.btnClasse.Click += new System.EventHandler(this.btnClasse_Click);
            // 
            // btnAnneeAcademique
            // 
            this.btnAnneeAcademique.BackColor = System.Drawing.Color.Transparent;
            this.btnAnneeAcademique.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnneeAcademique.FlatAppearance.BorderSize = 0;
            this.btnAnneeAcademique.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnneeAcademique.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnneeAcademique.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnAnneeAcademique.Location = new System.Drawing.Point(843, 18);
            this.btnAnneeAcademique.Name = "btnAnneeAcademique";
            this.btnAnneeAcademique.Size = new System.Drawing.Size(138, 61);
            this.btnAnneeAcademique.TabIndex = 6;
            this.btnAnneeAcademique.Text = "📅 Année Académique";
            this.btnAnneeAcademique.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnneeAcademique.UseVisualStyleBackColor = false;
            this.btnAnneeAcademique.Click += new System.EventHandler(this.btnAnneeAcademique_Click);
            // 
            // btnSyllabus
            // 
            this.btnSyllabus.BackColor = System.Drawing.Color.Transparent;
            this.btnSyllabus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSyllabus.FlatAppearance.BorderSize = 0;
            this.btnSyllabus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyllabus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSyllabus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnSyllabus.Location = new System.Drawing.Point(166, 16);
            this.btnSyllabus.Name = "btnSyllabus";
            this.btnSyllabus.Size = new System.Drawing.Size(90, 64);
            this.btnSyllabus.TabIndex = 7;
            this.btnSyllabus.Text = "📋 Syllabus";
            this.btnSyllabus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSyllabus.UseVisualStyleBackColor = false;
            this.btnSyllabus.Click += new System.EventHandler(this.btnSyllabus_Click);
            // 
            // btnDetailSyllabus
            // 
            this.btnDetailSyllabus.BackColor = System.Drawing.Color.Transparent;
            this.btnDetailSyllabus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetailSyllabus.FlatAppearance.BorderSize = 0;
            this.btnDetailSyllabus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailSyllabus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetailSyllabus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnDetailSyllabus.Location = new System.Drawing.Point(301, 14);
            this.btnDetailSyllabus.Name = "btnDetailSyllabus";
            this.btnDetailSyllabus.Size = new System.Drawing.Size(110, 69);
            this.btnDetailSyllabus.TabIndex = 8;
            this.btnDetailSyllabus.Text = "📄 Détail Syllabus";
            this.btnDetailSyllabus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailSyllabus.UseVisualStyleBackColor = false;
            this.btnDetailSyllabus.Click += new System.EventHandler(this.btnDetailSyllabus_Click);
            // 
            // lblSep2
            // 
            this.lblSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.lblSep2.Location = new System.Drawing.Point(708, 30);
            this.lblSep2.Name = "lblSep2";
            this.lblSep2.Size = new System.Drawing.Size(1, 36);
            this.lblSep2.TabIndex = 9;
            // 
            // btnCahierTexte
            // 
            this.btnCahierTexte.BackColor = System.Drawing.Color.Transparent;
            this.btnCahierTexte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCahierTexte.FlatAppearance.BorderSize = 0;
            this.btnCahierTexte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCahierTexte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCahierTexte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnCahierTexte.Location = new System.Drawing.Point(438, 10);
            this.btnCahierTexte.Name = "btnCahierTexte";
            this.btnCahierTexte.Size = new System.Drawing.Size(130, 77);
            this.btnCahierTexte.TabIndex = 11;
            this.btnCahierTexte.Text = "📖 Cahier de Texte";
            this.btnCahierTexte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCahierTexte.UseVisualStyleBackColor = false;
            this.btnCahierTexte.Click += new System.EventHandler(this.btnCahierTexte_Click);
            // 
            // lblSep3
            // 
            this.lblSep3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.lblSep3.Location = new System.Drawing.Point(852, 30);
            this.lblSep3.Name = "lblSep3";
            this.lblSep3.Size = new System.Drawing.Size(1, 36);
            this.lblSep3.TabIndex = 12;
            // 
            // btnProfesseur
            // 
            this.btnProfesseur.BackColor = System.Drawing.Color.Transparent;
            this.btnProfesseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfesseur.FlatAppearance.BorderSize = 0;
            this.btnProfesseur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfesseur.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnProfesseur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnProfesseur.Location = new System.Drawing.Point(1000, 16);
            this.btnProfesseur.Name = "btnProfesseur";
            this.btnProfesseur.Size = new System.Drawing.Size(100, 64);
            this.btnProfesseur.TabIndex = 14;
            this.btnProfesseur.Text = "🎓 Professeur";
            this.btnProfesseur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfesseur.UseVisualStyleBackColor = false;
            this.btnProfesseur.Click += new System.EventHandler(this.btnProfesseur_Click);
            // 
            // btnResponsableClasse
            // 
            this.btnResponsableClasse.BackColor = System.Drawing.Color.Transparent;
            this.btnResponsableClasse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResponsableClasse.FlatAppearance.BorderSize = 0;
            this.btnResponsableClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResponsableClasse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnResponsableClasse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.btnResponsableClasse.Location = new System.Drawing.Point(1123, 18);
            this.btnResponsableClasse.Name = "btnResponsableClasse";
            this.btnResponsableClasse.Size = new System.Drawing.Size(148, 61);
            this.btnResponsableClasse.TabIndex = 16;
            this.btnResponsableClasse.Text = "👤 Responsable Classe";
            this.btnResponsableClasse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResponsableClasse.UseVisualStyleBackColor = false;
            this.btnResponsableClasse.Click += new System.EventHandler(this.btnResponsableClasse_Click);
            // 
            // lblSep4
            // 
            this.lblSep4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.lblSep4.Location = new System.Drawing.Point(1158, 30);
            this.lblSep4.Name = "lblSep4";
            this.lblSep4.Size = new System.Drawing.Size(1, 36);
            this.lblSep4.TabIndex = 17;
            // 
            // btnDeconnecter
            // 
            this.btnDeconnecter.BackColor = System.Drawing.Color.Transparent;
            this.btnDeconnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeconnecter.FlatAppearance.BorderSize = 0;
            this.btnDeconnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconnecter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeconnecter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(50)))));
            this.btnDeconnecter.Location = new System.Drawing.Point(1292, 18);
            this.btnDeconnecter.Name = "btnDeconnecter";
            this.btnDeconnecter.Size = new System.Drawing.Size(141, 61);
            this.btnDeconnecter.TabIndex = 19;
            this.btnDeconnecter.Text = "Se déconnecté ";
            this.btnDeconnecter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeconnecter.UseVisualStyleBackColor = false;
            this.btnDeconnecter.Click += new System.EventHandler(this.btnDeconnecter_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuitter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnQuitter.Location = new System.Drawing.Point(1461, 25);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(108, 46);
            this.btnQuitter.TabIndex = 20;
            this.btnQuitter.Text = "✕ Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
            this.pnlUser.Controls.Add(this.lblUserIcon);
            this.pnlUser.Controls.Add(this.lblUserProfil);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUser.Location = new System.Drawing.Point(1760, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(160, 111);
            this.pnlUser.TabIndex = 21;
            // 
            // lblUserIcon
            // 
            this.lblUserIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblUserIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(179)))), ((int)(((byte)(237)))));
            this.lblUserIcon.Location = new System.Drawing.Point(8, 8);
            this.lblUserIcon.Name = "lblUserIcon";
            this.lblUserIcon.Size = new System.Drawing.Size(34, 34);
            this.lblUserIcon.TabIndex = 0;
            this.lblUserIcon.Text = "👤";
            this.lblUserIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserProfil
            // 
            this.lblUserProfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserProfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.lblUserProfil.Location = new System.Drawing.Point(46, 18);
            this.lblUserProfil.Name = "lblUserProfil";
            this.lblUserProfil.Size = new System.Drawing.Size(110, 20);
            this.lblUserProfil.TabIndex = 1;
            this.lblUserProfil.Text = "Utilisateur";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1920, 1050);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSidebar);
            this.IsMdiContainer = true;
            this.Name = "frmMDI";
            this.Text = "Gestion Cahier de Texte";
            this.Load += new System.EventHandler(this.frmMDI_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblSep1;
        private System.Windows.Forms.Label lblSep2;
        private System.Windows.Forms.Label lblSep3;
        private System.Windows.Forms.Label lblSep4;
        private System.Windows.Forms.Button btnMatiere;
        private System.Windows.Forms.Button btnClasse;
        private System.Windows.Forms.Button btnAnneeAcademique;
        private System.Windows.Forms.Button btnSyllabus;
        private System.Windows.Forms.Button btnDetailSyllabus;
        private System.Windows.Forms.Button btnCahierTexte;
        private System.Windows.Forms.Button btnProfesseur;
        private System.Windows.Forms.Button btnResponsableClasse;
        private System.Windows.Forms.Button btnDeconnecter;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblUserIcon;
        private System.Windows.Forms.Label lblUserProfil;
    }
}