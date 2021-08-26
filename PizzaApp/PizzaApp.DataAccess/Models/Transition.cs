namespace PizzaApp.DataAccess.Models
{
    public partial class Transition : BaseEntity
    {
        public int CurrentStateId { get; set; }
        public int NextStateId { get; set; }

        public virtual State CurrentStateNavigation { get; set; }
        public virtual State NextStateNavigation { get; set; }
    }
}
