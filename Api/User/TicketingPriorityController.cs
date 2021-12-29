using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketingPriorityController : EnumController<Priority>
{
    public override EnumBusiness<Priority> EnumBusiness => new PriorityBusiness();
}
