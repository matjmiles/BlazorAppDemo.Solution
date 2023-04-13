using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Core.Entities
{
    public interface IPrint3dContext
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
