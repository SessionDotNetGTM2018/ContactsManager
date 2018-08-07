using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactsManager.DAL
{
    public class DonneesContact : IDonneesContact
    {
        const string CheminFichier = "Contacts.txt";
        const char SeparateurChamps = ';';

        private List<Contact> contacts;

        public IEnumerable<Contact> GetListe()
        {
            if (this.contacts == null)
            {
                LireFichier();
            }

            return this.contacts;
        }

        public void Enregistrer(Contact contact)
        {
            if (!this.contacts.Contains(contact))
            {
                this.contacts.Add(contact);
            }

            this.EcrireFichier();
        }

        public void Supprimer(Contact contact)
        {
            this.contacts.Remove(contact);
            this.EcrireFichier();
        }

        private void LireFichier()
        {
            this.contacts = new List<Contact>();
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
        }

        private void EcrireFichier()
        {
            var contenuFichier = new StringBuilder();
            foreach (var contact in this.contacts)
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
