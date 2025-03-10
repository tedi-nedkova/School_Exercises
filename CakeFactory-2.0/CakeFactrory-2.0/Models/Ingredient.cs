using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeFactrory_2._0.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Quantity { get; set; }

        public string MeasurmentUnit { get; set; } = null!;

        public Ingredient(int id, string productName, decimal quantity, string measurmentUnit)
        {
            this.Id = id;
            this.ProductName = productName;
            this.Quantity = quantity;
            this.MeasurmentUnit = measurmentUnit;
        }
    }
}
