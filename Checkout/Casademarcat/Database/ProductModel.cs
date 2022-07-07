using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public string Product
        {
            get
            {
                return $"{ this.Name } - { this.Price } lei";
            }
        }
    }
}
