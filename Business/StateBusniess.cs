using Holism.Business;
using Holism.Ticketing.DataAccess;

namespace Holism.Ticketing.Business
{
    public class StateBusniess : EnumBusiness<State>
    {
        public override string ConnectionString => Repository.Ticket.ConnectionString;
    }
}
