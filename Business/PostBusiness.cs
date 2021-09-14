using Holism.Business;
using Holism.DataAccess;
using Holism.Infra;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using Microsoft.VisualBasic;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Holism.Ticketing.Business
{
    public class PostBusiness : Business<Post, Post>
    {
        protected override Repository<Post> WriteRepository => Repository.Post;

        protected override ReadRepository<Post> ReadRepository => Repository.Post;

        protected override Expression<Func<Post, object>> DefaultDescendingSortProperty => i => i.Id;

        protected override void ModifyItemBeforeReturning(Post item)
        {
            item.RelatedItems.TimeAgo = "Todo";
            base.ModifyItemBeforeReturning(item);
        }

        public void CreateUserResponse(long ticketId, string postHtml)
        {
            var post = new Post();
            post.TicketId = ticketId;
            post.IsSystemPost = false;
            post.Date = DateTime.Now;
            Create(post);
            new PostHtmlHtmlBusiness().Create(post.Id, postHtml);
            new TicketBusiness().SetState(ticketId, State.WaitingForBusinessResponse);
        }

        public void CreateSystemResponse(long ticketId, string postHtml)
        {
            var post = new Post();
            post.TicketId = ticketId;
            post.IsSystemPost = true;
            post.Date = DateTime.Now;
            Create(post);
            new PostHtmlHtmlBusiness().Create(post.Id, postHtml);
            new TicketBusiness().SetState(ticketId, State.WaitingForUserResponse);
        }

        public List<Post> GetAllTicketPost(long ticketId)
        {
            var ticketPosts = GetList(i => i.TicketId == ticketId);
            ticketPosts = ticketPosts.OrderByDescending(i => i.Date).ToList();
            return ticketPosts;
        }

        public object GetTicketAndPosts(long ticketId)
        {
            var result = new
            {
                Ticket = new TicketBusiness().Get(ticketId),
                Posts = GetAllTicketPost(ticketId)
            };
            return result;
        }
    }
}
