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

           //cm.addUtilisateur(new Utilisateur("", "", login.Text.ToLower(), password.Password));

            if (cm.Login(login.Text.ToLower(), password.Password) != null)
            {

                MainWindow auto = new MainWindow();
                auto.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou Mot de passe invalide");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Pilotage.SavePreferences(this);
            base.OnClosed(e);
        }
    }
}
