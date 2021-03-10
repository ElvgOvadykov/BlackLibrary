using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlackLibraryWH40K.Store
{
    public class ReadOnlyBlackLibraryContext : BlackLibraryContext
    {
        public ReadOnlyBlackLibraryContext(DbContextOptions<BlackLibraryContext> options) : base(options)
        {
        }
        
        private void SetUpBehavior()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //todo: disable lazy loading
        }
        
        public override int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}