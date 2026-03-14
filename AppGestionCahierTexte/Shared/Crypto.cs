using System;
using System.Security.Cryptography;
using System.Text;

namespace AppGestionCahierTexte.Shared
{
    public static class Crypto
    {
        /// <summary>
        /// Retourne le hash MD5 hexadécimal d'une chaîne UTF-8.
        /// </summary>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        /// <summary>
        /// Vérifie qu'une chaîne correspond à un hash MD5 (insensible à la casse).
        /// </summary>
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfInput, hash) == 0;
        }

        /// <summary>
        /// Raccourci : hash MD5 sans avoir à instancier MD5 soi-même.
        /// </summary>
        public static string Hash(string input)
        {
            using (var md5 = MD5.Create())
                return GetMd5Hash(md5, input);
        }

        /// <summary>
        /// Raccourci : vérification MD5 sans avoir à instancier MD5 soi-même.
        /// </summary>
        public static bool Verify(string input, string hash)
        {
            using (var md5 = MD5.Create())
                return VerifyMd5Hash(md5, input, hash);
        }
    }
}