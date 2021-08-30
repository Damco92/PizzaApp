using AutoMapper;
using PizzaApp.DataAccess.Models;
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
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepositroy orderRepostiroy, IStateRepositroy stateRepositroy, IPizzaRepository pizzaRepository, IMapper mapper)
        {
            _orderRepositroy = orderRepostiroy;
            _stateRepositroy = stateRepositroy;
            _pizzaRepository = pizzaRepository;
            _mapper = mapper;
        }
        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepositroy.GetOrderById(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.PizzaSize = order.Pizza.PizzaSizeId.ToString();
            orderDto.PizzaType = order.Pizza.PizzaTypeId.ToString();
            var nextStates = _stateRepositroy.GetNextPossibleStatesForOrderByOrderId(id);
            var nameOfStates = new System.Collections.Generic.List<string>();
            foreach (var state in nextStates)
            {
                nameOfStates.Add(state.StateTypeId.ToString());
            }
            orderDto.NextPossibleStates = nameOfStates;
            return orderDto;
        }

        public void InsertNewOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.StateId = _stateRepositroy.GetAllStates().SingleOrDefault(x => x.Id == 1).Id;
            order.PizzaId = _pizzaRepository.GetAllPizzas()
                .SingleOrDefault(x => x.PizzaSizeId.ToString() == orderDto.PizzaSize 
                && x.PizzaTypeId.ToString() == orderDto.PizzaType).Id;
            _orderRepositroy.InsertOrder(order);
        }
    }
}
