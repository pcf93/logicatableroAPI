using Cordelia.LoginRegister.Application.DTO;
using Cordelia.LoginRegister.Application.Services.Abstraction;
using Cordelia.LoginRegister.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cordelia.LoginRegister.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{

    private readonly IMessageService _service;

    public MessageController(IMessageService service) { _service = service; }


    [HttpGet]
    [Route("messages")]

    public async Task<ActionResult<List<Message>>> GetAllMessages()
    {
        var result = await _service.GetAllMessages();

        if (result.Count == 0)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("received/{id}")]

    public async Task<ActionResult<List<Message>>> MessagesReceivedById(int id)
    {
        var result = await _service.GetMessagesReceivedById(id);

        if (result.Count == 0)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("sent/{id}")]

    public async Task<ActionResult<List<Message>>> MessagedReceivedById(int id)
    {
        var result = await _service.GetMessagesSentById(id);

        if (result.Count == 0)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("add")]

    public async Task<ActionResult<Message>> InsertNewMessage(MessageInsertDto message)
    {
        var result = await _service.InsertMessage(message);

        if (result is null) { return BadRequest(); }

        return Ok(result);
    }

    [HttpPut]
    [Route("changeStatus/{messageId}")]

    public async Task<ActionResult<Message>> ChangeStatus(int messageId)
    {
        var result = await _service.ChangeStatusAsync(messageId);

        if (result is null) { return BadRequest(); }

        return Ok(result);

    }

    [HttpDelete]
    [Route("delete/{messageId}")]

    public async Task<ActionResult<Message>> DeleteMessage(int messageId)
    {
        var result = await _service.DeleteMessageAsync(messageId);

        if (result is null) { return BadRequest(); }

        return Ok(result);
    }
        


}
