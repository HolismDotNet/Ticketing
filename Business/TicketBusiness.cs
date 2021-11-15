using System;
using System.Linq.Expressions;
using Holism.Business;
using Holism.DataAccess;
using Holism.Infra;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using Humanizer;

namespace Holism.Ticketing.Business
{
    public class TicketBusiness : Business<TicketView, Ticket>
    {
        protected override Repository<Ticket> WriteRepository =>
            Repository.Ticket;

        protected override ReadRepository<TicketView> ReadRepository =>
            Repository.TicketView;

        protected override Expression<Func<TicketView, object>>
        DefaultDescendingSortProperty => i => i.LatestPostUtcDate;

        protected override void ModifyItemBeforeReturning(TicketView item)
        {
            item.RelatedItems.TimeAgo =
                DateTime.Now.Subtract(item.UtcDate).Humanize();
            base.ModifyItemBeforeReturning(item);
        }

        public Ticket Create(TicketWithBody ticketWithBody)
        {
            var ticket = ticketWithBody.CastTo<Ticket>();
            ticket.RelatedItems = ticketWithBody.Body;
            return Create(ticket);
        }

        protected override void BeforeCreation(
            Ticket ticket,
            object extraParameters = null
        )
        {
            ticket.UtcDate = DateTime.Now.ToUniversalTime();
            ticket.StateId = (int) State.New;
        }

        protected override void PostCreation(
            Ticket ticket,
            object extraParameters = null
        )
        {
            new PostBusiness()
                .CreateUserResponse(ticket.Id, ticket.RelatedItems);
        }

        public TicketView CloseTicket(long ticketId)
        {
            return SetState(ticketId, State.Closed);
        }

        public TicketView SetState(long ticketId, State state)
        {
            var ticket = WriteRepository.Get(ticketId);
            ticket.StateId = (int) state;
            Update (ticket);
            return Get(ticketId);
        }
    }
}
