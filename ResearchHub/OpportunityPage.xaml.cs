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
    /// Interaction logic for OpportunityPage.xaml
    /// </summary>
    public partial class OpportunityPage : Page
    {
        AreaList areaListPage;
        Opportunity thisOpp;
        public OpportunityPage(AreaList area, Opportunity opp)
        {
            thisOpp = opp;
            areaListPage = area;
            InitializeComponent();
            titleOfOpportunity.Text = opp.GetTitle();

            field.Text = "";
            if (opp.getAreas()[0].Length > 0) field.Text += opp.getAreas()[0];
            if (opp.getAreas()[1].Length > 0) {
                if (opp.getAreas()[2].Length == 0) {
                    field.Text += " and " + opp.getAreas()[1];
                } else {
                    field.Text += ", " + opp.getAreas()[1] + " and " + opp.getAreas()[2];
                }
            }
            projectDescription.Text = opp.getDescription();
            projectRequirement.Text = "";
            foreach (string s in opp.getRequirements())
            {
                projectRequirement.Text = s + "\n";
            }
            projectCommitment.Text = opp.getTimeCommitment();
            projectCompensation.Text = opp.getCompemsation();
            projectAvailability.Text = opp.getExpirationDate().ToString();
            projectContact.Text = opp.getNameOfContact();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(areaListPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            thisOpp.mail(emailRecieved.Text);
        }
    }
}
