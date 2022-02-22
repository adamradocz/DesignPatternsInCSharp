# Remote Proxy

- Client works with proxy as if remote resource were local
- Hides network details from client
- Centralizes knowledge of network details


# Example

```csharp
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Structural.Proxy;

// The remote proxy code is generated at build time and found in the /obj/Debug folder
[TestClass]
public class GreeterTests
{
    [TestMethod]
    public async Task GreetReturnsResponseAsync()
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new GreeterService.Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new GreeterService.HelloRequest { Name = "GreeterClient" });

        Assert.AreEqual("Hello GreeterClient", reply.Message);
    }
}
```csharp

When used properly, proxy 
implementations help you 
to follow Separation of 
Concerns and the Single 
Responsibility Principle.
