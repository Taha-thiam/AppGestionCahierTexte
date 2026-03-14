using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmProfesseur : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedId = null;

        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmProfesseur()
        {
            InitializeComponent();
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmProfesseur_Load(object sender, EventArgs e)
        {
            StyleUnderline(txtNom, pnlCard);
            StyleUnderline(txtPrenom, pnlCard);
            StyleUnderline(txtEmail, pnlCard);
            StyleUnderline(txtTelephone, pnlCard);
            StyleUnderline(txtAdresse, pnlCard);
            StyleUnderline(txtIdentifiant, pnlCard);
            StyleUnderline(txtMatricule, pnlCard);
            StyleUnderline(txtSpecialite, pnlCard);
            Effacer();
        }

        // ── Underline animé ───────────────────────────────────────────────────
        private void StyleUnderline(TextBox txt, Panel parent)
        {
            var line = new Panel
            {
                BackColor = C_BORDER,
                Height = 2,
                Width = txt.Width,
                Location = new Point(txt.Left, txt.Bottom + 4)
            };
            parent.Controls.Add(line);
            txt.Enter += (s, ev) => line.BackColor = C_ACCENT;
            txt.Leave += (s, ev) => line.BackColor = C_BORDER;
        }

        // ── Paint ─────────────────────────────────────────────────────────────
        private void pnlCard_Paint(object sender, PaintEventArgs e) => DrawCard(e.Graphics, (Panel)sender);
        private void pnlGrid_Paint(object sender, PaintEventArgs e) => DrawCard(e.Graphics, (Panel)sender);

        private void DrawCard(Graphics g, Panel p)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            using (var path = RoundedRect(rect, 12))
            using (var brush = new SolidBrush(C_CARD))
                g.FillPath(brush, path);
            using (var path = RoundedRect(rect, 12))
            using (var pen = new Pen(C_BORDER, 1))
                g.DrawPath(pen, path);
        }

        private GraphicsPath RoundedRect(Rectangle b, int r)
        {
            int d = r * 2;
            var path = new GraphicsPath();
            path.AddArc(b.X, b.Y, d, d, 180, 90);
            path.AddArc(b.Right - d, b.Y, d, d, 270, 90);
            path.AddArc(b.Right - d, b.Bottom - d, d, d, 0, 90);
            path.AddArc(b.X, b.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                new Point(0, pnlHeader.Height - 2),
                new Point(pnlHeader.Width, pnlHeader.Height - 2),
                Color.FromArgb(56, 139, 253),
                Color.FromArgb(99, 60, 220)))
            {
                e.Graphics.FillRectangle(brush, 0, pnlHeader.Height - 3, pnlHeader.Width, 3);
            }
        }

        // ── Effacer ───────────────────────────────────────────────────────────
        private void Effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtMatricule.Text = string.Empty;
            txtSpecialite.Text = string.Empty;
            _selectedId = null;

            var liste = db.Professeurs
                .Select(p => new
                {
                    p.IdUtilisateur,
                    p.NomUtilisateur,
                    p.PrenomUtilisateur,
                    p.EmailUtilisateur,
                    p.TelephoneUtilisateur,
                    p.AdresseUtilisateur,
                    p.Identifiant,
                    p.MatriculeProfesseur,
                    p.Specialite
                })
                .ToList();

            DgProfesseur.DataSource = liste;
            lblCount.Text = liste.Count + " entrée(s)";

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.BackColor = C_ACCENT;

            txtNom.Focus();
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            { ShowToast("Le nom est obligatoire.", Color.FromArgb(220, 80, 80)); txtNom.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            { ShowToast("Le prénom est obligatoire.", Color.FromArgb(220, 80, 80)); txtPrenom.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            { ShowToast("L'email est obligatoire.", Color.FromArgb(220, 80, 80)); txtEmail.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            { ShowToast("Le téléphone est obligatoire.", Color.FromArgb(220, 80, 80)); txtTelephone.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            { ShowToast("L'identifiant est obligatoire.", Color.FromArgb(220, 80, 80)); txtIdentifiant.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtMatricule.Text))
            { ShowToast("Le matricule est obligatoire.", Color.FromArgb(220, 80, 80)); txtMatricule.Focus(); return false; }

            return true;
        }

        // ── Ajouter ───────────────────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Valider()) return;

                string pass;
                using (MD5 md5 = MD5.Create())
                    pass = Crypto.GetMd5Hash(md5, "passer123");

                var p = new Professeur
                {
                    NomUtilisateur = txtNom.Text.Trim(),
                    PrenomUtilisateur = txtPrenom.Text.Trim(),
                    EmailUtilisateur = txtEmail.Text.Trim(),
                    TelephoneUtilisateur = txtTelephone.Text.Trim(),
                    AdresseUtilisateur = txtAdresse.Text.Trim(),
                    Identifiant = txtIdentifiant.Text.Trim(),
                    MotDePasse = pass,
                    MatriculeProfesseur = txtMatricule.Text.Trim(),
                    Specialite = txtSpecialite.Text.Trim()
                };

                db.Professeurs.Add(p);
                db.SaveChanges();
                Effacer();
                ShowToast("Professeur ajouté avec succès  (mot de passe : passer123)", C_ACCENT);
            }
            catch (Exception ex)
            {
                Logger.WriteFileError("btnAjouter_Click : " + ex.Message);
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Sélectionner ──────────────────────────────────────────────────────
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgProfesseur.SelectedRows.Count == 0)
                {
                    ShowToast("Veuillez sélectionner une ligne.", Color.FromArgb(255, 170, 50));
                    return;
                }

                _selectedId = Convert.ToInt32(
                    DgProfesseur.SelectedRows[0].Cells["IdUtilisateur"].Value);

                var p = db.Professeurs.Find(_selectedId);
                if (p == null) return;

                txtNom.Text = p.NomUtilisateur;
                txtPrenom.Text = p.PrenomUtilisateur;
                txtEmail.Text = p.EmailUtilisateur;
                txtTelephone.Text = p.TelephoneUtilisateur;
                txtAdresse.Text = p.AdresseUtilisateur;
                txtIdentifiant.Text = p.Identifiant;
                txtMatricule.Text = p.MatriculeProfesseur;
                txtSpecialite.Text = p.Specialite;

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAjouter.Enabled = false;
                btnAjouter.BackColor = Color.FromArgb(30, 35, 55);
            }
            catch (Exception ex)
            {
                Logger.WriteFileError("btnSelectionner_Click : " + ex.Message);
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Modifier ──────────────────────────────────────────────────────────
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedId == null || !Valider()) return;

                var p = db.Professeurs.Find(_selectedId);
                if (p == null) return;

                p.NomUtilisateur = txtNom.Text.Trim();
                p.PrenomUtilisateur = txtPrenom.Text.Trim();
                p.EmailUtilisateur = txtEmail.Text.Trim();
                p.TelephoneUtilisateur = txtTelephone.Text.Trim();
                p.AdresseUtilisateur = txtAdresse.Text.Trim();
                p.Identifiant = txtIdentifiant.Text.Trim();
                p.MatriculeProfesseur = txtMatricule.Text.Trim();
                p.Specialite = txtSpecialite.Text.Trim();

                db.SaveChanges();
                Effacer();
                ShowToast("Professeur modifié avec succès", Color.FromArgb(255, 170, 50));
            }
            catch (Exception ex)
            {
                Logger.WriteFileError("btnModifier_Click : " + ex.Message);
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Supprimer ─────────────────────────────────────────────────────────
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedId == null) return;

                var res = MessageBox.Show(
                    "Supprimer ce professeur ?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res != DialogResult.Yes) return;

                var p = db.Professeurs.Find(_selectedId);
                if (p == null) return;

                db.Professeurs.Remove(p);
                db.SaveChanges();
                Effacer();
                ShowToast("Professeur supprimé.", Color.FromArgb(220, 80, 80));
            }
            catch (Exception ex)
            {
                Logger.WriteFileError("btnSupprimer_Click : " + ex.Message);
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Réinitialiser ─────────────────────────────────────────────────────
        private void btnEffacer_Click(object sender, EventArgs e) => Effacer();

        // ── Toast ─────────────────────────────────────────────────────────────
        private void ShowToast(string message, Color color)
        {
            var toast = new Label
            {
                Text = "  " + message,
                AutoSize = false,
                Size = new Size(500, 44),
                Location = new Point(pnlGrid.Left + 20, pnlGrid.Bottom - 60),
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(toast);
            toast.BringToFront();
            var t = new Timer { Interval = 3000 };
            t.Tick += (s, ev) => { t.Stop(); Controls.Remove(toast); toast.Dispose(); };
            t.Start();
        }
    }
}