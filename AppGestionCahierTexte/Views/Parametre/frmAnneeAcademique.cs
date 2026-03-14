using AppGestionCahierTexte.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmAnneeAcademique : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedAnneAcademiqueId = null;

        // ── Couleurs thème ────────────────────────────────────────────────────
        private readonly Color C_BG = Color.FromArgb(15, 17, 26);
        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmAnneeAcademique()
        {
            InitializeComponent();
            StyleTextBoxUnderline(txtLibelle);
            StyleTextBoxUnderline(txtAnneAcademique);
        }

        // ── Underline effect sur les TextBox ──────────────────────────────────
        private void StyleTextBoxUnderline(TextBox txt)
        {
            Panel underline = new Panel
            {
                BackColor = C_BORDER,
                Height = 2,
                Width = txt.Width,
                Location = new Point(txt.Left, txt.Bottom + 4),
                Tag = txt
            };
            txt.Parent.Controls.Add(underline);
            txt.Enter += (s, e) => underline.BackColor = C_ACCENT;
            txt.Leave += (s, e) => underline.BackColor = C_BORDER;
        }

        // ── Paint : coins arrondis + ombre simulée sur les cards ─────────────
        private void pnlCard_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawCard(e.Graphics, (Panel)sender);
        }

        private void pnlGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawCard(e.Graphics, (Panel)sender);
        }

        private void DrawCard(Graphics g, Panel p)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            int r = 12;
            using (GraphicsPath path = RoundedRect(rect, r))
            using (SolidBrush brush = new SolidBrush(C_CARD))
            {
                g.FillPath(brush, path);
            }
            using (GraphicsPath path = RoundedRect(rect, r))
            using (Pen pen = new Pen(C_BORDER, 1))
            {
                g.DrawPath(pen, path);
            }
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ── Header accent bar ─────────────────────────────────────────────────
        private void pnlHeader_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, pnlHeader.Height - 2),
                new Point(pnlHeader.Width, pnlHeader.Height - 2),
                Color.FromArgb(56, 139, 253),
                Color.FromArgb(99, 60, 220)))
            {
                e.Graphics.FillRectangle(brush,
                    0, pnlHeader.Height - 3, pnlHeader.Width, 3);
            }
        }

        // ── Effacer / Reset ───────────────────────────────────────────────────
        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtAnneAcademique.Text = string.Empty;
            chkEstActive.Checked = false;
            _selectedAnneAcademiqueId = null;

            var liste = db.AnneeAcademiques.ToList();
            DgAnneAcademique.DataSource = liste;
            lblCount.Text = $"{liste.Count} entrée(s)";

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;

            // Couleur bouton Ajouter (actif = bleu plein)
            btnAjouter.BackColor = C_ACCENT;
            txtLibelle.Focus();
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        // ── Ajouter ───────────────────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                FlashError(txtLibelle, "Le libellé est obligatoire.");
                return;
            }

            AnneeAcademique a = new AnneeAcademique
            {
                LibelleAnneeAcademique = txtLibelle.Text.Trim(),
                ValueAnneeAcademique = int.TryParse(txtAnneAcademique.Text, out int annee) ? annee : DateTime.Now.Year,
                EstActive = chkEstActive.Checked
            };
            db.AnneeAcademiques.Add(a);
            db.SaveChanges();
            Effacer();
            ShowToast("Année ajoutée avec succès ✓", Color.FromArgb(56, 139, 253));
        }

        // ── Modifier ──────────────────────────────────────────────────────────
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (_selectedAnneAcademiqueId == null) return;
            var a = db.AnneeAcademiques.Find(_selectedAnneAcademiqueId);
            if (a == null) return;

            a.LibelleAnneeAcademique = txtLibelle.Text.Trim();
            a.ValueAnneeAcademique = int.TryParse(txtAnneAcademique.Text, out int annee) ? annee : a.ValueAnneeAcademique;
            a.EstActive = chkEstActive.Checked;
            db.SaveChanges();
            Effacer();
            ShowToast("Année modifiée avec succès ✓", Color.FromArgb(255, 170, 50));
        }

        // ── Supprimer ─────────────────────────────────────────────────────────
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_selectedAnneAcademiqueId == null) return;

            var confirm = MessageBox.Show(
                "Confirmer la suppression ?",
                "Supprimer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            var a = db.AnneeAcademiques.Find(_selectedAnneAcademiqueId);
            if (a == null) return;

            db.AnneeAcademiques.Remove(a);
            db.SaveChanges();
            Effacer();
            ShowToast("Année supprimée.", Color.FromArgb(220, 80, 80));
        }

        // ── Sélectionner ──────────────────────────────────────────────────────
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (DgAnneAcademique.CurrentRow == null) return;

            _selectedAnneAcademiqueId = Convert.ToInt32(DgAnneAcademique.CurrentRow.Cells[0].Value);
            var a = db.AnneeAcademiques.Find(_selectedAnneAcademiqueId);
            if (a == null) return;

            txtLibelle.Text = a.LibelleAnneeAcademique;
            txtAnneAcademique.Text = a.ValueAnneeAcademique.ToString();
            chkEstActive.Checked = a.EstActive;

            btnModifier.Enabled = true;
            btnSupprimer.Enabled = true;
            btnAjouter.Enabled = false;
            btnAjouter.BackColor = Color.FromArgb(30, 35, 55);
        }

        // ── Effacer bouton ────────────────────────────────────────────────────
        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Effacer();
        }

        private void DgAnneAcademique_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ── Helpers UI ────────────────────────────────────────────────────────
        private void FlashError(TextBox txt, string message)
        {
            txt.BackColor = Color.FromArgb(60, 30, 35);
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt.BackColor = Color.FromArgb(30, 35, 55);
            txt.Focus();
        }

        private void ShowToast(string message, Color color)
        {
            Label toast = new Label
            {
                Text = "  " + message,
                AutoSize = false,
                Size = new Size(340, 44),
                Location = new Point(pnlGrid.Left + 20, pnlGrid.Bottom - 60),
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(toast);
            toast.BringToFront();

            Timer t = new Timer { Interval = 2500 };
            t.Tick += (s, e) =>
            {
                t.Stop();
                this.Controls.Remove(toast);
                toast.Dispose();
            };
            t.Start();
        }

       
    }
}