using AppGestionCahierTexte.Models;
using Microsoft.Reporting.WinForms;
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
    public partial class frmPrintMatiere : Form
    {
        public frmPrintMatiere()
        {
            InitializeComponent();
        }

        BdCahierTexteContext db = new BdCahierTexteContext();

        private void frmPrintMatiere_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                // ── Option 1 : ReportPath (fichier copié dans bin/Debug) ──────────
                reportViewer1.LocalReport.ReportPath = "Report\\rpListeMatiere.rdlc";

                // ── Données ───────────────────────────────────────────────────────
                var data = db.Matieres
                    .Select(m => new
                    {
                        m.libelleMatiere,
                        m.Niveau,
                        m.VolumeHoraireMatiere
                    })
                    .ToList();

                ReportDataSource rds = new ReportDataSource("DataSet1", data);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur rapport : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
