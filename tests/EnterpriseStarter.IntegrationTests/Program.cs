// Copyright (c) 2026 ChuA Technologies LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Technologies Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Projects;
using EnterpriseStarter.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddEnterpriseStarterInfrastructure()
    .BuildServiceProvider();

using var scope = services.CreateScope();
var projectService = scope.ServiceProvider.GetRequiredService<IProjectService>();

var created = await projectService.CreateAsync(
    new CreateProjectRequest("Integration Check", "Verifies DI and repository wiring."),
    CancellationToken.None);

Assert.True(created.Succeeded, "Project creation should succeed through DI.");
Assert.NotNull(created.Value, "Created project should return a response.");

var loaded = await projectService.GetAsync(created.Value!.Id, CancellationToken.None);

Assert.NotNull(loaded, "Created project should be retrievable from the configured repository.");
Assert.Equal("Integration Check", loaded!.Name, "Retrieved project should match created project.");

Console.WriteLine("Integration checks passed.");

internal static class Assert
{
    public static void True(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    public static void NotNull(object? value, string message)
    {
        True(value is not null, message);
    }

    public static void Equal<T>(T expected, T actual, string message)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new InvalidOperationException($"{message} Expected '{expected}', got '{actual}'.");
        }
    }
}
