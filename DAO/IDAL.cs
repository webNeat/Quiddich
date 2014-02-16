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
        IList<Stade> getStades();
        IList<Match> getMatchs();
        IList<Coupe> getCoupes();
        IList<Match> getMatchesByid(int idCoupe);
        void addCoupe(Coupe coupe);
        void deleteCoupe(Coupe coupe);
        void addJoueur(Joueur joueur);
        void deleteJoueur(Joueur joueur);
        void addEquipe(Equipe equipe);
        void deleteEquipe(Equipe equipe);
        void addStade(Stade stade);
        void deleteStade(Stade stade);
        Utilisateur getUtilisateurByLogin(string login);

    }
}
