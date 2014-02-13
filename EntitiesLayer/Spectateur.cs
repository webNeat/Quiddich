using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Spectateur : Personne
    {
        string adresse;
        string email;
        public Spectateur() { }
        public Spectateur(string adresse, string email, DateTime dateNaissance, string nom, string prenom): base(dateNaissance, nom, prenom)
        {
            this.adresse = adresse;
            this.email = email;
        }
        public string ToString()
        {
            return "Spectatuer " + base.ToString() + " | adresse : " + adresse + " | email :" + email;
        }

    }
}
