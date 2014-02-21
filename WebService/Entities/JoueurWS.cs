using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using EntitiesLayer;
namespace WebService
{
    [DataContract]
    public class JoueurWS : PersonneWS
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
        public JoueurWS(Joueur joueur): base((Personne)joueur)
        {
            NbSelections = joueur.NbSelections;
            Score = joueur.Score;
            Poste = (PosteJoueurWS)joueur.Poste;
        }
        
    }
}
