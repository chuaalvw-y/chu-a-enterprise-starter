// Copyright (c) 2026 ChuA Technologies LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Technologies Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace EnterpriseStarter.Application.Projects;

public sealed record ProjectResponse(
    Guid Id,
    string Name,
    string? Description,
    string Status,
    DateTimeOffset CreatedAtUtc);
