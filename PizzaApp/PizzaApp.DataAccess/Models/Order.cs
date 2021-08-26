using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.DataAccess.Models
{
    public partial class Order : BaseEntity
    {
        public DateTime? TimeSubmited { get; set; }
        public bool IsDelivered { get; set; }
        public int PizzaId { get; set; }
        public int StateId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual State StateNavigation { get; set; }

        public void Test()
        {
        }
    }
}
