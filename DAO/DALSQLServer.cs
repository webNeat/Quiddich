using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
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

        public Coupe getCoupeById(int id)
        {
            DataTable table = SelectElementByRequest("SELECT * FROM Coupes WHERE ID = " + id);
            if(table.Rows.Count < 1)
                return null;
            return getCoupeFromRow(table.Rows[0]);
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

        public IList<Reservation> getReservations()
        {
            List<Reservation> res = new List<Reservation>();
            DataTable table = SelectElementByRequest("SELECT * FROM Reservations");

            foreach (DataRow row in table.Rows)
            {
                res.Add(getReservationFromRow(row));
            }
            return res;
        }

        public Reservation getReservationFromRow(DataRow row)
        {
            Reservation r = new Reservation(
                getMatchByID(Convert.ToInt32(row["MatcheID"])),
                getSpectateurByID(Convert.ToInt32(row["SpectateurID"])),
                Convert.ToInt32(row["NombrePlacesReservees"]));
            r.Id = Convert.ToInt32(row["ID"]);
            return r;
        }

        public Spectateur getSpectateurFromRow(DataRow row)
        {
            Spectateur s = new Spectateur(
                Convert.ToString(row["Adresse"]),
                Convert.ToString(row["EMail"]),
                Convert.ToDateTime(row["DateNaissance"]),
                Convert.ToString(row["Nom"]),
                Convert.ToString(row["Prenom"])
            );
            s.Id = Convert.ToInt32(row["ID"]);
            return s;
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
        public Match getMatchByID(int id)
        {
            DataTable dt = SelectElementByRequest("SELECT * FROM Matchs WHERE ID = " + id);
            if (dt.Rows.Count < 1)
                return null;
            DataRow row = dt.Rows[0];
            return getMatcheFromRow(row);
        }

        public Spectateur getSpectateurByID(int id)
        {
            DataTable dt = SelectElementByRequest("SELECT * FROM Spectateurs WHERE ID = " + id);
            if (dt.Rows.Count < 1)
                return null;
            DataRow row = dt.Rows[0];
            return getSpectateurFromRow(row);
        }
        public void addCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("INSERT INTO Coupes (Annee, Titre) VALUES(" + coupe.Year + ", '"+ coupe.Label +"')");
            
        }

        public void deleteCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("DELETE FROM Coupes WHERE ID = " + coupe.Id);
      
        }

        public void updateCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("UPDATE  Coupes SET Annee = " + coupe.Year + ", Titre = '" + coupe.Label + "' WHERE ID = " + coupe.Id);
        }

        public void addJoueur(Joueur joueur)
        {
            int posteID = (int)joueur.Poste;
            ExecuteElementByRequest("INSERT INTO Joueurs "
                + "( Prenom, Nom, DateNaissance, EquipeID, PosteID, Capitaine )"
                + " VALUES('" + joueur.Prenom + "','" + joueur.Nom + "','" + joueur.DateNaissance.Date.ToString("yyyy-MM-dd") + "'," + joueur.EquipeID + "," + posteID + ", 0)"
            );
        }

        public void deleteJoueur(Joueur joueur)
        {
            ExecuteElementByRequest("DELETE FROM Joueurs WHERE ID = " + joueur.Id);

        }

        public void updateJoueur(Joueur joueur)
        {
            int postID = (int)joueur.Poste; 
            ExecuteElementByRequest("UPDATE Joueurs SET"
               + " Prenom = '" + joueur.Prenom + "'"
               + ", Nom = '" + joueur.Nom + "'"
               + ", DateNaissance = '" + joueur.DateNaissance.Date.ToString("yyyy-MM-dd HH:mm:ss") + "'"
               + ", EquipeID = " + joueur.EquipeID
               + ", PosteID = " + postID
               + ", Capitaine = 0 "  
                + " WHERE ID = " + joueur.Id
           );
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
        
        public void updateStade(Stade stade)
        {
            ExecuteElementByRequest("UPDATE Stades SET"
               + " Nom = '" + stade.Nom + "'"
               + ", Adresse = '" + stade.Adresse+ "'"
               + ", NombrePlacesDisponibles = " + stade.Places
               + ", PourcentageCommision = " + stade.Pourcentage
                + " WHERE ID = " + stade.Id
           );
        }

        public void addEquipe(Equipe equipe)
        {
            ExecuteElementByRequest("INSERT INTO Equipes (Pays, Nom) VALUES('" + equipe.Pays + "','" + equipe.Nom + "')");
        }

        public void deleteEquipe(Equipe equipe)
        {
            ExecuteElementByRequest("DELETE FROM Equipes WHERE ID = " + equipe.Id);
        }

        public void updateEquipe(Equipe equipe)
        {
            ExecuteElementByRequest("UPDATE Equipes SET"
               + " Pays = '" + equipe.Pays + "'"
               + ", Nom = '" + equipe.Nom + "'"
               + " WHERE ID = " + equipe.Id
           );
        }

        private string HashPassword(string password)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashPassword = sha1.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder value = new StringBuilder();
            for (int i = 0; i < hashPassword.Length; i++ )
            {
                value.Append(hashPassword[i].ToString());

            }
            return value.ToString();
        }

        public void addUtilisateur(Utilisateur utilisateur)
        {
            string login = utilisateur.getLogin();

           ExecuteElementByRequest("INSERT INTO Utilisateur (Login, Password) VALUES('"
                + login + "','" 
                + HashPassword(utilisateur.getPassword())
                + "')");
        }
        public Utilisateur getUtilisateurByLogin(string login, string password)
        {
            DataTable dt = SelectElementByRequest("SELECT * FROM Utilisateur WHERE Password = '" + HashPassword(password) + "' AND Login = '" + login + "'" );

            if (dt.Rows.Count < 1)
                return null;
            DataRow row = dt.Rows[0];
            Utilisateur user = new Utilisateur("", "", Convert.ToString(row["Login"]), Convert.ToString(row["Password"])); 
            return user;
        }
    }
}
