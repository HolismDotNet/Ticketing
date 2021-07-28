using Holism.Business;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Business
{
    public class StateBusniess : EnumBusiness<State>
    {
        public override string ConnectionString => Repository.Ticket.ConnectionString;
    }
}
