using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public abstract class UnitOfWork(DbContext context) : IUnitOfWork
    {
        private bool disposed = false;

        // Public Dispose method to release resources
        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization since it's no longer needed
            GC.SuppressFinalize(this);
        }

        // Protected Dispose method that takes a parameter
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here
                    context.Dispose();
                }

                // Dispose unmanaged resources here

                disposed = true;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
