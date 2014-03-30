using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer;
using EntitiesLayer;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceQuiddich" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceQuiddich.svc ou ServiceQuiddich.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceQuiddich : IServiceQuiddich
    {
        private CoupeManager cm = new CoupeManager();
        
        public IList<CoupeWS> GetAllCoupes()
        {
            List<CoupeWS> result = new List<CoupeWS>();
            IList<Coupe> list = cm.allCoupes();
            foreach (Coupe coupe in list)
            {
                result.Add(new CoupeWS(coupe));
            }
            return result;
        }

        public IList<StadeWS> GetAllStades()
        {
            List<StadeWS> result = new List<StadeWS>();
            IList<Stade> list = cm.allStades();
            foreach(Stade stade in list)
            {
                result.Add(new StadeWS(stade));

            }
            return result;
        }

        public IList<EquipeWS> GetAllEquipes()
        {
            List<EquipeWS> result = new List<EquipeWS>();
            IList<Equipe> list = cm.allEquipes();
            foreach (Equipe equipe in list)
            {
                result.Add(new EquipeWS(equipe));

            }
            return result;
        }

        public IList<JoueurWS> GetJoueursOfEquipe(int id)
        {
            List<JoueurWS> result = new List<JoueurWS>();
            IList<Joueur> list = cm.getJoueursOfEquipe(id);
            foreach (Joueur joueur in list)
            {
                result.Add(new JoueurWS(joueur));

            }
            return result;
        }

        public IList<MatchWS> GetMatchesOfCoupe(int id)
        {
            List<MatchWS> result = new List<MatchWS>();
            IList<Match> list = cm.getMatchesByid(id);
            foreach (Match match in list)
            {
                result.Add(new MatchWS(match));

            }
            return result;
        }

        public int MakeReservation(int matchId, string nom, string prenom, DateTime dateNaissance, string adresse, string email, int numberPlaces)
        {/*
            Coupe coupe = cm.getCoupeById(matchId);
            IList<Match> matchs = cm.getMatchesByid(coupe.Id);
            Match match = null;
            foreach (Match m in matchs)
            {
                if(m.Id.Equals(matchId))
                     match = m;

            }
            cm.addReservation(numberPlaces, coupe.Id, dateNaissance, match.Prix, match.Stade, match.EquipeDomicile, match.EquipeVisiteur
                , match.ScoreDomicile, match.ScoreVisiteur, adresse, nom, prenom); */
            return 0;
      }

        public void CompleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public int CancelReservation(int id)
        {
            throw new NotImplementedException();
        }


        public void CreateUser(string nom, string prenom, string login, string password)
        {

            cm.addUtilisateur(new Utilisateur(nom, prenom, login, password));
        }

        public void CheckUser(string login, string password)
        {
            cm.Login(login, password);
        }
    }
}
