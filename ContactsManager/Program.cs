using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    class Program
    {
        List<string> contacts = new List<string>();

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

            Console.WriteLine("TODO...");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
            AfficherMenu();
        }

        static void AjouterContact()
        {
            Console.Clear();
            Console.WriteLine("AJOUT D'UN CONTACT\n");

            Console.WriteLine("TODO...");

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
            AfficherMenu();
        }

        static void SupprimerContact()
        {
            Console.Clear();
            Console.WriteLine("SUPPRESSION D'UN CONTACT\n");

            Console.WriteLine("TODO...");

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
