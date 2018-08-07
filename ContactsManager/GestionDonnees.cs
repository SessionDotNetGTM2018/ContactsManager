using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactsManager
{
    public static class GestionDonnees
    {
        const string CheminFichier = "Contacts.txt";
        const char SeparateurChamps = ';';

        public static List<Contact> LireFichier()
        {
            var contacts = new List<Contact>();
            if (File.Exists(CheminFichier))
            {
                var lignes = File.ReadAllLines(CheminFichier);
                foreach (var ligne in lignes)
                {
                    var champs = ligne.Split(SeparateurChamps);

                    var contact = new Contact();
                    contact.Nom = champs[0];
                    contact.Prenom = champs[1];
                    contact.Email = champs[2];
                    contact.Telephone = champs[3];
                    contact.DateNaissance = string.IsNullOrEmpty(champs[4])
                                                ? (DateTime?)null
                                                : DateTime.Parse(champs[4]);

                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        public static void EcrireFichier(IEnumerable<Contact> contacts)
        {
            var contenuFichier = new StringBuilder();
            foreach (var contact in contacts)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            contact.Nom,
                                            contact.Prenom,
                                            contact.Email,
                                            contact.Telephone,
                                            contact.DateNaissance));
            }

            File.WriteAllText(CheminFichier, contenuFichier.ToString());
        }
    }
}
