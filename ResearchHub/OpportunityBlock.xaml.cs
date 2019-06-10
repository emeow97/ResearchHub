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
    /// Interaction logic for OpportunityBlock.xaml
    /// </summary>
    public partial class OpportunityBlock : Page
    {
        AreaList thisPage;
        Opportunity thisOpp;
        public OpportunityBlock(Opportunity opp, AreaList page)
        {
            thisOpp = opp;
            thisPage = page;
            InitializeComponent();
            opportunityBannerPic.ImageSource = new BitmapImage(new Uri("C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\imgDefault.png", UriKind.Relative));
            opportunityName.Text = opp.GetTitle();
            description.Text = opp.getDescription();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(thisPage);
            ns.Navigate(new OpportunityPage(thisPage, thisOpp));
        }
    }
}
