using FluentEmail.Core;
using MassTransit;
using MassTransit.MultiBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using pagecom.email.infastructure.Consumer;

namespace pagecom.email.infastructure.Extenders;

public static class pagecomemailinfastructure
{
    public static IServiceCollection PageComEmailInfastructureExtender(this IServiceCollection service)
    {

        service.AddMassTransit(x =>
        {
            x.AddConsumer<EmailSender>(typeof(EmailconsumerDefinition));

            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                // configure health checks for this bus instance
        

                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("pagecom", ep =>
                {
                
                    ep.ConfigureConsumer<EmailSender>(provider);
                });
            }));
        });
        
        return service;
    }
}

