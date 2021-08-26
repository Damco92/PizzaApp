using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.DataAccess.Models
{
    public partial class StateType
    {
        public StateType()
        {
            States = new HashSet<State>();
        }
        [Key]
        public  StateTypeId StateTypeId { get; set; }
        [Required]
        public string Type { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
