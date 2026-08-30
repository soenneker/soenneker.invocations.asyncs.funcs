using System.Threading;
using System.Threading.Tasks;
using Soenneker.Tests.Unit;

namespace Soenneker.Invocations.Asyncs.Funcs.Tests;

public sealed class AsyncFuncInvocationTests : UnitTest
{
    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Invoke_returns_result_and_passes_state_and_token()
    {
        var state = new Calculation(21);
        using var cancellation = new CancellationTokenSource();
        var invocation = new AsyncFuncInvocation<int>(static (value, token) =>
        {
            var calculation = (Calculation)value!;
            calculation.Token = token;
            return Task.FromResult(calculation.Input * 2);
        }, state);

        int result = await invocation.Invoke(cancellation.Token);

        await Assert.That(result).IsEqualTo(42);
        await Assert.That(state.Token).IsEqualTo(cancellation.Token);
        await Assert.That(invocation.State).IsSameReferenceAs(state);
    }

    private sealed class Calculation(int input)
    {
        public int Input { get; } = input;
        public CancellationToken Token { get; set; }
    }
}
