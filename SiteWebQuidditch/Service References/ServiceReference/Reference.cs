﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.17929
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteWebQuidditch.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CoupeWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class CoupeWS : SiteWebQuidditch.ServiceReference.EntityObjectWS {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LabelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int YearField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Label {
            get {
                return this.LabelField;
            }
            set {
                if ((object.ReferenceEquals(this.LabelField, value) != true)) {
                    this.LabelField = value;
                    this.RaisePropertyChanged("Label");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Year {
            get {
                return this.YearField;
            }
            set {
                if ((this.YearField.Equals(value) != true)) {
                    this.YearField = value;
                    this.RaisePropertyChanged("Year");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityObjectWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.EquipeWS))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.PersonneWS))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.JoueurWS))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.StadeWS))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.MatchWS))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.CoupeWS))]
    public partial class EntityObjectWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EquipeWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class EquipeWS : SiteWebQuidditch.ServiceReference.EntityObjectWS {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonneWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SiteWebQuidditch.ServiceReference.JoueurWS))]
    public partial class PersonneWS : SiteWebQuidditch.ServiceReference.EntityObjectWS {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JoueurWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class JoueurWS : SiteWebQuidditch.ServiceReference.PersonneWS {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StadeWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class StadeWS : SiteWebQuidditch.ServiceReference.EntityObjectWS {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MatchWS", Namespace="http://schemas.datacontract.org/2004/07/WebService")]
    [System.SerializableAttribute()]
    public partial class MatchWS : SiteWebQuidditch.ServiceReference.EntityObjectWS {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IServiceQuiddich")]
    public interface IServiceQuiddich {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetAllCoupes", ReplyAction="http://tempuri.org/IServiceQuiddich/GetAllCoupesResponse")]
        SiteWebQuidditch.ServiceReference.CoupeWS[] GetAllCoupes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetAllCoupes", ReplyAction="http://tempuri.org/IServiceQuiddich/GetAllCoupesResponse")]
        System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.CoupeWS[]> GetAllCoupesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/Hello", ReplyAction="http://tempuri.org/IServiceQuiddich/HelloResponse")]
        string Hello();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/Hello", ReplyAction="http://tempuri.org/IServiceQuiddich/HelloResponse")]
        System.Threading.Tasks.Task<string> HelloAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetAllEquipes", ReplyAction="http://tempuri.org/IServiceQuiddich/GetAllEquipesResponse")]
        SiteWebQuidditch.ServiceReference.EquipeWS[] GetAllEquipes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetAllEquipes", ReplyAction="http://tempuri.org/IServiceQuiddich/GetAllEquipesResponse")]
        System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.EquipeWS[]> GetAllEquipesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetJoueursOfEquipe", ReplyAction="http://tempuri.org/IServiceQuiddich/GetJoueursOfEquipeResponse")]
        SiteWebQuidditch.ServiceReference.JoueurWS[] GetJoueursOfEquipe(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetJoueursOfEquipe", ReplyAction="http://tempuri.org/IServiceQuiddich/GetJoueursOfEquipeResponse")]
        System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.JoueurWS[]> GetJoueursOfEquipeAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetAllStades", ReplyAction="http://tempuri.org/IServiceQuiddich/GetAllStadesResponse")]
        SiteWebQuidditch.ServiceReference.StadeWS[] GetAllStades();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetAllStades", ReplyAction="http://tempuri.org/IServiceQuiddich/GetAllStadesResponse")]
        System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.StadeWS[]> GetAllStadesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetMatchesOfCoupe", ReplyAction="http://tempuri.org/IServiceQuiddich/GetMatchesOfCoupeResponse")]
        SiteWebQuidditch.ServiceReference.MatchWS[] GetMatchesOfCoupe(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/GetMatchesOfCoupe", ReplyAction="http://tempuri.org/IServiceQuiddich/GetMatchesOfCoupeResponse")]
        System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.MatchWS[]> GetMatchesOfCoupeAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/MakeReservation", ReplyAction="http://tempuri.org/IServiceQuiddich/MakeReservationResponse")]
        int MakeReservation(int matchId, string nom, string prenom, System.DateTime dateNaissance, string adresse, string email, int numberPlaces);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/MakeReservation", ReplyAction="http://tempuri.org/IServiceQuiddich/MakeReservationResponse")]
        System.Threading.Tasks.Task<int> MakeReservationAsync(int matchId, string nom, string prenom, System.DateTime dateNaissance, string adresse, string email, int numberPlaces);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CompleteReservation", ReplyAction="http://tempuri.org/IServiceQuiddich/CompleteReservationResponse")]
        void CompleteReservation(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CompleteReservation", ReplyAction="http://tempuri.org/IServiceQuiddich/CompleteReservationResponse")]
        System.Threading.Tasks.Task CompleteReservationAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CancelReservation", ReplyAction="http://tempuri.org/IServiceQuiddich/CancelReservationResponse")]
        int CancelReservation(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CancelReservation", ReplyAction="http://tempuri.org/IServiceQuiddich/CancelReservationResponse")]
        System.Threading.Tasks.Task<int> CancelReservationAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CreateUser", ReplyAction="http://tempuri.org/IServiceQuiddich/CreateUserResponse")]
        void CreateUser(string nom, string prenom, string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CreateUser", ReplyAction="http://tempuri.org/IServiceQuiddich/CreateUserResponse")]
        System.Threading.Tasks.Task CreateUserAsync(string nom, string prenom, string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CheckUser", ReplyAction="http://tempuri.org/IServiceQuiddich/CheckUserResponse")]
        void CheckUser(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceQuiddich/CheckUser", ReplyAction="http://tempuri.org/IServiceQuiddich/CheckUserResponse")]
        System.Threading.Tasks.Task CheckUserAsync(string login, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceQuiddichChannel : SiteWebQuidditch.ServiceReference.IServiceQuiddich, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceQuiddichClient : System.ServiceModel.ClientBase<SiteWebQuidditch.ServiceReference.IServiceQuiddich>, SiteWebQuidditch.ServiceReference.IServiceQuiddich {
        
        public ServiceQuiddichClient() {
        }
        
        public ServiceQuiddichClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceQuiddichClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceQuiddichClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceQuiddichClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SiteWebQuidditch.ServiceReference.CoupeWS[] GetAllCoupes() {
            return base.Channel.GetAllCoupes();
        }
        
        public System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.CoupeWS[]> GetAllCoupesAsync() {
            return base.Channel.GetAllCoupesAsync();
        }
        
        public string Hello() {
            return base.Channel.Hello();
        }
        
        public System.Threading.Tasks.Task<string> HelloAsync() {
            return base.Channel.HelloAsync();
        }
        
        public SiteWebQuidditch.ServiceReference.EquipeWS[] GetAllEquipes() {
            return base.Channel.GetAllEquipes();
        }
        
        public System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.EquipeWS[]> GetAllEquipesAsync() {
            return base.Channel.GetAllEquipesAsync();
        }
        
        public SiteWebQuidditch.ServiceReference.JoueurWS[] GetJoueursOfEquipe(int id) {
            return base.Channel.GetJoueursOfEquipe(id);
        }
        
        public System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.JoueurWS[]> GetJoueursOfEquipeAsync(int id) {
            return base.Channel.GetJoueursOfEquipeAsync(id);
        }
        
        public SiteWebQuidditch.ServiceReference.StadeWS[] GetAllStades() {
            return base.Channel.GetAllStades();
        }
        
        public System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.StadeWS[]> GetAllStadesAsync() {
            return base.Channel.GetAllStadesAsync();
        }
        
        public SiteWebQuidditch.ServiceReference.MatchWS[] GetMatchesOfCoupe(int id) {
            return base.Channel.GetMatchesOfCoupe(id);
        }
        
        public System.Threading.Tasks.Task<SiteWebQuidditch.ServiceReference.MatchWS[]> GetMatchesOfCoupeAsync(int id) {
            return base.Channel.GetMatchesOfCoupeAsync(id);
        }
        
        public int MakeReservation(int matchId, string nom, string prenom, System.DateTime dateNaissance, string adresse, string email, int numberPlaces) {
            return base.Channel.MakeReservation(matchId, nom, prenom, dateNaissance, adresse, email, numberPlaces);
        }
        
        public System.Threading.Tasks.Task<int> MakeReservationAsync(int matchId, string nom, string prenom, System.DateTime dateNaissance, string adresse, string email, int numberPlaces) {
            return base.Channel.MakeReservationAsync(matchId, nom, prenom, dateNaissance, adresse, email, numberPlaces);
        }
        
        public void CompleteReservation(int id) {
            base.Channel.CompleteReservation(id);
        }
        
        public System.Threading.Tasks.Task CompleteReservationAsync(int id) {
            return base.Channel.CompleteReservationAsync(id);
        }
        
        public int CancelReservation(int id) {
            return base.Channel.CancelReservation(id);
        }
        
        public System.Threading.Tasks.Task<int> CancelReservationAsync(int id) {
            return base.Channel.CancelReservationAsync(id);
        }
        
        public void CreateUser(string nom, string prenom, string login, string password) {
            base.Channel.CreateUser(nom, prenom, login, password);
        }
        
        public System.Threading.Tasks.Task CreateUserAsync(string nom, string prenom, string login, string password) {
            return base.Channel.CreateUserAsync(nom, prenom, login, password);
        }
        
        public void CheckUser(string login, string password) {
            base.Channel.CheckUser(login, password);
        }
        
        public System.Threading.Tasks.Task CheckUserAsync(string login, string password) {
            return base.Channel.CheckUserAsync(login, password);
        }
    }
}
