using AdventureWorks.UC;
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

namespace AdventureWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerList customerList;
        private SalesOrderList salesOrderList;
        private AdventureWorksLT2012Entities1 _context = new AdventureWorksLT2012Entities1();

        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            this._context.Customer.Load();
            this.customerList = new CustomerList(_context.Customer.Local);
            this._context.SalesOrderHeader.Load();
            this._context.Product.Load();
            this.salesOrderList = new SalesOrderList(_context.SalesOrderHeader.Local, _context.Product.Local);
            this.content.Content = this.salesOrderList;
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this._context.Dispose();
        }
        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            this.content.Content = this.customerList;
        }
        private void SalesOrders_Click(object sender, RoutedEventArgs e)
        {
            this.content.Content = this.salesOrderList;
        }
    }
}
