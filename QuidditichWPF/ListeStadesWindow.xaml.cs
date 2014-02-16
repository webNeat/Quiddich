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
    /// Logique d'interaction pour ListeStadesWindow.xaml
    /// </summary>
    public partial class ListeStadesWindow : Window
    {
        private CoupeManager cm = new CoupeManager();
        public ListeStadesWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            ListeStades.ItemsSource = cm.allStades();
        }
        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void stades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = ListeStades.SelectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListeStades.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int nbrePlaces;
            double percent;
            Int32.TryParse(places.Text, out nbrePlaces);
            Double.TryParse(pourcentage.Text, out percent);
            cm.addStade(adresse.Text,  nom.Text, nbrePlaces, percent);
            ListeStades.ItemsSource = cm.allStades();
            ListeStades.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            cm.deleteStade((Stade)ListeStades.SelectedItem);
            ListeStades.ItemsSource = cm.allStades();
            ListeStades.Items.Refresh();
        }
    }
}
