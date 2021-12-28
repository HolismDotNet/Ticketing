using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketingPriorityController : MariaEnumController<Priority>
{
    public override MariaEnumBusiness<Priority> EnumBusiness => new PriorityBusiness();
}
