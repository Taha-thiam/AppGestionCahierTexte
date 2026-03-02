using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionCahierTexte.Shared
{
    public static class Logger
    {
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Cahier de texte";
                eventLog.WriteEntry($"{libelle}: {erreur}", EventLogEntryType.Error);
            }
        }



        /// <summary>
        /// Rédiger le message d'erreur dans un fichier
        /// </summary>
        /// <param name="message">le message d'erreur</param>
        public static void WriteFileError(string message)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(basePath, "Error","erreur.txt");

                // Créer le répertoire s'il n'existe pas
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                System.IO.TextWriter writeFile = new StreamWriter(path, append: true);
                writeFile.WriteLine("" + DateTime.Now);
                writeFile.WriteLine(message);
                writeFile.WriteLine("--------------------------------------------------");
                writeFile.Flush();
                writeFile.Close();
            }
            catch (Exception ex)
            {
                // Éviter une boucle infinie si l'écriture échoue
                System.Diagnostics.Debug.WriteLine("Erreur lors de l'écriture du log : " + ex.Message);
            }
        }
    }
}
