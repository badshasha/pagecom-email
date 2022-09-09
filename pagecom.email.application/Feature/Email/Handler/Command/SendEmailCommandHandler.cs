using MediatR;
using pagecom.email.application.Contract;
using pagecom.email.application.Feature.Email.Request.command;

namespace pagecom.email.application.Feature.Email.Handler.Command;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand,bool>
{
    private readonly IEmailRepository _emailService;

    public SendEmailCommandHandler(IEmailRepository EmailService)
    {
        _emailService = EmailService;
    }
    
    public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await this._emailService.SendEmail(request.info);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}