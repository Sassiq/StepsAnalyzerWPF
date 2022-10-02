using System.Windows;
using StepsAnalyzer.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace StepsAnalyzer.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var provider = new ResolverConfig().CreateServiceProvider();
            DataContext = provider.GetService<UsersViewModel>();
        }
    }
}
