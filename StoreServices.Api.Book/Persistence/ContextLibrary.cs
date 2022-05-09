using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Model;

namespace StoreServices.Api.Book.Persistence
{
    public class ContextLibrary : DbContext
    {
        public ContextLibrary(DbContextOptions<ContextLibrary> options) : base(options) { }

        public DbSet<LibraryMaterial> LibraryMaterial { get; set; }

    }
}
