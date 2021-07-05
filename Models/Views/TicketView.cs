using System;

namespace Ticketing.Models.Views
{
    public class TicketView : Holism.Models.IEntity
    {
        public TicketView()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public Guid UserGuid { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string PersianDate { get; set; }

        public Guid? CategoryGuid { get; set; }

        public long PriorityId { get; set; }

        public long StateId { get; set; }

        public string StatePersianName { get; set; }

        public string PriorityPersianName { get; set; }

        public DateTime? LatestPostDate { get; set; }

        public string LatestPostPersianDate { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
