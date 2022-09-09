using pagecom.common;

namespace pagecom.email.application.Contract;

public interface IEmailRepository
{
    Task<bool> SendEmail(EmailInfomation obj); // create model 
}