using System;

namespace Holism.Ticketing
{
    public class Post : Holism.Models.IEntity
    {
        public Post()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long TicketId { get; set; }

        public DateTime Date { get; set; }

        public object IsSystemPost { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
