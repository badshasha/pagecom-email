using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using pagecom.email.application.Contract;
using pagecom.email.data.Services;

namespace pagecom.email.data.Extender;

public static class pagecomemaildtaextender
{
    public static IServiceCollection PageComEmailDataExtenderClass(this IServiceCollection service,  IConfiguration config)
    {
        
        var client = new SmtpClient("smtp-relay.sendinblue.com", 587);
        client.Credentials = new NetworkCredential("shavendraekanayake@gmail.com", "PXxp1BtJEnamY6sj");

        service
            .AddFluentEmail("pagecom@test.test","pagecom")
            .AddRazorRenderer()
            .AddSmtpSender(client);
       
        
        


        service.AddScoped<IEmailRepository, EmailService>();
            
        return service;
    }
}