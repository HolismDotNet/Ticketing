namespace Ticketing;

public class TicketPriorityController : EnumController<Ticketing.Priority>
{
    public override EnumBusiness<Ticketing.Priority> EnumBusiness => new Ticketing.PriorityBusiness();
}
