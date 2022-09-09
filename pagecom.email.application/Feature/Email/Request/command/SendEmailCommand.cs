using MediatR;
using pagecom.common;

namespace pagecom.email.application.Feature.Email.Request.command;

public record SendEmailCommand(EmailInfomation info) : IRequest<bool>;