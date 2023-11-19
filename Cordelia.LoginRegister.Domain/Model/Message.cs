using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cordelia.LoginRegister.Domain.Model;

public class Message
{
    public int MessageId { get; set; }

    public int MessageSenderId {  get; set; }

    public int MessageReceiverId { get; set; }

    public string MessageSubject { get; set; } = string.Empty;

    public string MessageContent { get; set; } = string.Empty;

    public DateTime MessageDate {  get; set; }
    
    public Boolean IsRead {  get; set; }

    public User MessageSender { get; set; }

    public User MessageReceiver { get; set; }

}
