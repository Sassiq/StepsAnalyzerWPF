using StepsAnalyzer.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            Plot.Plot.XLabel("Day");
            Plot.Plot.YLabel("Steps");
            Plot.Refresh();
        }

        private static void OnUserChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            User user = (User)e.NewValue;
            CustomPlot customPlot = (CustomPlot)sender;
            customPlot.Plot.Plot.Clear();
            customPlot.Plot.Plot.Title(customPlot.User.Name);

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