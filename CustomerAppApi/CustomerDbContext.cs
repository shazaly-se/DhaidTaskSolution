using CustomerAppApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerAppApi
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            try
            {
                var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(databaseCreater != null)
                {
                    if (!databaseCreater.CanConnect()) databaseCreater.Create();
                    if (!databaseCreater.HasTables()) databaseCreater.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
