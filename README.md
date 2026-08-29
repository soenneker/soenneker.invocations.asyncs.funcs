[![](https://img.shields.io/nuget/v/soenneker.invocations.asyncs.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.funcs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.funcs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.invocations.asyncs.funcs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.invocations.asyncs.funcs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.invocations.asyncs.funcs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.invocations.asyncs.funcs/actions/workflows/codeql.yml)

# Soenneker.Invocations.Asyncs.Funcs

Deferred, stateful asynchronous function invocation without closure capture.

## Install

```bash
dotnet add package Soenneker.Invocations.Asyncs.Funcs
```

## What you get

- `AsyncFuncInvocation<T>` — Deferred, stateful asynchronous function invocation without closure capture.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AsyncFuncInvocation<T>.State` | Gets state. | Gets state. |
| `AsyncFuncInvocation<T>.Invoke(ct)` | Invokes the async func invocation with the supplied payload. | A task whose result is the value returned by invoke. |
