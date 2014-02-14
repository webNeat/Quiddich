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
        int nbplacesReserves;
        Spectateur spectateur;

        public Reservation() { }
    }
}
