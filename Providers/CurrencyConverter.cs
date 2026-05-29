namespace UnitConversionAPI.Providers
{
    public class CurrencyConverter : IUnitConverter
    {
        public string Unit => "Currency";

        public double Convert(double value, string fromUnit, string toUnit)
        {
            // For demonstration purposes, we will use a fixed conversion rate. In a real application, you would likely want to fetch current exchange rates from an API.
            // based on the fromUnit and toUnit, you would determine the appropriate conversion rate. Here we will just demonstrate a conversion from USD to INR.

            double conversionRate = 92.15; // Example conversion rate from USD to INR
            if (fromUnit == "usd" && toUnit == "inr")
            {
                return value * conversionRate;
            }

            return value; 
        }

        
    }
}
