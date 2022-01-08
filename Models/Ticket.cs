namespace Holism.Ticketing.Models;

public class Ticket : IEntity
{
    public Ticket()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid UserGuid { get; set; }

    public string Title { get; set; }

    public long TicketPriorityId { get; set; }

    public DateTime UtcDate { get; set; }

    public long TicketStateId { get; set; }

    public dynamic RelatedItems { get; set; }
}
