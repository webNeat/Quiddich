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

        public Stade() { }
        public Stade(string nom, string adresse, int nbplaces, double poureCommission) 
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
