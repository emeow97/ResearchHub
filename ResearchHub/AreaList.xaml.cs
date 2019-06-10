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

namespace ResearchHub {
    /// <summary>
    /// Interaction logic for AreaList.xaml
    /// </summary>
    public partial class AreaList : Page {
        public AreaList(Area area) {
            InitializeComponent();
            title.Text = area.getTitle();
            container.Height = 1150 + 500 * (area.getOpportunityList().Count % 3 + 1);
            bannerImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\fieldImage\\fields_" + area.getSimplifiedTitle()
                + ".png", UriKind.Relative));
            // featured opportunities
            int i = area.getOpportunityList().Count >= 3 ? 3 : area.getOpportunityList().Count;
            while (i > 0) {
                featuredOpportunity.Children.Add(newFrame(area.getOpportunityList()[i - 1]));
                i--;
            }
            // all opportunities
            i = 0;
            StackPanel cur = new StackPanel();
            cur.Orientation = Orientation.Horizontal;
            ((StackPanel)this.FindName("allOpportunity")).Children.Add(cur);
            while (i < area.getOpportunityList().Count) {
                if (i % 3 == 0 && i != 0) {
                    cur = new StackPanel();
                    cur.Orientation = Orientation.Horizontal;
                    ((StackPanel)this.FindName("allOpportunity")).Children.Add(cur);
                }
                cur.Children.Add(newFrame(area.getOpportunityList()[i]));
                i++;
            }
            icon.Source = new BitmapImage(new Uri("C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\iconImage\\icon_"
                + area.getSimplifiedTitle() + ".png", UriKind.Absolute));
        }

        private Frame newFrame(Opportunity opp)
        {
            Frame f = new Frame();
            Thickness margin = f.Margin;
            margin.Left = 70;
            margin.Bottom = 60;
            f.Margin = margin;
            f.BorderBrush = new SolidColorBrush(Colors.Black);
            f.Content = new OpportunityBlock(opp, this);
            return f;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddList areaPage = new AddList(this);
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(areaPage);
        }
    }
}
