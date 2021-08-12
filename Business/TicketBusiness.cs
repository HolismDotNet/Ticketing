using Holism.Business;
using Holism.DataAccess;
using Holism.Framework;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using System;
using System.Linq.Expressions;
using Humanizer;

namespace Holism.Ticketing.Business
{
    public class TicketBusiness : Business<Ticket, Ticket>
    {
        protected override Repository<Ticket> WriteRepository => Repository.Ticket;

        protected override ReadRepository<Ticket> ReadRepository => Repository.Ticket;

        protected override Expression<Func<Ticket, object>> DefaultDescendingSortProperty => i => i.Id;

        protected override void ModifyItemBeforeReturning(Ticket item)
        {
            item.RelatedItems.TimeAgo = DateTime.Now.Subtract(item.Date).Humanize();
            base.ModifyItemBeforeReturning(item);
        }

        public Ticket CreateTicket(Ticket ticket, Guid userGuid)
        {
            ticket.UserGuid = userGuid;
            ticket.Date = DateTime.Now;
            ticket.StateId = (int)State.New;
            Create(ticket);
            new PostBusiness().CreateUserResponse(ticket.Id, ticket.RelatedItems);
            return Get(ticket.Id);
        }

        public void CloseTicket(long ticketId)
        {
            var ticket = Repository.Ticket.Get(ticketId);
            ticket.StateId = (int)State.Closed;
            Update(ticket);
        }

        public void SetState(long ticketId, State state)
        {
            var ticket = WriteRepository.Get(ticketId);
            ticket.StateId = (int)state;
            Update(ticket);
        }
    }
}
