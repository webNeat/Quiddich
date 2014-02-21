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
    public class ReservationWS : EntityObjectWS
    {
        public MatchWS MyMatch { get; set; }
        public SpectateurWS MySpectateurWS { get; set; }
        public int Places { get; set; }

        public ReservationWS( Reservation reservation) 
        {
            this.MyMatch = new MatchWS(reservation.MyMatch);
            this.MySpectateurWS = new SpectateurWS(reservation.MySpectateur);
            this.Places = reservation.Places;
        }
    }
}