using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Match : EntityObject
    {
        int coupeId;
        public int CoupeId
        {
            get{
                return coupeId;
            }
            set 
            {
                coupeId = value;
            }
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
        Equipe equipeDomicile;
        public Equipe EquipeDomicile
        {
            get
            {
                return equipeDomicile;
            }
            set
            {
                equipeDomicile = value;
            }
        }
        Equipe equipeVisiteur;
        public Equipe EquipeVisiteur
        {
            get
            {
                return equipeVisiteur;
            }
            set
            {
                equipeVisiteur = value;
            }

        }
        double prix;
        public double Prix
        {
            get
            {
                return prix;
            }
            set
            {
                prix = value;
            }

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
        Stade stade;
        public Stade Stade
        {
            get
            {
                return stade;
            }
            set
            {
                stade = value;
            }

        }
        
        public Match(){}
        public Match(int coupeId, DateTime date, Equipe equipeDomicile, Equipe equipeVisiteur, double prix, int scoreVisiteur, int scoreDomicile, Stade stade) 
        {
            this.coupeId = coupeId;
            this.date = date;
            this.equipeDomicile = equipeDomicile;
            this.equipeVisiteur = equipeVisiteur;
            this.prix = prix;
            this.scoreDomicile = scoreDomicile;
            this.scoreVisiteur = scoreVisiteur;
            this.stade = stade;
        
        }

        public string ToString()
        {
            return "Match  | coupeId : " + coupeId + " | date :" + date + "Equipe Visiteur : " + equipeVisiteur.Nom + "Equipe Domicile : " + equipeDomicile.Nom + " prix : " + prix + "score D :" + scoreDomicile + " score v : " + scoreVisiteur + " stade : " +  stade.Nom;
        }

    }
}
