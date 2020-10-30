# SignalRServerClient

A working sample of a standalone SignalR server with two clients (backend and frontend).

NB: the current implementation is not a showcase.

## Componnets

|Component|Descripton|Ports|
|---------|----------|-----|
|Server|regular Web API which hosts a SignalR hub|HTTP/1 5001|
|GrpcService|gRpc service which hosts a SignalR hub|HTTP/2 5000, HTTP/1 5001|
|ClientBackend|regular API which connects to SignalR as a client|HTTP/1 5002|
|ClientFrontend|regular web application which connects to SignalR from Javascript code as a client|HTTP/1 5003|

SignalR hub is hosted on TCP port 5001. Only one server should be running at a time. In this example it's possible to send a message from a server to all clients who is connected to the SignalR hub.

## Hint about CORS

The Server is a SinglanR server which configure CORS to allow connection from JS client. The backend client doesn't need CORS.

## Hint about gRPC

gRpc service and Signar hub cannot use the same port because they use different protocols. In gRpc service there is an additional configuration to listen two different ports by Kestrel.

## References

- [Introduction to ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-3.1)
- [Send messages from outside a hub](https://docs.microsoft.com/en-us/aspnet/core/signalr/hubcontext?view=aspnetcore-3.1)
- [ASP.NET Core SignalR .NET Client](https://docs.microsoft.com/en-us/aspnet/core/signalr/dotnet-client?view=aspnetcore-3.1&tabs=visual-studio)
- [ASP.NET Core SignalR JavaScript client](https://docs.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-3.1)
- [Host ASP.NET Core SignalR in background services](https://docs.microsoft.com/en-us/aspnet/core/signalr/background-services?view=aspnetcore-3.1)
- [Logging and diagnostics in ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/diagnostics?view=aspnetcore-3.1)
