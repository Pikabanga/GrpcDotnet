using Grpc.Net.Client;
using GrpcDotnet.Proto;

namespace GrpcDotnet.Client;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://grpcdotnet.service");
        var client = new Greeter.GreeterClient(channel);

        var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

        Console.WriteLine("Greeting: " + reply.Message);        
    }
}