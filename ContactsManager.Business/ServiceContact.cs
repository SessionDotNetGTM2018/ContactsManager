using System;
using System.Collections.Generic;
using System.Linq;
using ContactsManager.DAL;

namespace ContactsManager.Business
{
    public class ServiceContact : IServiceContact
    {
        private readonly IDonneesContact donnees;

        public ServiceContact()
        {
            this.donnees = new DonneesContact();
        }

        public void CreerContact(Contact contact)
        {
            if (contact == null)
            {
                throw new BusinessException("Aucun contact n'a été fourni");
            }

            if (string.IsNullOrWhiteSpace(contact.Nom))
            {
                throw new BusinessException("Le nom est requis");
            }

            if (string.IsNullOrWhiteSpace(contact.Prenom))
            {
                throw new BusinessException("Le prénom est requis");
            }

            this.donnees.Enregistrer(contact);
        }

        public void SupprimerContact(Contact contact)
        {
            if (contact == null)
            {
                throw new BusinessException("Aucun contact n'a été fourni");
            }

            this.donnees.Supprimer(contact);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return this.donnees.GetListe();
        }

        public IEnumerable<Contact> ChercherContacts(string texte)
        {
            if (string.IsNullOrWhiteSpace(texte))
            {
                return this.donnees.GetListe();
            }

            return this.donnees.GetListe()
                .Where(x => x.Prenom.StartsWith(texte, StringComparison.OrdinalIgnoreCase)
                            || x.Nom.StartsWith(texte, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
