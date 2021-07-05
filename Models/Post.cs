using System;

namespace Ticketing.Models
{
    public class Post : Holism.Models.IEntity
    {
        public Post()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public long TicketId { get; set; }

        public DateTime Date { get; set; }

        public string PersianDate { get; private set; }

        public bool? IsSystemPost { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
