using AppGestionCahierTexte.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmSyllabus : Form
    {
        private BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedSyllabusId = null;

        public string Profil { get; set; }
        public int IdUtilisateur { get; set; }

        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmSyllabus()
        {
            InitializeComponent();
            StyleUnderline(txtLibelle, pnlCard);
            StyleUnderline(txtDescription, pnlCard);
            StyleUnderline(txtVolumeHoraire, pnlCard);
            StyleComboBox(cmbMatiere);
            StyleComboBox(cmbClasse);
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
        private void frmSyllabus_Load(object sender, EventArgs e) { }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Effacer();
        }

        // ── Effacer ───────────────────────────────────────────────────────────
        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtVolumeHoraire.Text = string.Empty;
            _selectedSyllabusId = null;

            db = new BdCahierTexteContext();

            try
            {
                var matieres = db.Matieres.ToList();
                cmbMatiere.DataSource = null;
                cmbMatiere.DataSource = matieres;
                cmbMatiere.DisplayMember = "libelleMatiere";
                cmbMatiere.ValueMember = "idMatiere";
                cmbMatiere.SelectedIndex = -1;

                var classes = db.Classes.ToList();
                cmbClasse.DataSource = null;
                cmbClasse.DataSource = classes;
                cmbClasse.DisplayMember = "LibelleClasse";
                cmbClasse.ValueMember = "IdClasse";
                cmbClasse.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowToast($"Erreur chargement listes : {ex.Message}", Color.FromArgb(220, 80, 80));
            }

            ChargerGrille();

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.BackColor = C_ACCENT;
            txtLibelle.Focus();
        }

        // ── Charger grille ────────────────────────────────────────────────────
        private void ChargerGrille()
        {
            try
            {
                db = new BdCahierTexteContext();
                var liste = db.Syllabuses.ToList();

                DgSyllabus.DataSource = null;
                DgSyllabus.DataSource = liste;
                lblCount.Text = $"{liste.Count} entrée(s)";

                string[] amasquer = { "IdMatiere", "IdClasse", "IdProfesseur",
                                      "Matiere", "Classe", "Professeur",
                                      "DetailsSyllabuses", "CahiersTexte" };
                foreach (var col in amasquer)
                    if (DgSyllabus.Columns[col] != null)
                        DgSyllabus.Columns[col].Visible = false;
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

                var s = new Syllabus
                {
                    LibelleSyllabus = txtLibelle.Text.Trim(),
                    DescriptionSyllabus = txtDescription.Text.Trim(),
                    VolumeHoraireSyllabus = int.TryParse(txtVolumeHoraire.Text, out int vol) ? vol : (int?)null,
                    IdMatiere = (int)cmbMatiere.SelectedValue,
                    IdClasse = (int)cmbClasse.SelectedValue,
                    IdProfesseur = Profil == "Professeur" ? IdUtilisateur : (int?)null
                };

                db.Syllabuses.Add(s);
                db.SaveChanges();
                Effacer();
                ShowToast("Syllabus ajouté avec succès ✓", C_ACCENT);
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
                if (DgSyllabus.SelectedRows.Count == 0)
                { ShowToast("Veuillez sélectionner une ligne.", Color.FromArgb(255, 170, 50)); return; }

                _selectedSyllabusId = Convert.ToInt32(DgSyllabus.SelectedRows[0].Cells["IdSyllabus"].Value);
                var s = db.Syllabuses.Find(_selectedSyllabusId);
                if (s == null) return;

                txtLibelle.Text = s.LibelleSyllabus;
                txtDescription.Text = s.DescriptionSyllabus;
                txtVolumeHoraire.Text = s.VolumeHoraireSyllabus?.ToString() ?? string.Empty;
                cmbMatiere.SelectedValue = s.IdMatiere;
                cmbClasse.SelectedValue = s.IdClasse;

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
                if (_selectedSyllabusId == null || !Valider()) return;

                var s = db.Syllabuses.Find(_selectedSyllabusId);
                if (s == null) return;

                s.LibelleSyllabus = txtLibelle.Text.Trim();
                s.DescriptionSyllabus = txtDescription.Text.Trim();
                s.VolumeHoraireSyllabus = int.TryParse(txtVolumeHoraire.Text, out int vol) ? vol : (int?)null;
                s.IdMatiere = (int)cmbMatiere.SelectedValue;
                s.IdClasse = (int)cmbClasse.SelectedValue;

                db.SaveChanges();
                Effacer();
                ShowToast("Syllabus modifié avec succès ✓", Color.FromArgb(255, 170, 50));
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
                if (_selectedSyllabusId == null) return;

                if (MessageBox.Show("Supprimer ce syllabus ? Toutes les données associées seront affectées.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                var s = db.Syllabuses.Find(_selectedSyllabusId);
                if (s == null) return;

                db.Syllabuses.Remove(s);
                db.SaveChanges();
                Effacer();
                ShowToast("Syllabus supprimé.", Color.FromArgb(220, 80, 80));
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
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            { ShowToast("Le libellé est obligatoire.", Color.FromArgb(220, 80, 80)); txtLibelle.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            { ShowToast("La description est obligatoire.", Color.FromArgb(220, 80, 80)); txtDescription.Focus(); return false; }

            if (cmbMatiere.SelectedValue == null)
            { ShowToast("Veuillez sélectionner une matière.", Color.FromArgb(220, 80, 80)); cmbMatiere.Focus(); return false; }

            if (cmbClasse.SelectedValue == null)
            { ShowToast("Veuillez sélectionner une classe.", Color.FromArgb(220, 80, 80)); cmbClasse.Focus(); return false; }

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