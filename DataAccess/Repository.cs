namespace Ticketing;

public class Repository
{
    public static Write<Ticketing.AttachedFile> AttachedFile
    {
        get
        {
            return new Write<Ticketing.AttachedFile>(new TicketingContext());
        }
    }

    public static Write<Ticketing.PostContent> PostContent
    {
        get
        {
            return new Write<Ticketing.PostContent>(new TicketingContext());
        }
    }

    public static Write<Ticketing.Post> Post
    {
        get
        {
            return new Write<Ticketing.Post>(new TicketingContext());
        }
    }

    public static Write<Ticketing.Ticket> Ticket
    {
        get
        {
            return new Write<Ticketing.Ticket>(new TicketingContext());
        }
    }

    public static Write<Ticketing.TicketView> TicketView
    {
        get
        {
            return new Write<Ticketing.TicketView>(new TicketingContext());
        }
    }
}
