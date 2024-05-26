using supermarket_manager.Models;
using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;
using WpfMVVMAgendaCommands.ViewModels;

namespace supermarket_manager.View_Models
{
    class StocksCRUDVM : BasePropertyChanged
    {
        StockBLL stockBLL = new StockBLL();
        ProductBLL productBLL = new ProductBLL();
        public ObservableCollection<Stock> StockList
        {
            get => stockBLL.StockList;
            set => stockBLL.StockList = value;
        }
        public ObservableCollection<string> Products { get; set; }
        public List<string> Units { get; set; }
        public StocksCRUDVM()
        {
            StockList = stockBLL.GetAllStocks();
            Products = new ObservableCollection<string>();
            acqDate = new DateOnly(2024,5,26);
            foreach (Product product in productBLL.GetAllProducts())
            {
                Products.Add(productBLL.GetProductName(product.Id));
            }
            Units = new List<string>
            {
                "Liter",
                "Kg",
                "Per piece"
            };
        }

        private DateOnly acqDate;
        public DateOnly AcqDate
        {
            get => acqDate;
            set
            {
                acqDate = value;
                NotifyPropertyChanged(nameof(AcqDate));
            }
        }

        private float sellPrice;

        private float acqPrice;

        public float AcqPrice
        {
            get { return acqPrice; }
            set
            {
                if (value != acqPrice)
                {
                    acqPrice = value;
                    NotifyPropertyChanged(nameof(AcqPrice));
                    UpdateSellPrice();
                }
            }
        }
        public float SellPrice
        {
            get { return sellPrice; }
            set
            {
                sellPrice = value;
                NotifyPropertyChanged("SellPrice");
            }
        }

        private void UpdateSellPrice()
        {
            float commercialAdd = float.Parse(ConfigurationManager.AppSettings[name: "CommercialAdd"]);
            SellPrice = AcqPrice + commercialAdd;
        }

        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Stock>(stockBLL.AddStock);
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
                    deleteCommand = new RelayCommand<Stock>(stockBLL.DeleteStock);
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
                    updateCommand = new RelayCommand<Stock>(stockBLL.UpdateStock);
                }
                return updateCommand;
            }
        }
        #endregion
    }
}
