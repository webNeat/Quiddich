using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    [ServiceContract]

    public interface IServiceQuiddich
    {
        [OperationContract]
        IList<CoupeWS> GetAllCoupes();
        [OperationContract]
        string Hello();
        [OperationContract]
        IList<EquipeWS> GetAllEquipes();
        [OperationContract]
        IList<JoueurWS> GetJoueursOfEquipe(int id);
        [OperationContract]
        IList<StadeWS> GetAllStades();
        [OperationContract]
        IList<MatchWS> GetMatchesOfCoupe(int id);
        [OperationContract]
        int MakeReservation(int matchId, string nom, string prenom, DateTime dateNaissance, string adresse, string email, int numberPlaces);
        [OperationContract]
        void CompleteReservation(int id);
        [OperationContract]
        int CancelReservation(int id);
        [OperationContract]
        void CreateUser(string nom, string prenom, string login, string password);
        [OperationContract]
        void CheckUser(string login, string password);

    }
}
