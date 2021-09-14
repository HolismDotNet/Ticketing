namespace Holism.Ticketing.Models
{
    public class PostHtml : Holism.Models.IEntity
    {
        public PostHtml()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public object Html { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
