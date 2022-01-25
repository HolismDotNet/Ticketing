namespace Ticketing;

public class TicketingContext : DatabaseContext
{
    public override string ConnectionStringName => "Ticketing";

    public DbSet<Ticketing.AttachedFile> AttachedFiles { get; set; }

    public DbSet<Ticketing.PostContent> PostContents { get; set; }

    public DbSet<Ticketing.Post> Posts { get; set; }

    public DbSet<Ticketing.Ticket> Tickets { get; set; }

    public DbSet<Ticketing.TicketView> TicketViews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
