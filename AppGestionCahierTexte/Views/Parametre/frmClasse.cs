using AppGestionCahierTexte.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity; // Pour Entity Framework 6
// OU

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmClasse : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedClasseId = null;

        private void Effacer()
        {
            txtLibelle.Text = string.Empty;

            // Charger les années académiques
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

            // ✅ Charger avec Include pour inclure la relation
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
                // Validation des champs
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

                // Vérifier si la classe existe déjà pour cette année
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

                // Créer la nouvelle classe
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
                    // Récupérer l'ID de la classe sélectionnée
                    _selectedClasseId = Convert.ToInt32(DgClasse.SelectedRows[0].Cells["IdClasse"].Value);

                    // Charger les données dans les champs
                    var classe = db.Classes.Find(_selectedClasseId);

                    if (classe != null)
                    {
                        txtLibelle.Text = classe.LibelleClasse;
                        cbbAnneeAcademique.SelectedValue = classe.IdAnneeAcademique;

                        // Activer les boutons Modifier et Supprimer
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

                // Validation des champs
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

                // Vérifier si une autre classe porte le même nom pour cette année
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

                // Modifier la classe
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
                MessageBox.Show($"Erreur lors de la modification: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            // Appeler la même méthode que btnModifier_Click
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

                // Demander confirmation
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
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}\n\nCette classe est peut-être utilisée dans d'autres tables.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {
            // Limiter à 10 caractères (contrainte du modèle)
            if (txtLibelle.Text.Length > 10)
            {
                txtLibelle.Text = txtLibelle.Text.Substring(0, 10);
                txtLibelle.SelectionStart = txtLibelle.Text.Length;
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            var query = db.Classes.Include(c => c.AnneeAcademique).AsQueryable();

            // Filtrer par année académique
            if (!string.IsNullOrEmpty(txtRAnnee.Text))
            {
                string anneeRecherche = txtRAnnee.Text.ToUpper();
                query = query.Where(c =>
                    c.AnneeAcademique.ValueAnneeAcademique.ToString().ToUpper().Contains(anneeRecherche)
                );
            }

            // Filtrer par classe
            if (!string.IsNullOrEmpty(txtRClasse.Text))
            {
                string classeRecherche = txtRClasse.Text.ToUpper();
                query = query.Where(c =>
                    c.LibelleClasse.ToUpper().Contains(classeRecherche)
                );
            }

            // Correction : il manquait la récupération de la liste
            var liste = query.Select(c => new
            {
                c.IdClasse,
                c.LibelleClasse,
                c.IdAnneeAcademique,
                AnneeAcademique = c.AnneeAcademique.LibelleAnneeAcademique
            }).ToList();

            DgClasse.DataSource = liste;
        }

    }

}