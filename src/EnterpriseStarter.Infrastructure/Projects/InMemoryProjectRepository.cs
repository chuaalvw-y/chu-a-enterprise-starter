// Copyright (c) 2026 ChuA Technologies LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Technologies Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using System.Collections.Concurrent;
using EnterpriseStarter.Application.Projects;
using EnterpriseStarter.Domain.Projects;

namespace EnterpriseStarter.Infrastructure.Projects;

public sealed class InMemoryProjectRepository : IProjectRepository
{
    private readonly ConcurrentDictionary<Guid, ProjectItem> _projects = new();

    public Task<IReadOnlyCollection<ProjectItem>> ListAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult<IReadOnlyCollection<ProjectItem>>(_projects.Values.ToArray());
    }

    public Task<ProjectItem?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _projects.TryGetValue(id, out var project);

        return Task.FromResult(project);
    }

    public Task AddAsync(ProjectItem project, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (!_projects.TryAdd(project.Id, project))
        {
            throw new InvalidOperationException($"Project '{project.Id}' already exists.");
        }

        return Task.CompletedTask;
    }
}
