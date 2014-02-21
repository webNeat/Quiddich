using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class StadeWS : EntityObjectWS
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

        StadeWS() { }
        public StadeWS(string adresse, string nom, int nbplaces, double poureCommission) 
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
