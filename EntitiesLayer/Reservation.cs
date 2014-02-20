using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Reservation : EntityObject
    {
        public Match MyMatch { get; set; }
        public Spectateur MySpectateur { get; set; }
        public int Places { get; set; }

        public Reservation() { }
        public Reservation( Match MyMatch, Spectateur MySpectateur, int Places) 
        {
            this.MyMatch = MyMatch;
            this.MySpectateur = MySpectateur;
            this.Places = Places;
        }
    }
}