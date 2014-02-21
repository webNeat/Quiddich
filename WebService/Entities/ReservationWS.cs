using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class ReservationWS : EntityObjectWS
    {
        public Match MyMatch { get; set; }
        public SpectateurWS MySpectateurWS { get; set; }
        public int Places { get; set; }

        public ReservationWS() { }
        public ReservationWS( Match MyMatch, SpectateurWS MySpectateurWS, int Places) 
        {
            this.MyMatch = MyMatch;
            this.MySpectateurWS = MySpectateurWS;
            this.Places = Places;
        }
    }
}