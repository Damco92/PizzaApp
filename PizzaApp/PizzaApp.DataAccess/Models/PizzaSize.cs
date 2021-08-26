using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess.Models
{
    public partial class PizzaSize : BaseEntity
    {
        public PizzaSize()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public string Size { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
