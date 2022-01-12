using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketStateController : EnumController<TicketState>
{
    public override EnumBusiness<TicketState> EnumBusiness => new TicketStateBusiness();
}
