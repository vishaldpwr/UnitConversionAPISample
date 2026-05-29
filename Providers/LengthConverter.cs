namespace UnitConversionAPI.Providers
{
    public class LengthConverter : IUnitConverter
    {
        public string Unit => "Length";

        public double Convert(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == "m" && toUnit == "ft")
            {
                return value * 3.28084;
            }

            if (fromUnit == "ft" && toUnit == "m") 
            {
                return value / 3.28084;
            }

            return value;
        }
    }
}
