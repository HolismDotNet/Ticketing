using System;

namespace Holism.Ticketing
{
    public class Ticket : Holism.Models.IEntity
    {
        public Ticket()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public Guid UserGuid { get; set; }

        public object Title { get; set; }

        public long PriorityId { get; set; }

        public DateTime Date { get; set; }

        public long StateId { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
