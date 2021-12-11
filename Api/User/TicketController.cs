using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketController : ReadController<TicketView>
{
    public override ReadBusiness<TicketView> ReadBusiness => new TicketBusiness();

    public override Action<ListParameters> ListParametersAugmenter => listParameters =>
    {
        listParameters.AddFilter<TicketView>(i => i.UserGuid, UserGuid);
    };

    [HttpPost]
    public virtual IActionResult Create(TicketWithBody model)
    {
        model.UserGuid = UserGuid;
        var createdEntity = new TicketBusiness().Create(model);
        return CreationJson(createdEntity);
    }

    [HttpPost]
    public IActionResult AddUserResponse(PostWithMessage model)
    {
        new TicketBusiness().EnsureTicketBelongsToUser(model.TicketId, UserGuid);
        new PostBusiness().CreateUserResponse(model.TicketId, model.Message);
        return OkJson();
    }

    [HttpPost]
    public TicketView Close(long ticketId)
    {
        new TicketBusiness().EnsureTicketBelongsToUser(ticketId, UserGuid);
        var ticket = new TicketBusiness().CloseTicket(ticketId);
        return ticket;
    }

    [HttpGet]
    public TicketWithPosts View(long ticketId)
    {
        new TicketBusiness().EnsureTicketBelongsToUser(ticketId, UserGuid);
        var ticketWithPosts = new TicketBusiness().GetTicketWithPosts(ticketId);
        return ticketWithPosts;
    }
}
