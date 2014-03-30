using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Web;
using System.Runtime.Serialization;

namespace WebService
{
    [DataContract]
    public class CoupeWS : EntityObjectWS
    {
        int year;
        [DataMember]
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        string label;
        [DataMember]
        public string Label
        {
            get { return label; }
            set { label = value; }
        }
        int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public CoupeWS(Coupe coupe) 
        {
            this.year = coupe.Year;
            this.Label = coupe.Label;
            this.id = coupe.Id;
        }
    }
}
