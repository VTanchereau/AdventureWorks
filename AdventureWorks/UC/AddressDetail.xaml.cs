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
    /// Interaction logic for AddressDetail.xaml
    /// </summary>
    public partial class AddressDetail : UserControl
    {
        public AddressDetail(string addressType)
        {
            InitializeComponent();
            this.addressTypeLabel.Content = addressType;
        }
        public void SetDataContext(Address address)
        {
            this.addressPanel.DataContext = address;
        }
    }
}
