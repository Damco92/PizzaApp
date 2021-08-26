using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess.Models
{
    public partial class PizzaType : BaseEntity
    {
        public PizzaType()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public string TypeOfPizza { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
