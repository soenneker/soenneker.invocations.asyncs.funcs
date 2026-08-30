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
    /// Gets the state passed to the callback when <see cref="Invoke"/> is called.
    /// </summary>
    public object? State { get; }

    /// <summary>
    /// Creates a deferred asynchronous function from a callback and its explicit state.
    /// </summary>
    /// <param name="callback">The callback to invoke.</param>
    /// <param name="state">The state supplied to <paramref name="callback"/>.</param>
    public AsyncFuncInvocation(Func<object?, CancellationToken, Task<T>> callback, object? state)
    {
        _callback = callback ?? throw new ArgumentNullException(nameof(callback));
        State = state;
    }

    /// <summary>
    /// Invokes the callback with <see cref="State"/> and the supplied cancellation token.
    /// </summary>
    /// <param name="ct">The token forwarded to the callback.</param>
    /// <returns>The task returned by the callback.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<T> Invoke(CancellationToken ct = default) => _callback(State, ct);
}
