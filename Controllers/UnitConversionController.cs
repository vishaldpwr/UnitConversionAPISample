using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using UnitConversionAPI.Managers;

namespace UnitConversionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class UnitConversionController : ControllerBase
    {
        private readonly IUnitConversionManager _conversionManager;
        public UnitConversionController(IUnitConversionManager conversionManager)
        {
            _conversionManager = conversionManager;
        }

        [HttpGet("{value}/{fromUnit}/{toUnit}/{precision?}")]
        public IActionResult Convert(string value, string fromUnit, string toUnit, int? precision = null)
        {
            try
            {

                // Verify if the conversion is valid for the specified unit and get the unit type
                var unit = _conversionManager.VerifyUnit(fromUnit, toUnit);
                if (unit == null)
                {
                    return BadRequest("Invalid unit conversion");
                }

                // Determine culture from Accept-Language header (use first language if multiple provided)
                var acceptLang = Request.Headers["Accept-Language"].ToString();
                CultureInfo culture = CultureInfo.InvariantCulture;

                if (string.IsNullOrWhiteSpace(acceptLang))
                {
                    acceptLang = "en-US"; // For demonstration, we will default to en-US if Accept-Language is not provided for any reason.                                          
                }

                var firstLang = acceptLang.Split(',')[0].Split(';')[0].Trim();
                try
                {
                    culture = CultureInfo.GetCultureInfo(firstLang);
                }
                catch (CultureNotFoundException)
                {
                    culture = CultureInfo.InvariantCulture;
                }

                // Parse the incoming value using the determined culture
                if (!double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, culture, out var parsedValue))
                {
                    return BadRequest($"Invalid numeric value '{value}' for culture '{culture.Name}'.");
                }

                // Perform the conversion
                var result = _conversionManager.Convert(parsedValue, fromUnit, toUnit, unit);
                if (precision.HasValue)
                {
                    return Ok(result.ToString($"F{precision.Value}")); // return result formatted to specified decimal places.
                }
                return Ok(result.ToString("F2"));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
