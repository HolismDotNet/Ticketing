namespace Holism.Ticketing
{
    public class PostHtml : Holism.Models.IEntity
    {
        public PostHtml()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public object Html { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
