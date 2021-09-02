using PizzaApp.Services.Dtos;
using System.Collections.Generic;

namespace PizzaApp.Services.Servicess.Interfaces
{
    public interface IStateService
    {
        IEnumerable<StateDto> GetNextStatesForOrder(int orderId);
        int GetCurrentStateIdByOrderId(int orderId);
        int GetNextStateIdByOrderId(int orderId);
    }
}
