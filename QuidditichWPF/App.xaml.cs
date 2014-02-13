using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            
        }
    }
}
