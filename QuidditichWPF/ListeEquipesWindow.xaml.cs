using BusinessLayer;
using EntitiesLayer;
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

namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour ListeequipesWindow.xaml
    /// </summary>
    public partial class ListeequipesWindow : Window
    {
        public ListeequipesWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            CoupeManager cm = new CoupeManager();
            ListeEquipes.ItemsSource = cm.allEquipes();
            Equipe coupe = new Equipe();
            this.DataContext = coupe;
        }

        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void ListeEquipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = ListeEquipes.SelectedItem;
        }
    }
}
