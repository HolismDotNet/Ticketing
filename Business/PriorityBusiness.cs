namespace Ticketing;

public class PriorityBusiness : EnumBusiness<Ticketing.Priority>
{
    public override string ConnectionString =>
        Ticketing.Repository.Ticket.ConnectionString;
}
