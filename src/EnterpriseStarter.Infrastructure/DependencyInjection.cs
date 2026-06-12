// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Common;
using EnterpriseStarter.Application.Projects;
using EnterpriseStarter.Infrastructure.Projects;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseStarter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddEnterpriseStarterInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<IProjectRepository, InMemoryProjectRepository>();
        services.AddScoped<IProjectService, ProjectService>();

        return services;
    }
}
