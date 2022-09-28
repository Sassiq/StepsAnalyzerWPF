using StepsAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StepsAnalyzer.ViewModels
{
    internal class UsersViewModel : INotifyPropertyChanged
    {
        private User selectedUser;
        public ObservableCollection<User> Users { get; }

        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public UsersViewModel()
        {
            Users = new ObservableCollection<User>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
