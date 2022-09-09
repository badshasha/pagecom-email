using System.Data.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using pagecom.common;
using pagecom.email.application.Feature.Email.Request.command;

namespace pagecom.email.api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EmailSernder : Controller
{
    private readonly IMediator _mediator;

    public EmailSernder(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> SendMail()
    {

        
        List<CartBookDto> b = new()
        {
            new CartBookDto()
            {
                Id = 1,
                Quentity = 2,
                BookId = 1,
                CartId = 2,
                BookName = "shvaendra book",
            },
            new CartBookDto()
            {
                Id = 2,
                Quentity = 2,
                BookId = 3,
                CartId = 2,
                BookName = "secound book",
            },
        

        };

        DoneCartDTO d = new()
        {
            city = "Matale",
            contactNumber = "324",
            Email = "shavendragoesfot@gmail.com",
            laneName = "flower road matale",
        };

            EmailInfomation v = new()
        {
          info   = d,
          Price = 100,
          bookList = b
        };
        
        await this._mediator.Send(new SendEmailCommand(v));
        return Ok("email send success");
    }
}