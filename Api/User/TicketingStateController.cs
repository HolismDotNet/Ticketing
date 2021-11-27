using Holism.Api;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holism.Ticketing.UserApi
{
    public class TicketingStateController : EnumController<State>
    {
        public override EnumBusiness<State> EnumBusiness => new StateBusiness();
    }
}
