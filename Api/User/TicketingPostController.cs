using Holism.Api;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holism.Ticketing.UserApi
{
    public class TicketingPostController : Controller<Post, Post>
    {
        public override ReadBusiness<Post> ReadBusiness => new PostBusiness();
        
        public override Business<Post, Post> Business => new PostBusiness();
    }
}
