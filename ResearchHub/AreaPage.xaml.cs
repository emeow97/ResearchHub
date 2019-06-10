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

namespace ResearchHub
{
    /// <summary>
    /// Interaction logic for AreaPage.xaml
    /// </summary>
    public partial class AreaPage : Page
    {
        Area currentArea;
        public AreaPage(Area area)
        {
            currentArea = area;
            InitializeComponent();
            title.Text = area.getTitle();
            description.Text = area.getDescription();
            exampleProjectTitle.Text = area.getExampleProjectName();
            exampleProjectDescription.Text = area.getExampleProjectDescription();
            quote.Text = area.getQuote();
            quoteBy.Text = area.getQuoteBy();
            quoteByWho.Text = area.getQuoteByWho();
            String path = "C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\fieldImage\\fields_";
            AreaBackground.ImageSource = new BitmapImage(new Uri(path + area.getSimplifiedTitle() + ".png", UriKind.Absolute));
            icon.Source = new BitmapImage(new Uri("C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\iconImage\\icon_"
                + area.getSimplifiedTitle() + ".png", UriKind.Absolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AreaList areaPage = new AreaList(currentArea);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(areaPage);
        }
    }
}
