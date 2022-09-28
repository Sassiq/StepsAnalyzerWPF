using StepsAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StepsAnalyzer.ViewModel
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
            User user = new User();
            user.Name = "Stas";
            user.Days.Add(new Day() { Number = 1, Status = Status.Finished, UserRank = 1, UserSteps = 10000 });
            Users.Add(user);
            Users.Add(user);

            User user1 = new User();
            user1.Name = "Who";
            user1.Days.Add(new Day() { Number = 3, Status = Status.Finished, UserRank = 2, UserSteps = 4021 });
            Users.Add(user1);
            selectedUser = user;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
