using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// configure CORS
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => 
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}