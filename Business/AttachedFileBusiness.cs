using Holism.Business;
using Holism.EntityFramework;
using Ticketing.DataAccess;
using Ticketing.DataAccess.Models;

namespace Ticketing.Business
{
    public class AttachedFileBusiness : Business<AttachedFile, AttachedFile>
    {
        protected override Repository<AttachedFile> ModelRepository => RepositoryFactory.AttachedFile;

        protected override ViewRepository<AttachedFile> ViewRepository => RepositoryFactory.AttachedFile;

    }
}
