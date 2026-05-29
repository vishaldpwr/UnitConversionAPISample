UnitConversionAPI
=================

A small ASP.NET Core Web API for converting between units (length, weight, temperature, currency, etc.).

Key points
- Targets: .NET 10
- Single controller: Controllers/UnitConversionController.cs
- The Convert endpoint accepts a numeric "value" as part of the route and supports culture-aware parsing using the Accept-Language request header.

Build and run
1. From the repository root run:
   dotnet build
   dotnet run --project UnitConversionAPI.csproj

2. The API hosts endpoints under /api/UnitConversion when running locally (see launchSettings.json for configured URLs).

Convert endpoint
GET /api/UnitConversion/{value}/{fromUnit}/{toUnit}/{precision?}

Parameters
- value: numeric value to convert (provided in the route). The value is parsed using the culture supplied in the Accept-Language header (falls back to invariant culture when none or unrecognized).
- fromUnit: unit code or name (examples: m, km, ft, lb, kg, inr, usd, c, f)
- toUnit: unit to convert into
- precision (optional): integer number of decimal places to format the response

Culture-aware parsing
- If the client sends an Accept-Language header (for example: "en-US" or "de-DE,fr-CA;q=0.8"), the API uses the first language token to determine the CultureInfo used to parse the incoming value.
- Example differences:
  - en-US: decimal separator is '.'  -> value = "1.23"
  - de-DE: decimal separator is ','  -> value = "1,23"

Examples
- Request: GET /api/UnitConversion/8600.15/g/kg
  Headers: Accept-Language: en-US
  Response: converted value formatted to two decimal places (default)

- Request: GET /api/UnitConversion/8600,15/g/kg
  Headers: Accept-Language: de-DE
  Response: parsed as 8.60

Error handling
- Returns 400 Bad Request for:
  - invalid numeric value for the chosen culture
  - unsupported or invalid unit conversion
  - other conversion errors (InvalidOperationException messages are returned)

Project Structure
- Controllers/UnitConversionController.cs: API controller handling conversion requests.
- Converters/: contains unit converter classes for different categories (LengthConverter, WeightConverter, TemperatureConverter, CurrencyConverter) implementing IUnitConverter interface.
- UnitConversionManager.cs: orchestrates the conversion process by determining the appropriate converter based on the fromUnit and toUnit parameters and invoking the conversion method.
- UnitMapProvider.cs: provides mapping of unit codes/names to their corresponding converter implementations. In future iterations this could be extended to load data from a configuration file or database for greater flexibility.

Notes
- Solution is implemented with factory pattern for unit converters, making it easy to add new unit types and conversions in the future.
- UnitMapProvider.cs contains the mapping of unit codes/names to their corresponding converter implementations. 
- In future iterations, this could be extended to support more units and categories (volume, speed, etc.) and even loaded from a configuration file or database for greater flexibility.
- Unit conversion logic is encapsulated in separate classes (LengthConverter, WeightConverter, TemperatureConverter, CurrencyConverter) that implement a common IUnitConverter interface.
- UnitConversionManager.cs is responsible for orchestrating the conversion process by determining the appropriate converter based on the fromUnit and toUnit parameters and invoking the conversion method.
- Logging, validations and error handling can be further enhanced for better maintainability and user experience. 
- Additional : as the numeric value is part of the route, URL encoding may be required for some locales (for example, when using a comma as the decimal separator you may need to 
- encode the comma or use the Accept-Language header appropriately).

License
This workspace contains demo code.
