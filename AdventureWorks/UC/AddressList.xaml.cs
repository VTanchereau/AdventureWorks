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

namespace AdventureWorks.UC
{
    /// <summary>
    /// Interaction logic for AddressList.xaml
    /// </summary>
    public partial class AddressList : UserControl
    {
        private Customer customer;
        private AddressDetail mainOffice;
        private AddressDetail shipping;
        private string SHIPPING_TYPE = "Shipping";
        private string MAIN_TYPE = "Main Office";
        public AddressList()
        {
            InitializeComponent();

            this.mainOffice = new AddressDetail("Main Office");
            this.shipping = new AddressDetail("Shipping Address");
            this.mainOfficeControl.Content = this.mainOffice;
            this.shippingControl.Content = this.shipping;
        }
        public void SetCustomerSource(Customer cust)
        {
            this.customer = cust;
            this.SetAddress(cust);
        }
        private void SetAddress(Customer cust)
        {
            this.mainOffice.SetDataContext(null);
            this.shipping.SetDataContext(null);
            foreach (CustomerAddress custAddress in cust.CustomerAddress)
            {
                if (custAddress.AddressType == this.MAIN_TYPE)
                {
                    this.mainOffice.SetDataContext(custAddress.Address);
                }
                if (custAddress.AddressType == this.SHIPPING_TYPE)
                {
                    this.shipping.SetDataContext(custAddress.Address);
                }
            }
        }
    }
}
