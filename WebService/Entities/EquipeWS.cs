using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class EquipeWSWS : EntityObjectWS
    {
        List<JoueurWS> JoueurWSs;
        string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        string pays;

        public string Pays
        {
            get { return pays; }
            set { pays = value; }
        }

       public EquipeWS(string nom, string pays, List<JoueurWS> JoueurWSs) 
        {
            this.nom = nom;
            this.pays = pays;
            this.JoueurWSs = JoueurWSs;
        }
       public EquipeWS(string nom, string pays)
       {
           this.nom = nom;
           this.pays = pays;
         
       }

       public EquipeWS(){}

        public override string ToString()
        {
            string s = nom + " " + pays;
            /*
            for (int i = 0; i < JoueurWSs.Count();i++ )
            {
                s += JoueurWSs[i].ToString();

            }
             */
            return s;
           
        }
        public List<JoueurWS> getJoueurWSs(){
            return JoueurWSs;
        }
        public void setJoueurWSs(List<JoueurWS> JoueurWSs)
        {
            this.JoueurWSs = JoueurWSs;
        }
    }
}
