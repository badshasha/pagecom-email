using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using pagecom.common;
using pagecom.email.application.Contract;

namespace pagecom.email.data.Services;

public class EmailService : IEmailRepository
{
    private readonly IFluentEmail _fluentEmail;

    public EmailService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }
    
    public async Task<bool> SendEmail(EmailInfomation obj)
    {
        try
        {
            var template = "Dear @Model.Name, You are totally <b> @Model.Compliment. </b> . from <i> @Model.Sender </i> ";


            var message =
                "Dear @Model.Name, <br> thank you for making that purchase. It will always be our pleasure to serve you with quality products.<br>" +
                "<br> this email confirms your order." +
                "<table><tr><th>BookName</th><th>Quentity</th></tr>" +
                "@foreach (var product in Model.Products){" +
                "<tr>" +
                "<td>@product.BookName</td>" +
                "<td>@product.Quentity</td>" +
                "</tr>} </table> <br> total prince = @Model.Price <br> will ship your product to the following address please be sure to pay cash on delivery." +
                " <h2>shipping address</h2><tr>" +
                "<table><tr><td>home number</td><td>@Model.number</td></tr><tr><td>lane</td><td>@Model.lane</td></tr><tr><td>home town</td><td>@Model.city</td></tr></table>";
                
            await this._fluentEmail
                // .To("lovebadshasha@gmail.com")
                .To(obj.info.Email)
                .Subject("test email form pagecom shopping site")
                // .Body("message comming from page com testing email site")
                .UsingTemplate(message,new {
                    Name=obj.info.Email ,
                    Products=obj.bookList ,
                    Price=obj.Price , 
                    number=obj.info.laneNumber ,
                    lane=obj.info.laneName, 
                    city=obj.info.city,
                })
                .SendAsync();
            return true;
        }
        
            catch (Exception e)
        {
            return false;
        }
  
    }
}