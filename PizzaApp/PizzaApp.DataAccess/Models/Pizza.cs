using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.DataAccess.Models
{
    public partial class Pizza : BaseEntity
    {
        public Pizza()
        {
            Orders = new HashSet<Order>();
        }

        public PizzaTypeId PizzaTypeId { get; set; }
        public PizzaSizeId PizzaSizeId { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual PizzaSize PizzaSize { get; set; }
        public virtual PizzaType PizzaType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
