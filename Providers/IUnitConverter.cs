namespace UnitConversionAPI.Providers
{
    public interface IUnitConverter
    {
        /// <summary>
        /// Name of Unit
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Performs the conversion from one unit to another.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="fromUnit">The unit to convert from.</param>
        /// <param name="toUnit">The unit to convert to.</param>
        /// <returns>The converted value.</returns>
        double Convert(double value, string fromUnit, string toUnit);

    }
}
