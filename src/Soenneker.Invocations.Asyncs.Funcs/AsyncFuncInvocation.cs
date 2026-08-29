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

    /// <summary>
    /// Gets state.
    /// </summary>
    public object? State { get; }

    public AsyncFuncInvocation(Func<object?, CancellationToken, Task<T>> callback, object? state)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        State = state;
    }

    /// <summary>
    /// Invokes the async func invocation with the supplied payload.
    /// </summary>
    /// <param name="ct">Ct for the invoke operation.</param>
    /// <returns>A task whose result is the value returned by invoke.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<T> Invoke(CancellationToken ct = default) => _callback(State, ct);
}
