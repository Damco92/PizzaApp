using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.DataAccess.Models
{
    public partial class PizzaType
    {
        public PizzaType()
        {
            Pizzas = new HashSet<Pizza>();
        }
        [Key]
        public PizzaTypeId PizzaTypeId { get; set; }
        [Required]
        public string TypeOfPizza { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
