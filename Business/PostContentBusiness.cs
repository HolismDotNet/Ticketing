using Holism.Business;
using Holism.DataAccess;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using System;

namespace Holism.Ticketing.Business
{
    public class PostContentBusiness : Business<PostContent, PostContent>
    {
        protected override Repository<PostContent> WriteRepository => Repository.PostContent;

        protected override ReadRepository<PostContent> ReadRepository => Repository.PostContent;

        public void Create(long postId, string content)
        {
            var postContent = new PostContent();
            postContent.Id = postId;
            postContent.Content = content;
            Create(postContent);
        }
    }
}
