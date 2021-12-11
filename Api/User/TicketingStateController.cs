using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketingStateController : EnumController<State>
{
    public override EnumBusiness<State> EnumBusiness => new StateBusiness();
}
