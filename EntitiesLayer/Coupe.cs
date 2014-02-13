using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Coupe : EntityObject
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
        public Coupe() { }

        public Coupe(int year, string label) 
        {
            this.year = year;
            this.Label = label;
        }

     
        public override string ToString(){
            return getId() + " : " + this.Label + " " + this.Year ;
        }
    }
}
