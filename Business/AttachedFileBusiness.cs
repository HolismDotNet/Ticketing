namespace Ticketing;

public class AttachedFileBusiness : Business<Ticketing.AttachedFile, Ticketing.AttachedFile>
{
    protected override Repository<Ticketing.AttachedFile> WriteRepository => Ticketing.Repository.AttachedFile;

    protected override ReadRepository<Ticketing.AttachedFile> ReadRepository => Ticketing.Repository.AttachedFile;

}
