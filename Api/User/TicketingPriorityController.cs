using Holism.Api;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holism.Ticketing.UserApi
{
    public class TicketingPriorityController : EnumController<Priority>
    {
        public override EnumBusiness<Priority> EnumBusiness => new PriorityBusiness();
    }
}
