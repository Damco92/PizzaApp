namespace PizzaApp.WPF.Models
{
    public class Pizza
    {
        public string PizzaSize { get; set; }
        public string PizzaType { get; set; }
        public string PizzaSizeAndType 
        {
            get 
            {
                return $"{PizzaSize} {PizzaType}";
            } 
        }
    }
}
