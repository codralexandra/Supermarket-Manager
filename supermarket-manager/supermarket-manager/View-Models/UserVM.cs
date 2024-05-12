using supermarket_manager.Models;
using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.EntityLayer;
using supermarket_manager.Views;
using System.Windows;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    public class UserVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    NotifyPropertyChanged(nameof(Username));
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged(nameof(Password));
                }
            }
        }
        public ICommand LoginCommand { get; }

        public UserVM()
        {
            LoginCommand = new RelayCommand<object>(Login);
        }

        #region Commands
        private void Login(object parameter)
        {
            Role role = userBLL.GetUserByLogin(username, password);

            if (role == Role.Admin)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (role == Role.Cashier)
            {
                CashierWindow cashierWindow = new CashierWindow();
                cashierWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
        #endregion
    }
}
