using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace WebService
{
    public class MatchWS : EntityObjectWS
    {
        public int CoupeId
        {
            get;
            set;
        }
        DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }

        }
        public EquipeWS EquipeDomicile
        {
            get;
            set;
        }
        public EquipeWS EquipeVisiteur
        {
            get;
            set;
        }
        public double Prix
        {
            get;
            set;
        }
        int scoreDomicile;
        public int ScoreDomicile
        {
            get
            {
                return scoreDomicile;
            }
            set
            {
                scoreDomicile = value;
            }

        }
        int scoreVisiteur;
        public int ScoreVisiteur
        {
            get
            {
                return scoreVisiteur;
            }
            set
            {
                scoreVisiteur = value;
            }

        }
        StadeWS stadeWS;
        public StadeWS Stade
        {
            get;
            set;
        }

        public MatchWS(Match match) 
        {
            this.CoupeId = match.CoupeId;
            this.Date = match.Date;
            this.EquipeDomicile = new EquipeWS(match.EquipeDomicile);
            this.EquipeVisiteur = new EquipeWS(match.EquipeVisiteur);
            this.Prix = match.Prix;
           /*this.scoreDomicile = scoreDomicile;
            this.scoreVisiteur = scoreVisiteur;
            this.StadeWS = StadeWS;*/
        }

    }
}
