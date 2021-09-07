using AutoMapper;
using PizzaApp.DataAccess.Models;
using PizzaApp.Domain.Repositories.Interfaces;
using PizzaApp.Services.Dtos;
using PizzaApp.Services.Servicess.Interfaces;
using System;
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

        public string CheckIfOrderIsReady()
        {
            var order = _orderRepositroy.GetAllOrders().Result.LastOrDefault();
            if(DateTime.Now > order.TimeSubmited.Value.AddMinutes(20))
            {
                return "The pizza is burrned";
            }
            return order.StateNavigation.Description;
        }

        public string DeleteLastOrder()
        {
            var order = _orderRepositroy.GetAllOrders().Result.LastOrDefault();

            if (order.IsDeleted)
                return "Order is already deleted. Place a new order";

            order.IsDeleted = true;
            _orderRepositroy.UpdateOrder(order);
            return "Order is deleted";
        }

        public int GetLastAddedOrderId()
        {
            return _orderRepositroy.GetAllOrders().Result.LastOrDefault().Id;
        }

        public OrderDto GetOrderById(int id)
        {
            var order = _orderRepositroy.GetOrderById(id).Result;
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
            orderDto.CurrentStateType = "Preparing";
            orderDto.DateAndTimeSubmited = DateTime.Now.ToString();
            orderDto.IsDelivered = false;
            var order = _mapper.Map<Order>(orderDto);
            order.StateId = _stateRepositroy.GetAllStates().SingleOrDefault(x => x.Id == 1).Id;
            order.PizzaId = _pizzaRepository.GetAllPizzas().Result
                .SingleOrDefault(x => x.PizzaSizeId.ToString() == orderDto.PizzaSize
                && x.PizzaTypeId.ToString() == orderDto.PizzaType).Id;
            _orderRepositroy.InsertOrder(order);
        }

        public string UpdateLastOrderState()
        {
            var lastOrderId = _orderRepositroy.GetAllOrders().Result.LastOrDefault().Id;
            var order = _orderRepositroy.GetOrderById(lastOrderId);
            var nextState = _stateRepositroy.GetNextPossibleStatesForOrderByOrderId(lastOrderId)
                                    .SingleOrDefault(x => x.StateTypeId != StateTypeId.Canceled);
            if(nextState == null)
            {
                return "The order is delivered";
            }
            order.Result.StateId = nextState.Id;
            _orderRepositroy.UpdateOrder(order.Result);
            return "Updated";
        }
    }
}
