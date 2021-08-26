using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess.Models
{
    public partial class State : BaseEntity
    {
        public State()
        {
            Orders = new HashSet<Order>();
            TransitionsNextStateNavigation = new HashSet<Transition>();
            TransitionsStateNavigation = new HashSet<Transition>();
        }

        public StateTypeId StateTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual StateType StateType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Transition> TransitionsNextStateNavigation { get; set; }
        public virtual ICollection<Transition> TransitionsStateNavigation { get; set; }
    }
}
