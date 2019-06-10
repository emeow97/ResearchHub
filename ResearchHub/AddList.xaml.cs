﻿using System;
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
    /// Interaction logic for AddList.xaml
    /// </summary>
    public partial class AddList : Page
    {
        Page thisPg;
        public AddList(Page pg)
        {
            InitializeComponent();
            this.thisPg = pg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService ns = NavigationService.GetNavigationService(this);
            ns.Navigate(thisPg);
        }
    }
}
