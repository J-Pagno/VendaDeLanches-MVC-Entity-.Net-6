using Microsoft.EntityFrameworkCore;
using VendaDeLanches.Models;

namespace VendaDeLanches.Context
{
    public class AppDbContext : DbContext
    {
        //A classe DbContextOptions carrega as informações necessárias para configurar o dbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Snack> Snacks { get; set; }

        public DbSet<ShoppingCartItens> ShoppingCartItens { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
