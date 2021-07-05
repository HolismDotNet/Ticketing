using Holism.Api.Controllers;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Api.Controllers
{
    public class PostController : ReadController<Post>
    {
        public override ReadBusiness<Post> ReadBusiness => new PostBusiness();
    }
}
