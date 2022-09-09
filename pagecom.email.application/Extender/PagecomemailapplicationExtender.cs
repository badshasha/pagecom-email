using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace pagecom.email.application.Extender;

public static class PagecomemailapplicationExtender
{
    public static IServiceCollection PageComEmailApplicationExtender(this IServiceCollection service)
    {
        service.AddMediatR(Assembly.GetExecutingAssembly());
        return service;
    }
}