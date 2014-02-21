using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace QuidditichWPF
{
    class ReservationsViewModel : ViewModelBase
    {
        private ObservableCollection<ReservationViewModel> _res;

        public ObservableCollection<ReservationViewModel> Reservations
        {
            get { return _res; }
            private set 
            { 
                _res = value;
                OnPropertyChanged("Reservations");
            }
        }

        private ReservationViewModel _selectedItem;
        public ReservationViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
     
        public ReservationsViewModel(IList<Reservation> list) 
        {
            _res = new ObservableCollection<ReservationViewModel>();
            foreach (Reservation a in list) 
            {
                _res.Add(new ReservationViewModel(a)); 
            }
        }

        // Commande Add
        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return SelectedItem != null;
        }

        private void Add()
        {
            Reservation r = new Reservation(SelectedItem.MyMatch, SelectedItem.MyReservation.MySpectateur, SelectedItem.Places);
            this.SelectedItem = new ReservationViewModel(r);
            Reservations.Add(this.SelectedItem);
        }

        // Commande Remove
        private RelayCommand _removeCommand;
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return _removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedItem != null);
        }

        private void Remove()
        {
            if (this.SelectedItem != null) Reservations.Remove(this.SelectedItem);
        }
    }
}
