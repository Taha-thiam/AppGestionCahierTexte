using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AppGestionCahierTexte.Views.Parametre;
using Microsoft.VisualBasic.Devices;

namespace AppGestionCahierTexte
{
    public partial class frmMDI : Form
    {
        // ── Propriétés publiques transmises depuis frmConnexion ───────────────
        public string profil;
        public int idUtilisateur;
        public string nomUtilisateur;

        public frmMDI()
        {
            InitializeComponent();
        }

        // ── Fermer tous les enfants MDI ───────────────────────────────────────
        private void Fermer()
        {
            foreach (Form child in this.MdiChildren)
                child.Close();
        }

        // ── Ouvrir un formulaire enfant sans bordure ──────────────────────────
        private void OuvrirForme(Form f)
        {
            f.MdiParent = this;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        // ── Highlight bouton actif ────────────────────────────────────────────
        private Button _activeBtn = null;

        private void SetActive(Button btn)
        {
            if (_activeBtn != null)
            {
                _activeBtn.BackColor = Color.Transparent;
                _activeBtn.ForeColor = Color.FromArgb(160, 170, 200);
            }
            _activeBtn = btn;
            if (_activeBtn != null)
            {
                _activeBtn.BackColor = Color.FromArgb(30, 60, 110);
                _activeBtn.ForeColor = Color.White;
            }
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmMDI_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);

            lblUserProfil.Text = string.IsNullOrEmpty(nomUtilisateur)
                ? profil
                : $"{nomUtilisateur}  ({profil})";

            AppliquerDroits();
        }

        // ── Droits par rôle ───────────────────────────────────────────────────
        private void AppliquerDroits()
        {
            switch (profil)
            {
                case "Admin":
                    // Tout visible — rien à masquer
                    break;

                case "Professeur":
                    btnMatiere.Visible = false;
                    btnClasse.Visible = false;
                    btnAnneeAcademique.Visible = false;
                    btnResponsableClasse.Visible = false;
                    btnProfesseur.Visible = false;
                    btnCahierTexte.Visible = false;
                    // ✅ btnSyllabus + btnDetailSyllabus restent visibles
                    break;

                case "ResponsableClasse":
                    btnMatiere.Visible = false;
                    btnClasse.Visible = false;
                    btnAnneeAcademique.Visible = false;
                    btnResponsableClasse.Visible = false;
                    btnProfesseur.Visible = false;
                    // ✅ btnSyllabus + btnDetailSyllabus + btnCahierTexte visibles
                    break;

                default:
                    // Profil inconnu → tout masquer par sécurité
                    btnMatiere.Visible = false;
                    btnClasse.Visible = false;
                    btnAnneeAcademique.Visible = false;
                    btnSyllabus.Visible = false;
                    btnDetailSyllabus.Visible = false;
                    btnCahierTexte.Visible = false;
                    btnResponsableClasse.Visible = false;
                    btnProfesseur.Visible = false;
                    break;
            }
        }

        // ── Navigation ────────────────────────────────────────────────────────
        private void btnMatiere_Click(object sender, EventArgs e)
        {
            SetActive(btnMatiere); Fermer();
            OuvrirForme(new frmMatiere());
        }

        private void btnClasse_Click(object sender, EventArgs e)
        {
            SetActive(btnClasse); Fermer();
            OuvrirForme(new frmClasse());
        }

        private void btnAnneeAcademique_Click(object sender, EventArgs e)
        {
            SetActive(btnAnneeAcademique); Fermer();
            OuvrirForme(new frmAnneeAcademique());
        }

        private void btnSyllabus_Click(object sender, EventArgs e)
        {
            SetActive(btnSyllabus); Fermer();
            OuvrirForme(new frmSyllabus
            {
                Profil = this.profil,
                IdUtilisateur = this.idUtilisateur
            });
        }

        private void btnDetailSyllabus_Click(object sender, EventArgs e)
        {

            SetActive(btnDetailSyllabus); Fermer();
            OuvrirForme(new frmDetailSyllabus
            {

                Profil = this.profil,
                IdUtilisateur = this.idUtilisateur
            });
        }

        private void btnCahierTexte_Click(object sender, EventArgs e)
        {
            SetActive(btnCahierTexte); Fermer();
            OuvrirForme(new frmCahierTexte
            {
                Profil = this.profil,
                IdUtilisateur = this.idUtilisateur
            });
        }

        private void btnResponsableClasse_Click(object sender, EventArgs e)
        {
            SetActive(btnResponsableClasse); Fermer();
            OuvrirForme(new frmResponsableClasse());
        }

        private void btnProfesseur_Click(object sender, EventArgs e)
        {
            SetActive(btnProfesseur); Fermer();
            OuvrirForme(new frmProfesseur());
        }

        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            new frmConnexion().Show();
            this.Close();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ── Paint sidebar ─────────────────────────────────────────────────────
        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new LinearGradientBrush(
                new Point(0, pnlSidebar.Height - 3),
                new Point(pnlSidebar.Width, pnlSidebar.Height - 3),
                Color.FromArgb(56, 139, 253),
                Color.FromArgb(99, 60, 220)))
            {
                e.Graphics.FillRectangle(brush, 0, pnlSidebar.Height - 3, pnlSidebar.Width, 3);
            }
        }
    }
}
