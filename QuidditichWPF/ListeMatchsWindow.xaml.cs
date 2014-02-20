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
        Coupe coupe;
        public ListeMatchsWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            cm = new CoupeManager();
            coupes.ItemsSource = cm.allCoupes();
            stades.ItemsSource = cm.allStades();
            equipesV.ItemsSource = equipesD.ItemsSource = cm.allEquipeNames();
        }
        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void coupes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            coupe = (Coupe)coupes.SelectedItem;
            IList<Match> matchsR = cm.allMatchofCoupe(coupe.Id);
            matchs.ItemsSource = matchsR;
        }

        private void matchs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = matchs.SelectedItem;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //delete
             cm.deleteMatch((Match)matchs.SelectedItem);
             IList<Match> matchsR = cm.allMatchofCoupe(coupe.Id);
             matchs.ItemsSource = matchsR;
             matchs.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //update
            cm.updateMatch((Match)DataContext);
            matchs.ItemsSource = cm.allMatchofCoupe(coupe.Id);
            matchs.Items.Refresh();
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Coupe coupe = (Coupe)coupes.SelectedItem;
            cm.addMatch(coupe.Id ,(DateTime) date.SelectedDate,Convert.ToDouble(prix.Text), (Stade)stades.SelectedItem,(Equipe) equipesD.SelectedItem,(Equipe) equipesV.SelectedItem,Convert.ToInt32(scoreDomicile.Text),Convert.ToInt32(scoreVisiteur.Text));
            IList<Match> matchsR = cm.allMatchofCoupe(coupe.Id);
            matchs.ItemsSource = matchsR;
            matchs.Items.Refresh();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            MainWindow auto = new MainWindow();
            auto.Show();
            this.Close();
        }
      
    }
}
