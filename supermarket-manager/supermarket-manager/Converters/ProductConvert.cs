using supermarket_manager.Models.EntityLayer;
using System.Windows.Data;

namespace supermarket_manager.Converters
{
    class ProductConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Default values
            string name = values[0]?.ToString() ?? string.Empty;
            int categoryId = 0;
            int suplierId = 0;

            // Try to parse CategoryId and SuplierId, with default values if parsing fails
            if (values[1] != null && !int.TryParse(values[1].ToString(), out categoryId))
            {
                // Handle the error or provide a default value
                categoryId = 0; // Or any other default value or error handling
            }

            if (values[2] != null && !int.TryParse(values[2].ToString(), out suplierId))
            {
                // Handle the error or provide a default value
                suplierId = 0; // Or any other default value or error handling
            }

            return new Product()
            {
                Name = name,
                BarCode = "0000",                   // Defaults
                ExpDate = new DateOnly(2000, 1, 1), // Defaults
                CategoryId = categoryId,
                SuplierId = suplierId
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
