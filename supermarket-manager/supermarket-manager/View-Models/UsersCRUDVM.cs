using supermarket_manager.Models;
using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class UsersCRUDVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();
        public List<string> Roles { get; set; }
        public ObservableCollection<User> UsersList
        {
            get => userBLL.UsersList;
            set => userBLL.UsersList = value;
        }
        public UsersCRUDVM()
        {
            UsersList = userBLL.GetAllUsers();
            Roles = new List<string>
            {
                "Admin",
                "Cashier"
            };
        }

        #region Commands

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<User>(userBLL.AddUser);
                }
                return addCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if(deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<User>(userBLL.DeleteUser);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
