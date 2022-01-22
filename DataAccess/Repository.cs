namespace Ticketing;

public class Repository
{
    public static Repository<Ticketing.AttachedFile> AttachedFile
    {
        get
        {
            return new Repository<Ticketing.AttachedFile>(new TicketingContext());
        }
    }

    public static Repository<Ticketing.PostContent> PostContent
    {
        get
        {
            return new Repository<Ticketing.PostContent>(new TicketingContext());
        }
    }

    public static Repository<Ticketing.Post> Post
    {
        get
        {
            return new Repository<Ticketing.Post>(new TicketingContext());
        }
    }

    public static Repository<Ticketing.Ticket> Ticket
    {
        get
        {
            return new Repository<Ticketing.Ticket>(new TicketingContext());
        }
    }

    public static Repository<Ticketing.TicketView> TicketView
    {
        get
        {
            return new Repository<Ticketing.TicketView>(new TicketingContext());
        }
    }
}
