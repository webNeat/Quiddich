using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DAO
{
    public interface IDAL
    {
        
        IList<Joueur> getJoueurs();
        IList<Equipe> getEquipes();
        IList<Equipe> getEquipeNames();
        IList<Stade> getStades();
        IList<Match> getMatchs();
        IList<Reservation> getReservations();
        IList<Coupe> getCoupes();
        IList<Match> getMatchesByid(int idCoupe);

        Coupe getCoupeById(int id);
        void addCoupe(Coupe coupe);
        void deleteCoupe(Coupe coupe);
        void updateCoupe(Coupe coupe);
        
        void addJoueur(Joueur joueur);
        void deleteJoueur(Joueur joueur);
        void updateJoueur(Joueur joueur);
        
        void addEquipe(Equipe equipe);
        void deleteEquipe(Equipe equipe);
        void updateEquipe(Equipe equipe);
        
        void addStade(Stade stade);
        void deleteStade(Stade stade);
        void updateStade(Stade stade);
        
        void addMatch(Match match);
        void deleteMatch(Match match);
        void updateMatch(Match m);

        Utilisateur getUtilisateurByLogin(string login);
    }
}
