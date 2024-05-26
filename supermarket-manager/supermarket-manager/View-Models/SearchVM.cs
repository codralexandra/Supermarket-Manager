using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class SearchVM : BasePropertyChanged
    {
        ProductBLL productBLL = new ProductBLL();
        SuplierBLL suplierBLL = new SuplierBLL();
        CategoryBLL categoryBLL = new CategoryBLL();
        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<Product> FilteredSearch { get; set; }
        public ObservableCollection<string> Options { get; set; }
        private string pickedOption { get; set; }
        public string PickedOption
        {
            get { return pickedOption; }
            set
            {
                pickedOption = value;
                NotifyPropertyChanged("PickedOption");
            }
        }

        private string searchParam { get; set; }
        public string SearchParam
        {
            get { return searchParam; }
            set
            {
                searchParam = value;
                NotifyPropertyChanged("SearchParam");
            }
        }

        public ICommand SearchProduct { get; set; }

        private void SearchProductOption(object parameter)
        {
            Product result;
            ObservableCollection<Product> results = new ObservableCollection<Product>();
            switch(PickedOption)
            {
                case "Name":
                    result = productBLL.GetProductByName(SearchParam);
                    if (result != null)
                    {
                        FilteredSearch.Clear();
                        FilteredSearch.Add(result);
                    }
                    else MessageBox.Show("No results found.");
                    break;
                case "Bar Code":
                    results = productBLL.GetProductByBarCode(SearchParam);
                    if(results.Count>0)
                    {
                        FilteredSearch.Clear();
                        foreach (Product product in results)
                            FilteredSearch.Add(product);
                    }
                    else MessageBox.Show("No results found.");
                    break;
                case "Exp Date":
                    results = productBLL.GetProductByExpDate(DateOnly.Parse(SearchParam));
                    if (results.Count > 0)
                    {
                        FilteredSearch.Clear();
                        foreach (Product product in results)
                            FilteredSearch.Add(product);
                    }
                    else MessageBox.Show("No results found.");
                    break;
                case "Suplier":
                    results = productBLL.GetProductBySuplier(suplierBLL.GetSuplierID(SearchParam));
                    if (results.Count > 0)
                    {
                        FilteredSearch.Clear();
                        foreach (Product product in results)
                            FilteredSearch.Add(product);
                    }
                    else MessageBox.Show("No results found.");
                    break;
                case "Category":
                    results = productBLL.GetProductByCategory(categoryBLL.GetCategoryID(SearchParam));
                    if (results.Count > 0)
                    {
                        FilteredSearch.Clear();
                        foreach (Product product in results)
                            FilteredSearch.Add(product);
                    }
                    else MessageBox.Show("No results found.");
                    break;
                default:
                    MessageBox.Show("Invalid option.");
                    break;

            }
        }

        public SearchVM()
        {
            ProductList = productBLL.GetAllProducts();
            FilteredSearch = new ObservableCollection<Product>();
            Options = new ObservableCollection<string>()
            {
                "Name",
                "Bar Code",
                "Exp Date",
                "Suplier",
                "Category"
            };
            SearchProduct = new RelayCommand<object>(SearchProductOption);
        }
    }
}
