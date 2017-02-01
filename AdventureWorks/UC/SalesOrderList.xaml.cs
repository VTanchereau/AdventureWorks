using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SalesOrderList.xaml
    /// </summary>
    public partial class SalesOrderList : UserControl
    {
        private ObservableCollection<SalesOrderHeader> salesOrderCollection;
        private ObservableCollection<Product> productCollection;
        private SalesOrderDetailList detailList;
        public SalesOrderList(ObservableCollection<SalesOrderHeader> _salesOrderCollection, ObservableCollection<Product> _productCollection)
        {
            InitializeComponent();
            this.salesOrderCollection = _salesOrderCollection;
            this.productCollection = _productCollection;
            this.detailList = new SalesOrderDetailList(this.productCollection);
            this.detailControl.Content = this.detailList;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource salesOrderHeaderViewSource =
                    ((System.Windows.Data.CollectionViewSource)(this.FindResource("salesOrderHeaderViewSource")));
            
            salesOrderHeaderViewSource.Source = this.salesOrderCollection;
        }

        private void salesOrderHeaderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.detailList.SetSalesOrderSource(this.salesOrderHeaderListView.SelectedItem as SalesOrderHeader);
        }
    }
}
