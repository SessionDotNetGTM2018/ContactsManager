using System;

namespace ContactsManager.Application
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

        /// <summary>
        /// Récupère la saisie sous forme d'entier.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie convertie en entier si renseignée, null autrement.</returns>
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

        /// <summary>
        /// Récupère la saisie sous forme d'entier.
        /// Tant que la saisie est vide ou invalide, la méthode redemande.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie convertie en entier.</returns>
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

        /// <summary>
        /// Récupère la saisie sous forme de date.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie convertie en date si renseignée, null autrement.</returns>
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

        /// <summary>
        /// Récupère la saisie sous forme de date.
        /// Tant que la saisie est vide ou invalide, la méthode redemande.
        /// </summary>
        /// <param name="message">Message à afficher sur la console</param>
        /// <returns>Renvoie la saisie convertie en date.</returns>
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

        /// <summary>
        /// Affiche un message d'erreur sur la console.
        /// </summary>
        /// <param name="message">Message à afficher</param>
        public static void AfficherMessageErreur(string message)
        {
            AfficherMessage(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Affiche un message d'erreur sur la console de la couleur voulue.
        /// </summary>
        /// <param name="message">Message à afficher</param>
        /// <param name="couleur">Couleur à utiliser (gris par défaut)</param>
        public static void AfficherMessage(
            string message, 
            ConsoleColor couleur = ConsoleColor.Gray)
        {
            Console.ForegroundColor = couleur;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Affiche un texte à la longueur fournie.
        /// Si le texte est plus long, il sera tronqué.
        /// S'il est plus court, il sera complété par des espaces.
        /// </summary>
        /// <param name="texte">Texte à afficher</param>
        /// <param name="longueurAffichage">Longueur d'affichage</param>
        public static void AfficherChamp(string texte, int longueurAffichage)
        {
            texte = (texte ?? string.Empty);

            // Si le texte est plus long que la longueur d'affichage,
            //  on le tronque
            texte = texte.Substring(0, Math.Min(texte.Length, longueurAffichage));
            Console.Write($"{texte.PadRight(longueurAffichage)} | ");
        }

        /// <summary>
        /// Affiche un message indiquant qu'en appuyant sur une touche,
        /// l'utilisateur va être redirigé vers le menu.
        /// </summary>
        public static void AfficherRetourMenu()
        {
            Console.WriteLine();
            AfficherMessage(
                "\n > Appuie sur une touche pour revenir au menu...",
                ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
