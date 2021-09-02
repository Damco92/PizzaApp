using System.Collections.Generic;

namespace PizzaApp.Services.Dtos
{
    public class OrderDto
    {
        public string DateAndTimeSubmited { get; set; }
        public bool IsDelivered { get; set; }
        public string PizzaType { get; set; }
        public string PizzaSize { get; set; }
        public string CurrentStateType { get; set; }
        public IEnumerable<string> NextPossibleStates { get; set; }
    }
}
