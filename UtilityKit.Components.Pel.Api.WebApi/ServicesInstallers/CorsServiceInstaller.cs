using UtilityKit.Components.Pel.Application.Shared.Interfaces;

namespace UtilityKit.Components.Pel.Api.WebApi.ServicesInstallers
{
    public class CorsServiceInstaller : IServiceInstaller
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                       builder =>
                       {
                           builder
                           .AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                           /*
                               builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(
                               configuration.GetSection("CorsOrigins").Get<List<string>>().ToArray());

                           */
                       });
            });
        }
    }
}
