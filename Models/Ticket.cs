namespace Ticketing;

public class Ticket : IEntity
{
    public Ticket()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public Guid UserGuid { get; set; }

    public string Title { get; set; }

    public long PriorityId { get; set; }

    public DateTime UtcDate { get; set; }

    public long StateId { get; set; }

    public dynamic RelatedItems { get; set; }
}
