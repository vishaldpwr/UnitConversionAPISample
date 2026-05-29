namespace UnitConversionAPI.Providers
{
    public class WeightConverter : IUnitConverter
    {
        public string Unit => "Weight";

        public double Convert(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == "kg" && toUnit == "g")
            {
                return value * 1000;
            }
            if (fromUnit == "g" && toUnit == "kg")
            {
                return value / 1000;
            }
            return value;
        }
    }
}
