using pagecom.email.application.DTO.CartDTO;

namespace pagecom.email.application.DTO.EmailDTO;

public class SendEmailDTO
{
    public DoneCartDTO info { get; set; }
    public List<CartBookDto> bookList { get; set; }
    public Double? Price { get; set; } = 0;
}