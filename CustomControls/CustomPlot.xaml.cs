using StepsAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for CustomPlot.xaml
    /// </summary>
    public partial class CustomPlot : UserControl
    {
        public static DependencyProperty UserProperty;

        public User User
        {
            get => (User)GetValue(UserProperty);
            set => SetValue(UserProperty, value);
        }

        static CustomPlot()
        {
            UserProperty = DependencyProperty.Register("User", typeof(User), typeof(CustomPlot),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnUserChanged)));
        }

        public CustomPlot()
        {
            InitializeComponent();

            Plot.Refresh();
        }

        private static void OnUserChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            User user = (User)e.NewValue;
            CustomPlot customPlot = (CustomPlot)sender;
            customPlot.Plot.Plot.Clear();

            int daysCount = user.Days.Count;
            double[] dataX = new double[daysCount];
            double[] dataY = new double[daysCount];

            int index = 0;

            foreach (Day day in user.Days.OrderBy(day => day.Number))
            {
                dataX[index] = day.Number;
                dataY[index] = day.UserSteps;
                index++;
            }

            customPlot.Plot.Plot.AddScatter(dataX, dataY);
            customPlot.Plot.Refresh();
        }
    }
}