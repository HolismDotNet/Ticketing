using Microsoft.EntityFrameworkCore.Migrations;
using Holism.DataAccess;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.DataAccess.Migrations
{
    public partial class PriorityEnum : EnumMigration<Priority>
    {
        protected override string TableName => "Priorities";
    }
}
