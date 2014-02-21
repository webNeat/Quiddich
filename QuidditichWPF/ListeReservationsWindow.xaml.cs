using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;
using EntitiesLayer;

namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour ListeReservationsWindow.xaml
    /// </summary>
    public partial class ListeReservationsWindow : Window
    {
        public ListeReservationsWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            CoupeManager cm = new CoupeManager();
            IList<Reservation> res = cm.allReservations();
            ReservationsViewModel rvm = new ReservationsViewModel(res);
            reservations.DataContext = rvm;
        }
        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }
    }
}
