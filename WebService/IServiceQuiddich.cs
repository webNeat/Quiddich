using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceQuiddich" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceQuiddich
    {
        [OperationContract]
        IList<CoupeWS> GetAllCoupes();
        [OperationContract]
        IList<CoupeWS> GetAllEquipes();
        [OperationContract]
        IList<CoupeWS> GetJoueursOfEquipe(int id);
        [OperationContract]
        IList<CoupeWS> GetAllStades();
        [OperationContract]
        IList<CoupeWS> GetMatchesOfCoupe(int id);
        [OperationContract]
        int MakeReservation(int matchId, string nom, string prenom, DateTime dateNaissance, string adresse, string email, int numberPlaces);
        [OperationContract]
        void CompleteReservation(int id);
        [OperationContract]
        int CancelReservation(int id);
    }
}
