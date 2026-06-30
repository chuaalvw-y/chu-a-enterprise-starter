// Copyright (c) 2026 ChuA Technologies LLC.
// GitHub: chuaalvw-y
// Licensed under the ChuA Technologies Proprietary Use-Only License.
// See LICENSE.txt in the project root for full license information.

namespace EnterpriseStarter.Application.Common;

public sealed record OperationResult<T>(bool Succeeded, T? Value, string? Error)
{
    public static OperationResult<T> Success(T value)
    {
        return new OperationResult<T>(true, value, null);
    }

    public static OperationResult<T> Failure(string error)
    {
        return new OperationResult<T>(false, default, error);
    }
}
