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
    public partial class frmSyllabus : Form
    {

        BdCahierTexteContext db = new BdCahierTexteContext();
        private int? _selectedSyllabusId = null;

        private void Effacer()
        {
            txtLibelle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtVolumeHoraire.Text = string.Empty;
            txtNiveauSyllabus.Text = string.Empty;
            DgSyllabus.DataSource = db.Syllabuses.ToList();
            txtLibelle.Focus();
            txtDescription.Focus();
            txtVolumeHoraire.Focus();
            txtNiveauSyllabus.Focus();

            _selectedSyllabusId = null;

            // Réinitialiser l'état des boutons
            btnAjouter.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;

        }
        public frmSyllabus()
        {
            InitializeComponent();
        }

      

    

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Syllabus s = new Syllabus();
            s.LibelleSyllabus = txtLibelle.Text;
            s.DescriptionSyllabus = txtDescription.Text;
            s.VolumeHoraireSyllabus = int.TryParse(txtVolumeHoraire.Text, out int volume) ? volume : (int?)null;
            s.NiveauSyllabus = txtNiveauSyllabus.Text;
            db.Syllabuses.Add(s);
            db.SaveChanges();
            Effacer();
        }

        private void frmSyllabus_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtLibelle.Text = DgSyllabus.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = DgSyllabus.CurrentRow.Cells[2].Value.ToString();
            txtVolumeHoraire.Text = DgSyllabus.CurrentRow.Cells[3].Value.ToString();
            txtNiveauSyllabus.Text = DgSyllabus.CurrentRow.Cells[4].Value.ToString();

            if (DgSyllabus.SelectedRows.Count > 0)
            {
                // Récupérer l'ID de la ligne sélectionnée
                _selectedSyllabusId = Convert.ToInt32(DgSyllabus.SelectedRows[0].Cells["idSyllabus"].Value);

                // Charger les données dans les champs
                var syllab = db.Syllabuses.Find(_selectedSyllabusId);

                if (syllab != null)
                {
                    txtLibelle.Text = syllab.LibelleSyllabus;
                    txtDescription.Text = syllab.DescriptionSyllabus;
                    txtVolumeHoraire.Text = syllab.VolumeHoraireSyllabus?.ToString() ?? string.Empty;
                    txtNiveauSyllabus.Text = syllab.NiveauSyllabus;


                    // Activer les boutons Modifier et Supprimer
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                    btnAjouter.Enabled = false;
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            int? id = int.Parse(DgSyllabus.CurrentRow.Cells[0].Value.ToString());
            var a = db.Syllabuses.Find(id);
            a.LibelleSyllabus = txtLibelle.Text;
            a.DescriptionSyllabus = txtDescription.Text;
            a.VolumeHoraireSyllabus = int.TryParse(txtVolumeHoraire.Text, out int volume) ? volume : (int?)null;
            a.NiveauSyllabus = txtNiveauSyllabus.Text;
            db.SaveChanges();
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(DgSyllabus.CurrentRow.Cells[0].Value.ToString());
            var a = db.Syllabuses.Find(id);

            db.Syllabuses.Remove(a);
            db.SaveChanges();
            Effacer();
        }
    }
}
