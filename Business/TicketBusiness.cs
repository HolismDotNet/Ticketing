using Holism.Business;
using Holism.EntityFramework;
using Holism.Framework;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.DataAccess.Models;
using Holism.Ticketing.DataAccess.Models.Views;
using System;
using System.Linq.Expressions;

namespace Holism.Ticketing.Business
{
    public class TicketBusiness : Business<TicketView, Ticket>
    {
        protected override Repository<Ticket> ModelRepository => RepositoryFactory.Ticket;

        protected override ViewRepository<TicketView> ViewRepository => RepositoryFactory.TicketView;

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
            var ticket = RepositoryFactory.Ticket.Get(ticketId);
            ticket.StateId = (int)State.Closed;
            Update(ticket);
        }

        public void SetState(long ticketId, State state)
        {
            var ticket = ModelRepository.Get(ticketId);
            ticket.StateId = (int)state;
            Update(ticket);
        }
    }
}
