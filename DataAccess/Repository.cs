using Holism.Ticketing.Models;
using Holism.DataAccess;

namespace Holism.Ticketing.DataAccess
{
    public class Repository
    {
        
        public static Repository<State> State
        {
            get
            {
                return new Holism.DataAccess.Repository<State>(new TicketingsContext());
            }
        }
    


        public static Repository<Priority> Priority
        {
            get
            {
                return new Holism.DataAccess.Repository<Priority>(new TicketingsContext());
            }
        }
    


        public static Repository<Ticket> Ticket
        {
            get
            {
                return new Holism.DataAccess.Repository<Ticket>(new TicketingsContext());
            }
        }
    


        public static Repository<Post> Post
        {
            get
            {
                return new Holism.DataAccess.Repository<Post>(new TicketingsContext());
            }
        }
    


        public static Repository<PostHtml> PostHtml
        {
            get
            {
                return new Holism.DataAccess.Repository<PostHtml>(new TicketingsContext());
            }
        }
    


        public static Repository<AttachedFile> AttachedFile
        {
            get
            {
                return new Holism.DataAccess.Repository<AttachedFile>(new TicketingsContext());
            }
        }
    


        public static Repository<Goal> Goal
        {
            get
            {
                return new Holism.DataAccess.Repository<Goal>(new TicketingsContext());
            }
        }
    


    }
}