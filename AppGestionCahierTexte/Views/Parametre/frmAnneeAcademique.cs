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
    public partial class frmAnneeAcademique : Form
    {
        BdCahierTexteContext db= new BdCahierTexteContext();
        private int? _selectedAnneAcademiqueId = null;

        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtAnneAcademique.Text = string.Empty;
            DgAnneAcademique.DataSource = db.AnneeAcademiques.ToList();
            txtLibelle.Focus();
            txtAnneAcademique.Focus();

            // Réinitialiser l'état des boutons
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
        }

        public frmAnneeAcademique()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            AnneeAcademique a = new AnneeAcademique();
            a.LibelleAnneeAcademique = txtLibelle.Text;
            a.ValueAnneeAcademique = int.TryParse(txtAnneAcademique.Text, out int annee) ? annee : 0;
            db.AnneeAcademiques.Add(a);
            db.SaveChanges();
            Effacer();
            // Ajoutez ici la logique pour sauvegarder l'objet 'a' dans la base de données si nécessaire
        }

        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(DgAnneAcademique.CurrentRow.Cells[0].Value.ToString());
            var a = db.AnneeAcademiques.Find(id);
            a.LibelleAnneeAcademique = txtLibelle.Text;
            a.ValueAnneeAcademique = int.TryParse(txtAnneAcademique.Text, out int annee) ? annee : 0;
            db.SaveChanges();
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(DgAnneAcademique.CurrentRow.Cells[0].Value.ToString());
            var a = db.AnneeAcademiques.Find(id);
            
            db.AnneeAcademiques.Remove(a);
            db.SaveChanges();
            Effacer();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtLibelle.Text = DgAnneAcademique.CurrentRow.Cells[1].Value.ToString();
            txtAnneAcademique.Text = DgAnneAcademique.CurrentRow.Cells[2].Value.ToString();

            if (DgAnneAcademique.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de la ligne sélectionnée
                _selectedAnneAcademiqueId = Convert.ToInt32(DgAnneAcademique.SelectedRows[0].Cells["idAnneeAcademique"].Value);

                // Charger les données dans les champs
                var AnneeAcca = db.AnneeAcademiques.Find(_selectedAnneAcademiqueId);

                if (AnneeAcca != null)
                {
                    txtLibelle.Text = AnneeAcca.LibelleAnneeAcademique;
                    txtAnneAcademique.Text = AnneeAcca.ValueAnneeAcademique.ToString();

                    // Activer les boutons Modifier et Supprimer
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                    btnAjouter.Enabled = false;
                }
            }

        }
    }
}
