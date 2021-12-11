namespace Holism.Ticketing.AdminApi;

public class TicketController : Controller<TicketView, Ticket>
{
    public override ReadBusiness<TicketView> ReadBusiness => new TicketBusiness();
    
    public override Business<TicketView, Ticket> Business => new TicketBusiness();
}
