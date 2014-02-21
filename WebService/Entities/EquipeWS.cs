using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace WebService
{
    [DataContract]
    public class EquipeWS : EntityObjectWS
    {
       
        string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        string pays;

        public string Pays
        {
            get { return pays; }
            set { pays = value; }
        }

       public EquipeWS(Equipe equipe) 
        {
            this.nom = equipe.Nom;
            this.pays = equipe.Pays;
            
        }
       
    }
}
