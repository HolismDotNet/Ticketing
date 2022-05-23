namespace Ticketing;

public class PostContentBusiness : Business<Ticketing.PostContent, Ticketing.PostContent>
{
    public override string EntityType => "TicketingPostContent";

    protected override Write<Ticketing.PostContent> Write => Ticketing.Repository.PostContent;

    protected override Read<Ticketing.PostContent> Read => Ticketing.Repository.PostContent;

    public void Create(long postId, string content)
    {
        var postContent = new Ticketing.PostContent();
        postContent.Id = postId;
        postContent.Content = content;
        Create(postContent);
    }
}
