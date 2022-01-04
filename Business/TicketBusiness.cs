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

        protected override Func<Sort> DefaultSort => () => new Sort
        {
            Property = nameof(TicketView.LatestPostUtcDate),
            Direction = SortDirection.Descending
        };

        protected override void ModifyItemBeforeReturning(TicketView item)
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

        protected override void PreCreation(Ticket ticket)
        {
            ticket.UtcDate = UniversalDateTime.Now;
            ticket.StateId = (int)TicketState.New;
        }

        protected override void PostCreation(Ticket ticket)
        {
            new PostBusiness()
                .CreateUserResponse(ticket.Id, ticket.RelatedItems);
        }

        public TicketView CloseTicket(long ticketId)
        {
            return SetState(ticketId, TicketState.Closed);
        }

        public TicketView SetState(long ticketId, TicketState state)
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
            ticketWithPosts.Posts = new PostBusiness().GetPosts(ticketId);
            return ticketWithPosts;
        }
    }
}
