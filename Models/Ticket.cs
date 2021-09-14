using System;

namespace Holism.Ticketing.Models
{
    public class Ticket : Holism.Models.IEntity
    {
        public Ticket()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public Guid UserGuid { get; set; }

        public string Title { get; set; }

        public long PriorityId { get; set; }

        public DateTime Date { get; set; }

        public long StateId { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
