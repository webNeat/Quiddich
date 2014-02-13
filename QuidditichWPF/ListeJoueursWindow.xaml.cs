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
    /// Logique d'interaction pour ListeJoueursWindow.xaml
    /// </summary>
    public partial class ListeJoueursWindow : Window
    {
        CoupeManager cm;
        public ListeJoueursWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            cm = new CoupeManager();
            listequipe.ItemsSource = cm.allEquipes();
            cbpostes.ItemsSource = Enum.GetValues(typeof(PosteJoueur));
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataContext = joueurs.SelectedItem;
        }

        private void listeequipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            joueurs.ItemsSource = ((Equipe)listequipe.SelectedItem).getJoueurs();
        }

        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cm.addJoueur(nom.Text, prenom.Text, Convert.ToInt32(score.Text), (PosteJoueur)cbpostes.SelectedItem, Convert.ToInt32(selections.Text));
            listequipe.ItemsSource = cm.allEquipes();
            listequipe.Items.Refresh();
            joueurs.ItemsSource = ((Equipe)listequipe.SelectedItem).getJoueurs();
            joueurs.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            joueurs.Items.Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            cm.deleteJoueur((Joueur)joueurs.SelectedItem);
            listequipe.ItemsSource = cm.allEquipes();
            listequipe.Items.Refresh();
            joueurs.ItemsSource = ((Equipe)listequipe.SelectedItem).getJoueurs();
            joueurs.Items.Refresh();
        }
    }
}
