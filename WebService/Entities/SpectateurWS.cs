using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Runtime.Serialization;
namespace WebService{
    [DataContract]
    public class SpectateurWS : PersonneWS
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
        public SpectateurWS(Spectateur spectateur): base((Personne)spectateur)
        {
            this.Adresse = spectateur.Adresse;
            this.Email = spectateur.Email;
        }
    }
}
