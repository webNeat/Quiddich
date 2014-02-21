using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DAO
{
    public enum DALProvider
    {
        SQLSERVER,
        ORACLE
    }
    public class DALManager : IDAL
    {
        private static DALManager manager = null;
        private IDAL dal;
        public IDAL dataAccessLayer 
        {
            get { return dal; }
            set { dal = value; }
        }
        private DALManager(DALProvider provider) 
        {
            string connexion = @"Data Source=jwdaec5gna.database.windows.net;Initial Catalog=QuidditchWorldCup;Integrated Security=False;User ID=QuidditchWorldCups@jwdaec5gna;Password=&aqwXSZ2;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            switch(provider)
               {
                   case DALProvider.ORACLE :
                       break;
                   case DALProvider.SQLSERVER :
                       dataAccessLayer = new DALSQLServer(connexion);
                       break;
               } 
        }

        public static DALManager GetInstance(DALProvider provider)
        {
            if (manager == null)
                return manager = new DALManager(provider);
            else
                return manager;
        
        }

        public IList<Joueur> getJoueurs()
        {
            return dal.getJoueurs();
        }

        public IList<Equipe> getEquipes()
        {
            return dal.getEquipes();
        }

        public IList<Equipe> getEquipeNames()
        {
            return dal.getEquipeNames();
        }

        public IList<Stade> getStades()
        {
            return dal.getStades();
        }

        public IList<Match> getMatchs()
        {
            return dal.getMatchs();
        }

        public IList<Reservation> getReservations()
        {
            return dal.getReservations();
        }

        public IList<Coupe> getCoupes()
        {
            return dal.getCoupes();
        }

        public IList<Match> getMatchesByid(int idCoupe)
        {
            return dal.getMatchesByid(idCoupe);
        }

        public Coupe getCoupeById(int id)
        {
            return dal.getCoupeById(id);
        }

        public void addCoupe(Coupe coupe)
        {
            dal.addCoupe(coupe);
        }

        public void deleteCoupe(Coupe coupe)
        {
            dal.deleteCoupe(coupe);
        }

        public void addJoueur(Joueur joueur)
        {
            dal.addJoueur(joueur);
        }

        public void deleteJoueur(Joueur joueur)
        {
            dal.deleteJoueur(joueur);
        }

        public void addEquipe(Equipe equipe)
        {
            dal.addEquipe(equipe);
        }

        public void deleteEquipe(Equipe equipe)
        {
            dal.deleteEquipe(equipe);
        }

        public void addStade(Stade stade)
        {
            dal.addStade(stade);
        }

        public void deleteStade(Stade stade)
        {
            dal.deleteStade(stade);
        }

        public void addUtilisateur(Utilisateur user)
        {
            dal.addUtilisateur(user);
        }

        public Utilisateur getUtilisateurByLogin(string login, string password)
        {
            return dal.getUtilisateurByLogin(login, password);
        }

        public void addMatch(Match match)
        {
            dal.addMatch(match);
        }

        public void deleteMatch(Match match)
        {
            dal.deleteMatch(match);
        }

        public void updateMatch(Match m)
        {
            dataAccessLayer.updateMatch(m);
        }

        public void updateCoupe(Coupe coupe)
        {
            dal.updateCoupe(coupe);
        }

        public void updateJoueur(Joueur joueur)
        {
            dal.updateJoueur(joueur);
        }

        public void updateEquipe(Equipe equipe)
        {
            dal.updateEquipe(equipe);
        }

        public void updateStade(Stade stade)
        {
            dal.updateStade(stade);
        }
      
    }
}
