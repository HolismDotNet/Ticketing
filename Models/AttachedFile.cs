using System;

namespace Holism.Ticketing
{
    public class AttachedFile : Holism.Models.IEntity
    {
        public AttachedFile()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long PostId { get; set; }

        public Guid FileGuid { get; set; }

        public object FileExtension { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
