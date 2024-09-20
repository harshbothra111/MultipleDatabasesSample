using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    internal class UnitOfWorkFactory(IConfiguration configuration) : IUnitOfWorkFactory
    {
        public IUnitOfWork Create(string connectionStringKey)
        {
            var connectionString = configuration.GetConnectionString(connectionStringKey);
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

            //if (connectionStringKey == "Database1")
            //{
            //    var db1Options = optionsBuilder.UseSqlServer(connectionString).Options;
            //    return new UnitOfWork(new Db1Context(db1Options));
            //}
            //else if (connectionStringKey == "Database2")
            //{
            //    var db2Options = optionsBuilder.UseSqlServer(connectionString).Options;
            //    return new UnitOfWork(new Db2Context(db2Options));
            //}

            throw new InvalidOperationException("Unsupported database connection string.");
        }
    }
}
