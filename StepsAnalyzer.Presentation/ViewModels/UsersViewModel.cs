using StepsAnalyzer.Interfaces;
using StepsAnalyzer.Models;
using StepsAnalyzer.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StepsAnalyzer.Presentation.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private User? selectedUser;
        private RelayCommand saveCommand;
        private IUserSerializer serializer;
        private IDialogService dialogService;

        public ObservableCollection<User> Users { get; }

        public RelayCommand SaveCommand
        {
            get => saveCommand ??
                (saveCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (dialogService.SaveFileDialog())
                        {
                            serializer.Serialize(Users, dialogService.FilePath);
                            dialogService.ShowMessage("Successfully saved.");
                        }
                    }
                    catch (Exception e)
                    {
                        dialogService.ShowMessage(e.Message);
                    }
                }));
        }

        public User? SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public UsersViewModel(IUserDeserializer deserializer, IUserSerializer serializer, IDialogService dialogService)
        {
            if (deserializer is null)
            {
                throw new ArgumentNullException(nameof(deserializer));
            }

            if (serializer is null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            if (dialogService is null)
            {
                throw new ArgumentNullException(nameof(dialogService));
            }

            this.serializer = serializer;
            this.dialogService = dialogService;
            Users = new ObservableCollection<User>(deserializer.GetUsers());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
