using Holism.Business;
using Holism.DataAccess;
using Holism.Framework;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using Holism.Ticketing.Models;
using System;
using System.Linq.Expressions;

namespace Holism.Ticketing.Business
{
    public class TicketBusiness : Business<TicketView, Ticket>
    {
        protected override Repository<Ticket> WriteRepository => Repository.Ticket;

        protected override ReadRepository<TicketView> ReadRepository => Repository.TicketView;

        protected override Expression<Func<TicketView, object>> DefaultDescendingSortProperty => i => i.Id;

        protected override void ModifyItemBeforeReturning(TicketView item)
        {
            item.RelatedItems.TimeAgo = PersianDateTime.GetTimeAgo(item.Date);
            base.ModifyItemBeforeReturning(item);
        }

        public TicketView CreateTicket(Ticket ticket, Guid userGuid)
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
