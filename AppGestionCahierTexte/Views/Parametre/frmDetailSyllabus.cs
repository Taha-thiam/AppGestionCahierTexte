using AppGestionCahierTexte.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmDetailSyllabus : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedDetailSyllabusId = null;

        public string Profil { get; set; }
        public int IdUtilisateur { get; set; }

        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmDetailSyllabus()
        {
            InitializeComponent();
            StyleUnderline(txtSeance, pnlCard);
            StyleUnderline(txtContenue, pnlCard);
            StyleUnderline(txtDuree, pnlCard);
            StyleComboBox(cmbSyllabus);
        }

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
            txt.Enter += (s, e) => line.BackColor = C_ACCENT;
            txt.Leave += (s, e) => line.BackColor = C_BORDER;
        }

        private void StyleComboBox(ComboBox cmb)
        {
            cmb.BackColor = Color.FromArgb(30, 35, 55);
            cmb.ForeColor = Color.FromArgb(220, 225, 255);
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 11F);
        }

        // ── Paint ─────────────────────────────────────────────────────────────
        private void pnlCard_Paint(object sender, PaintEventArgs e) => DrawCard(e.Graphics, (Panel)sender);
        private void pnlGrid_Paint(object sender, PaintEventArgs e) => DrawCard(e.Graphics, (Panel)sender);

        private void DrawCard(Graphics g, Panel p)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            using (var path = RoundedRect(rect, 12))
            using (var brush = new SolidBrush(C_CARD)) g.FillPath(brush, path);
            using (var path = RoundedRect(rect, 12))
            using (var pen = new Pen(C_BORDER, 1)) g.DrawPath(pen, path);
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
                new Point(0, pnlHeader.Height - 2), new Point(pnlHeader.Width, pnlHeader.Height - 2),
                Color.FromArgb(56, 139, 253), Color.FromArgb(99, 60, 220)))
                e.Graphics.FillRectangle(brush, 0, pnlHeader.Height - 3, pnlHeader.Width, 3);
        }

        // ── Load / OnShown ────────────────────────────────────────────────────
        private void frmDetailSyllabus_Load(object sender, EventArgs e) { }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Effacer();
        }

        // ── Effacer ───────────────────────────────────────────────────────────
        private void Effacer()
        {
            txtSeance.Text = string.Empty;
            txtContenue.Text = string.Empty;
            txtDuree.Text = string.Empty;
            _selectedDetailSyllabusId = null;

            db = new BdCahierTexteContext();
            ChargerComboSyllabus();
            ChargerGrille();

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.BackColor = C_ACCENT;
            txtSeance.Focus();
        }

        // ── Charger ComboBox ──────────────────────────────────────────────────
        private void ChargerComboSyllabus()
        {
            try
            {
                var syllabuses = db.Syllabuses.ToList();
                cmbSyllabus.DataSource = null;
                cmbSyllabus.DataSource = syllabuses;
                cmbSyllabus.DisplayMember = "LibelleSyllabus";
                cmbSyllabus.ValueMember = "IdSyllabus";
                cmbSyllabus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur chargement syllabus : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Charger grille ────────────────────────────────────────────────────
        private void ChargerGrille()
        {
            try
            {
                db = new BdCahierTexteContext();
                var liste = db.DetailsSyllabuses.ToList();

                DgDetailSyllabus.DataSource = null;
                DgDetailSyllabus.DataSource = liste;
                lblCount.Text = $"{liste.Count} entrée(s)";

                string[] amasquer = { "SyllabusId", "Syllabus" };
                foreach (var col in amasquer)
                    if (DgDetailSyllabus.Columns[col] != null)
                        DgDetailSyllabus.Columns[col].Visible = false;
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur chargement grille : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Ajouter ───────────────────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Valider()) return;

                var d = new DetailsSyllabus
                {
                    SeanceSyllabus = txtSeance.Text.Trim(),
                    ContenuSyllabus = txtContenue.Text.Trim(),
                    DureeSyllabus = double.TryParse(txtDuree.Text, out double duree) ? duree : (double?)null,
                    SyllabusId = (int)cmbSyllabus.SelectedValue
                };

                db.DetailsSyllabuses.Add(d);
                db.SaveChanges();
                Effacer();
                ShowToast("Détail ajouté avec succès ✓", C_ACCENT);
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
                if (DgDetailSyllabus.SelectedRows.Count == 0)
                { ShowToast("Veuillez sélectionner une ligne.", Color.FromArgb(255, 170, 50)); return; }

                _selectedDetailSyllabusId = Convert.ToInt32(
                    DgDetailSyllabus.SelectedRows[0].Cells["IdDetailsSyllabus"].Value);

                var d = db.DetailsSyllabuses.Find(_selectedDetailSyllabusId);
                if (d == null) return;

                txtSeance.Text = d.SeanceSyllabus;
                txtContenue.Text = d.ContenuSyllabus;
                txtDuree.Text = d.DureeSyllabus?.ToString() ?? string.Empty;
                cmbSyllabus.SelectedValue = d.SyllabusId;

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
                if (_selectedDetailSyllabusId == null || !Valider()) return;

                var d = db.DetailsSyllabuses.Find(_selectedDetailSyllabusId);
                if (d == null) return;

                d.SeanceSyllabus = txtSeance.Text.Trim();
                d.ContenuSyllabus = txtContenue.Text.Trim();
                d.DureeSyllabus = double.TryParse(txtDuree.Text, out double duree) ? duree : (double?)null;
                d.SyllabusId = (int)cmbSyllabus.SelectedValue;

                db.SaveChanges();
                Effacer();
                ShowToast("Détail modifié avec succès ✓", Color.FromArgb(255, 170, 50));
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
                if (_selectedDetailSyllabusId == null) return;

                if (MessageBox.Show("Supprimer ce détail ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                var d = db.DetailsSyllabuses.Find(_selectedDetailSyllabusId);
                if (d == null) return;

                db.DetailsSyllabuses.Remove(d);
                db.SaveChanges();
                Effacer();
                ShowToast("Détail supprimé.", Color.FromArgb(220, 80, 80));
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        private void btnEffacer_Click(object sender, EventArgs e) => Effacer();

        // ── Validation ────────────────────────────────────────────────────────
        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtSeance.Text))
            { ShowToast("La séance est obligatoire.", Color.FromArgb(220, 80, 80)); txtSeance.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtContenue.Text))
            { ShowToast("Le contenu est obligatoire.", Color.FromArgb(220, 80, 80)); txtContenue.Focus(); return false; }

            if (!string.IsNullOrEmpty(txtDuree.Text) &&
                !double.TryParse(txtDuree.Text, out _))
            { ShowToast("La durée doit être un nombre. Ex: 1.5", Color.FromArgb(220, 80, 80)); txtDuree.Focus(); return false; }

            if (cmbSyllabus.SelectedValue == null)
            { ShowToast("Veuillez sélectionner un syllabus.", Color.FromArgb(220, 80, 80)); cmbSyllabus.Focus(); return false; }

            return true;
        }

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
            Controls.Add(toast); toast.BringToFront();
            var t = new Timer { Interval = 3000 };
            t.Tick += (s, ev) => { t.Stop(); Controls.Remove(toast); toast.Dispose(); };
            t.Start();
        }
    }
}