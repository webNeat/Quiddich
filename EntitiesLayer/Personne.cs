using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class Personne : EntityObject
    {
        private DateTime dateNaissance;
        public System.DateTime DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }
        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private string prenom;
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public Personne()
        { }
        public Personne(DateTime d, string n, string p)
        {
            DateNaissance = d;
            Nom = n;
            Prenom = p;
        }
        public string ToString()
        {
            return "Nom : " + Nom + "  prenom :" + Prenom + " Date : " + DateNaissance;
        }


    }
}
