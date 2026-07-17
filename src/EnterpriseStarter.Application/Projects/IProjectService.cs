// Copyright (c) 2026 ChuA Unified Platforms LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Unified Platforms Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Common;

namespace EnterpriseStarter.Application.Projects;

public interface IProjectService
{
    Task<IReadOnlyCollection<ProjectResponse>> ListAsync(CancellationToken cancellationToken);

    Task<ProjectResponse?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<OperationResult<ProjectResponse>> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken);
}
