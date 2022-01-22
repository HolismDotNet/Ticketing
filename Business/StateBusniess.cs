namespace Ticketing;

public class StateBusiness : EnumBusiness<Ticketing.State>
{
    public override string ConnectionString =>
        Ticketing.Repository.Ticket.ConnectionString;
}
