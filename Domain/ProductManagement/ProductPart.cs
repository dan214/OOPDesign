using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign.Domain.ProductManagement
{
    public partial class Product
    {
        private void UpdateLowStock()
        {
            if (AmountInStock <= 10)
            {
                IsBelowStockThreshold = true;
            }
        }
        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
        private void Log(string message)
        {
            Console.WriteLine(message);
        }

    }
}
