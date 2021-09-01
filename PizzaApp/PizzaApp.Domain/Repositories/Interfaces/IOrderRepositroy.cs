using PizzaApp.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaApp.Domain.Repositories.Interfaces
{
    public interface IOrderRepositroy
    {
        Task<Order> GetOrderById(int id);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrderById(int id);
    }
}
