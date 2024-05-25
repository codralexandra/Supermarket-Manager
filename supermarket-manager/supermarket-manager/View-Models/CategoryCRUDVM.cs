using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class CategoryCRUDVM
    {
       // public ObservableCollection<Category> Categories { get; set; }
        CategoryBLL categoryBLL = new CategoryBLL();

        public ObservableCollection<Category> Categories
        {
            get => categoryBLL.CategoryList;
            set => categoryBLL.CategoryList = value;
        }
        public CategoryCRUDVM()
        {
            Categories = categoryBLL.GetAllCategories();
        }

        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Category>(categoryBLL.AddCategory);
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
                    deleteCommand = new RelayCommand<Category>(categoryBLL.DeleteCategory);
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
                    updateCommand = new RelayCommand<Category>(categoryBLL.UpdateCategory);
                }
                return updateCommand;
            }
        }
        #endregion
    }
}
