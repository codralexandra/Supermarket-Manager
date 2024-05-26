using System.Globalization;
using System.Windows.Controls;

namespace supermarket_manager.Service
{
    public class SellPriceValidationRule : ValidationRule
    {
        public TextBox AcqPriceTextBox { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (AcqPriceTextBox == null || !decimal.TryParse(AcqPriceTextBox.Text, out decimal acqPrice))
            {
                return new ValidationResult(false, "Invalid acquisition price.");
            }

            if (decimal.TryParse(value.ToString(), out decimal sellPrice))
            {
                if (sellPrice < acqPrice)
                {
                    return new ValidationResult(false, "Sell Price cannot be lower than Acquisition Price.");
                }
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Invalid sell price.");
        }
    }
}
