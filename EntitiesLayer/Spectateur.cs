using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Spectateur : Personne
    {
        public string Adresse
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public Spectateur() { }
        public Spectateur(string adresse, string email, DateTime dateNaissance, string nom, string prenom): base(dateNaissance, nom, prenom)
        {
            this.Adresse = adresse;
            this.Email = email;
        }
    }
}
