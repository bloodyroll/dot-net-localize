

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using AppLocalizer;


namespace WpfLocTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();


            DataContext = new MainWindowModel();
        }

        private bool _flag;
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
             var mvm = DataContext as MainWindowModel;
            if (mvm != null)
            {
                mvm.SomeEnumValue = _flag ? TestLangEnum.First : TestLangEnum.Second;
            }

            
            _flag = !_flag;

        }


        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // 
            try
            {
                Translate.SetLanguage(((KeyValuePair<byte, string>) e.AddedItems[0]).Key);
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message);
            }
        }
    }
}
