using System;

namespace Holism.Ticketing
{
    public class Goal : Holism.Models.IEntity
    {
        public Goal()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public Guid UserGuid { get; set; }

        public object GoalName { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
