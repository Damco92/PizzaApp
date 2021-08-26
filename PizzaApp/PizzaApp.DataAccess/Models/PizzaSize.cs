using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.DataAccess.Models
{
    public partial class PizzaSize
    {
        public PizzaSize()
        {
            Pizzas = new HashSet<Pizza>();
        }
        [Key]
        public PizzaSizeId PizzaSizeId { get; set; }
        [Required]
        public string Size { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
