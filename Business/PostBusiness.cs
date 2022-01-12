﻿using Holism.Business;
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

        protected override Func<Sort> DefaultSort => () => new Sort
        {
            Property = nameof(Post.Id),
            Direction = SortDirection.Descending
        };

        protected override void ModifyItemBeforeReturning(Post item)
        {
            item.RelatedItems.TimeAgo = "Todo";
            base.ModifyItemBeforeReturning(item);
        }

        public void CreateUserResponse(long ticketId, string postContent)
        {
            var post = new Post();
            post.TicketId = ticketId;
            post.IsSystemPost = false;
            post.UtcDate = UniversalDateTime.Now;
            Create(post);
            new PostContentBusiness().Create(post.Id, postContent);
            new TicketBusiness().SetState(ticketId, TicketState.WaitingForBusinessResponse);
        }

        public void CreateSystemResponse(long ticketId, string postContent)
        {
            var post = new Post();
            post.TicketId = ticketId;
            post.IsSystemPost = true;
            post.UtcDate = UniversalDateTime.Now;
            Create(post);
            new PostContentBusiness().Create(post.Id, postContent);
            new TicketBusiness().SetState(ticketId, TicketState.WaitingForUserResponse);
        }

        public List<Post> GetPosts(long ticketId)
        {
            var ticketPosts = GetList(i => i.TicketId == ticketId);
            ticketPosts = ticketPosts.OrderByDescending(i => i.UtcDate).ToList();
            var postIds = ticketPosts.Select(i => i.Id).ToList();
            var postContents = new PostContentBusiness().GetList(postIds);
            foreach (var post in ticketPosts)
            {
                var content = postContents.SingleOrDefault(i => i.Id == post.Id);
                post.RelatedItems.Content = "";
                if (content != null)
                {
                    post.RelatedItems.Content = content.Content;
                }
            }
            return ticketPosts;
        }
    }
}
