﻿using supermarket_manager.Models.EntityLayer;
using System.Windows.Data;

namespace supermarket_manager.Converters
{
    class UserConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                return new User()
                {
                    Username = values[0].ToString(),
                    Password = values[1].ToString(),
                    Role = values[2].ToString()
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
