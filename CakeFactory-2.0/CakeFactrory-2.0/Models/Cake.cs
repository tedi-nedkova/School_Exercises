using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeFactrory_2._0.Models
{
    public class Cake
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Occassion { get; set; } = null!;

        public string Size { get; set; } = null!;

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public Cake(int id, string name, string description, decimal price, string occassion, string size)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Occassion = occassion;
            this.Size = size;
        }
    }
}
