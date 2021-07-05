using Holism.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ticketing.Models;

namespace Ticketing.DataAccess
{
    public class TicketingContext : DatabaseContext
    {
        public override string ConnectionStringName => "TicketingContext";

        public DbSet<AttachedFile> AttachedFiles { get; set; }
        public DbSet<Post> Posts {get; set;}
        public DbSet<PostHtml> PostHtmls {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Post>().Property(i => i.Id).ValueGeneratedNever();
			modelBuilder.Entity<PostHtml>().Property(i => i.Id).ValueGeneratedNever();
			modelBuilder.Entity<AttachedFile>().Property(i => i.Id).ValueGeneratedNever();
			modelBuilder.Entity<Post>().Property(i => i.Date).HasColumnType("datetime");
            base.OnModelCreating(modelBuilder);
        }
    }
}
