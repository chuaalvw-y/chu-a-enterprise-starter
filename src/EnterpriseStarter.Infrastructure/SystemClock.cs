// Copyright (c) 2026 Alvin Wilsen Chan Chua
// GitHub: chuaalvw-y
// Licensed under the Alvin Wilsen Chan Chua Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

using EnterpriseStarter.Application.Common;

namespace EnterpriseStarter.Infrastructure;

public sealed class SystemClock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
