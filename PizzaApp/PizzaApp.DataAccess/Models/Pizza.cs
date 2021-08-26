﻿using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess.Models
{
    public partial class Pizza : BaseEntity
    {
        public Pizza()
        {
            Orders = new HashSet<Order>();
        }

        public int PizzaTypeId { get; set; }
        public int PizzaSizeId { get; set; }

        public virtual PizzaSize PizzaSize { get; set; }
        public virtual PizzaType PizzaType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
