using Holism.Api.Controllers;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Api.Controllers
{
    public class TicketController : ReadController<Ticket>
    {
        public override ReadBusiness<Ticket> ReadBusiness => new TicketBusiness();
        
        // public long UserId
        // {
        //     get
        //     {
        //         return (long)new SecureController().ParsedUserData(HttpContext).UserId;
        //         return 1;
        //     }
        // }

        // public override Action<ListOptions> ListOptionsAugmenter => listOptions =>
        // {
        //     Guid? userGuid = new UserBusiness().GetGuid(UserId);
        //     listOptions.AddFilter<TicketView>(i => i.UserGuid, userGuid.ToString());
        // };

        // public override ViewBusiness<TicketView> ViewBusiness => new TicketBusiness();

        // [HttpPost]
        // public virtual IActionResult Create(Ticket ticket)
        // {
        //     Guid? userGuid = new UserBusiness().GetGuid(UserId);
        //     var createdEntity = new TicketBusiness().CreateTicket(ticket, userGuid.Value);
        //     return OkJson("Done", createdEntity, "CretionDone");
        // }

        // [HttpPost]
        // public IActionResult Close(long ticketId)
        // {
        //     new TicketBusiness().CloseTicket(ticketId);
        //     return OkJson();
        // }

    }
}
