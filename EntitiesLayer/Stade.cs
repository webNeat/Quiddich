using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
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
        public int Places
        {
            get;
            set;
        }
        public double Pourcentage
        {
            get;
            set;
        }

        Stade() { }
        public Stade(string adresse, string nom, int nbplaces, double poureCommission) 
        {
            this.Adresse = adresse;
            this.Nom = nom;
            this.Places = nbplaces;
            this.Pourcentage = poureCommission;
        }

        public override string ToString()
        {
            return  Nom;
        }
    }
}
