using supermarket_manager.Models.BusinessLogicLayer;
using supermarket_manager.Models.DataAccessLayer;
using supermarket_manager.Models.EntityLayer;
using System.Windows.Data;

namespace supermarket_manager.Converters
{
    class ProductConvert : IMultiValueConverter
    {
        CategoryBLL categoryBLL = new CategoryBLL();
        SuplierBLL suplierBLL = new SuplierBLL();
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Default values
            string name = values[0]?.ToString() ?? string.Empty;
            string categoryName = values[1]?.ToString() ?? string.Empty;
            string suplierName = values[2]?.ToString() ?? string.Empty;

            return new Product()
            {
                Name = name,
                BarCode = "0000",                   // Defaults
                ExpDate = new DateOnly(2000, 1, 1), // Defaults
                CategoryId = categoryBLL.GetCategoryID(categoryName),
                CategoryName = categoryBLL.GetCategoryName(categoryBLL.GetCategoryID(categoryName)),
                SuplierId = suplierBLL.GetSuplierID(suplierName),
                SuplierName = suplierBLL.GetSuplierName(suplierBLL.GetSuplierID(suplierName))
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Person pers = value as Person;
            //object[] result = new object[2] { pers.Name, pers.Address };
            //return result;
            throw new NotImplementedException();
        }
    }
}
