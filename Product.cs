using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class Product
    {
        public Product(int id, string name) 
        {
            Name = name;
            Id = id;
        }

        public Product(int id) : this(id, string.Empty)
        {
        }

        public Product(int id, string name, string? description, UnitType unitType, int maxAmountInStock)
        {
            maxItemsInStock = maxAmountInStock;
            UnitType = unitType;
            Id = id;
            Name = name;
            Description = description;

            UpdateLowStock();
        }   

        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;

        public UnitType UnitType { get; set; }

        public int AmountInStock { get;private set; }

        public bool IsBelowStockThreshold { get; private set; }

        public int Id 
        {
            get { return id; }
            set { id = value; }
            
        }
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value.Length > 50 ? value[..50] : value;
            }
        }

        public string? Description
        {
            get { return description; }
            set
            {
                if(value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
        }

        public void UseProduct(int items)
        {
            if(items <= AmountInStock)
            {
                AmountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated.Now {AmountInStock} items in stock.");

            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}.{AmountInStock} available but {items} requested");
            }
        }
        public void IncreaseStock()
        {
            AmountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if( newStock < maxItemsInStock )
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemsInStock;
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordered that couldnt be stored.");
            }

            if(AmountInStock > 10)
            {
                IsBelowStockThreshold = false;
            }
        }

        private void DecreaseStock(int items, string reason)
        {
            if(items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }
        }

        public void UpdateLowStock()
        {
            if(AmountInStock <= 10)
            {
                IsBelowStockThreshold = true;
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

        public string DisplayDetailsShort()
        {
            return $"{id}. {name} \n{AmountInStock} items in stock";
        }
        public string DisplayDetailsLong()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{id} {name} \n{description}\n{AmountInStock} item(s) in stock");

            if(IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }

        public string DisplayDetailsLong(string extraDetails)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{id} {name} \n{description}\n{AmountInStock} item(s) in stock");
            sb.Append (extraDetails);   

            if (IsBelowStockThreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();
        }
    }
}
