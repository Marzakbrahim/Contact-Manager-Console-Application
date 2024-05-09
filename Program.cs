using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace contacts
{
    class Program
    {

        private static List<Contact> contacts = new List<Contact>();
        private static string commande = null;
        private static string tel = " ";
        private static string email = " ";
        private static string choose;
        private static bool saisieValide= false;
        private const string emailPattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
        private const string phonePattern = @"^\+\d+$";
        static void Main(string[] args)
        {
            while (commande != "0")
            {
                Menu();
            }
        }

        private static void CreerContact()
        {
            string nom = " ";
            string prenom = " ";

            Console.WriteLine("Entrez un nom");
            nom = Console.ReadLine().ToUpper();

            Console.WriteLine("Entrez un prenom");
            prenom = Console.ReadLine();
            //string prenom2 = prenom.Concat(prenom[0].ToString().ToUpper(), prenom.ToLower().AsSpan(1));
            string prenom2 = char.ToUpper(prenom[0]) + prenom.ToLower().Substring(1);

            // La saisie de numéro de téléphone :
            while (!saisieValide)
            {
                Console.WriteLine("Entrez le num si vous voulez, ou 'No phone' sinon.");
                tel = Console.ReadLine();
                if (Regex.IsMatch(tel, phonePattern) || tel == "No phone")
                {
                    saisieValide = true;
                }
                else { Console.WriteLine("Votre saisie est invalide ! réessayer."); }
            }
            // la saisie de l'adresse mail :
            saisieValide = false;
            while (!saisieValide)
            {
                Console.WriteLine("Entrez le mail si vous voulez, ou No e-mail sinon.");
                email = Console.ReadLine();
                if(Regex.IsMatch(email, emailPattern) || email== "No e-mail")
                {
                    saisieValide = true;
                }
                else { Console.WriteLine("Votre saisie est invalide ! réessayer."); }
            }
            
            Contact actuelContact = new Contact();

            Cordonnes cordonnes = new Cordonnes(tel, email);
            actuelContact = new Contact(nom, prenom2, cordonnes);

            contacts.Add(actuelContact);
        }


        private static void SupprimerContact()
        {

            Console.WriteLine("Entrer le nom ou le prenom du contact à supprimer : ");
            string nomOuPrenom = Console.ReadLine();
            while(choose != "Q" && choose != "Y")
            {
                Console.WriteLine("Vous voulez vraiment supprimer ce contact ? (Tapez Y si oui ou Q pour quitter)");
                choose = Console.ReadLine();
                if (choose == "Y")
                {
                    Contact toDelete = null;
                    foreach (Contact Elem in contacts)
                    {
                        if (Elem.Nom.ToLower() == nomOuPrenom.ToLower() || Elem.Prenom.ToLower() == nomOuPrenom.ToLower())
                        {
                            toDelete = Elem;
                        }
                    }
                    if (toDelete != null)
                    { contacts.Remove(toDelete); }
                    else { Console.WriteLine("Ce contact n'existe pas dans la liste des contacts."); }
                }
                else if (choose == "Q") { Console.WriteLine("Au revoir !"); }
                else
                {
                    Console.WriteLine("Nous n'avons pas compris votre choix, réessayer svp !");
                }
            }
        }

        private static void MettreAJourContact()
        {
            Console.WriteLine("Entrez le nom ou le prenom que tu veux changer :");
            string nomOuPrenom = Console.ReadLine();
            Console.WriteLine("Entrez le nouveau nom ou prenom :");
            string newNomOuPrenom = Console.ReadLine();
            foreach (Contact elem in contacts)
            {
                if (elem.Nom == nomOuPrenom)
                {
                    elem.Nom = newNomOuPrenom;
                }
                if (elem.Prenom == nomOuPrenom)
                {
                    elem.Prenom = newNomOuPrenom;
                }
            }
        }

        private static void RechercherContact()
        {
            Console.WriteLine("Entrez le nom ou le prenom que tu cherches :");
            string nomOuPrenom = Console.ReadLine();
            foreach (Contact elem in contacts)
            {
                if (elem.Nom.ToLower() == nomOuPrenom.ToLower() || elem.Prenom.ToLower() == nomOuPrenom.ToLower())
                {
                    Console.WriteLine("C'est trouvé !");
                    Console.WriteLine("Le nom :" + elem.Nom);
                    Console.WriteLine("Le prenom :" + elem.Prenom);
                }

            }
        }

        private static void AfficherContacts()
        {
            foreach (Contact elem in contacts)
            {
                Console.Write($"le nom complet : {elem.Nom} {elem.Prenom} ");
                Console.WriteLine($" //// Le tel : {elem.cordonne.Telephone} ; //// l'adresse mail : {elem.cordonne.Email} ");
            }

        }
        private static void AjouterCoordonees()
        {
            Cordonnes cordonne = new Cordonnes();
            Console.WriteLine("Tapez le nom ou le prenom du contact ");
            string contactRecherche = Console.ReadLine();
            foreach (Contact elem in contacts)
            {
                if (elem.Nom.ToLower() == contactRecherche.ToLower() || elem.Prenom.ToLower() == contactRecherche.ToLower())
                {
                    Console.WriteLine("Tapez le numéro de téléphone ");
                    string num = Console.ReadLine();
                    Console.WriteLine("Tapez l'adresse mail du contact ");
                    string email = Console.ReadLine();
                    cordonne.Email = email;
                    cordonne.Telephone = num;
                    elem.cordonne = cordonne;
                    Console.WriteLine("Le contact :" + elem.Nom + " " + elem.Prenom + " " + elem.cordonne.Email + " " + elem.cordonne.Telephone);
                    break;
                }
                else
                {
                    Console.WriteLine("On n'a pas trouvé ce contact !");
                }
            }




        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Taper 0 pour sortir");
            Console.WriteLine("Taper 1 pour ajouter contact");
            Console.WriteLine("Taper 2 pour Supprimer contact");
            Console.WriteLine("Taper 3 pour modifier contact");
            Console.WriteLine("Taper 4 pour chercher un contact");
            Console.WriteLine("Taper 5 pour ajouter des coordonées à un contact");
            Console.WriteLine("Taper 6 pour afficher les contact");
            Console.WriteLine("---------------------------------------------------------");
            commande = Console.ReadLine();
            switch (commande)
            {
                case "0":
                    Console.WriteLine("Au revoir !");
                    break;
                case "1":
                    CreerContact();
                    break;
                case "2":
                    SupprimerContact();
                    break;
                case "3":
                    MettreAJourContact();
                    break;
                case "4":
                    RechercherContact();
                    break;
                case "5":
                    AjouterCoordonees();
                    break;
                case "6":
                    AfficherContacts();
                    break;
            }
            Console.ReadKey();
        }
    }
}