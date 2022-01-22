namespace Ticketing;

public class TicketController : Controller<TicketView, Ticket>
{
    public override ReadBusiness<TicketView> ReadBusiness => new TicketBusiness();
    
    public override Business<TicketView, Ticket> Business => new TicketBusiness();

    [HttpPost]
    public TicketView Close(long ticketId)
    {
        var ticket = new TicketBusiness().CloseTicket(ticketId);
        return ticket;
    }

    [HttpGet]
    public TicketWithPosts View(long ticketId)
    {
        var ticketWithPosts = new TicketBusiness().GetTicketWithPosts(ticketId);
        return ticketWithPosts;
    }
}
