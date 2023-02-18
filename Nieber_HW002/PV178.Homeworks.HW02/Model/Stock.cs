using PV178.Homeworks.HW02.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Model
{
    internal class Stock
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Stock(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public void DispatchStock()
        {
            if (Quantity > 0) 
            {
                Quantity--;
            }
            else
            {
                throw new StockUnavailableException($"No units of {Product.Name} available.");
            }
        }

        public override string ToString()
        {
            return $"{Product} (available: {Quantity})";
        }
    }
}
