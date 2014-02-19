using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class DALSQLServer : IDAL
    {
        private string connection;
        public DALSQLServer(string connection) 
        {
            this.connection = connection;
        }

        private DataTable SelectElementByRequest(string request)
        {
            DataTable table = new DataTable();
            using (SqlConnection sqlconnection = new SqlConnection(connection))
            {
                SqlCommand commande = new SqlCommand(request, sqlconnection);
                SqlDataAdapter dataadapter = new SqlDataAdapter(commande);
                dataadapter.Fill(table);
            }
            return table;
        }

        private void ExecuteElementByRequest(string request)
        {
           using (SqlConnection sqlconnection = new SqlConnection(connection))
            {
                sqlconnection.Open();
                SqlCommand commande = new SqlCommand(request, sqlconnection);
                commande.ExecuteNonQuery();
                sqlconnection.Close();
            }
        }

        public IList<Joueur> getJoueurs()
        {
            List<Joueur> joueurs = new List<Joueur>();
            DataTable table = SelectElementByRequest("SELECT * FROM Joueurs");

            foreach (DataRow row in table.Rows)
            {
                joueurs.Add(getJoueurFromRow(row));
            }
            return joueurs;
        }

        public IList<Joueur> getJoueursOfEquipe(int equipeId)
        {
            List<Joueur> joueurs = new List<Joueur>();
            DataTable table = SelectElementByRequest("SELECT * FROM Joueurs WHERE EquipeID = " + equipeId);

            foreach (DataRow row in table.Rows)
            {
                joueurs.Add(getJoueurFromRow(row));
            }
            return joueurs;
        }

        private Joueur getJoueurFromRow(DataRow row)
        {
            PosteJoueur poste;
            switch(Convert.ToInt32(row["PosteID"])){
                case 0 : poste = PosteJoueur.Attrapeur;
                    break;
                case 1 : poste = PosteJoueur.Batteur; 
                    break;
                case 2 : poste = PosteJoueur.Gardien;
                    break;
                case 3 : poste = PosteJoueur.Poursuiveur; 
                        break;
                default :
                    poste = PosteJoueur.None;
                    break;
            }
            
            Joueur joueur = new Joueur(0, 0, poste, Convert.ToDateTime(row["DateNaissance"]),Convert.ToString(row["Nom"]), Convert.ToString(row["Prenom"]));
            joueur.EquipeID =  Convert.ToInt32(row["EquipeID"]);
            joueur.Id = Convert.ToInt32(row["ID"]);
            return joueur;
        }

        public IList<Equipe> getEquipes()
        {
            List<Equipe> equipes = new List<Equipe>();
            DataTable table = SelectElementByRequest("SELECT * FROM Equipes");
            foreach (DataRow row in table.Rows)
            {
                equipes.Add(getEquipeFromRow(row));
            }
            return equipes;
        }

        public IList<Equipe> getEquipeNames() {
            List<Equipe> equipes = new List<Equipe>();
            DataTable table = SelectElementByRequest("SELECT * FROM Equipes");
            foreach (DataRow row in table.Rows)
            {
                Equipe equipe = new Equipe(Convert.ToString(row["Nom"]), Convert.ToString(row["Pays"]));
                equipe.Id = Convert.ToInt32(row["ID"]);
                equipes.Add(equipe);
            }
            return equipes;
        }
        
        public Equipe getEquipeFromRow(DataRow row)
        {
            Equipe equipe = new Equipe(Convert.ToString(row["Nom"]), Convert.ToString(row["Pays"]));
            equipe.Id = Convert.ToInt32(row["ID"]);

            List<Joueur> joueurs = new List<Joueur>();

            foreach(Joueur joueur in getJoueursOfEquipe(equipe.Id) )
            {
                    joueurs.Add(joueur);
            }
            equipe.setJoueurs(joueurs);
            return equipe;
        }
        
        public IList<Coupe> getCoupes()
        {
            List<Coupe> coupes = new List<Coupe>();
            DataTable table = SelectElementByRequest("SELECT * FROM Coupes");
            foreach (DataRow row in table.Rows)
            {
                coupes.Add(getCoupeFromRow(row));
            }
            return coupes;   
        }
        
        public Coupe getCoupeFromRow(DataRow row)
        {
            Coupe coupe = new Coupe(Convert.ToInt32(row["Annee"]), Convert.ToString(row["Titre"]));
            coupe.Id = Convert.ToInt32(row["ID"]);
            return coupe;
        }

        public IList<Match> getMatchesByid(int idCoupe)
        {
            List<Match> matches = new List<Match>();
            DataTable table = SelectElementByRequest("SELECT * FROM Matchs WHERE CoupeID = " + idCoupe);
            foreach (DataRow row in table.Rows)
            {
                matches.Add(getMatcheFromRow(row));
            }
            return matches;
        }

        public IList<Stade> getStades()
        {
            List<Stade> stades = new List<Stade>();
            DataTable table = SelectElementByRequest("SELECT * FROM Stades");

            foreach (DataRow row in table.Rows)
            {
                stades.Add(getStadeFromRow(row));
            }
            return stades;
        }

        public Stade getStadeFromRow(DataRow row)
        {
            Stade stade = new Stade(
                Convert.ToString(row["Adresse"]), 
                Convert.ToString(row["Nom"]), 
                Convert.ToInt32(row["NombrePlacesDisponibles"]), 
                Convert.ToDouble(row["PourcentageCommision"])
            );
            stade.Id = Convert.ToInt32(row["ID"]);
            return stade;
        
        }
        public IList<Match> getMatchs()
        {
            List<Match> matches = new List<Match>();
            DataTable table = SelectElementByRequest("SELECT * FROM Matchs");

            foreach (DataRow row in table.Rows)
            {
                matches.Add(getMatcheFromRow(row));

            }
            return matches;
        }
        public Match getMatcheFromRow(DataRow row)
        {
            int dId = Convert.ToInt32(row["DomicileID"]);
            Match match = new Match(
                Convert.ToInt32(row["CoupeID"]), 
                Convert.ToDateTime(row["Date"]), 
                getEquipeByID(Convert.ToInt32(row["DomicileID"])), 
                getEquipeByID(Convert.ToInt32(row["VisiteurID"])), 
                0, 
                Convert.ToInt32(row["ScoreVisiteur"]), 
                Convert.ToInt32(row["ScoreDomicile"]), 
                getStadeByID(Convert.ToInt32(row["StadeID"]))
            );
            match.Id = Convert.ToInt32(row["ID"]);
            return match;

        }

        public Equipe getEquipeByID(int equipeID)
        {
            DataTable dt = SelectElementByRequest("SELECT * FROM Equipes WHERE ID = " + equipeID);
            if (dt.Rows.Count < 1)
                return null;
            Equipe equipe = new Equipe(Convert.ToString(dt.Rows[0]["Nom"]), Convert.ToString(dt.Rows[0]["Pays"]));
            equipe.Id = equipeID;
            return equipe;
        }


        public Stade getStadeByID(int stadeID)
        {
            DataTable dt = SelectElementByRequest("SELECT * FROM Stades WHERE ID = " + stadeID);
            if (dt.Rows.Count < 1)
                return null;
            DataRow row = dt.Rows[0];
            Stade stade = new Stade(Convert.ToString(row["Adresse"]), Convert.ToString(row["Nom"]), Convert.ToInt32(row["NombrePlacesDisponibles"]), Convert.ToDouble(row["PourcentageCommision"]));
            stade.Id = Convert.ToInt32(row["ID"]);
            return stade;
        }
      
    

        public void addCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("INSERT INTO Coupes (Annee, Titre) VALUES(" + coupe.Year + ", '"+ coupe.Label +"')");
            
        }
        public void updateCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("UPDATE  Coupes SET Annee = " + coupe.Year + ", Titre = '" + coupe.Label + "' WHERE ID = " + coupe.Id);      
        }

        public void deleteCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("DELETE FROM Coupes WHERE ID = " + coupe.Id);
      
        }

        public void addJoueur(Joueur joueur)
        {
            int posteID = (int)joueur.Poste;
            ExecuteElementByRequest("INSERT INTO Joueurs "
                + "( Prenom, Nom, DateNaissance, EquipeID, PosteID, Captaine )"
                +" VALUES('" + joueur.Prenom + "','" + joueur.Nom + "','" + joueur.DateNaissance + "'," + joueur.EquipeID + "," + posteID + ", 0)"
            );
        }

        public void deleteJoueur(Joueur joueur)
        {
            ExecuteElementByRequest("DELETE FROM Joueurs WHERE ID = " + joueur.Id);

        }
        public void addMatch(Match match)
        {
            ExecuteElementByRequest("INSERT INTO Matchs (CoupeID, StadeID, DomicileID, VisiteurID, ScoreDomicile, ScoreVisiteur, Date) VALUES(" 
                + match.CoupeId 
                + "," + match.Stade.Id 
                + "," + match.EquipeDomicile.Id 
                + "," + match.EquipeVisiteur.Id 
                + "," + match.ScoreDomicile 
                + "," + match.ScoreVisiteur 
                + ",'" + match.Date.Date.ToString("yyyy-MM-dd HH:mm:ss") + "')"
            );
        }

        public void deleteMatch(Match match)
        {
            ExecuteElementByRequest("DELETE FROM Matchs WHERE ID = " + match.Id);

        }
        public void updateMatch(Match match)
        {
            ExecuteElementByRequest("UPDATE Matchs SET"
                + " CoupeID = " + match.CoupeId
                + ", StadeID = " + match.Stade.Id
                + ", DomicileID = " + match.EquipeDomicile.Id
                + ", VisiteurID = " + match.EquipeVisiteur.Id
                + ", ScoreDomicile = " + match.ScoreDomicile
                + ", ScoreVisiteur =" + match.ScoreVisiteur
                + ", Date = '" + match.Date.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'"
                + " WHERE ID = " + match.Id
            );
        }
        public void addStade(Stade stade)
        {
            ExecuteElementByRequest("INSERT INTO Stades "
                + " (Nom, Adresse, NombrePlacesDisponibles, PourcentageCommision) "
                + " VALUES('" + stade.Nom + "','" + stade.Adresse + "'," + stade.Places + "," + stade.Pourcentage + ")");
        }

        public void deleteStade(Stade stade)
        {
            ExecuteElementByRequest("DELETE FROM Stades WHERE ID = " + stade.Id);
        }

        public void addEquipe(Equipe equipe)
        {
            ExecuteElementByRequest("INSERT INTO Equipes (Pays, Nom) VALUES('" + equipe.Pays + "','" + equipe.Nom + "')");
        }

        public void deleteEquipe(Equipe equipe)
        {
            ExecuteElementByRequest("DELETE FROM Equipes WHERE ID = " + equipe.Id);
        }

        public Utilisateur getUtilisateurByLogin(string login)
        {
            throw new NotImplementedException();
        }


        public void updateJoueur(Joueur joueur)
        {
               
        }

        public void updateEquipe(Equipe equipe)
        {
            throw new NotImplementedException();
        }

        public void updateStade(Stade stade)
        {
            throw new NotImplementedException();
        }
    }
}
