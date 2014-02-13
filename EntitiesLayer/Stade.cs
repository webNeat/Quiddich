using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
        string adresse;
        string nom;
        int nombrePlaces;
        double pourcentageCommission;
        public string Nom
        {
             get;
             set;
        }
        public string Adresse
        {
            get;
            set;
        }
        public string Places
        {
            get;
            set;
        }
        public string Pourcentages
        {
            get;
            set;
        }

        Stade() { }
        public Stade(string adresse, string nom, int nbplaces, double poureCommission) 
        {
            this.adresse = adresse;
            this.nom = nom;
            this.nombrePlaces = nbplaces;
            this.pourcentageCommission = poureCommission;
        }

        public override string ToString()
        {
            return  nom ;
        }
    }
}
