using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        public int maxItemsInStock = 0;

        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStockThreshold = false;

        public void UseProduct(int items)
        {
            if(items <= amountInStock)
            {
                amountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated.Now {amountInStock} items in stock.");

            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}.{amountInStock} available but {items} requested");
            }
        }
        public void IncreaseStock()
        {
            amountInStock++;
        }

        public void UpdateLowStock()
        {
            if(amountInStock <= 10)
            {
                isBelowStockThreshold = true;
            }
        }
        public string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
        private void Log(string message)
        {
            Console.WriteLine (message);
        }
    }
}
