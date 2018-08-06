using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    public static class OutilsConsole
    {
        /// <summary>
        /// Récupère la saisie d'une chaîne de caractères.
        /// Tant que la chaîne n'est pas fournie, la méthode redemande.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie non vide</returns>
        public static string SaisirChaineObligatoire(string message)
        {
            Console.WriteLine(message);
            var saisie = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(saisie))
            {
                AfficherMessageErreur("Champ requis. Recommence:");
                saisie = Console.ReadLine();
            }

            return saisie;
        }

        public static int? SaisirEntier(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();

            int entier = 0;
            while (!string.IsNullOrEmpty(saisie)
                    &&!int.TryParse(saisie, out entier))
            {
                AfficherMessageErreur("Saisie invalide. Recommence:");
                saisie = Console.ReadLine();
            }

            return string.IsNullOrEmpty(saisie)
                    ? (int?)null
                    : entier;
        }

        public static int SaisirEntierObligatoire(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();

            int entier = 0;
            while (string.IsNullOrEmpty(saisie)
                    ||!int.TryParse(saisie, out entier))
            {
                var messageErreur = string.IsNullOrEmpty(saisie)
                     ? "Champ obligatoire. Recommence:"
                     : "Saisie invalide. Recommence:";
                AfficherMessageErreur(messageErreur);
                saisie = Console.ReadLine();
            }

            return entier;
        }

        public static DateTime? SaisirDate(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();

            DateTime date = default(DateTime);
            while (!string.IsNullOrEmpty(saisie)
                    &&!DateTime.TryParse(saisie, out date))
            {
                AfficherMessageErreur("Saisie invalide. Recommence:");
                saisie = Console.ReadLine();
            }

            return string.IsNullOrEmpty(saisie)
                    ? (DateTime?)null
                    : date;
        }

        public static DateTime SaisirDateObligatoire(string message)
        {
            Console.WriteLine(message);
            string saisie = Console.ReadLine();

            DateTime date;
            while (string.IsNullOrEmpty(saisie)
                    ||!DateTime.TryParse(saisie, out date))
            {
                var messageErreur = string.IsNullOrEmpty(saisie)
                     ? "Champ obligatoire. Recommence:"
                     : "Saisie invalide. Recommence:";
                AfficherMessageErreur(messageErreur);
                saisie = Console.ReadLine();
            }

            return date;
        }

        public static void AfficherMessageErreur(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
