using System;

namespace ContactsManager
{
    public class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime? DateNaissance { get; set; }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}