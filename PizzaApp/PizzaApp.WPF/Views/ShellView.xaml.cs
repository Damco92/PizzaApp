using PizzaApp.WPF.Models;
using PizzaApp.WPF.ViewModels;
using System.Windows;

namespace PizzaApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            this.DataContext = new ShellViewModel();
        }

        private async void Add_Order(object sender, RoutedEventArgs e)
        {
            var selectedPizza = (Pizza)Pizzas.SelectedItem;
            var vm = (ShellViewModel)this.DataContext;
            var message = await vm.InsertOrder(selectedPizza);
            MessageBox.Show(message);
        }

        private async void Check_Order(object sender, RoutedEventArgs e)
        {
            var vm = (ShellViewModel)this.DataContext;
            var orderId = await vm.GetlastOrderId();
            var resultMessage = vm.CheckCurrentOrderStatus(orderId);
            MessageBox.Show(resultMessage.Result);
        }
    }
}
