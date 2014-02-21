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
        public StadeWS(Stade stade ) 
        {
            this.Adresse = stade.Adresse;
            this.Nom = stade.Nom;
            this.Places = stade.Places;
            this.Pourcentage = stade.Pourcentage;
        }

    }
}
