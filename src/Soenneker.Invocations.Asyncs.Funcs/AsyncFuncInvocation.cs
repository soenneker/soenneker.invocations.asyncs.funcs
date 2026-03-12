using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Invocations.Asyncs.Funcs;

/// <summary>
/// Deferred, stateful asynchronous function invocation without closure capture.
/// </summary>
public sealed class AsyncFuncInvocation<T>
{
    private readonly Func<object?, CancellationToken, Task<T>> _callback;

    public object? State { get; }

    public AsyncFuncInvocation(Func<object?, CancellationToken, Task<T>> callback, object? state)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        State = state;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<T> Invoke(CancellationToken ct = default) => _callback(State, ct);
}