using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace AdventureWorks.UC
{
    /// <summary>
    /// Interaction logic for CustomerList.xaml
    /// </summary>
    public partial class CustomerList : UserControl
    {
        private AddressList addressList;
        private AdventureWorkContext context;
        public CustomerList(AdventureWorkContext _context)
        {
            InitializeComponent();
            this.context = _context;
            this.addressList = new AddressList();
            this.detailControl.Content = this.addressList;
        }
        private void customerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.addressList.SetCustomerSource((Customer)customerListView.SelectedItem);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource customerViewSource =
                    ((System.Windows.Data.CollectionViewSource)(this.FindResource("customerViewSource")));

            this.context.Customer.Load();

            customerViewSource.Source = this.context.Customer.Local;

            customerListView.SelectedIndex = 0;
        }
    }
}
