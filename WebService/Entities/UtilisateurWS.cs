using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Runtime.Serialization;
namespace WebService
{   [DataContract]
    public class UtilisateurWS 
    {
        public string Nom { get; set; }    
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UtilisateurWS(Utilisateur user) {
            this.Nom = user.getNom();
            this.Prenom = user.getPrenom();
            this.Login = user.getLogin();
            this.Password = user.getPassword();
        }

    }
}
