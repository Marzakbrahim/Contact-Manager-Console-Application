using System;

namespace contacts

{
    public class Cordonnes
    {
        public string Telephone { get; set; }
        public string Email { get; set; }
        public Cordonnes(string telephone = "No phone", string email = "No e-mail")
        {
            Telephone = telephone;
            Email = email;
        }
    }
}