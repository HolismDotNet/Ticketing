using System;

namespace Ticketing.Models
{
    public class AttachedFile : Holism.Models.IEntity
    {
        public AttachedFile()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public long PostId { get; set; }

        public Guid FileGuid { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}