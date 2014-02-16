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
        public ListeStadesWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
            CoupeManager cm = new CoupeManager();
            stades.ItemsSource =  cm.allStades();
        }
        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }

        private void stades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
