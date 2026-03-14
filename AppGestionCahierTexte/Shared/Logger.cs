using System;
using System.Diagnostics;
using System.IO;

namespace AppGestionCahierTexte.Shared
{
    public static class Logger
    {
        private static readonly string LogPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Error", "erreur.txt");

        /// <summary>
        /// Écrit un événement dans le journal Windows (Event Log).
        /// </summary>
        public static void WriteLogSystem(string message, string libelle)
        {
            try
            {
                using (var eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Cahier de texte";
                    eventLog.WriteEntry($"{libelle}: {message}", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur EventLog : {ex.Message}");
            }
        }

        /// <summary>
        /// Écrit un message d'erreur dans le fichier Error/erreur.txt.
        /// </summary>
        public static void WriteFileError(string message)
        {
            try
            {
                string directory = Path.GetDirectoryName(LogPath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                using (var writer = new StreamWriter(LogPath, append: true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteLine(message);
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erreur lors de l'écriture du log : {ex.Message}");
            }
        }
    }
}