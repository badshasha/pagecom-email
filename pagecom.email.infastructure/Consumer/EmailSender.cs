using FluentEmail.Core;
using MassTransit;
using MediatR;
using pagecom.common;
using pagecom.email.application.DTO.EmailDTO;
using pagecom.email.application.Feature.Email.Request.command;

namespace pagecom.email.infastructure.Consumer;



public class EmailSender : IConsumer<EmailInfomation>
{
    private readonly IMediator _mediator;

    public EmailSender(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<EmailInfomation> context)
    {
        var obj = context.Message;
        await this._mediator.Send(new SendEmailCommand(obj));
        Console.WriteLine("email send successful");
    }
}

public class EmailconsumerDefinition : ConsumerDefinition<EmailSender>
{
    public EmailconsumerDefinition()
    {
        EndpointName = "pagecom";
    }
}
