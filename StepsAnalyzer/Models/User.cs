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
    internal class User : INotifyPropertyChanged
    {
        private string name;
        private uint averageSteps;
        public readonly ObservableCollection<Day> Days;

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
        
        public User()
        {
            Days = new ObservableCollection<Day>();
            Days.CollectionChanged += (_, _) => 
            {
                OnPropertyChanged("Days");
                CalculateAverageSteps();
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
    }
}
