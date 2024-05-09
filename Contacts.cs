using System;

namespace contacts

{
    public class Contact
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Cordonnes? cordonne { get; set; }

        public Contact() { }
        public Contact(string nom, string prenom, Cordonnes cordonneVar)
        {
            Nom = nom;
            Prenom = prenom;
            cordonne = cordonneVar;

        }

    }
}