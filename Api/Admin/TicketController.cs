using Holism.Api;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holism.Ticketing.AdminApi
{
    public class TicketController : Controller<TicketView, Ticket>
    {
        public override ReadBusiness<TicketView> ReadBusiness => new TicketBusiness();
        
        public override Business<TicketView, Ticket> Business => new TicketBusiness();
    }
}
