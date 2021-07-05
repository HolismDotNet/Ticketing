using Holism.Business;
using Holism.DataAccess;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;
using System;

namespace Holism.Ticketing.Business
{
    public class PostHtmlHtmlBusiness : Business<PostHtml, PostHtml>
    {
        protected override Repository<PostHtml> WriteRepository => Repository.PostHtml;

        protected override ReadRepository<PostHtml> ReadRepository => Repository.PostHtml;

        public void Create(long postId, string html)
        {
            var postHtml = new PostHtml();
            postHtml.Id = postId;
            postHtml.Html = html;
            Create(postHtml);
        }
    }
}
