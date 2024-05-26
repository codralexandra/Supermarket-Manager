using supermarket_manager.Views;
using System.Windows.Input;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class CashierVM
    {
        public ICommand searchCommand { get; set; }
        public CashierVM()
        {
            searchCommand = new RelayCommand<object>(SearchPage);
        }
        private void SearchPage(object parameter)
        {
            SearchProductWindow searchWindow = new SearchProductWindow();
            searchWindow.Show();
        }
    }
}
