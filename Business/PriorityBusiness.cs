using Holism.Business;
using Holism.Ticketing.DataAccess;

namespace Holism.Ticketing.Business
{
    public class PriorityBusiness : EnumBusiness<Priority>
    {
        public override string ConnectionString => Repository.Ticket.ConnectionString;
    }
}
