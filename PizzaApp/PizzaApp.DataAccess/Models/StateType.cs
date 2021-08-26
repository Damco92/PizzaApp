using System.Collections.Generic;

namespace PizzaApp.DataAccess.Models
{
    public partial class StateType : BaseEntity
    {
        public StateType()
        {
            States = new HashSet<State>();
        }

        public string Type { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
