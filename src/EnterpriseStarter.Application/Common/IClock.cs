// Copyright (c) 2026 ChuA Technologies LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Technologies Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace EnterpriseStarter.Application.Common;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
