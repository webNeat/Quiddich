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
namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour Authentification.xaml
    /// </summary>
    public partial class Authentification : Window
    {
        public Authentification()
        {
            InitializeComponent();
            Pilotage.LoadPreferences(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CoupeManager cm = new CoupeManager();
            //cm.Login(login.Text.ToLower(), password.Password) != null
            if (true)
            {
                Console.WriteLine("Testt bien");
                MainWindow auto = new MainWindow();
                auto.Show();
                this.Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }
    }
}
