using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Model;

namespace StoreServices.Api.ShoppingCart.Persitence
{
    public class CartContext: DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options) { }
        public DbSet<CartSession> CartSession { get; set; }
        public DbSet<CartSessionDetail> CartSessonDetail { get; set; }

    }
}
