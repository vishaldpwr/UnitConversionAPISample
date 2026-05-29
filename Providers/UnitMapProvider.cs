using UnitConversionAPI.Models;

namespace UnitConversionAPI.Providers
{
    public class UnitMapProvider : IUnitMapProvider
    {
        public string VerifyUnit(string fromUnit, string toUnit)
        {
            // TODO : for future database based implementation            
            // Verify if the conversion is valid for the specified unit
            // Return the unit type if valid, otherwise return null or throw an exception.

            var unitMaps = GetUnitMaps(); // This should ideally come from a database or configuration file.

            var validMap = unitMaps.FirstOrDefault(map =>
                        (map.FromUnit.Equals(fromUnit) && map.ToUnit.Equals(toUnit)) || 
                        (map.FromUnit.Equals(toUnit) && map.ToUnit.Equals(fromUnit)));
            
            if (validMap != null)
            {
                return validMap.UnitType;
            }
            throw new InvalidOperationException($"No valid conversion found for units: {fromUnit} to {toUnit}");
        }

        public IEnumerable<UnitMap> GetUnitMaps()
        {
            return new List<UnitMap>
            {
                new UnitMap { FromUnit = "m", ToUnit = "ft", UnitType = "Length" },
                new UnitMap { FromUnit = "m", ToUnit = "cm", UnitType = "Length" },
                new UnitMap { FromUnit = "ft", ToUnit = "cm", UnitType = "Length" },
                new UnitMap { FromUnit = "kg", ToUnit = "g", UnitType = "Weight" },
                new UnitMap { FromUnit = "usd", ToUnit = "inr", UnitType = "Currency" },

                // Add more valid units as needed or fetch from a database
            };
        }
    }
}
