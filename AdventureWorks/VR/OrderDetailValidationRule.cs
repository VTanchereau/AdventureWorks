using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace AdventureWorks.VR
{
    class OrderDetailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureInfo)
        {
            SalesOrderDetail orderDetail = (value as BindingGroup).Items[0] as SalesOrderDetail;
            return ValidationResult.ValidResult;
        }
    }
}
