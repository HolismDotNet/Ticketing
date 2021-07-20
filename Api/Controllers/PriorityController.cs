using Holism.Api.Controllers;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Api.Controllers
{
    public class PriorityController : EnumController<Priority>
    {
        public override EnumBusiness<Priority> EnumBusiness => new PriorityBusiness();
    }
}
