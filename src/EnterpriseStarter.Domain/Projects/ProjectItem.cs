// Copyright (c) 2026 ChuA Unified Platforms LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Unified Platforms Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace EnterpriseStarter.Domain.Projects;

public sealed class ProjectItem
{
    public ProjectItem(Guid id, string name, string? description, ProjectStatus status, DateTimeOffset createdAtUtc)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Project id is required.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Project name is required.", nameof(name));
        }

        Id = id;
        Name = name.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        Status = status;
        CreatedAtUtc = createdAtUtc;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string? Description { get; }

    public ProjectStatus Status { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public void Archive()
    {
        Status = ProjectStatus.Archived;
    }
}
