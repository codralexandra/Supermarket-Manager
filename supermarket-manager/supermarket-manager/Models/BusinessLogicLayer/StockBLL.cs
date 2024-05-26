using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;

namespace supermarket_manager.Models.BusinessLogicLayer
{
    class StockBLL
    {
        public ObservableCollection<Stock> StockList { get; set; }
        StockDAL stockDAL = new StockDAL();
        ProductDAL productDAL = new ProductDAL();
        string BarCodeSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public ObservableCollection<Stock> GetAllStocks()
        {
            return stockDAL.GetAllStocks();
        }
        public void AddStock(Stock stock)
        {
            if (stock == null || stock.Product== null || stock.Quantity == 0 || stock.Unit == null || stock.Acq_Date == DateOnly.MinValue || stock.Acq_Price == 0)
            {
                MessageBox.Show("All fields are mandatory");
            }
            else if(stock.Sell_Price < stock.Acq_Price)
            {
                MessageBox.Show("Selling price can't be smaller than acquisition price!");
            }
            else
            {
                stockDAL.AddStock(stock);
                StockList.Add(stock);
                
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string barcode = new string(Enumerable.Repeat(chars, 4)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                DateOnly expDate = stock.Acq_Date.AddMonths(2);

                Product product = productDAL.GetProductByName(stock.Product);
                if (product != null)
                {
                    product.BarCode = barcode;
                    product.ExpDate = expDate;
                    productDAL.ModifyProductForStock(product);
                }
            }
        }
        public void UpdateStock(Stock stock)
        {
            if (stock == null || stock.Product == null || stock.Quantity == 0 || stock.Unit == null || stock.Acq_Date == DateOnly.MinValue || stock.Acq_Price == 0)
            {
                MessageBox.Show("All fields are mandatory");
            }
            else
            {
                stockDAL.ModifyStock(stock);
            }
        }
        public void DeleteStock(Stock stock)
        {
            if (stock == null || stock.Product == null || stock.Quantity == 0 || stock.Unit == null || stock.Acq_Date == DateOnly.MinValue || stock.Acq_Price == 0)
            {
                MessageBox.Show("All fields are mandatory");
            }
            else
            {
                stockDAL.DeleteStock(stock);
                StockList.Remove(stock);
            }
        }
    }
}
