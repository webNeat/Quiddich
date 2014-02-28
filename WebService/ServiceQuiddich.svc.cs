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

        public IList<CoupeWS> GetAllStades()
        {
            throw new NotImplementedException();
        }

        public IList<CoupeWS> GetAllEquipes()
        {
            throw new NotImplementedException();
        }

        public IList<CoupeWS> GetJoueursOfEquipe(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CoupeWS> GetMatchesOfCoupe(int id)
        {
            throw new NotImplementedException();
        }

        public int MakeReservation(int matchId, string nom, string prenom, DateTime dateNaissance, string adresse, string email, int numberPlaces)
        {
            throw new NotImplementedException();
        }

        public void CompleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public int CancelReservation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
