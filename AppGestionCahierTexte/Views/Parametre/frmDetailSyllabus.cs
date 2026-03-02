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

namespace AppGestionCahierTexte.Views.Parametre
{
    public partial class frmDetailSyllabus : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedDetailSyllabusId = null;
        private void Effacer()
        {
            txtSeance.Text = string.Empty;
            txtContenue.Text = string.Empty;
            DgDetailSyllabsu.DataSource = db.DetailsSyllabuses.ToList();
            txtSeance.Focus();
            _selectedDetailSyllabusId = null;
            if (DgDetailSyllabsu.Columns["SyllabusId"] != null)
                DgDetailSyllabsu.Columns["SyllabusId"].Visible = false;
            if (DgDetailSyllabsu.Columns["Syllabus"] != null)
                DgDetailSyllabsu.Columns["Syllabus"].Visible = false;

            // Réinitialiser l'état des boutons
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }
        public frmDetailSyllabus()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtSeance.Text))
                {
                    MessageBox.Show("Veuillez saisir la seance du syllabus.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSeance.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtContenue.Text))
                {
                    MessageBox.Show("Veuillez saisir le contenue du syllabus.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContenue.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDure.Text))
                {
                    MessageBox.Show("Veuillez saisir la durée du syllabus.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDure.Focus();
                    return;
                }


                // Créer une nouvelle Detail syllabus
                DetailsSyllabus nouvelleDetailSyllabus = new DetailsSyllabus();
                {
                    nouvelleDetailSyllabus.SeanceSyllabus = txtSeance.Text.Trim();
                    nouvelleDetailSyllabus.ContenuSyllabus = txtContenue.Text.Trim();
                };

                // Ajouter à la base de données
                db.DetailsSyllabuses.Add(nouvelleDetailSyllabus);
                db.SaveChanges();

                MessageBox.Show("Detail Syllabus ajoutée avec succès!",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Rafraîchir et vider les champs
                Effacer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDetailSyllabus_Load(object sender, EventArgs e)
        {
            Effacer();
        }
    }
}
