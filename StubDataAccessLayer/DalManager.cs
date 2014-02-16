using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager
    {
        List<Joueur> joueurs;
        List<Equipe> equipes;
        List<Stade> stades;
        List<Match> matches;
        List<Coupe> coupes;
        List<Utilisateur> utilisateurs;

        public DalManager(){
            Joueur joeur1 = new Joueur(5, 12, PosteJoueur.Gardien, new DateTime(1980, 2, 1), "amin", "ben hammou");
            Joueur joeur2 = new Joueur(2, 12, PosteJoueur.Poursuiveur, new DateTime(1978, 10, 11), "Nabil", "Zaini");
            Joueur joeur3 = new Joueur(8, 12, PosteJoueur.Attrapeur, new DateTime(1990, 11, 28), "mohamed", "el gadi");
            Joueur joeur4 = new Joueur(5, 12, PosteJoueur.Batteur, new DateTime(1982, 2, 1), "salim", "mouad");
            Joueur joeur5 = new Joueur(2, 12, PosteJoueur.Poursuiveur, new DateTime(1992, 9, 11), "ismail", "daraji");
            Joueur joeur6 = new Joueur(8, 12, PosteJoueur.Batteur, new DateTime(1991, 10, 28), "bilal", "nait");
            Joueur joeur7 = new Joueur(5, 12, PosteJoueur.Gardien, new DateTime(1983, 3, 1), "zakaria", "dkhissi");
            Joueur joeur8 = new Joueur(2, 12, PosteJoueur.Poursuiveur, new DateTime(1988, 10, 11), "youssef", "chakri");
            Joueur joeur9 = new Joueur(8, 12, PosteJoueur.Attrapeur, new DateTime(1989, 6, 28), "josef", "zeroual");
            Joueur joeur10 = new Joueur(5, 12, PosteJoueur.Attrapeur, new DateTime(1983, 4, 1), "mehdi", "alami");
            Joueur joeur11 = new Joueur(2, 12, PosteJoueur.Poursuiveur, new DateTime(1988, 5, 11), "ismail", "qasmi");
            Joueur joeur12 = new Joueur(8, 12, PosteJoueur.Attrapeur, new DateTime(1992, 9, 28), "mohamed", "sabir");
            Joueur joeur13 = new Joueur(5, 12, PosteJoueur.Gardien, new DateTime(1987, 2, 11), "amin", "moha");
            Joueur joeur14 = new Joueur(2, 12, PosteJoueur.Poursuiveur, new DateTime(1979, 10, 11), "Nabil", "lima");

            joueurs = new List<Joueur>();

            joueurs.Add(joeur1);
            joueurs.Add(joeur2);
            joueurs.Add(joeur3);
            joueurs.Add(joeur4);
            joueurs.Add(joeur5);
            joueurs.Add(joeur6);
            joueurs.Add(joeur7);
            joueurs.Add(joeur8);
            joueurs.Add(joeur9);
            joueurs.Add(joeur10);
            joueurs.Add(joeur11);
            joueurs.Add(joeur12);
            joueurs.Add(joeur13);
            joueurs.Add(joeur14);

            Equipe equipe1 = new Equipe("ASM", "France", joueurs.GetRange(0, 7));
            Equipe equipe2 = new Equipe("PSG", "France", joueurs.GetRange(7, 7));
            equipes = new List<Equipe>();
            equipes.Add(equipe1);
            equipes.Add(equipe2);


            Stade stade1 = new Stade("Stade Michelin", "Michelin", 45000, 45.6);
            Stade stade2 = new Stade("Saint denis", "Parc du Prince", 55000, 75.9);
            stades = new List<Stade>();
            stades.Add(stade1);
            stades.Add(stade2);

            Coupe coupe1 = new Coupe(2014,"Champions League");
            Coupe coupe2 = new Coupe(2013, "Ligue France");
            coupes = new List<Coupe>();
            coupes.Add(coupe1);
            coupes.Add(coupe2);
            Match match1 = new Match(coupe1.Id, new DateTime(2014, 2, 22), equipe1, equipe2, 458.48, 50, 14, stade1);
            Match match2 = new Match(coupe2.Id, new DateTime(2013, 2, 22), equipe2, equipe1, 458.48, 45, 66, stade2);
            matches = new List<Match>();
            matches.Add(match1);
            matches.Add(match2);



            Utilisateur user1 = new Utilisateur("zaini","nabil","nabil.zaini","123456");
            Utilisateur user2 = new Utilisateur("benhammo", "amin", "amin.benhamo", "875");
            Utilisateur user3 = new Utilisateur("el gadi", "momo", "momo.gadi", "7855");
            utilisateurs = new List<Utilisateur>();
            utilisateurs.Add(user1);
            utilisateurs.Add(user2);
            utilisateurs.Add(user3);


        }

        public void addCoupe(Coupe coupe)
        {
            coupes.Add(coupe);
        
        }

        public void deleteCoupe(Coupe coupe)
        {
            coupes.Remove(coupe);
        }
        public void addEquipe(Equipe equipe)
        {
            equipes.Add(equipe);
        }

        public void addJoueur(Joueur joueur ) 
        {
            joueurs.Add(joueur);
        }

        public void addStade(Stade s)
        {
            stades.Add(s);
        }

        public void deleteEquipe(Equipe equipe)
        {
            equipes.Remove(equipe);
        }
        public void deleteJoueur(Joueur joueur) 
        {
            joueurs.Remove(joueur);
        }
        public void deleteStade(Stade s)
        {
            stades.Remove(s);
        }
        public List<Match> getMatchesById(int idCoupe)
        {
            List<Match> matchsTmp = new List<Match>();
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].CoupeId == idCoupe)
                    matchsTmp.Add(matches[i]);
            
            }
            return matchsTmp;        
        }

        public Utilisateur getUtilisateurByLogin(string login)
        {

            for (int i = 0; i < utilisateurs.Count;i++ )
            {
                if (utilisateurs[i].getLogin().Equals(login))
                {
                    return utilisateurs[i]; 
                }
            }
            return null;
        }


        public List<Joueur> getJoueurs()
        {
            return joueurs;
        }
        public List<Equipe> getEquipes(){
            return equipes;
        }
        public List<Stade> getStades()
        { 
            return stades; 
        }        
        public List<Match> getMatches()
        {
            return matches;
        }
        public List<Coupe> getCoupes() {
            return coupes;
        }

    }
}
