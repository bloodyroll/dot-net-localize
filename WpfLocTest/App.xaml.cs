using System;
using System.Windows;

using AppLocalizer;


namespace WpfLocTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            Translate.Initialize();
            Translate.SetLanguage(1);

            base.OnStartup(e);
        }
    }


    
}
