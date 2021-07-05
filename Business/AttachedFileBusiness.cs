using Holism.Business;
using Holism.DataAccess;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.Business
{
    public class AttachedFileBusiness : Business<AttachedFile, AttachedFile>
    {
        protected override Repository<AttachedFile> WriteRepository => Repository.AttachedFile;

        protected override ReadRepository<AttachedFile> ReadRepository => Repository.AttachedFile;

    }
}
