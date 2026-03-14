using AppGestionCahierTexte.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmCahierTexte : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedId = null;

        public string Profil { get; set; }
        public int IdUtilisateur { get; set; }

        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmCahierTexte()
        {
            InitializeComponent();
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmCahierTexte_Load(object sender, EventArgs e)
        {
            StyleUnderline(txtTitre, pnlCard);
            StyleUnderline(txtDescription, pnlCard);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
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

        // ── Charger ComboBox Classes — toutes les classes ─────────────────────
        private void ChargerClasses()
        {
            var liste = new List<object>();
            liste.Add(new { IdClasse = 0, LibelleClasse = "— Sélectionner —" });
            liste.AddRange(db.Classes
                .Select(c => new { c.IdClasse, c.LibelleClasse })
                .ToList<object>());

            cbbClasse.DataSource = liste;
            cbbClasse.DisplayMember = "LibelleClasse";
            cbbClasse.ValueMember = "IdClasse";
            cbbClasse.SelectedIndex = 0;
        }

        // ── Charger Grille — tous les profils voient tout ─────────────────────
        private void ChargerGrille()
        {
            db = new BdCahierTexteContext();

            var liste = db.CahierTextes
                .Include(c => c.Classe)
                .Select(c => new
                {
                    c.IdCahierTexte,
                    c.TitreCahierTexte,
                    c.DescriptionCahierTexte,
                    Classe = c.Classe != null ? c.Classe.LibelleClasse : "—",
                    c.DateCreation
                }).ToList();

            DgCahierTexte.DataSource = liste;
            lblCount.Text = liste.Count + " entrée(s)";
        }

        // ── Effacer ───────────────────────────────────────────────────────────
        private void Effacer()
        {
            txtTitre.Text = string.Empty;
            txtDescription.Text = string.Empty;
            _selectedId = null;

            db = new BdCahierTexteContext();

            ChargerClasses();
            ChargerGrille();

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.BackColor = C_ACCENT;

            txtTitre.Focus();
        }

        // ── Validation ────────────────────────────────────────────────────────
        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtTitre.Text))
            {
                ShowToast("Le titre est obligatoire.", Color.FromArgb(220, 80, 80));
                txtTitre.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                ShowToast("La description est obligatoire.", Color.FromArgb(220, 80, 80));
                txtDescription.Focus();
                return false;
            }
            if (cbbClasse.SelectedValue == null ||
                int.Parse(cbbClasse.SelectedValue.ToString()) == 0)
            {
                ShowToast("Veuillez sélectionner une classe.", Color.FromArgb(220, 80, 80));
                cbbClasse.Focus();
                return false;
            }
            return true;
        }

        // ── Ajouter ───────────────────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Valider()) return;

                var cahier = new CahierTexte
                {
                    TitreCahierTexte = txtTitre.Text.Trim(),
                    DescriptionCahierTexte = txtDescription.Text.Trim(),
                    IdClasse = int.Parse(cbbClasse.SelectedValue.ToString()),
                    DateCreation = DateTime.Now
                };

                db.CahierTextes.Add(cahier);
                db.SaveChanges();
                Effacer();
                ShowToast("Cahier ajouté avec succès ✓", C_ACCENT);
            }
            catch (Exception ex)
            {
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Sélectionner ──────────────────────────────────────────────────────
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgCahierTexte.SelectedRows.Count == 0)
                {
                    ShowToast("Veuillez sélectionner une ligne.", Color.FromArgb(255, 170, 50));
                    return;
                }

                _selectedId = Convert.ToInt32(
                    DgCahierTexte.SelectedRows[0].Cells["IdCahierTexte"].Value);

                var c = db.CahierTextes.Find(_selectedId);
                if (c == null) return;

                txtTitre.Text = c.TitreCahierTexte;
                txtDescription.Text = c.DescriptionCahierTexte;
                cbbClasse.SelectedValue = c.IdClasse;

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAjouter.Enabled = false;
                btnAjouter.BackColor = Color.FromArgb(30, 35, 55);
            }
            catch (Exception ex)
            {
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Modifier ──────────────────────────────────────────────────────────
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedId == null || !Valider()) return;

                var c = db.CahierTextes.Find(_selectedId);
                if (c == null) return;

                c.TitreCahierTexte = txtTitre.Text.Trim();
                c.DescriptionCahierTexte = txtDescription.Text.Trim();
                c.IdClasse = int.Parse(cbbClasse.SelectedValue.ToString());

                db.SaveChanges();
                Effacer();
                ShowToast("Cahier modifié avec succès ✓", Color.FromArgb(255, 170, 50));
            }
            catch (Exception ex)
            {
                ShowToast("Erreur : " + ex.Message, Color.FromArgb(220, 80, 80));
            }
        }

        // ── Supprimer ─────────────────────────────────────────────────────────
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedId == null) return;

                if (MessageBox.Show(
                    "Supprimer ce cahier de texte ?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes) return;

                var c = db.CahierTextes.Find(_selectedId);
                if (c == null) return;

                db.CahierTextes.Remove(c);
                db.SaveChanges();
                Effacer();
                ShowToast("Cahier supprimé.", Color.FromArgb(220, 80, 80));
            }
            catch (Exception ex)
            {
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
                Size = new Size(440, 44),
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