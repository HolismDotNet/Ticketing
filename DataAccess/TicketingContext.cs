namespace Holism.Ticketing.DataAccess;

public class TicketingContext : DatabaseContext
{
    public override string ConnectionStringName => "Ticketing";

    public DbSet<AttachedFile> AttachedFiles { get; set; }

    public DbSet<PostHtml> PostHtmls { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<TicketView> TicketViews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
