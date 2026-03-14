using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AppGestionCahierTexte
{
    public partial class frmConnexion : Form
    {
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmConnexion()
        {
            InitializeComponent();
            StyleUnderline(textIdentifiant, pnlForm);
            StyleUnderline(textMotDePasse, pnlForm);
        }

        // ── Underline animé ───────────────────────────────────────────────────
        private void StyleUnderline(TextBox txt, Panel parent)
        {
            var line = new Panel
            {
                BackColor = C_BORDER,
                Height = 2,
                Width = txt.Width,
                Location = new Point(txt.Left, txt.Bottom + 4),
            };
            parent.Controls.Add(line);
            txt.Enter += (s, e) => line.BackColor = C_ACCENT;
            txt.Leave += (s, e) => line.BackColor = C_BORDER;
        }

        // ── Paint ─────────────────────────────────────────────────────────────
        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var p = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            using (var path = RoundedRect(rect, 16))
            using (var brush = new SolidBrush(Color.FromArgb(22, 26, 40)))
                g.FillPath(brush, path);
            using (var path = RoundedRect(rect, 16))
            using (var pen = new Pen(Color.FromArgb(35, 42, 65), 1))
                g.DrawPath(pen, path);
        }

        private void frmConnexion_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                new Point(0, 0), new Point(ClientSize.Width, 0),
                Color.FromArgb(56, 139, 253), Color.FromArgb(99, 60, 220)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, ClientSize.Width, 5);
            }
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

        // ── Connexion ─────────────────────────────────────────────────────────
        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textIdentifiant.Text))
            {
                ShowError("Veuillez saisir votre identifiant.");
                textIdentifiant.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textMotDePasse.Text))
            {
                ShowError("Veuillez saisir votre mot de passe.");
                textMotDePasse.Focus();
                return;
            }

            try
            {
                BdCahierTexteContext db = new BdCahierTexteContext();

                var leUser = db.Utilisateurs
                               .Where(u => u.Identifiant == textIdentifiant.Text.Trim())
                               .FirstOrDefault();

                if (leUser == null)
                {
                    ShowError("Identifiant ou mot de passe incorrect.");
                    return;
                }

                using (MD5 md5Hash = MD5.Create())
                {
                    bool isValid = Crypto.VerifyMd5Hash(md5Hash, textMotDePasse.Text, leUser.MotDePasse);
                    if (!isValid)
                    {
                        ShowError("Identifiant ou mot de passe incorrect.");
                        return;
                    }

                    // ── Détermination du profil ───────────────────────────────
                    string profil = "";

                    if (db.ChefDepartements.Any(c => c.IdUtilisateur == leUser.IdUtilisateur))
                        profil = "Admin";
                    else if (db.ResponsableClasses.Any(r => r.IdUtilisateur == leUser.IdUtilisateur))
                        profil = "ResponsableClasse";
                    else if (db.Professeurs.Any(p => p.IdUtilisateur == leUser.IdUtilisateur))
                        profil = "Professeur";

                    // ── Ouverture MDI ─────────────────────────────────────────
                    frmMDI f = new frmMDI();
                    f.profil = profil;
                    f.idUtilisateur = leUser.IdUtilisateur;
                    f.nomUtilisateur = leUser.PrenomUtilisateur + " " + leUser.NomUtilisateur;
                    f.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Erreur de connexion : {ex.Message}");
            }
        }

        // ── Quitter ───────────────────────────────────────────────────────────
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmConnexion_Load(object sender, EventArgs e)
        {
            Logger.WriteLogSystem("Lancement de l'application", "Info");
            textIdentifiant.Focus();
        }

        // ── Touche Entrée ─────────────────────────────────────────────────────
        private void textMotDePasse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSeConnecter_Click(sender, e);
        }

        private void textIdentifiant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textMotDePasse.Focus();
        }

        // ── Afficher/masquer mot de passe ─────────────────────────────────────
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            textMotDePasse.UseSystemPasswordChar = !textMotDePasse.UseSystemPasswordChar;
            btnTogglePassword.Text = textMotDePasse.UseSystemPasswordChar ? "👁" : "🙈";
        }

        // ── Message d'erreur inline ───────────────────────────────────────────
        private void ShowError(string message)
        {
            lblErreur.Text = "⚠  " + message;
            lblErreur.Visible = true;
            var t = new Timer { Interval = 4000 };
            t.Tick += (s, ev) => { t.Stop(); lblErreur.Visible = false; };
            t.Start();
        }
    }
}