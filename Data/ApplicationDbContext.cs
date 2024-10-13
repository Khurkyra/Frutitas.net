using Frutas.Models;
using Microsoft.EntityFrameworkCore;


namespace Frutas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Fruit> Fruits { get; set; }  // Representa la tabla frutas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fruit>().ToTable("frutas"); // Mapea a la tabla 'frutas'
        }
    }
}
