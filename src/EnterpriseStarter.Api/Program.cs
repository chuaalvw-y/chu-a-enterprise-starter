// Copyright (c) 2026 ChuA Unified Platforms LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Unified Platforms Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Projects;
using EnterpriseStarter.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddEnterpriseStarterInfrastructure();

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await Results.Problem(
            title: "Unexpected error",
            detail: "The request could not be completed.",
            statusCode: StatusCodes.Status500InternalServerError)
            .ExecuteAsync(context);
    });
});

app.MapHealthChecks("/health");

var projects = app.MapGroup("/api/projects");

projects.MapGet("/", async (IProjectService service, CancellationToken cancellationToken) =>
{
    var response = await service.ListAsync(cancellationToken);

    return Results.Ok(response);
});

projects.MapGet("/{id:guid}", async (Guid id, IProjectService service, CancellationToken cancellationToken) =>
{
    var response = await service.GetAsync(id, cancellationToken);

    return response is null ? Results.NotFound() : Results.Ok(response);
});

projects.MapPost("/", async (CreateProjectRequest request, IProjectService service, CancellationToken cancellationToken) =>
{
    var result = await service.CreateAsync(request, cancellationToken);
    if (!result.Succeeded || result.Value is null)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["name"] = [result.Error ?? "Project request is invalid."]
        });
    }

    return Results.Created($"/api/projects/{result.Value.Id}", result.Value);
});

app.Run();
