using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Joueur : Personne
    {
        private int nbSelections;
        public int NbSelections
        {
            get { return nbSelections; }
            set { nbSelections = value; }
        }
        private int equipeId;

        public int EquipeID
        {
            get { return equipeId; }
            set { equipeId = value; }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private PosteJoueur poste;
        public PosteJoueur Poste
        {
            get { return poste; }
            set { poste = value; }
        }
        public Joueur() { }
        public Joueur(int nb, int scor, PosteJoueur post, DateTime dateNaissance ,string nom, string prenom): base(dateNaissance, nom, prenom)
        {
            NbSelections = nb;
            Score = scor;
            Poste = post;
        }
        public string ToString()
        {
            return "Joueur " + base.ToString() + "  nbSelection : " + NbSelections + " score :" + Score + " poste : " + Poste;  
        }
    }
}
