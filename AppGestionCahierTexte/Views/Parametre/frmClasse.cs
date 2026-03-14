using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmClasse : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedClasseId = null;

        // ── Couleurs thème ────────────────────────────────────────────────────
        private readonly Color C_BG = Color.FromArgb(15, 17, 26);
        private readonly Color C_CARD = Color.FromArgb(22, 26, 40);
        private readonly Color C_ACCENT = Color.FromArgb(56, 139, 253);
        private readonly Color C_BORDER = Color.FromArgb(35, 42, 65);

        public frmClasse()
        {
            InitializeComponent();
            StyleTextBoxUnderline(txtLibelle, pnlCard);
            StyleTextBoxUnderline(txtNiveau, pnlCard);
            StyleTextBoxUnderline(txtRClasse, pnlSearch);
            StyleTextBoxUnderline(txtRAnnee, pnlSearch);
        }

        // ── Underline animé ───────────────────────────────────────────────────
        private void StyleTextBoxUnderline(TextBox txt, Panel parent)
        {
            Panel line = new Panel
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
        private void pnlCard_Paint(object sender, System.Windows.Forms.PaintEventArgs e) => DrawCard(e.Graphics, (Panel)sender);
        private void pnlGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e) => DrawCard(e.Graphics, (Panel)sender);

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

        private void pnlHeader_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
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

        // ── Charger ComboBox Années ───────────────────────────────────────────
        private void ChargerAnnees()
        {
            var liste = new List<AnneeAcademique>();
            liste.Add(new AnneeAcademique { IdAnneeAcademique = 0, LibelleAnneeAcademique = "— Sélectionner —" });
            liste.AddRange(db.AnneeAcademiques.ToList());

            cbbAnneeAcademique.DataSource = liste;
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
            cbbAnneeAcademique.ValueMember = "IdAnneeAcademique";
            cbbAnneeAcademique.SelectedIndex = 0;
        }

        // ── Charger ComboBox Responsables ─────────────────────────────────────
        private void ChargerResponsables()
        {
            var liste = new List<object>();
            liste.Add(new { IdUtilisateur = 0, NomComplet = "— Aucun responsable —" });

            var responsables = db.ResponsableClasses
                .Select(r => new { r.IdUtilisateur, NomComplet = r.NomUtilisateur + " " + r.PrenomUtilisateur })
                .ToList();
            liste.AddRange(responsables);

            cbbResponsable.DataSource = liste;
            cbbResponsable.DisplayMember = "NomComplet";
            cbbResponsable.ValueMember = "IdUtilisateur";
            cbbResponsable.SelectedIndex = 0;
        }

        // ── Effacer / Reset ───────────────────────────────────────────────────
        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtNiveau.Text = string.Empty;
            _selectedClasseId = null;

            ChargerAnnees();
            ChargerResponsables();
            ChargerGrille();

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjouter.BackColor = C_ACCENT;

            txtLibelle.Focus();
        }

        // ── Charger la grille ─────────────────────────────────────────────────
        private void ChargerGrille(string filtreClasse = "", string filtreAnnee = "")
        {
            var query = db.Classes.Include(c => c.AnneeAcademique)
                                  .Include(c => c.ResponsableClasse)
                                  .AsQueryable();

            if (!string.IsNullOrEmpty(filtreClasse))
                query = query.Where(c => c.LibelleClasse.ToUpper().Contains(filtreClasse.ToUpper()));

            if (!string.IsNullOrEmpty(filtreAnnee))
                query = query.Where(c => c.AnneeAcademique.LibelleAnneeAcademique.ToUpper().Contains(filtreAnnee.ToUpper()));

            var liste = query.Select(c => new
            {
                c.IdClasse,
                c.LibelleClasse,
                Niveau = c.NiveauClasse,
                AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique,
                Responsable = c.ResponsableClasse != null
                                    ? c.ResponsableClasse.NomUtilisateur + " " + c.ResponsableClasse.PrenomUtilisateur
                                    : "—"
            }).ToList();

            DgClasse.DataSource = liste;
            lblCount.Text = $"{liste.Count} entrée(s)";
        }

        // ── Load ──────────────────────────────────────────────────────────────
        private void frmClasse_Load(object sender, EventArgs e) => Effacer();

        // ── Ajouter ───────────────────────────────────────────────────────────
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Valider()) return;

                int idAnnee = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());

                bool existe = db.Classes.Any(c =>
                    c.LibelleClasse.ToLower() == txtLibelle.Text.Trim().ToLower() &&
                    c.IdAnneeAcademique == idAnnee);

                if (existe)
                {
                    ShowToast("Cette classe existe déjà pour cette année.", Color.FromArgb(220, 80, 80));
                    return;
                }

                int? idResp = GetResponsableId();

                var classe = new Classe
                {
                    LibelleClasse = txtLibelle.Text.Trim(),
                    NiveauClasse = txtNiveau.Text.Trim(),
                    IdAnneeAcademique = idAnnee,
                    IdResponsableClasse = idResp
                };

                db.Classes.Add(classe);
                db.SaveChanges();
                Effacer();
                ShowToast("Classe ajoutée avec succès ✓", C_ACCENT);
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnAjouter_Click : {ex.Message}");
                ShowToast($"Erreur : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Sélectionner ──────────────────────────────────────────────────────
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgClasse.SelectedRows.Count == 0)
                {
                    ShowToast("Veuillez sélectionner une ligne.", Color.FromArgb(255, 170, 50));
                    return;
                }

                _selectedClasseId = Convert.ToInt32(DgClasse.SelectedRows[0].Cells["IdClasse"].Value);
                var c = db.Classes.Find(_selectedClasseId);
                if (c == null) return;

                txtLibelle.Text = c.LibelleClasse;
                txtNiveau.Text = c.NiveauClasse;
                cbbAnneeAcademique.SelectedValue = c.IdAnneeAcademique;

                if (c.IdResponsableClasse.HasValue)
                    cbbResponsable.SelectedValue = c.IdResponsableClasse.Value;
                else
                    cbbResponsable.SelectedIndex = 0;

                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAjouter.Enabled = false;
                btnAjouter.BackColor = Color.FromArgb(30, 35, 55);
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnSelectionner_Click : {ex.Message}");
            }
        }

        // ── Modifier ──────────────────────────────────────────────────────────
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClasseId == null || !Valider()) return;

                int idAnnee = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());

                bool existe = db.Classes.Any(cl =>
                    cl.LibelleClasse.ToLower() == txtLibelle.Text.Trim().ToLower() &&
                    cl.IdAnneeAcademique == idAnnee &&
                    cl.IdClasse != _selectedClasseId);

                if (existe)
                {
                    ShowToast("Une autre classe porte déjà ce nom pour cette année.", Color.FromArgb(220, 80, 80));
                    return;
                }

                var c = db.Classes.Find(_selectedClasseId);
                if (c == null) return;

                c.LibelleClasse = txtLibelle.Text.Trim();
                c.NiveauClasse = txtNiveau.Text.Trim();
                c.IdAnneeAcademique = idAnnee;
                c.IdResponsableClasse = GetResponsableId();

                db.SaveChanges();
                Effacer();
                ShowToast("Classe modifiée avec succès ✓", Color.FromArgb(255, 170, 50));
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnModifier_Click : {ex.Message}");
                ShowToast($"Erreur : {ex.Message}", Color.FromArgb(220, 80, 80));
            }
        }

        private void btnModifier_Click_1(object sender, EventArgs e) => btnModifier_Click(sender, e);

        // ── Supprimer ─────────────────────────────────────────────────────────
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClasseId == null) return;

                var res = MessageBox.Show(
                    "Supprimer cette classe ? Toutes les données associées seront perdues.",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res != DialogResult.Yes) return;

                var c = db.Classes.Find(_selectedClasseId);
                if (c == null) return;

                db.Classes.Remove(c);
                db.SaveChanges();
                Effacer();
                ShowToast("Classe supprimée.", Color.FromArgb(220, 80, 80));
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnSupprimer_Click : {ex.Message}");
                ShowToast($"Erreur : {ex.Message} — La classe est peut-être liée à d'autres données.", Color.FromArgb(220, 80, 80));
            }
        }

        // ── Réinitialiser ─────────────────────────────────────────────────────
        private void btnEffacer_Click(object sender, EventArgs e) => Effacer();

        // ── Rechercher ────────────────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try { ChargerGrille(txtRClasse.Text, txtRAnnee.Text); }
            catch (Exception ex) { Logger.WriteFileError($"btnSearch_Click : {ex.Message}"); }
        }

        // ── TextChanged : limite libellé ──────────────────────────────────────
        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            if (txtLibelle.Text.Length > 20)
            {
                txtLibelle.Text = txtLibelle.Text.Substring(0, 20);
                txtLibelle.SelectionStart = txtLibelle.Text.Length;
            }
        }

        // ── Helpers ───────────────────────────────────────────────────────────
        private bool Valider()
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                ShowToast("Le libellé de la classe est obligatoire.", Color.FromArgb(220, 80, 80));
                txtLibelle.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNiveau.Text))
            {
                ShowToast("Le niveau est obligatoire (ex: Licence 1).", Color.FromArgb(220, 80, 80));
                txtNiveau.Focus();
                return false;
            }
            if (cbbAnneeAcademique.SelectedValue == null ||
                int.Parse(cbbAnneeAcademique.SelectedValue.ToString()) == 0)
            {
                ShowToast("Veuillez sélectionner une année académique.", Color.FromArgb(220, 80, 80));
                cbbAnneeAcademique.Focus();
                return false;
            }
            return true;
        }

        private int? GetResponsableId()
        {
            if (cbbResponsable.SelectedValue == null) return null;
            int id = int.Parse(cbbResponsable.SelectedValue.ToString());
            return id == 0 ? (int?)null : id;
        }

        private void ShowToast(string message, Color color)
        {
            Label toast = new Label
            {
                Text = "  " + message,
                AutoSize = false,
                Size = new Size(400, 44),
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
    }
}