using Microsoft.EntityFrameworkCore;
using StoreService.Api.Author.Model;

namespace StoreService.Api.Author.Persistence
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Degrees> Degree { get; set; }
    }
}

