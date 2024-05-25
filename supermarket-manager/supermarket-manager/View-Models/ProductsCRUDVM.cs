using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class ProductsCRUDVM
    {
        ProductBLL productBLL = new ProductBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        public ObservableCollection<Product> ProducList
        {
            get => productBLL.ProductList;
            set => productBLL.ProductList = value;
        }
        public ObservableCollection<Category> Categories
        {
            get => categoryBLL.CategoryList;
            set => categoryBLL.CategoryList = value;
        }
        public ProductsCRUDVM()
        {
            ProducList = productBLL.GetAllProducts();
        }

        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Product>(productBLL.AddProduct);
                }
                return addCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Product>(productBLL.DeleteProduct);
                }
                return deleteCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Product>(productBLL.ModifyProduct);
                }
                return updateCommand;
            }
        }
        #endregion
    }
}
