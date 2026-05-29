using UnitConversionAPI.Managers;
using UnitConversionAPI.Providers;

namespace UnitConversionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Dependency Injection for Managers and Providers
            builder.Services.AddScoped<IUnitConversionManager, UnitConversionManager>();
            builder.Services.AddScoped<IUnitMapProvider, UnitMapProvider>();
            builder.Services.AddScoped<IUnitConverter, LengthConverter>();
            builder.Services.AddScoped<IUnitConverter, WeightConverter>();
            builder.Services.AddScoped<IUnitConverter, TemperatureConverter>();
            builder.Services.AddScoped<IUnitConverter, CurrencyConverter>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();            
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
