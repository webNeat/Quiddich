using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using StubDataAccessLayer;
using DAO;
namespace BusinessLayer
{
    public class CoupeManager
    {
       // private DalManager data;
        private IDAL data;

        public CoupeManager()
        {
            data = DALManager.GetInstance(DALProvider.SQLSERVER);
        }

        public IList<Equipe> allEquipes()
        {
            return data.getEquipes();
        }

        public IList<Equipe> allEquipeNames()
        {
            return data.getEquipeNames();
        }

        public IList<Joueur> allJoueurs()
        {
            return data.getJoueurs();
        }

        public IList<Coupe> allCoupes()
        {
            /*list<coupe> query = (list<coupe>)
                from c in coupes
                select c;*/
            return data.getCoupes();
        }

        public IList<Match> allMatchofCoupe(int idcoupe)
        {
            return data.getMatchesByid(idcoupe);
        }

        public void addCoupe(int year, string libelle)
        {
            data.addCoupe(new Coupe(year, libelle));


        }
        public void addJoueur(string nom, string prenom, int score, PosteJoueur poste, int slections)
        {
            data.addJoueur(new Joueur(slections, score, poste, new DateTime(), nom, prenom));
        }

        public void addStade(string nom, string adresse, int places, double p)
        {
            data.addStade(new Stade(adresse, nom, places, p));
        }

        public void deleteEquipe(Equipe equipe)
        {
            data.deleteEquipe(equipe);
        }
        public void deleteJoueur(Joueur joueur)
        {
            data.deleteJoueur(joueur);
        }
        public void deleteStade(Stade s)
        {
            data.deleteStade(s);
        }
        public void deleteCoupe(Coupe coupe)
        {
            data.deleteCoupe(coupe);
        }
        public void addEquipe(string nom, string pays)
        {
            data.addEquipe(new Equipe(nom, pays));

        }
        public void addMatch(int coupeId, DateTime date, double prix, Stade stade, Equipe equipeD, Equipe equipeV, int scoreD, int scoreV)
        {

            data.addMatch(new Match(coupeId, date, equipeD, equipeV, prix, scoreV, scoreD, stade));
        }
        public void deleteMatch(Match match)
        {
            data.deleteMatch(match);
        }
        public IList<Stade> allStades()
        {
            return data.getStades();
        }
        public IList<Match> allMatches()
        {
            return data.getMatchs();
        }

        public void updateMatch(Match m)
        {
            data.updateMatch(m);
        }

        public void updateJoueur(Joueur joueur)
        {
            data.updateJoueur(joueur);
        }

        public void updateStade(Stade stade)
        {
            data.updateStade(stade);
        }
        public void updateEquipe(Equipe equipe)
        {
            data.updateEquipe(equipe);
        }

        public Utilisateur Login(string login, string password)
        {
            Utilisateur user = data.getUtilisateurByLogin(login);
            if (user != null)
                if (user.getPassword().Equals(password))
                    return user;
            return null;
        }


        /*
         public static List<string> allCoupes(){

             List<Coupe> coupes = data.getCoupes();
             List<string> query = (List<string>)
                 from c in coupes
                 select c.ToString();
             return query;
         }
        */

        /*
     public List<string> matchesOf(int coupeId) {
         List<Match> matches = data.getMatches();
         List<string> query = (List<string>)
             from m in matches
             where m.getCoupeId() == coupeId
             select m.ToString();
         return query;
     }

     public List<string> stadeOf(int coupeId)
     {
         List<Match> matches = data.getMatches();
         List<Stade> stades = data.getStades();

         List<string> query = (List<string>)
                 from s in stades 
                 where (from m in matches where m.getStade() == s && m.getCoupeId() == coupeId select m).Count() > 0
                 select s.ToString();
         return query;
     }

     public List<string> joueursDomicleOf(int coupeId) {
         List<Match> matches = data.getMatches();
         List<Equipe> equipes = data.getEquipes();
         List<Joueur> joueurs = data.getJoueurs();

         List<string> query = (List<string>)
                 from j in joueurs
                 where j.Poste == PosteJoueur.Attrapeur &&
                 (from e in equipes
                  where (from m in matches where m.getCoupeId() == coupeId && m.getEquipeDomicile() == e select m).Count() > 0
                      && (from jj in e.getJoueurs() where jj == j select jj).Count() > 0
                  select e
                 ).Count() > 0
                 select j.ToString();
         return query;
            
     } */




    }
}