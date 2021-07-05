namespace Ticketing.Models
{
    public class PostHtml : Holism.Models.IEntity
    {
        public PostHtml()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public string Html { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
