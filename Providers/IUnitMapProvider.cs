using UnitConversionAPI.Models;

namespace UnitConversionAPI.Providers
{
    public interface IUnitMapProvider
    {
        public string VerifyUnit(string fromUnit, string toUnit);
        public IEnumerable<UnitMap> GetUnitMaps();
    }
}