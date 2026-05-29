using UnitConversionAPI.Providers;

namespace UnitConversionAPI.Managers
{
    public class UnitConversionManager : IUnitConversionManager
    {
        private readonly IEnumerable<IUnitConverter> _unitConverters;
        private readonly IUnitMapProvider _unitMapProvider;
        public UnitConversionManager(
                                      IEnumerable<IUnitConverter> unitConverters,
                                      IUnitMapProvider unitMapProvider)
        {
            _unitConverters = unitConverters;
            _unitMapProvider = unitMapProvider;
        }

        public double Convert(double value, string fromUnit, string toUnit, string unit)
        {
            var converter = _unitConverters.FirstOrDefault(c => c.Unit.Equals(unit, StringComparison.OrdinalIgnoreCase));

            if (converter == null)
            {
                throw new InvalidOperationException($"No converter found for unit: {unit}");
            }
            return converter.Convert(value, fromUnit, toUnit);
        }


        // Verify if the conversion is valid for the specified unit
        // This method checks if there is a converter available for the given unit and returns a Convertory Unit Name.
        public string VerifyUnit(string fromUnit, string toUnit)
        {            
            return _unitMapProvider.VerifyUnit(fromUnit, toUnit);
        }
    }
}
