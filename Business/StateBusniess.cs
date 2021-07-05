using Holism.Business;
using Ticketing.DataAccess;

namespace Ticketing.Business
{
    public class StateBusniess : EnumBusiness<State>
    {
        public override string ConnectionString => RepositoryFactory.Ticket.ConnectionString;
    }
}
