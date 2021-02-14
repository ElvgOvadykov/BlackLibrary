using BlackLibraryWH40K.Store.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Store
{
    public class BlackLibraryContext : DbContext
    {
        public DbSet<Chapter> Chapter { get; set; }
        public DbSet<Legion> Legion { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Primarch> Primarch { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<World> World { get; set; }

        public BlackLibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blacklibrarydb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Primarch>().HasOne(x => x.State);
            modelBuilder.Entity<Primarch>().HasOne(x => x.HomeWorld);
        }
    }
}