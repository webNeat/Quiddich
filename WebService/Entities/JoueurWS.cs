using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class JoueurWS : Personne
    {
        private int nbSelections;
        public int NbSelections
        {
            get { return nbSelections; }
            set { nbSelections = value; }
        }
        private int EquipeWSId;

        public int EquipeWSID
        {
            get { return EquipeWSId; }
            set { EquipeWSId = value; }
        }

        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private PosteJoueurWS poste;
        public PosteJoueurWS Poste
        {
            get { return poste; }
            set { poste = value; }
        }
        public JoueurWS() { }
        public JoueurWS(int nb, int scor, PosteJoueurWS post, DateTime dateNaissance ,string nom, string prenom): base(dateNaissance, nom, prenom)
        {
            NbSelections = nb;
            Score = scor;
            Poste = post;
        }
        public string ToString()
        {
            return "JoueurWS " + base.ToString() + "  nbSelection : " + NbSelections + " score :" + Score + " poste : " + Poste;  
        }
    }
}
