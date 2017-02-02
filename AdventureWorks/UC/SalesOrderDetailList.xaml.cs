using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace AdventureWorks.UC
{
    /// <summary>
    /// Interaction logic for SalesOrderDetailList.xaml
    /// </summary>
    public partial class SalesOrderDetailList : UserControl
    {
        private SalesOrderHeader source;
        private ObservableCollection<Product> productCollection;
        public SalesOrderDetailList(ObservableCollection<Product> _productCollection)
        {
            InitializeComponent();
            this.productCollection = _productCollection;
        }
        public void SetSalesOrderSource(SalesOrderHeader salesOrderSource)
        {
            System.Windows.Data.CollectionViewSource salesOrderDetailViewSource =
                    ((System.Windows.Data.CollectionViewSource)(this.FindResource("salesOrderDetailViewSource")));
            

            this.source = salesOrderSource;
            salesOrderDetailViewSource.Source = this.source.SalesOrderDetail;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource productCollectionSource =
                    ((System.Windows.Data.CollectionViewSource)(this.FindResource("productCollectionSource")));
            productCollectionSource.Source = this.productCollection;
            this.salesOrderDetailDataGrid.Items.Refresh();
        }
        private void salesOrderDetailDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ListCollectionView itemList = this.salesOrderDetailDataGrid.Items.SourceCollection as ListCollectionView;
            SalesOrderDetail current = itemList.CurrentItem as SalesOrderDetail;
            if (e.Row.IsNewItem)
            {
                current.SalesOrderHeader = this.source;
                this.source.SalesOrderDetail.Add(current);
            }
            current.UnitPrice = current.Product.ListPrice;
            System.Windows.Data.CollectionViewSource salesOrderDetailViewSource =
                    ((System.Windows.Data.CollectionViewSource)(this.FindResource("salesOrderDetailViewSource")));

            this.source = current.SalesOrderHeader;
            salesOrderDetailViewSource.Source = this.source.SalesOrderDetail;
            this.salesOrderDetailDataGrid.DataContext = null;
            this.salesOrderDetailDataGrid.DataContext = salesOrderDetailViewSource;
        }
    }
}
