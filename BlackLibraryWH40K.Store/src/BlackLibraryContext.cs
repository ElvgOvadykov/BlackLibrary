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
            
        }
        
        public BlackLibraryContext(DbContextOptions<BlackLibraryContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blacklibrarydb;Integrated Security=True");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Primarch>().HasOne(x => x.State);
            modelBuilder.Entity<Primarch>().HasOne(x => x.HomeWorld);
        }
    }
}