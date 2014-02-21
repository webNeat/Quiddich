using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using BusinessLayer;

namespace QuidditichWPF
{
    class ReservationViewModel : ViewModelBase
    {
        private CoupeManager cm;
        public Reservation MyReservation
        {
            get;
            private set;
        }

        public ReservationViewModel(Reservation res)
        {
            MyReservation = res;
            cm = new CoupeManager();
        }

        public Coupe MyCoupe
        {
            get { return cm.getCoupeById(MyMatch.CoupeId); }
            set { MyMatch.CoupeId = value.Id; base.OnPropertyChanged("MyCoupe"); }
        }
        public Match MyMatch
        {
            get { return MyReservation.MyMatch; }
            set { MyReservation.MyMatch = value; base.OnPropertyChanged("MyMatch"); }
        }
        public string Nom
        {
            get { return MyReservation.MySpectateur.Nom; }
            set { MyReservation.MySpectateur.Nom = value; base.OnPropertyChanged("Nom"); }
        }
        public string Prenom
        {
            get { return MyReservation.MySpectateur.Prenom; }
            set { MyReservation.MySpectateur.Prenom = value; base.OnPropertyChanged("Prenom"); }
        }
        public string Adresse
        {
            get { return MyReservation.MySpectateur.Adresse; }
            set { MyReservation.MySpectateur.Adresse = value; base.OnPropertyChanged("Adresse"); }
        }
        public int Places
        {
            get { return MyReservation.Places; }
            set 
            { 
                MyReservation.Places = value;
                base.OnPropertyChanged("Places");
                base.OnPropertyChanged("Prix");
            }
        }
        public double Prix
        {
            get { return Places * MyMatch.Prix; }
            set { }
        }
    }
}
