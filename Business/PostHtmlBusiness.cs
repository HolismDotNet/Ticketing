using Holism.Business;
using Holism.EntityFramework;
using Ticketing.DataAccess;
using Ticketing.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace Ticketing.Business
{
    public class PostHtmlHtmlBusiness : Business<PostHtml, PostHtml>
    {
        protected override Repository<PostHtml> ModelRepository => RepositoryFactory.PostHtml;

        protected override ViewRepository<PostHtml> ViewRepository => RepositoryFactory.PostHtml;

        public void Create(long postId, string html)
        {
            var postHtml = new PostHtml();
            postHtml.Id = postId;
            postHtml.Html = html;
            Create(postHtml);
        }
    }
}
