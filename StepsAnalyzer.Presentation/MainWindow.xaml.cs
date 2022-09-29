using StepsAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
