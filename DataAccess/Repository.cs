namespace Holism.Ticketing.DataAccess;

public class Repository
{
    public static Repository<AttachedFile> AttachedFile
    {
        get
        {
            return new Repository<AttachedFile>(new TicketingContext());
        }
    }    public static Repository<PostHtml> PostHtml
    {
        get
        {
            return new Repository<PostHtml>(new TicketingContext());
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


}
