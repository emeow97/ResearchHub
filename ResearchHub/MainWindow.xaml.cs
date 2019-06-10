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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace ResearchHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Parse parse;
        public MainWindow() {
            InitializeComponent();
            parse = new Parse();
            //PageContent.Content = new Default();
            PageContent.Source = new Uri("Default.xaml", UriKind.Relative);
            /*
            ReadPort readPort = new ReadPort();
            Default areaPage = new Default(readPort);
            NavigationService ns = NavigationService.GetNavigationService(PageContent);
            ns.Navigate(areaPage);
            */

            
        }
    }
}
