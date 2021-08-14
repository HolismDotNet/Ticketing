using System;

namespace Holism.Ticketing.Models
{
    public class PostView : Holism.Models.IEntity
    {
        public PostView()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public long TicketId { get; set; }

        public DateTime Date { get; set; }

        public bool? IsSystemPost { get; set; }

        public string PostHtml { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
