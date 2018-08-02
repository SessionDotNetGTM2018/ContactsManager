using System;
using System.Collections.Generic;

namespace ContactsManager
{
    class Program
    {
        static List<string> contacts = new List<string>();

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

        static string AfficherMenu()
        {
            bool continuerExecution = true;
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

            foreach(var contact in contacts)
            {
                Console.WriteLine($"- {contact}");
            }

            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void AjouterContact()
        {
            Console.Clear();
            Console.WriteLine("AJOUT D'UN CONTACT\n");

            Console.WriteLine("Entre le nom:");
            var contact = Console.ReadLine();
            contacts.Add(contact);

            Console.WriteLine("Contact ajouté !");

            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        static void SupprimerContact()
        {
            Console.Clear();
            Console.WriteLine("SUPPRESSION D'UN CONTACT\n");

            for (var i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"- {contacts[i]} ({i})");
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
                Console.WriteLine("Numéro invalide !");
            }

            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
        }
    }
}
