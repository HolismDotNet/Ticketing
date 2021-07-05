using Holism.Business;
using Holism.EntityFramework;
using Holism.Ticketing.DataAccess;
using Holism.Ticketing.DataAccess.Models;

namespace Holism.Ticketing.Business
{
    public class AttachedFileBusiness : Business<AttachedFile, AttachedFile>
    {
        protected override Repository<AttachedFile> ModelRepository => RepositoryFactory.AttachedFile;

        protected override ViewRepository<AttachedFile> ViewRepository => RepositoryFactory.AttachedFile;

    }
}
