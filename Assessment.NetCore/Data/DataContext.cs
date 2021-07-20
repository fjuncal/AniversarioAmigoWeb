using Assessment.NetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessment.NetCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Amigo> Amigos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Amigo>().HasKey(t => t.id);
        }
    }
}