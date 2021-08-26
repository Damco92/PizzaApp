using PizzaApp.DataAccess.Models;
using System.Collections.Generic;

namespace PizzaApp.Domain.Repositories.Interfaces
{
    public interface IOrderRepositroy
    {
        Order GetOrderById(int id);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrderById(int id);
    }
}
