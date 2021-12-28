using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.UserApi;

public class TicketingStateController : MariaEnumController<Ticketing.Models.State>
{
    public override MariaEnumBusiness<Ticketing.Models.State> EnumBusiness => new Ticketing.Business.StateBusiness();
}
