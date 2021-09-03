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
        private bool _isCheckOrderJobRunning = false;
        private bool _isNewOrderCreated = false;
        public ShellView()
        {
            InitializeComponent();
            this.DataContext = new ShellViewModel();
            EnableDisableCreateOrderButtons();
            cancel_checking_order_job.IsEnabled = false;
        }

        private async void Add_Order(object sender, RoutedEventArgs e)
        {
            _isNewOrderCreated = true;
            EnableDisableCreateOrderButtons();
            var selectedPizza = (Pizza)Pizzas.SelectedItem;
            var vm = (ShellViewModel)this.DataContext;
            var message = await vm.InsertOrder(selectedPizza);
            MessageBox.Show(message);
        }

        private async void Check_Order(object sender, RoutedEventArgs e)
        {
            EnableDisableCheckOrderButtons();
            var vm = (ShellViewModel)this.DataContext;
            var orderId = await vm.GetlastOrderId();
            var resultMessage = vm.CheckCurrentOrderStatus(orderId);
            MessageBox.Show(resultMessage.Result);
        }

        private async void Start_Check_PizzaJob(object sender, RoutedEventArgs e)
        {
            _isCheckOrderJobRunning = true;
            EnableDisableCheckOrderButtons();
            var vm = (ShellViewModel)this.DataContext;
            var result = await vm.Start_Check_PizzaJob();
            MessageBox.Show(result);
        }
        private void cancel_checking_order_job_Click(object sender, RoutedEventArgs e)
        {
            _isCheckOrderJobRunning = false;
            EnableDisableCheckOrderButtons();
        }
        private async void Cancel_Order(object sender, RoutedEventArgs e)
        {
            _isNewOrderCreated = false;
            EnableDisableCreateOrderButtons();
            cancel_checking_order_job.IsEnabled = false;
            var vm = (ShellViewModel)this.DataContext;
            var result = await vm.DeleteLastOrder();
            MessageBox.Show(result.ToString());
        }
        private void EnableDisableCheckOrderButtons()
        {
            if (_isCheckOrderJobRunning)
            {
                check_order_btn.IsEnabled = false;
                check_order_job_btn.IsEnabled = false;
                cancel_checking_order_job.IsEnabled = true;
            }
            else
            {
                check_order_btn.IsEnabled = true;
                check_order_job_btn.IsEnabled = true;
                cancel_checking_order_job.IsEnabled = false;
            }
        }
        private void EnableDisableCreateOrderButtons()
        {
            if (_isNewOrderCreated)
            {
                check_order_btn.IsEnabled = true;
                check_order_job_btn.IsEnabled = true;
                cancel_checking_order_job.IsEnabled = false;
                add_order_btn.IsEnabled = false;
            }
            else
            {
                check_order_btn.IsEnabled = false;
                check_order_job_btn.IsEnabled = false;
                cancel_checking_order_job.IsEnabled = true;
                add_order_btn.IsEnabled = true;
            }
        }
    }
}
