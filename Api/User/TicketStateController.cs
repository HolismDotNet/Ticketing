namespace Ticketing;

public class TicketStateController : EnumController<Ticketing.State>
{
    public override EnumBusiness<Ticketing.State> EnumBusiness => new Ticketing.StateBusiness();
}
