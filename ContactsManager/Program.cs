using System;
using System.Collections.Generic;

namespace ContactsManager
{
    class Program
    {
        static List<string> contacts = new List<string>();

        static void Main(string[] args)
        {
            AfficherMenu();
        }

        static void AfficherMenu()
        {
            Console.Clear();

            Console.WriteLine("MENU\n");
            Console.WriteLine("1. Liste des contacts");
            Console.WriteLine("2. Ajout d’un contact");
            Console.WriteLine("3. Suppression d’un contact");
            Console.WriteLine("4. Quitter");
            Console.Write("\nVotre choix: ");

            var choix = Console.ReadLine();
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
                    Quitter();
                    break;
                default:
                    Console.WriteLine("Choix invalide, l'application va fermer");
                    Quitter();
                    break;
            }
        }

        static void ListerContacts()
        {
            Console.Clear();
            Console.WriteLine("LISTE DES CONTACTS\n");

            foreach(var contact in contacts)
            {
                Console.WriteLine($"- {contact}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
            AfficherMenu();
        }

        static void AjouterContact()
        {
            Console.Clear();
            Console.WriteLine("AJOUT D'UN CONTACT\n");

            Console.WriteLine("Entre le nom:");
            var contact = Console.ReadLine();
            contacts.Add(contact);

            Console.WriteLine("Contact ajouté !");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
            AfficherMenu();
        }

        static void SupprimerContact()
        {
            Console.Clear();
            Console.WriteLine("SUPPRESSION D'UN CONTACT\n");

            for (var i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"- ({i}) {contacts[i]}");
            }

            Console.Write("Entre le numéro du contact à supprimer: ");
            var index = int.Parse(Console.ReadLine());

            if (index < contacts.Count)
            {
                contacts.RemoveAt(index);
                Console.WriteLine("Contact supprimé !");
            }
            else
            {
                Console.WriteLine("Impossible de supprimer le contact: index inconnu !");
            }

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
            AfficherMenu();
        }

        static void Quitter()
        {
            Environment.Exit(0);
        }
    }
}
