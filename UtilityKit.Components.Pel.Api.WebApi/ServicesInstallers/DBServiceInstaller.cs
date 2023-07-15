using UtilityKit.Components.Pel.Application.Shared.Interfaces;
using UtilityKit.Components.Pel.Infrastrcuture;
using Microsoft.EntityFrameworkCore;

namespace UtilityKit.Components.Pel.Api.WebApi.ServicesInstallers
{
    public class DBServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            services.AddDbContext<PelDbContext>(options =>
                options.UseNpgsql(configuration.GetValue<string>("DBSettigs:ConnectionString")));
        }
    }
}
