using pagecom.email.application.Extender;
using pagecom.email.data.Extender;
using pagecom.email.infastructure.Extenders;

using MassTransit;
using pagecom.email.api;
using pagecom.email.api.cons;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.PageComEmailApplicationExtender();
builder.Services.PageComEmailDataExtenderClass(builder.Configuration);
builder.Services.PageComEmailInfastructureExtender();



//
// builder.Services.AddMassTransit(x =>
// {
//     x.AddConsumer<consumer>(typeof(consumerDefinition));
//
//     x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
//     {
//         // configure health checks for this bus instance
//         
//
//         cfg.Host("localhost", "/", h =>
//         {
//             h.Username("guest");
//             h.Password("guest");
//         });
//
//         cfg.ReceiveEndpoint("pagecom", ep =>
//         {
//             // ep.PrefetchCount = 16;
//             //     // ep.UseMessageRetry(r => r.Interval(2, 100));
//             //
//             ep.ConfigureConsumer<consumer>(provider);
//         });
//     }));
// });
//




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

