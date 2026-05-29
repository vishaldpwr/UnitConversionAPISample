namespace UnitConversionAPI.Managers
{
    public interface IUnitConversionManager
    {
        public double Convert(double value, string fromUnit, string toUnit, string unit);

        public string VerifyUnit(string fromUnit, string toUnit);
    }
}