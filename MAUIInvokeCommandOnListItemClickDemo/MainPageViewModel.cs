using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MAUIInvokeCommandOnListItemClickDemo
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> userList;

        [ObservableProperty]
        private string user;

        public MainPageViewModel()
        {
            GetUserList();
        }

        [RelayCommand]
        public void AddUser()
        {
            Application.Current.Dispatcher.Dispatch(() =>
            {
                if (!string.IsNullOrEmpty(User))
                {
                    UserList.Add(User);
                    User = string.Empty;
                }
            });
        }

        [RelayCommand]
        public void DeleteUser(string user)
        {
            Application.Current.Dispatcher.Dispatch(() =>
            {
                if (!string.IsNullOrEmpty(user))
                {
                    UserList.Remove(user);
                }
            });
        }

        private void GetUserList()
        {
            UserList = new ObservableCollection<string>()
            {
                "User 1",
                "User 2",
                "User 3",
                "User 4",
                "User 5",
            };
        }
    }
}
