namespace Ticketing;

public class PostContentBusiness : Business<Ticketing.PostContent, Ticketing.PostContent>
{
    protected override Repository<Ticketing.PostContent> WriteRepository => Ticketing.Repository.PostContent;

    protected override ReadRepository<Ticketing.PostContent> ReadRepository => Ticketing.Repository.PostContent;

    public void Create(long postId, string content)
    {
        var postContent = new Ticketing.PostContent();
        postContent.Id = postId;
        postContent.Content = content;
        Create(postContent);
    }
}
