using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsManager
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>
        {
            new Contact{Nom="BAZAN", Prenom="Yannick" },
            new Contact{Nom="DUPONT", Prenom="Gérard" },
            new Contact{Nom="SMITH", Prenom="John", DateNaissance = new DateTime(1978,04,23) },
            new Contact{Nom="FOULT", Prenom="Anaïs" },
        };

        static void Main(string[] args)
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = AfficherMenu();
                switch (choix)
                {
                    case "1":
                        ListerContacts();
                        break;
                    case "2":
                        AjouterContact();
                        break;
                    case "3":
                        SupprimerContact();
                        break;
                    case "4":
                        TrierContacts();
                        break;
                    case "q":
                    case "Q":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, l'application va fermer...");
                        continuer = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Affiche le menu
        /// </summary>
        /// <returns>Retourne le choix de l'utilisateur.</returns>
        static string AfficherMenu()
        {
            Console.Clear();

            Console.WriteLine("MENU\n");
            Console.WriteLine("1. Liste des contacts");
            Console.WriteLine("2. Ajout d’un contact");
            Console.WriteLine("3. Suppression d’un contact");
            Console.WriteLine("4. Trier les contacts");
            Console.WriteLine("Q. Quitter");
            Console.Write("\nVotre choix: ");

            return Console.ReadLine();
        }

        static void ListerContacts()
        {
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS\n");

            AfficherListeContacts(contacts);

            Console.WriteLine();
            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        private static void AfficherListeContacts(IEnumerable<Contact> listeContacts)
        {
            OutilsConsole.AfficherChamp("NOM", 10);
            OutilsConsole.AfficherChamp("PRENOM", 10);
            OutilsConsole.AfficherChamp("EMAIL", 20);
            OutilsConsole.AfficherChamp("TELEPHONE", 10);
            OutilsConsole.AfficherChamp("DATE NAISSANCE", 10);
            Console.WriteLine();
            Console.WriteLine(new string('-', 75));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var contact in listeContacts)
            {
                OutilsConsole.AfficherChamp(contact.Nom, 10);
                OutilsConsole.AfficherChamp(contact.Prenom, 10);
                OutilsConsole.AfficherChamp(contact.Email, 20);
                OutilsConsole.AfficherChamp(contact.Telephone, 10);
                OutilsConsole.AfficherChamp(contact.DateNaissance?.ToShortDateString(), 10);
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void TrierContacts()
        {
            OutilsConsole.AfficherMessage(
                "Sur quel champ (1 pour le nom, 2 pour le prénom) ?",
                ConsoleColor.Yellow);
            var saisie = Console.ReadLine();
            byte tri;
            while (!byte.TryParse(saisie, out tri)
                || (tri < 1 || tri > 2))
            {
                OutilsConsole.AfficherMessageErreur("Choix inconnu. Recommence.");
                saisie = Console.ReadLine();
            }

            IEnumerable<Contact> contactsTries = null;
            switch (tri)
            {
                case 1:
                    contactsTries = contacts
                        .OrderBy(x => x.Nom)
                        .ToList();
                    break;

                case 2:
                    contactsTries = contacts
                        .OrderBy(x => x.Prenom)
                        .ToList();
                    break;
            }

            AfficherListeContacts(contactsTries);

            Console.WriteLine();
            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void AjouterContact()
        {
            Console.Clear();
            Console.WriteLine("AJOUT D'UN CONTACT\n");

            var contact = new Contact();
            contact.Nom = OutilsConsole.SaisirChaineObligatoire("Nom:");
            contact.Prenom = OutilsConsole.SaisirChaineObligatoire("Prénom:");

            Console.WriteLine("Email:");
            contact.Email = Console.ReadLine();

            Console.WriteLine("Téléphone:");
            contact.Telephone = Console.ReadLine();

            contact.DateNaissance = OutilsConsole.SaisirDate("Date de naissance:");

            contacts.Add(contact);

            Console.WriteLine("Contact ajouté !");

            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }


        static void SupprimerContact()
        {
            Console.Clear();
            Console.WriteLine("SUPPRESSION D'UN CONTACT\n");

            Console.Write("{0,-6} | ", "NUMERO");
            Console.Write("{0,-10} | ", "NOM");
            Console.Write("{0,-10} | ", "PRENOM");
            Console.WriteLine();
            Console.WriteLine(new string('-', 35));

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (var i = 0; i < contacts.Count; i++)
            {
                var contact = contacts[i];
                Console.Write("{0,-6} | ", i);
                Console.Write("{0,-10} | ", contact.Nom);
                Console.Write("{0,-10} | ", contact.Prenom);
                Console.WriteLine();
            }
            Console.ResetColor();

            Console.Write("Entre le numéro du contact à supprimer: ");
            var index = int.Parse(Console.ReadLine());

            if (index < contacts.Count)
            {
                contacts.RemoveAt(index);
                Console.WriteLine("Contact supprimé !");
            }
            else
            {
                Console.WriteLine("Numéro invalide !");
            }

            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
    }
}