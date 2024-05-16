using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models;
using supermarket_manager.Views;
using System.Windows;
using System.Windows.Input;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    internal class AdminWindowVM
    {
        public ICommand UserCommand { get; }
        public ICommand SuplierCommand { get; }

        public AdminWindowVM()
        {
            UserCommand = new RelayCommand<object>(UserPage);
            SuplierCommand = new RelayCommand<object>(SuplierPage);
        }

        private void UserPage(object parameter)
        {
            UsersCRUD usersCRUd = new UsersCRUD();
            usersCRUd.Show();
        }

        private void SuplierPage(object parameter)
        {
            SupliersCRUD supliersCRUD = new SupliersCRUD();
            supliersCRUD.Show();
        }
    }
}
