using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;
using EntitiesLayer;
using DAO;
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

           foreach(DataRow row in table.Rows)
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
        
        public Equipe getEquipeFromRow(DataRow row)
        {

            Equipe equipe = new Equipe(Convert.ToString(row["Nom"]), Convert.ToString(row["Pays"]));
            equipe.Id = Convert.ToInt32(row["ID"]);

            List<Joueur> joueurs = new List<Joueur>();

            foreach(Joueur joueur in getJoueurs() )
            {
                if (joueur.EquipeID.Equals(equipe.Id))
                    joueurs.Add(joueur);
            }
            equipe.setJoueurs(joueurs);
            return equipe;
        
        }
        public IList<EntitiesLayer.Coupe> getCoupes()
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

            Coupe coupe = new Coupe(Convert.ToInt32(row["Annee"]), "Coupe" + Convert.ToInt32(row["Annee"]));
            coupe.Id = Convert.ToInt32(row["ID"]);
            return coupe;
        
        }

        public IList<Match> getMatchesByid(int idCoupe)
        {
            List<Match> matches = new List<Match>();
            foreach (Match match in getMatchs())
            {
                if (match.CoupeId.Equals(idCoupe))
                    matches.Add(match);
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

            Stade stade = new Stade(Convert.ToString(row["Adresse"]), Convert.ToString(row["Nom"]), Convert.ToInt32(row["NombrePlacesDisponibles"]), Convert.ToDouble(row["PourcentageCommision"]));
            stade.Id = Convert.ToInt32(row["ID"]);
            return stade;
        
        }
        public IList<Match> getMatchs()
        {
            List<Match> matches = new List<Match>();
            DataTable table = SelectElementByRequest("SELECT * FROM Matchs  WHERE ID = 5");

            foreach (DataRow row in table.Rows)
            {
                matches.Add(getMatcheFromRow(row));

            }
            return matches;
        }
        public Match getMatcheFromRow(DataRow row)
        {

            Match match = new Match(Convert.ToInt32(row["CoupeID"]), Convert.ToDateTime(row["Date"]), getEquipeByID(Convert.ToInt32(row["DomicileID"])), getEquipeByID(Convert.ToInt32(row["VisiteurID"])), 0, Convert.ToInt32(row["ScoreVisiteur"]), Convert.ToInt32(row["ScoreDomicile"]), getStadeByID(Convert.ToInt32(row["StadeID"])));
            match.Id = Convert.ToInt32(row["ID"]);
            return match;

        }
        public Equipe getEquipeByID(int equipeID)
        {
            foreach(Equipe equipe in getEquipes() )
            {
                if (equipe.Id.Equals(equipeID))
                    return equipe;
            }
            return null;
        }


        public Stade getStadeByID(int stadeID)
        {
            foreach(Stade stade in getStades() )
            {
                if (stade.Id.Equals(stadeID))
                    return stade;
            }
            return null;
        }
      
    

        public void addCoupe(Coupe coupe)
        {
            ExecuteElementByRequest("INSERT INTO Coupes VALUES(NULL , " +  coupe.Year + ")");
            
        }

        public void deleteCoupe(EntitiesLayer.Coupe coupe)
        {
            ExecuteElementByRequest("DELETE FROM Coupes WHERE ID = " + coupe.Id);
      
        }

        public void addJoueur(Joueur joueur)
        {
            //Colonne NO_IDENTITY
            int posteID = (int)joueur.Poste;
            ExecuteElementByRequest("INSERT INTO Joueurs VALUES(NULL , '" + joueur.Prenom + "','" + joueur.Nom + "','" + joueur.DateNaissance + "'," + joueur.EquipeID + "," + posteID + ",NULL)");

        }

        public void deleteJoueur(Joueur joueur)
        {
            ExecuteElementByRequest("DELETE FROM Joueurs WHERE ID = " + joueur.Id);

        }

        public void addStade(Stade stade)
        {
            // TODO
        }

        public void deleteStade(Stade stade)
        {
            // TODO
        }

        public void addEquipe(EntitiesLayer.Equipe equipe)
        {
            throw new NotImplementedException();
        }

        public void deleteEquipe(EntitiesLayer.Equipe equipe)
        {
            throw new NotImplementedException();
        }

        public EntitiesLayer.Utilisateur getUtilisateurByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
