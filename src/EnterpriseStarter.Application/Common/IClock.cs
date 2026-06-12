// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace EnterpriseStarter.Application.Common;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
