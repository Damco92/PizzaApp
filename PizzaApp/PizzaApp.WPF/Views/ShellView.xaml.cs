using PizzaApp.WPF.Models;
using PizzaApp.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace PizzaApp.WPF.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        private bool _isCheckOrderJobRunning = false;
        private bool _isNewOrderCreated = false;
        private DispatcherTimer _timer;
        public ShellView()
        {
            InitializeComponent();
            this.DataContext = new ShellViewModel();
            EnableDisableCreateOrderButtons();
            cancel_checking_order_job.IsEnabled = false;
            _timer = new DispatcherTimer();
        }

        private async void Add_Order(object sender, RoutedEventArgs e)
        {
            _isNewOrderCreated = true;
            EnableDisableCreateOrderButtons();
            var selectedPizza = (Pizza)Pizzas.SelectedItem;
            var vm = (ShellViewModel)this.DataContext;
            var message = await vm.InsertOrder(selectedPizza);
            MessageBox.Show(message);
            if (message == "No pizza has been selected")
            {
                _isNewOrderCreated = false;
                EnableDisableCreateOrderButtons();
                return;
            }
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(30);
            _timer.Tick += new EventHandler(async (object s, EventArgs a) =>
            {
                var result = await vm.UpdateLastOrderStatus();
                if (result == "Delivered")
                {
                    _timer.Stop();
                    _isNewOrderCreated = false;
                    EnableDisableCreateOrderButtons();
                }
            });
            _timer.Start();
        }

        private async void Check_Order(object sender, RoutedEventArgs e)
        {
            EnableDisableCheckOrderButtons();
            var vm = (ShellViewModel)this.DataContext;
            var resultMessage = await vm.CheckCurrentOrderStatus();
            if(resultMessage == "The pizza has been delivered to the customer")
            {
                _isNewOrderCreated = false;
            }
            MessageBox.Show(resultMessage);
        }

        private void Start_Check_PizzaJob(object sender, RoutedEventArgs e)
        {
            _isCheckOrderJobRunning = true;
            EnableDisableCheckOrderButtons();
            var vm = (ShellViewModel)this.DataContext;
            DispatcherTimer checkerTimer = new DispatcherTimer();
            checkerTimer.Interval = TimeSpan.FromSeconds(35);
            checkerTimer.Tick += new EventHandler(async (object s, EventArgs a) =>
            {
                var result = await vm.CheckCurrentOrderStatus();
                var cleanResult = result.Remove(0, 1).Remove(result.Length -2, 1);
                MessageBox.Show(cleanResult);
                if (cleanResult == "Delivered")
                {
                    checkerTimer.Stop();
                    return;
                }
            });
            checkerTimer.Start();
        }
        private void cancel_checking_order_job_Click(object sender, RoutedEventArgs e)
        {
            _isCheckOrderJobRunning = false;
            EnableDisableCheckOrderButtons();
            _timer.Stop();
        }
        private async void Cancel_Order(object sender, RoutedEventArgs e)
        {
            _isNewOrderCreated = false;
            EnableDisableCreateOrderButtons();
            cancel_checking_order_job.IsEnabled = false;
            _timer.Stop();
            var vm = (ShellViewModel)this.DataContext;
            string result = string.Empty;
            try
            {
                result = await vm.DeleteLastOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(result);
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
                cancel_checking_order_job.IsEnabled = false;
                add_order_btn.IsEnabled = true;
            }
        }
    }
}
