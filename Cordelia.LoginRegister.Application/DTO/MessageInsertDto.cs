namespace Cordelia.LoginRegister.Application.DTO;

public class MessageInsertDto
{
    public int MessageSenderId { get; set; }

    public int MessageReceiverId { get; set; }

    public string MessageSubject { get; set; } = string.Empty;

    public string MessageContent { get; set; } = string.Empty;

}
