using System.ComponentModel.DataAnnotations;
using Interfaces;

namespace Models
{
    public class Vacations : IVactionPurchasable
    {
        public int Id { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

    }
}