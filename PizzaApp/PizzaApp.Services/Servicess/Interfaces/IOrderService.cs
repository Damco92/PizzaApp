using PizzaApp.DataAccess.Models;
using PizzaApp.Services.Dtos;

namespace PizzaApp.Services.Servicess.Interfaces
{
    public interface IOrderService
    {
        OrderDto GetOrderById(int id);
        void InsertNewOrder(OrderDto orderDto);
        string CheckIfOrderIsReady(int orderId);
        int GetLastAddedOrderId();
        void UpdateLastOrderState();
    }
}
