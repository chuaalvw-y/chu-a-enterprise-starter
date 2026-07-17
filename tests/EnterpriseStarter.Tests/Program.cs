// Copyright (c) 2026 ChuA Unified Platforms LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Unified Platforms Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Common;
using EnterpriseStarter.Application.Projects;
using EnterpriseStarter.Infrastructure.Projects;

var tests = new TestRunner();

await tests.RunAsync("Create project returns active response", async () =>
{
    var service = CreateService();
    var result = await service.CreateAsync(new CreateProjectRequest("Reference Project", "Public-safe sample"), CancellationToken.None);

    Assert.True(result.Succeeded, "Project creation should succeed.");
    Assert.NotNull(result.Value, "Project response should be returned.");
    Assert.Equal("Reference Project", result.Value!.Name, "Project name should match.");
    Assert.Equal("Active", result.Value.Status, "Project should be active.");
});

await tests.RunAsync("Blank name fails validation", async () =>
{
    var service = CreateService();
    var result = await service.CreateAsync(new CreateProjectRequest(" ", null), CancellationToken.None);

    Assert.False(result.Succeeded, "Blank name should fail validation.");
    Assert.Equal("Project name is required.", result.Error, "Validation message should be clear.");
});

await tests.RunAsync("List returns created projects", async () =>
{
    var service = CreateService();
    await service.CreateAsync(new CreateProjectRequest("Beta", null), CancellationToken.None);
    await service.CreateAsync(new CreateProjectRequest("Alpha", null), CancellationToken.None);

    var projects = await service.ListAsync(CancellationToken.None);

    Assert.Equal(2, projects.Count, "List should contain two projects.");
    Assert.Equal("Alpha", projects.First().Name, "List should be sorted by name.");
});

tests.Complete();

static ProjectService CreateService()
{
    return new ProjectService(new InMemoryProjectRepository(), new FixedClock());
}

internal sealed class FixedClock : IClock
{
    public DateTimeOffset UtcNow => new(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
}

internal sealed class TestRunner
{
    private int _count;

    public async Task RunAsync(string name, Func<Task> test)
    {
        await test();
        _count++;
        Console.WriteLine($"PASS: {name}");
    }

    public void Complete()
    {
        Console.WriteLine($"{_count} tests passed.");
    }
}

internal static class Assert
{
    public static void True(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    public static void False(bool condition, string message)
    {
        True(!condition, message);
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
