using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketingStateController : EnumController<Ticketing.Models.State>
{
    public override EnumBusiness<Ticketing.Models.State> EnumBusiness => new Ticketing.Business.StateBusiness();
}
