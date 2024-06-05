using KLA.Conversion.Interfaces;
using KLA.Conversion.Services;
using Microsoft.AspNetCore.HttpLogging;

namespace KLA.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddCors();
            services.AddScoped<IConvert, ConvertService>();

            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.Request | HttpLoggingFields.Response;
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
                logging.CombineLogs = true;
            });

            return services;
        }
    }
}
