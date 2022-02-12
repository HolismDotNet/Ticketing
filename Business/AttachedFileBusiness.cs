namespace Ticketing;

public class AttachedFileBusiness : Business<Ticketing.AttachedFile, Ticketing.AttachedFile>
{
    protected override Write<Ticketing.AttachedFile> Write => Ticketing.Repository.AttachedFile;

    protected override Read<Ticketing.AttachedFile> Read => Ticketing.Repository.AttachedFile;

}
