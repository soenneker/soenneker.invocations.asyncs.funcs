[![](https://img.shields.io/nuget/v/soenneker.invocations.asyncs.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.funcs/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.funcs/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.funcs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.funcs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.invocations.asyncs.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.funcs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.funcs/actions/workflows/codeql.yml)

# Soenneker.Invocations.Asyncs.Funcs

Represents a deferred asynchronous function with explicit state and cancellation, allowing a static delegate to avoid closure allocation.

## Install

```bash
dotnet add package Soenneker.Invocations.Asyncs.Funcs
```

## Usage

```csharp
using Soenneker.Invocations.Asyncs.Funcs;

var query = new CustomerQuery(customerId);

var invocation = new AsyncFuncInvocation<Customer>(
    static (state, cancellationToken) =>
        ((CustomerQuery)state!).Execute(cancellationToken),
    query);

pending.Enqueue(invocation);

// Later:
AsyncFuncInvocation<Customer> next = pending.Dequeue();
Customer customer = await next.Invoke(cancellationToken);
```

`Invoke()` passes the stored `State` and caller-supplied token directly to the callback and returns its `Task<T>`. Cancellation occurs only if the callback observes the token. Results, exceptions, and cancellation flow through unchanged, and repeated calls execute the callback again.

Use a `static` lambda or static method when avoiding closure capture matters. A capturing lambda remains valid but creates its own closure. Value-type state is boxed because state is stored as `object`.
