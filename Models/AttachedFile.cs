namespace Ticketing;

public class AttachedFile : IEntity
{
    public AttachedFile()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public long PostId { get; set; }

    public Guid FileGuid { get; set; }

    public string FileExtension { get; set; }

    public dynamic RelatedItems { get; set; }
}
