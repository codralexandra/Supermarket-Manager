using WpfMVVMAgendaCommands.Models;

namespace supermarket_manager.Models.EntityLayer
{
    class Product : BasePropertyChanged
    {
        private int id;
        private string name;
        private string barCode;
        private DateOnly expDate;
        private int categoryId;    //FK
        private string categoryName;
        private int suplierId;      //FK
        private string suplierName;
        private bool valid;

        public Product()
        {
        }

        public Product(string product, string bar_code, DateOnly exp_date, int v1, int v2, bool v3)
        {
            this.name = product;
            this.barCode = bar_code;
            this.expDate = exp_date;
            this.categoryId = v1;
            this.suplierId = v2;
            this.valid = v3;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string BarCode
        {
            get { return barCode; }
            set
            {
                barCode = value;
                NotifyPropertyChanged("BarCode");
            }
        }

        public DateOnly ExpDate
        {
            get { return expDate; }
            set
            {
                expDate = value;
                NotifyPropertyChanged("ExpDate");
            }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                NotifyPropertyChanged("CategoryId");
            }
        }
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                NotifyPropertyChanged("CategoryName");
            }
        }

        public int SuplierId
        {
            get { return suplierId; }
            set
            {
                suplierId = value;
                NotifyPropertyChanged("SuplierId");
            }
        }
        public string SuplierName
        {
            get { return suplierName; }
            set
            {
                suplierName = value;
                NotifyPropertyChanged("SuplierName");
            }
        }

        public bool Valid
        {
            get { return valid; }
            set
            {
                valid = value;
                NotifyPropertyChanged("Valid");
            }
        }
    }
}
