namespace Holism.Ticketing.DataAccess;

public class Repository
{
    public static Repository<AttachedFile> AttachedFile
    {
        get
        {
            return new Repository<AttachedFile>(new TicketingContext());
        }
    }

    public static Repository<PostContent> PostContent
    {
        get
        {
            return new Repository<PostContent>(new TicketingContext());
        }
    }

    public static Repository<Post> Post
    {
        get
        {
            return new Repository<Post>(new TicketingContext());
        }
    }

    public static Repository<Ticket> Ticket
    {
        get
        {
            return new Repository<Ticket>(new TicketingContext());
        }
    }

    public static Repository<TicketView> TicketView
    {
        get
        {
            return new Repository<TicketView>(new TicketingContext());
        }
    }
}
