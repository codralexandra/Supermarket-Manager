using WpfMVVMAgendaCommands.Models;

namespace supermarket_manager.Models.EntityLayer
{
    class Stock : BasePropertyChanged
    {
        private int id;
        private string product;
        private int quantity;
        private string unit;
        private DateOnly acq_date;
        private float acq_price;
        private float sell_price;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                NotifyPropertyChanged("Product");
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                NotifyPropertyChanged("Unit");
            }
        }

        public DateOnly Acq_Date
        {
            get { return acq_date; }
            set
            {
                acq_date = value;
                NotifyPropertyChanged("Acq_Date");
            }
        }

        public float Acq_Price
        {
            get { return acq_price; }
            set
            {
                acq_price = value;
                NotifyPropertyChanged("Acq_Price");
            }
        }
        public float Sell_Price
        {
            get { return sell_price; }
            set
            {
                sell_price = value;
                NotifyPropertyChanged("Sell_Price");
            }
        }

    }
}
