using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Runtime.Serialization;
namespace WebService
{
    [DataContract]
    public abstract class PersonneWS : EntityObjectWS
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
   
        public PersonneWS(Personne personne)
        {
            DateNaissance = personne.DateNaissance;
            Nom = personne.Nom;
            Prenom = personne.Prenom;
        }
    }
}
