namespace Ticketing;

public class PostBusiness : Business<Ticketing.Post, Ticketing.Post>
{
    protected override Write<Ticketing.Post> Write => Ticketing.Repository.Post;

    protected override Read<Ticketing.Post> Read => Ticketing.Repository.Post;

    protected override Func<Sort> DefaultSort => () => new Sort
    {
        Property = nameof(Post.Id),
        Direction = SortDirection.Descending
    };

    protected override void ModifyItemBeforeReturning(Ticketing.Post item)
    {
        item.RelatedItems.TimeAgo = "Todo";
        base.ModifyItemBeforeReturning(item);
    }

    public void CreateUserResponse(long ticketId, string postContent)
    {
        var post = new Ticketing.Post();
        post.TicketId = ticketId;
        post.IsSystemPost = false;
        post.UtcDate = UniversalDateTime.Now;
        Create(post);
        new PostContentBusiness().Create(post.Id, postContent);
        new TicketBusiness().SetState(ticketId, Ticketing.State.WaitingForBusinessResponse);
    }

    public void CreateSystemResponse(long ticketId, string postContent)
    {
        var post = new Post();
        post.TicketId = ticketId;
        post.IsSystemPost = true;
        post.UtcDate = UniversalDateTime.Now;
        Create(post);
        new PostContentBusiness().Create(post.Id, postContent);
        new TicketBusiness().SetState(ticketId, Ticketing.State.WaitingForUserResponse);
    }

    public List<Post> GetPosts(long ticketId)
    {
        var ticketPosts = GetList(i => i.TicketId == ticketId);
        ticketPosts = ticketPosts.OrderByDescending(i => i.UtcDate).ToList();
        var postIds = ticketPosts.Select(i => i.Id).ToList();
        var postContents = new PostContentBusiness().GetList(postIds);
        foreach (var post in ticketPosts)
        {
            var content = postContents.SingleOrDefault(i => i.Id == post.Id);
            post.RelatedItems.Content = "";
            if (content != null)
            {
                post.RelatedItems.Content = content.Content;
            }
        }
        return ticketPosts;
    }
}
