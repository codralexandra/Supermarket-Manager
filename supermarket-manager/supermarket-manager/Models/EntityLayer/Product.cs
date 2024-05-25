using WpfMVVMAgendaCommands.Models;

namespace supermarket_manager.Models.EntityLayer
{
    class Product : BasePropertyChanged
    {
        private int id;
        private string? name;
        private string? barCode;
        private DateOnly? expDate;
        private int? categoryId;    //FK
        private int? suplierId;      //FK
        private bool valid;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string? BarCode
        {
            get { return barCode; }
            set
            {
                barCode = value;
                NotifyPropertyChanged("BarCode");
            }
        }

        public DateOnly? ExpDate
        {
            get { return expDate; }
            set
            {
                expDate = value;
                NotifyPropertyChanged("ExpDate");
            }
        }

        public int? CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                NotifyPropertyChanged("CategoryId");
            }
        }

        public int? SuplierId
        {
            get { return suplierId; }
            set
            {
                suplierId = value;
                NotifyPropertyChanged("SuplierId");
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
