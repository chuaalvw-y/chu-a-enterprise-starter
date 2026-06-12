// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Domain.Projects;

namespace EnterpriseStarter.Application.Projects;

public interface IProjectRepository
{
    Task<IReadOnlyCollection<ProjectItem>> ListAsync(CancellationToken cancellationToken);

    Task<ProjectItem?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(ProjectItem project, CancellationToken cancellationToken);
}
