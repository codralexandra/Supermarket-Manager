using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.EntityLayer;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace supermarket_manager.Converters
{
    class StockConvert : IMultiValueConverter
    {
        ProductBLL productBLL = new ProductBLL();
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Default values
            string productName = values[0]?.ToString() ?? string.Empty;
            string unit = values[5]?.ToString() ?? string.Empty;

            // Convert DateTime to DateOnly
            DateOnly acqDate = DateOnly.MinValue; ;
            if (values[2] is DateTime dateTime)
            {
                acqDate = DateOnly.FromDateTime(dateTime);
            }
            else if (DateOnly.TryParse(values[2]?.ToString(), out DateOnly parsedDate))
            {
                acqDate = parsedDate;
            }
            else
            {
                acqDate = DateOnly.FromDateTime(DateTime.Now); // Default to current date
            }

            // Convert quantity and prices
            int quantity = int.TryParse(values[1]?.ToString(), out int q) ? q : 0;
            float acqPrice = float.TryParse(values[3]?.ToString(), out float ap) ? ap : 0f;
            float sellPrice = float.TryParse(values[4]?.ToString(), out float sp) ? sp : 0f;

            return new Stock()
            {
                Product = productName,
                Quantity = quantity,
                Acq_Date = acqDate,
                Acq_Price = acqPrice,
                Sell_Price = sellPrice,
                Unit = unit
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
