using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuidditichWPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void  OnStartup(StartupEventArgs e){
            base.OnStartup(e);
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            Pilotage.LoadAll();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Pilotage.SaveAll();
            base.OnExit(e);
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            using (FileStream log = new FileStream("log.txt", FileMode.OpenOrCreate))
            {
                StreamWriter output = new StreamWriter(log);
                output.Write(new DateTime() + ": " + e.ToString());
                output.Close();
            }
            MessageBox.Show("Il y avait une erreur innatendu !\nDetails:\n" + e.Exception.Message, "Erreur");
            e.Handled = true;
        }
    }
}
