using System.Collections.Generic;
using ContactsManager.DAL;

namespace ContactsManager.Business
{
    public interface IServiceContact
    {
        IEnumerable<Contact> ChercherContacts(string texte);

        void CreerContact(Contact contact);

        IEnumerable<Contact> GetContacts();

        void SupprimerContact(Contact contact);
    }
}