using AutoMapper;
using PizzaApp.Domain.Repositories.Interfaces;
using PizzaApp.Services.Dtos;
using PizzaApp.Services.Servicess.Interfaces;
using System.Linq;

namespace PizzaApp.Services.Servicess.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositroy _orderRepositroy;
        private readonly IStateRepositroy _stateRepositroy;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepositroy orderRepostiroy, IStateRepositroy stateRepositroy, IMapper mapper)
        {
            _orderRepositroy = orderRepostiroy;
            _stateRepositroy = stateRepositroy;
            _mapper = mapper;
        }
        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepositroy.GetOrderById(id);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
