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
    /// Logique d'interaction pour ListeCoupesWindow.xaml
    /// </summary>
    public partial class ListeCoupesWindow : Window
    {
        public ListeCoupesWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            CoupeManager cm = new CoupeManager();
            listecoupe.ItemsSource =  cm.allCoupes();
            Coupe coupe = new Coupe();
            this.DataContext = coupe;
        }
        
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void listecoupe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = listecoupe.SelectedItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }
    }
}
