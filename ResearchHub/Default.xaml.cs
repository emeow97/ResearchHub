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
    /// Interaction logic for Default.xaml
    /// </summary>
    public partial class Default : Page
    {
        Parse parse;
        public Default() {
            InitializeComponent();
            parse = new Parse();
            Grid container = (Grid)this.FindName("ButtonContainer");
            foreach (Object button in container.Children) {
                Button currButt = button as Button;
                if (currButt != null) { currButt.Click += new RoutedEventHandler(clickButt); }
            }
        }

        public void lightUp(string field)
        {
            ((Image) this.FindName(field)).Opacity = 1;
        }

        public void clickButt(object sender, RoutedEventArgs e) {
            ((Button)sender).Opacity = 1;
            System.Threading.Thread.Sleep(1000);
            string name = parse.getTitleFromSimplified((((Button) sender).Name).ToString());
            Area area = (parse.getArea(name));
            AreaPage areaPage = new AreaPage(area);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(areaPage);
        }
    }
}
