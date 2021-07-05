using Holism.Ticketing.Models;
using Holism.Ticketing.Models;
using Holism.DataAccess;
namespace Holism.Ticketing.DataAccess
{
    public class Repository
    {
        public static Repository<Post> Post
        {
            get
            {
                return new Holism.DataAccess.Repository<Post>(new Holism.TicketingContext());
            }
        }

        public static Repository<PostHtml> PostHtml
        {
            get
            {
                return new Holism.DataAccess.Repository<PostHtml>(new Holism.TicketingContext());
            }
        }
        public static Repository<AttachedFile> AttachedFile
        {
            get
            {
                return new Holism.DataAccess.Repository<AttachedFile>(new Holism.TicketingContext());
            }
        }
        
        public static Repository<PostView> PostView
        {
            get
            {
                return new Holism.DataAccess.Repository<PostView>(new Holism.TicketingContext());
            }
        }
        
        public static Repository<TicketView> TicketView
        {
            get
            {
                return new Holism.DataAccess.Repository<TicketView>(new Holism.TicketingContext());
            }
        }        
    }
}
