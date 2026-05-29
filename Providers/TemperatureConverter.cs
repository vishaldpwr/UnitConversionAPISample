namespace UnitConversionAPI.Providers
{
    public class TemperatureConverter : IUnitConverter
    {
        public string Unit => "Temperature";

        public double Convert(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == "f" && toUnit == "f")
            {
                return (value * 9 / 5) + 32;
            }
            if (fromUnit == "f" && toUnit == "c")
            {
                return (value - 32) * 5 / 9;
            }
            return value;
        }
    }
}
