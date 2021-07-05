﻿using Holism.Business;
using Holism.EntityFramework;
using Holism.Framework;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.DataAccess.Models;
using Holism.Ticketing.DataAccess.Models.Views;
using Microsoft.VisualBasic;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Holism.Ticketing.Business
{
    public class PostBusiness : Business<PostView, Post>
    {
        protected override Repository<Post> ModelRepository => RepositoryFactory.Post;

        protected override ViewRepository<PostView> ViewRepository => RepositoryFactory.PostView;

        protected override Expression<Func<PostView, object>> DefaultDescendingSortProperty => i => i.Id;

        protected override void ModifyItemBeforeReturning(PostView item)
        {
            item.RelatedItems.TimeAgo = PersianDateTime.GetTimeAgo(item.Date);
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

        public List<PostView> GetAllTicketPost(long ticketId)
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