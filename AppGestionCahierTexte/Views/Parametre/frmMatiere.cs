using AppGestionCahierTexte.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmMatiere : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedMatiereId = null;

        // ── Couleurs thème ────────────────────────────────────────────────────
        private readonly Color C_BG = Color.FromArgb(15, 17, 26);
        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmMatiere()
        {
            InitializeComponent();
            StyleTextBoxUnderline(txtLibelle, pnlCard);
            StyleTextBoxUnderline(txtVolumeHoraire, pnlCard);
            StyleTextBoxUnderline(txtNiveau, pnlCard);
        }

        // ── Underline animé ───────────────────────────────────────────────────
        private void StyleTextBoxUnderline(TextBox txt, Panel parent)
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

        // ── Paint cards arrondies ─────────────────────────────────────────────
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

        // ── Effacer / Reset ───────────────────────────────────────────────────
        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtVolumeHoraire.Text = string.Empty;
            txtNiveau.Text = string.Empty;
            _selectedMatiereId = null;

            var liste = db.Matieres.ToList();
            DgMatiere.DataSource = liste;
            lblCount.Text = $"{liste.Count} entrée(s)";

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.BackColor = C_ACCENT;

            txtLibelle.Focus();
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmMatiere_Load(object sender, EventArgs e) => Effacer();

        // ── Ajouter ───────────────────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Valider(out int volumeHoraire)) return;

                var nouvelleMatiere = new Matiere
                {
                    libelleMatiere = txtLibelle.Text.Trim(),
                    VolumeHoraireMatiere = volumeHoraire,
                    Niveau = txtNiveau.Text.Trim()
                };

                db.Matieres.Add(nouvelleMatiere);
                db.SaveChanges();
                Effacer();
                ShowToast("Matière ajoutée avec succès ✓", C_ACCENT);
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Sélectionner ──────────────────────────────────────────────────────
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgMatiere.SelectedRows.Count == 0)
                {
                    ShowToast("Veuillez sélectionner une ligne.", Color.FromArgb(255, 170, 50));
                    return;
                }

                _selectedMatiereId = Convert.ToInt32(DgMatiere.SelectedRows[0].Cells["idMatiere"].Value);
                var matiere = db.Matieres.Find(_selectedMatiereId);
                if (matiere == null) return;

                txtLibelle.Text = matiere.libelleMatiere;
                txtVolumeHoraire.Text = matiere.VolumeHoraireMatiere.ToString();
                txtNiveau.Text = matiere.Niveau;

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAjouter.Enabled = false;
                btnAjouter.BackColor = Color.FromArgb(30, 35, 55);
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Modifier ──────────────────────────────────────────────────────────
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedMatiereId == null || !Valider(out int volumeHoraire)) return;

                var matiere = db.Matieres.Find(_selectedMatiereId);
                if (matiere == null) return;

                matiere.libelleMatiere = txtLibelle.Text.Trim();
                matiere.VolumeHoraireMatiere = volumeHoraire;
                matiere.Niveau = txtNiveau.Text.Trim();

                db.SaveChanges();
                Effacer();
                ShowToast("Matière modifiée avec succès ✓", Color.FromArgb(255, 170, 50));
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Supprimer ─────────────────────────────────────────────────────────
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedMatiereId == null) return;

                var res = MessageBox.Show(
                    "Supprimer cette matière ? Les syllabus associés seront également affectés.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res != DialogResult.Yes) return;

                var matiere = db.Matieres.Find(_selectedMatiereId);
                if (matiere == null) return;

                db.Matieres.Remove(matiere);
                db.SaveChanges();
                Effacer();
                ShowToast("Matière supprimée.", Color.FromArgb(220, 80, 80));
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur : {ex.Message} — La matière est peut-être liée à des syllabus.",
                    Color.FromArgb(220, 80, 80));
            }
        }

        // ── Réinitialiser ─────────────────────────────────────────────────────
        private void btnEffacer_Click(object sender, EventArgs e) => Effacer();

        // ── TextChanged ───────────────────────────────────────────────────────
        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            if (txtLibelle.Text.Length > 200)
            {
                txtLibelle.Text = txtLibelle.Text.Substring(0, 200);
                txtLibelle.SelectionStart = txtLibelle.Text.Length;
            }
        }

        private void txtVolumeHoraire_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVolumeHoraire.Text) &&
                !int.TryParse(txtVolumeHoraire.Text, out _))
            {
                int pos = txtVolumeHoraire.SelectionStart;
                txtVolumeHoraire.Text = txtVolumeHoraire.Text.Remove(txtVolumeHoraire.Text.Length - 1);
                txtVolumeHoraire.SelectionStart = pos > 0 ? pos - 1 : 0;
            }
        }

        private void txtNiveau_TextChanged(object sender, EventArgs e)
        {
            if (txtNiveau.Text.Length > 80)
            {
                txtNiveau.Text = txtNiveau.Text.Substring(0, 80);
                txtNiveau.SelectionStart = txtNiveau.Text.Length;
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private bool Valider(out int volumeHoraire)
        {
            volumeHoraire = 0;

            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                ShowToast("Le libellé de la matière est obligatoire.", Color.FromArgb(220, 80, 80));
                txtLibelle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVolumeHoraire.Text) ||
                !int.TryParse(txtVolumeHoraire.Text, out volumeHoraire) || volumeHoraire <= 0)
            {
                ShowToast("Veuillez saisir un volume horaire valide (nombre entier > 0).", Color.FromArgb(220, 80, 80));
                txtVolumeHoraire.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNiveau.Text))
            {
                ShowToast("Le niveau est obligatoire (ex: L1, M2).", Color.FromArgb(220, 80, 80));
                txtNiveau.Focus();
                return false;
            }

            return true;
        }

        private void ShowToast(string message, Color color)
        {
            var toast = new Label
            {
                Text = "  " + message,
                AutoSize = false,
                Size = new Size(420, 44),
                Location = new Point(pnlGrid.Left + 20, pnlGrid.Bottom - 60),
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            Controls.Add(toast);
            toast.BringToFront();

            var t = new Timer { Interval = 2800 };
            t.Tick += (s, ev) => { t.Stop(); Controls.Remove(toast); toast.Dispose(); };
            t.Start();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintMatiere f = new frmPrintMatiere();
            f.ShowDialog();
        }
    }
}