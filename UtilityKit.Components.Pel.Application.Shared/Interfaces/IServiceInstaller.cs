using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UtilityKit.Components.Pel.Application.Shared.Interfaces
{
    public interface IServiceInstaller
    {
        void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups);
    }
}
