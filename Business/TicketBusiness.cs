namespace Ticketing;

public class TicketBusiness : Business<Ticketing.TicketView, Ticketing.Ticket>
{
    protected override Repository<Ticketing.Ticket> WriteRepository =>
        Ticketing.Repository.Ticket;

    protected override ReadRepository<Ticketing.TicketView> ReadRepository =>
        Ticketing.Repository.TicketView;

    protected override Func<Sort> DefaultSort => () => new Sort
    {
        Property = nameof(TicketView.LatestPostUtcDate),
        Direction = SortDirection.Descending
    };

    protected override void ModifyItemBeforeReturning(Ticketing.TicketView item)
    {
        item.RelatedItems.TimeAgo =
            UniversalDateTime.Now.Subtract(item.UtcDate).Humanize();
        item.RelatedItems.TitleizedStateKey = item.StateKey.Titleize();
        base.ModifyItemBeforeReturning(item);
    }

    public Ticket Create(TicketWithBody ticketWithBody)
    {
        var ticket = ticketWithBody.CastTo<Ticket>();
        ticket.RelatedItems = ticketWithBody.Body;
        return Create(ticket);
    }

    protected override void PreCreation(Ticketing.Ticket ticket)
    {
        ticket.UtcDate = UniversalDateTime.Now;
        ticket.StateId = (int)Ticketing.State.New;
    }

    protected override void PostCreation(Ticket ticket)
    {
        new PostBusiness()
            .CreateUserResponse(ticket.Id, ticket.RelatedItems);
    }

    public Ticketing.TicketView CloseTicket(long ticketId)
    {
        return SetState(ticketId, Ticketing.State.Closed);
    }

    public Ticketing.TicketView SetState(long ticketId, Ticketing.State state)
    {
        var ticket = WriteRepository.Get(ticketId);
        ticket.StateId = (int)state;
        Update (ticket);
        return Get(ticketId);
    }

    public void EnsureTicketBelongsToUser(long ticketId, Guid userGuid)
    {
        var ticket = Get(ticketId);
        if (ticket.UserGuid != userGuid)
        {
            throw new ClientException($"User does not own this ticket");
        }
    }

    public TicketWithPosts GetTicketWithPosts(long ticketId)
    {
        var ticketWithPosts = new TicketWithPosts();
        ticketWithPosts.Ticket = Get(ticketId);
        ticketWithPosts.Posts = new Ticketing.PostBusiness().GetPosts(ticketId);
        return ticketWithPosts;
    }
}
