using System.ComponentModel.DataAnnotations;

namespace RazorPagesPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string? name { get; set; }
        public bool isGlutenFree { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }


    }
}
