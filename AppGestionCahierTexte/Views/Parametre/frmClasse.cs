using AppGestionCahierTexte.Models;
using AppGestionCahierTexte.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmClasse : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedClasseId = null;

        private void Effacer()
        {
            txtLibelle.Text = string.Empty;

            var anneesAcademiques = db.AnneeAcademiques.ToList();

            var listeAvecDefaut = new List<AnneeAcademique>();
            listeAvecDefaut.Add(new AnneeAcademique
            {
                IdAnneeAcademique = 0,
                LibelleAnneeAcademique = "Sélectionner"
            });
            listeAvecDefaut.AddRange(anneesAcademiques);

            cbbAnneeAcademique.DataSource = listeAvecDefaut;
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
            cbbAnneeAcademique.ValueMember = "IdAnneeAcademique";
            cbbAnneeAcademique.SelectedIndex = 0;

            DgClasse.DataSource = db.Classes
                .Select(c => new
                {
                    c.IdClasse,
                    c.LibelleClasse,
                    c.IdAnneeAcademique,
                    AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique
                })
                .ToList();

            txtLibelle.Focus();
            _selectedClasseId = null;

            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        public frmClasse()
        {
            InitializeComponent();
        }

        private void frmClasse_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Veuillez saisir le libellé de la classe.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                if (txtLibelle.Text.Length > 10)
                {
                    MessageBox.Show("Le libellé ne peut pas dépasser 10 caractères.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.WriteFileError("Validation - Le libellé ne peut pas dépasser 10 caractères.");
                    txtLibelle.Focus();
                    return;
                }

                if (cbbAnneeAcademique.SelectedValue == null ||
                    int.Parse(cbbAnneeAcademique.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une année académique.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbAnneeAcademique.Focus();
                    return;
                }

                int idAnnee = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
                bool classeExiste = db.Classes.Any(classe =>
                    classe.LibelleClasse.ToLower() == txtLibelle.Text.Trim().ToLower() &&
                    classe.IdAnneeAcademique == idAnnee);

                if (classeExiste)
                {
                    MessageBox.Show("Cette classe existe déjà pour cette année académique.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Classe c = new Classe();
                c.LibelleClasse = txtLibelle.Text.Trim();
                c.IdAnneeAcademique = idAnnee;

                db.Classes.Add(c);
                db.SaveChanges();

                MessageBox.Show("Classe ajoutée avec succès!",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Effacer();
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnAjouter_Click : {ex.Message}");
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgClasse.SelectedRows.Count > 0)
                {
                    _selectedClasseId = Convert.ToInt32(DgClasse.SelectedRows[0].Cells["IdClasse"].Value);

                    var classe = db.Classes.Find(_selectedClasseId);

                    if (classe != null)
                    {
                        txtLibelle.Text = classe.LibelleClasse;
                        cbbAnneeAcademique.SelectedValue = classe.IdAnneeAcademique;

                        btnModifier.Enabled = true;
                        btnSupprimer.Enabled = true;
                        btnAjouter.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnSelectionner_Click : {ex.Message}");
                MessageBox.Show($"Erreur lors de la sélection: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClasseId == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner une classe à modifier.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Veuillez saisir le libellé de la classe.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                if (txtLibelle.Text.Length > 10)
                {
                    MessageBox.Show("Le libellé ne peut pas dépasser 10 caractères.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.WriteFileError("btnModifier_Click - Validation : Le libellé ne peut pas dépasser 10 caractères.");
                    txtLibelle.Focus();
                    return;
                }

                if (cbbAnneeAcademique.SelectedValue == null ||
                    int.Parse(cbbAnneeAcademique.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une année académique.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbAnneeAcademique.Focus();
                    return;
                }

                int idAnnee = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
                bool classeExiste = db.Classes.Any(classe =>
                    classe.LibelleClasse.ToLower() == txtLibelle.Text.Trim().ToLower() &&
                    classe.IdAnneeAcademique == idAnnee &&
                    classe.IdClasse != _selectedClasseId);

                if (classeExiste)
                {
                    MessageBox.Show("Une autre classe porte déjà ce nom pour cette année académique.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var c = db.Classes.Find(_selectedClasseId);

                if (c != null)
                {
                    c.LibelleClasse = txtLibelle.Text.Trim();
                    c.IdAnneeAcademique = idAnnee;

                    db.SaveChanges();

                    MessageBox.Show("Classe modifiée avec succès!",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Effacer();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnModifier_Click : {ex.Message}");
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            btnModifier_Click(sender, e);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedClasseId == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner une classe à supprimer.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cette classe ?\n\nAttention : Cette action supprimera également toutes les données associées à cette classe.",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var c = db.Classes.Find(_selectedClasseId);

                    if (c != null)
                    {
                        db.Classes.Remove(c);
                        db.SaveChanges();

                        MessageBox.Show("Classe supprimée avec succès!",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Effacer();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnSupprimer_Click : {ex.Message}");
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}\n\nCette classe est peut-être utilisée dans d'autres tables.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            if (txtLibelle.Text.Length > 10)
            {
                txtLibelle.Text = txtLibelle.Text.Substring(0, 10);
                txtLibelle.SelectionStart = txtLibelle.Text.Length;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var query = db.Classes.Include(c => c.AnneeAcademique).AsQueryable();

                if (!string.IsNullOrEmpty(txtRAnnee.Text))
                {
                    string anneeRecherche = txtRAnnee.Text.ToUpper();
                    query = query.Where(c =>
                        c.AnneeAcademique.ValueAnneeAcademique.ToString().ToUpper().Contains(anneeRecherche)
                    );
                }

                if (!string.IsNullOrEmpty(txtRClasse.Text))
                {
                    string classeRecherche = txtRClasse.Text.ToUpper();
                    query = query.Where(c =>
                        c.LibelleClasse.ToUpper().Contains(classeRecherche)
                    );
                }

                var liste = query.Select(c => new
                {
                    c.IdClasse,
                    c.LibelleClasse,
                    c.IdAnneeAcademique,
                    AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique
                }).ToList();

                DgClasse.DataSource = liste;
            }
            catch (Exception ex)
            {
                Logger.WriteFileError($"btnSearch_Click : {ex.Message}");
                MessageBox.Show($"Erreur lors de la recherche: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}