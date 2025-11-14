using RetailChainData.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailChainData.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public ProductType Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
