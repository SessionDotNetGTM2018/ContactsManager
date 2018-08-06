using System;
using System.Collections.Generic;

namespace ContactsManager
{
    class Program
    {
        static List<Contact> contacts = new List<Contact>();

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
            Console.WriteLine("4. Quitter");
            Console.Write("\nVotre choix: ");

            return Console.ReadLine();
        }

        static void ListerContacts()
        {
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS\n");

            Console.Write("{0,-10} | ", "NOM");
            Console.Write("{0,-10} | ", "PRENOM");
            Console.Write("{0,-20} | ", "EMAIL");
            Console.Write("{0,-10} | ", "TELEPHONE");
            Console.Write("{0,-10} | ", "DATE NAIS.");
            Console.WriteLine();
            Console.WriteLine(new string('-', 75));

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var contact in contacts)
            {
                Console.Write("{0,-10} | ", contact.Nom);
                Console.Write("{0,-10} | ", contact.Prenom);
                Console.Write("{0,-20} | ", contact.Email);
                Console.Write("{0,-10} | ", contact.Telephone);
                Console.Write("{0,-10} | ", contact.DateNaissance?.ToShortDateString());
                Console.WriteLine();
            }
            Console.ResetColor();

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