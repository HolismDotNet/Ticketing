using Holism.Business;
using Ticketing.DataAccess;

namespace Ticketing.Business
{
    public class PriorityBusiness : EnumBusiness<Priority>
    {
        public override string ConnectionString => RepositoryFactory.Ticket.ConnectionString;
    }
}
