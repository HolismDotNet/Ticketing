using Holism.Business;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Business
{
    public class StateBusiness : EnumBusiness<State>
    {
        public override string ConnectionString =>
            Repository.Ticket.ConnectionString;
    }
}
