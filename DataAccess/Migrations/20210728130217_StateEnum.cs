using Microsoft.EntityFrameworkCore.Migrations;
using Holism.DataAccess;
using Holism.Ticketing.Models;

namespace Holism.Ticketing.DataAccess.Migrations
{
    public partial class StateEnum : EnumMigration<State>
    {
        protected override string TableName => "States";
    }
}
