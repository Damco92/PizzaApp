using Caliburn.Micro;
using PizzaApp.WPF.ViewModels;
using System.Windows;

namespace PizzaApp.WPF
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
