namespace Ticketing;

public class TicketWithPosts
{
    public TicketView Ticket { get; set; }

    public List<Ticketing.Post> Posts { get; set; }
}
