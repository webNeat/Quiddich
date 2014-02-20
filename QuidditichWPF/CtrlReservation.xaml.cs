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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using EntitiesLayer;

namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour CtrlReservation.xaml
    /// </summary>
    public partial class CtrlReservation : UserControl
    {
        public CtrlReservation()
        {
            CoupeManager cm = new CoupeManager();
            InitializeComponent();
            coupes.ItemsSource = cm.allCoupes();
        }

        private void coupes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Coupe selectedCoupe = (Coupe)coupes.SelectedItem;
            CoupeManager cm = new CoupeManager();
            matches.ItemsSource = cm.allMatchofCoupe(selectedCoupe.Id);
        }


    }
}
