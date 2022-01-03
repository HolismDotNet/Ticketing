using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketPriorityController : EnumController<TicketPriority>
{
    public override EnumBusiness<TicketPriority> EnumBusiness => new TicketPriorityBusiness();
}
