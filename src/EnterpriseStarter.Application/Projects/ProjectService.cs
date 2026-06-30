// Copyright (c) 2026 ChuA Technologies LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Technologies Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Common;
using EnterpriseStarter.Domain.Projects;

namespace EnterpriseStarter.Application.Projects;

public sealed class ProjectService : IProjectService
{
    private const int MaxNameLength = 120;
    private readonly IClock _clock;
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository, IClock clock)
    {
        _repository = repository;
        _clock = clock;
    }

    public async Task<IReadOnlyCollection<ProjectResponse>> ListAsync(CancellationToken cancellationToken)
    {
        var projects = await _repository.ListAsync(cancellationToken);

        return projects
            .OrderBy(project => project.Name, StringComparer.OrdinalIgnoreCase)
            .Select(ToResponse)
            .ToArray();
    }

    public async Task<ProjectResponse?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var project = await _repository.GetAsync(id, cancellationToken);

        return project is null ? null : ToResponse(project);
    }

    public async Task<OperationResult<ProjectResponse>> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var validationError = Validate(request);
        if (validationError is not null)
        {
            return OperationResult<ProjectResponse>.Failure(validationError);
        }

        var project = new ProjectItem(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            ProjectStatus.Active,
            _clock.UtcNow);

        await _repository.AddAsync(project, cancellationToken);

        return OperationResult<ProjectResponse>.Success(ToResponse(project));
    }

    private static string? Validate(CreateProjectRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return "Project name is required.";
        }

        if (request.Name.Trim().Length > MaxNameLength)
        {
            return $"Project name must be {MaxNameLength} characters or fewer.";
        }

        return null;
    }

    private static ProjectResponse ToResponse(ProjectItem project)
    {
        return new ProjectResponse(
            project.Id,
            project.Name,
            project.Description,
            project.Status.ToString(),
            project.CreatedAtUtc);
    }
}
