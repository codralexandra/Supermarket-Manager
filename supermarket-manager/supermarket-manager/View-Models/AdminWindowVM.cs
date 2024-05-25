using supermarket_manager.Views;
using System.Windows.Input;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    internal class AdminWindowVM
    {
        public ICommand UserCommand { get; }
        public ICommand SuplierCommand { get; }
        public ICommand ProductCommand { get; }
        public ICommand CategoryCommand { get; }
        public ICommand StockCommand { get; }

        public AdminWindowVM()
        {
            UserCommand = new RelayCommand<object>(UserPage);
            SuplierCommand = new RelayCommand<object>(SuplierPage);
            ProductCommand = new RelayCommand<object>(ProductPage);
            CategoryCommand = new RelayCommand<object>(CategoryPage);
            StockCommand = new RelayCommand<object>(StockPage);
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

        private void ProductPage(object parameter)
        {
            ProductCRUD productCRUD = new ProductCRUD();
            productCRUD.Show();
        }
        private void CategoryPage(object parameter)
        {
            CategoryCRUD categoryCRUD = new CategoryCRUD();
            categoryCRUD.Show();
        }
        private void StockPage(object parameter)
        {
            StocksCRUD stocksCRUD = new StocksCRUD();
            stocksCRUD.Show();
        }
    }
}
