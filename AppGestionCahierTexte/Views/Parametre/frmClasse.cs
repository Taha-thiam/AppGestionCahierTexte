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
    public partial class frmClasse : Form
    {
        BdCahierTexteContext db = new BdCahierTexteContext();
        private void Effacer()
        {
            txtLibelle.Text=string.Empty;
            cbbAnneeAcademique.Text=string.Empty;
            cbbAnneeAcademique.DataSource= db.AnneeAcademiques.ToList();
            cbbAnneeAcademique.DisplayMember = "LibelleAnneeAcademique";
            cbbAnneeAcademique.ValueMember = "ValueAnneeAcademique";
            DgClasse.DataSource = db.Classes.ToList();
            txtLibelle.Focus();
        }
        public frmClasse()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Classe c = new Classe();
            c.LibelleClasse = txtLibelle.Text;
            c.IdAnneeAcademique = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
            db.Classes.Add(c);
            db.SaveChanges();
            Effacer();
        }


        private void frmClasse_Load(object sender, EventArgs e)
        {
            Effacer();
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(DgClasse.CurrentRow.Cells[0].Value.ToString());
            var c = db.Classes.Find(id);
            c.LibelleClasse = txtLibelle.Text;
            c.IdAnneeAcademique = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
            db.SaveChanges();
            Effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(DgClasse.CurrentRow.Cells[0].Value.ToString());
            var c = db.Classes.Find(id);   
            db.Classes.Remove(c);
            db.SaveChanges();
            Effacer();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtLibelle.Text = DgClasse.CurrentRow.Cells[1].Value.ToString();
            cbbAnneeAcademique.SelectedValue = DgClasse.CurrentRow.Cells[2].Value;
        }
    }
}
