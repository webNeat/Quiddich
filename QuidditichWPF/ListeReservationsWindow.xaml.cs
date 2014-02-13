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
    /// Logique d'interaction pour ListeReservationsWindow.xaml
    /// </summary>
    public partial class ListeReservationsWindow : Window
    {
        public ListeReservationsWindow()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
        }
        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }
    }
}
