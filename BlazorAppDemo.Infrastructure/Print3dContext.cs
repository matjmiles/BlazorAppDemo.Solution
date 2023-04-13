using Microsoft.EntityFrameworkCore;
using BlazorAppDemo.Core.Entities;

namespace BlazorAppDemo.Infrastructure.Repositories;

public class Print3dContext : DbContext, IPrint3dContext
{
    public DbSet<Email> Emails { get; set; }
    public DbSet<Status> Statuses { get; set; }

    public Print3dContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(ent =>
        {
            ent.ToTable("Email");
            ent.HasKey(e => e.EmailId);
        });

        modelBuilder.Entity<Status>(ent => {
            ent.ToTable("Status");
            ent.HasOne(e => e.Email).WithMany(e => e.Statuses).HasForeignKey(e => e.EmailId);
            ent.HasKey(e => e.StatusId);
        });
    }
}
