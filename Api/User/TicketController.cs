using Holism.Api;
using Holism.Business;
using Holism.Ticketing.Business;
using Holism.Ticketing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Holism.Infra;

namespace Holism.Ticketing.UserApi
{
    public class TicketController : ReadController<TicketView>
    {
        public override ReadBusiness<TicketView> ReadBusiness => new TicketBusiness();

        public override Action<ListParameters> ListParametersAugmenter => listParameters =>
        {
            listParameters.AddFilter<TicketView>(i => i.UserGuid, UserGuid);
        };

        [HttpPost]
        public virtual IActionResult Create(TicketWithBody model)
        {
            model.UserGuid = UserGuid;
            var createdEntity = new TicketBusiness().Create(model);
            return CreationJson(createdEntity);
        }

        [HttpPost]
        public TicketView Close(long ticketId)
        {
            new TicketBusiness().EnsureTicketBelongsToUser(ticketId, UserGuid);
            var ticket = new TicketBusiness().CloseTicket(ticketId);
            return ticket;
        }
    }
}
