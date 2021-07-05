using Holism.Api.Controllers;
using Holism.Business;
using Ticketing.Business;
using Ticketing.Models;

namespace Ticketing.Api.Controllers
{
    public class PostController : ReadController<Post>
    {
        public override ReadBusiness<Post> ReadBusiness => new PostBusiness();
    }
}
