namespace Holism.Ticketing.Models;

public class Post : IEntity
{
    public Post()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long TicketId { get; set; }

    public DateTime UtcDate { get; set; }

    public bool? IsSystemPost { get; set; }

    public dynamic RelatedItems { get; set; }
}
