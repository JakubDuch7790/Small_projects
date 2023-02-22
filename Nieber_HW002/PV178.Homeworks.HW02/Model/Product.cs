using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Model
{
    public class Product
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;

            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} for {Price},- CZK";
        }
    }
}
