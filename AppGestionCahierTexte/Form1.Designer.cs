namespace AppGestionCahierTexte
{
    partial class frmConnexion
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppSub = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.textIdentifiant = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.textMotDePasse = new System.Windows.Forms.TextBox();
            this.btnTogglePassword = new System.Windows.Forms.Button();
            this.lblErreur = new System.Windows.Forms.Label();
            this.btnSeConnecter = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(40)))));
            this.pnlForm.Controls.Add(this.lblAppName);
            this.pnlForm.Controls.Add(this.lblAppSub);
            this.pnlForm.Controls.Add(this.lblSeparator);
            this.pnlForm.Controls.Add(this.lblIdentifiant);
            this.pnlForm.Controls.Add(this.textIdentifiant);
            this.pnlForm.Controls.Add(this.lblMotDePasse);
            this.pnlForm.Controls.Add(this.textMotDePasse);
            this.pnlForm.Controls.Add(this.btnTogglePassword);
            this.pnlForm.Controls.Add(this.lblErreur);
            this.pnlForm.Controls.Add(this.btnSeConnecter);
            this.pnlForm.Controls.Add(this.btnQuitter);
            this.pnlForm.Location = new System.Drawing.Point(100, 12);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(693, 638);
            this.pnlForm.TabIndex = 0;
            this.pnlForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlForm_Paint);
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblAppName.Location = new System.Drawing.Point(89, 32);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(497, 67);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "📓  CahierTexte";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppSub
            // 
            this.lblAppSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAppSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.lblAppSub.Location = new System.Drawing.Point(89, 99);
            this.lblAppSub.Name = "lblAppSub";
            this.lblAppSub.Size = new System.Drawing.Size(497, 22);
            this.lblAppSub.TabIndex = 1;
            this.lblAppSub.Text = "Système de gestion du cahier de texte";
            this.lblAppSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeparator
            // 
            this.lblSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(42)))), ((int)(((byte)(65)))));
            this.lblSeparator.Location = new System.Drawing.Point(169, 136);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(360, 1);
            this.lblSeparator.TabIndex = 2;
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIdentifiant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.lblIdentifiant.Location = new System.Drawing.Point(164, 158);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(125, 25);
            this.lblIdentifiant.TabIndex = 3;
            this.lblIdentifiant.Text = "IDENTIFIANT";
            // 
            // textIdentifiant
            // 
            this.textIdentifiant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.textIdentifiant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textIdentifiant.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textIdentifiant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textIdentifiant.Location = new System.Drawing.Point(164, 203);
            this.textIdentifiant.Name = "textIdentifiant";
            this.textIdentifiant.Size = new System.Drawing.Size(365, 35);
            this.textIdentifiant.TabIndex = 0;
            this.textIdentifiant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textIdentifiant_KeyDown);
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMotDePasse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.lblMotDePasse.Location = new System.Drawing.Point(164, 272);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(139, 25);
            this.lblMotDePasse.TabIndex = 4;
            this.lblMotDePasse.Text = "MOT DE PASSE";
            // 
            // textMotDePasse
            // 
            this.textMotDePasse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(55)))));
            this.textMotDePasse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textMotDePasse.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textMotDePasse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textMotDePasse.Location = new System.Drawing.Point(163, 308);
            this.textMotDePasse.Name = "textMotDePasse";
            this.textMotDePasse.Size = new System.Drawing.Size(320, 35);
            this.textMotDePasse.TabIndex = 1;
            this.textMotDePasse.UseSystemPasswordChar = true;
            this.textMotDePasse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textMotDePasse_KeyDown);
            // 
            // btnTogglePassword
            // 
            this.btnTogglePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnTogglePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTogglePassword.FlatAppearance.BorderSize = 0;
            this.btnTogglePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTogglePassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTogglePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.btnTogglePassword.Location = new System.Drawing.Point(489, 307);
            this.btnTogglePassword.Name = "btnTogglePassword";
            this.btnTogglePassword.Size = new System.Drawing.Size(36, 36);
            this.btnTogglePassword.TabIndex = 5;
            this.btnTogglePassword.TabStop = false;
            this.btnTogglePassword.Text = "👁";
            this.btnTogglePassword.UseVisualStyleBackColor = false;
            this.btnTogglePassword.Click += new System.EventHandler(this.btnTogglePassword_Click);
            // 
            // lblErreur
            // 
            this.lblErreur.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblErreur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblErreur.Location = new System.Drawing.Point(164, 346);
            this.lblErreur.Name = "lblErreur";
            this.lblErreur.Size = new System.Drawing.Size(360, 22);
            this.lblErreur.TabIndex = 6;
            this.lblErreur.Visible = false;
            // 
            // btnSeConnecter
            // 
            this.btnSeConnecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(139)))), ((int)(((byte)(253)))));
            this.btnSeConnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeConnecter.FlatAppearance.BorderSize = 0;
            this.btnSeConnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeConnecter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSeConnecter.ForeColor = System.Drawing.Color.White;
            this.btnSeConnecter.Location = new System.Drawing.Point(169, 414);
            this.btnSeConnecter.Name = "btnSeConnecter";
            this.btnSeConnecter.Size = new System.Drawing.Size(360, 48);
            this.btnSeConnecter.TabIndex = 2;
            this.btnSeConnecter.Text = "Se connecter  →";
            this.btnSeConnecter.UseVisualStyleBackColor = false;
            this.btnSeConnecter.Click += new System.EventHandler(this.btnSeConnecter_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnQuitter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(150)))));
            this.btnQuitter.Location = new System.Drawing.Point(169, 479);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(360, 34);
            this.btnQuitter.TabIndex = 3;
            this.btnQuitter.Text = "Quitter l\'application";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // frmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(900, 706);
            this.ControlBox = false;
            this.Controls.Add(this.pnlForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Cahier de Texte";
            this.Load += new System.EventHandler(this.frmConnexion_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmConnexion_Paint);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppSub;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.TextBox textIdentifiant;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.TextBox textMotDePasse;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Label lblErreur;
        private System.Windows.Forms.Button btnSeConnecter;
        private System.Windows.Forms.Button btnQuitter;
    }
}