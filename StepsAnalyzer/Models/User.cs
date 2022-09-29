using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            private set => averageSteps = value;
        }

        public uint BestStepsResult
        {
            get => bestStepsResult;
            private set => bestStepsResult = value;
        }

        public uint WorstStepsResult
        {
            get => worstStepsResult;
            private set => worstStepsResult = value;
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
            OnPropertyChanged("AverageSteps");
        }

        private void CalculateBestStepsResult()
        {
            this.BestStepsResult = (uint)Days.Max(day => day.UserSteps);
            OnPropertyChanged("BestStepsResult");
        }

        private void CalculateWorstStepsResult()
        {
            this.WorstStepsResult = (uint)Days.Min(day => day.UserSteps);
            OnPropertyChanged("WorstStepsResult");
        }
    }
}
