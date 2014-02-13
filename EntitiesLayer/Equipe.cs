using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Equipe : EntityObject
    {
        List<Joueur> joueurs;
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

       public Equipe(string nom, string pays, List<Joueur> joueurs) 
        {
            this.nom = nom;
            this.pays = pays;
            this.joueurs = joueurs;
        }
       public Equipe(string nom, string pays)
       {
           this.nom = nom;
           this.pays = pays;
         
       }

       public Equipe(){}

        public override string ToString()
        {
            string s = nom + " " + pays;
            /*
            for (int i = 0; i < joueurs.Count();i++ )
            {
                s += joueurs[i].ToString();

            }
             */
            return s;
           
        }
        public List<Joueur> getJoueurs(){
            return joueurs;
        }
    }
}
