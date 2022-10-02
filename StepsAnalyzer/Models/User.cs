using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StepsAnalyzer.Models
{
    public class User : INotifyPropertyChanged
    {
        private string name;
        private uint averageSteps;
        private uint bestStepsResult;
        private uint worstStepsResult;

        public ObservableCollection<Day> Days { get; }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public uint AverageSteps
        {
            get => averageSteps;
            private set
            {
                averageSteps = value;
                OnPropertyChanged("AverageSteps");
            }
        }

        public uint BestStepsResult
        {
            get => bestStepsResult;
            private set
            {
                bestStepsResult = value;
                OnPropertyChanged("BestStepsResult");
            }
        }

        public uint WorstStepsResult
        {
            get => worstStepsResult;
            private set
            {
                worstStepsResult = value;
                OnPropertyChanged("WorstStepsResult");
            }
        }

        public bool IsStable
        {
            get => AverageSteps * 0.8 > WorstStepsResult || AverageSteps * 1.2 < BestStepsResult;
        }

        public User()
        {
            Days = new ObservableCollection<Day>();
            Days.CollectionChanged += (_, _) =>
            {
                OnPropertyChanged("Days");
                CalculateAverageSteps();
                CalculateBestStepsResult();
                CalculateWorstStepsResult();
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        private void CalculateAverageSteps()
        {
            this.AverageSteps = (uint)Days.Average(day => day.UserSteps);
        }

        private void CalculateBestStepsResult()
        {
            this.BestStepsResult = (uint)Days.Max(day => day.UserSteps);
        }

        private void CalculateWorstStepsResult()
        {
            this.WorstStepsResult = (uint)Days.Min(day => day.UserSteps);
        }
    }
}
