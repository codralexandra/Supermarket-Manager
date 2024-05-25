using supermarket_manager.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace supermarket_manager.Converters
{
    internal class CategoryConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null)
            {
                return new Category()
                {
                    Name = values[0].ToString(),
                };
            }
            return null;
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
