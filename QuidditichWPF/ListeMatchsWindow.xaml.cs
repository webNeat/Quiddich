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
using EntitiesLayer;
using BusinessLayer;
namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour ListeMatchsWindow.xaml
    /// </summary>
    public partial class ListeMatchsWindow : Window
    {
        CoupeManager cm;
        public ListeMatchsWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            cm = new CoupeManager();
            coupes.ItemsSource = cm.allCoupes();

            stades.ItemsSource = cm.allStades();
            equipesV.ItemsSource = cm.allEquipes();
            equipesD.ItemsSource = cm.allEquipes();
        }
        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void coupes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Coupe coupe = (Coupe)coupes.SelectedItem;
            IList<Match> matchsR = cm.allMatchofCoupe(coupe.Id);
            matchs.ItemsSource = matchsR;
        }

        private void matchs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = matchs.SelectedItem;
        }
    }
}
