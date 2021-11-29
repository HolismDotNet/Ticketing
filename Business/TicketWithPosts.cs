using System.Collections.Generic;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Business
{
    public class TicketWithPosts
    {
        public TicketView Ticket { get; set; }

        public List<Post> Posts { get; set; }
    }
}