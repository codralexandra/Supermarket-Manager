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
        SuplierBLL suplierBLL = new SuplierBLL();
        public ObservableCollection<Product> ProducList
        {
            get => productBLL.ProductList;
            set => productBLL.ProductList = value;
        }
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<string> Supliers { get; set; }
        public ProductsCRUDVM()
        {
            ProducList = productBLL.GetAllProducts();
            Categories = new ObservableCollection<string>();
            Supliers = new ObservableCollection<string>();
            foreach(Category category in categoryBLL.GetAllCategories())
            {
                Categories.Add(categoryBLL.GetCategoryName(category.Id));
            }
            foreach(Suplier suplier in suplierBLL.GetAllSupliers())
            {
                Supliers.Add(suplierBLL.GetSuplierName(suplier.Id));
            }
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
