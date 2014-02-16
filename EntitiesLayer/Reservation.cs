using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    class Reservation : EntityObject
    {
        Coupe MyCoupe { get; set; }
        Match MyMatch { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        string Adresse { get; set; }
        int Places { get; set; }
        double Prix { get; set; }
        Spectateur MySpectateur { get; set; }

        public Reservation() { }
        public Reservation( Coupe MyCoupe, Match MyMatch, string Nom, string Prenom, string Adresse, int Places, double Prix, Spectateur MySpectateur) 
        {
            this.MyCoupe = MyCoupe;
            this.MyMatch = MyMatch;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Adresse = Adresse;
            this.Places = Places;
            this.Prix = Prix;
            this.MySpectateur = MySpectateur;
        }
    }
}
