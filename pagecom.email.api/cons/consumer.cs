using MassTransit;
using pagecom.common;

namespace pagecom.email.api.cons;

public class consumer : IConsumer<P>
{
    public async Task Consume(ConsumeContext<P> context)
    {
        Console.WriteLine("project working");
    }
}

public class consumerDefinition : ConsumerDefinition<consumer>
{
    public consumerDefinition()
    {
        EndpointName = "pagecom";
    }
}

