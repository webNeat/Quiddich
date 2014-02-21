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
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        string label;
        public string Label
        {
            get { return label; }
            set { label = value; }
        }
        public CoupeWS(Coupe coupe) 
        {
            this.year = coupe.Year;
            this.Label = coupe.Label;
        }
    }
}
