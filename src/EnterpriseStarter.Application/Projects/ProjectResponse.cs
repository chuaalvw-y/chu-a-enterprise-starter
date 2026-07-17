// Copyright (c) 2026 ChuA Unified Platforms LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Unified Platforms Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace EnterpriseStarter.Application.Projects;

public sealed record ProjectResponse(
    Guid Id,
    string Name,
    string? Description,
    string Status,
    DateTimeOffset CreatedAtUtc);
