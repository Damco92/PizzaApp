namespace PizzaApp.DataAccess.Models
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
