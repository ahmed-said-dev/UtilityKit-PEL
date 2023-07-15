﻿using UtilityKit.Components.Pel.Application.Shared.Interfaces;

namespace UtilityKit.Components.Pel.Api.WebApi.ServicesInstallers
{
    public class SwaggerServiceInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration, List<IProjectStartup> projectStartups)
        {
            services.AddSwaggerGen();
        }
    }
}