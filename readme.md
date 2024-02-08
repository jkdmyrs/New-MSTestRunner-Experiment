# Debug Test project and Function Apps in Visual Studio

- Microsoft recently released a new MSTest Runner in [this blog post](https://devblogs.microsoft.com/dotnet/introducing-ms-test-runner/).
- The new runner allows tests to be run as a console application. 
- This makes it easier to debug integration/E2E tests and function apps (or other dotnet apps) at the same time.

## Prior to the new runner

Prior to the new runner, the process was:

1. start the function app without debugging (ctrl-F5)
1. add a breakpoint at the start of the test
1. start debugging the test
1. once breakpoint in test is hit, manually attach debugger to the function app process

Then you are free to debug the function app and test project at the same time. 

**This isn't ideal due to the need to manually attach the debugger.**

## With the new runner

1. configure multiple startup projects
    - setup test project and function app to start
1. start the projects as normal (run button in Visual Studio)

Then you are free to debug the function app and test project at the same time. **No need to manually attach the debugger.**

### Questions

- Are we always garunteed that the function app will start up before the tests run?
    - Or are there race-conditions where the tests exectute before the function HTTP endpoints are available?
    - I haven't hit this race condition yet in my testing, but the function app is minimal with quick startup times. Maybe a function app with a longer startup time could be impacted?