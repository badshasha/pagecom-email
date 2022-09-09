using MassTransit;

namespace pagecom.email.api;


public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
}

public class SendInfoConsumer : IConsumer<Product>
{
    public async Task Consume(ConsumeContext<Product> context)
    {
        var p =  context.Message;
        Console.WriteLine("message recieve");
    }
}