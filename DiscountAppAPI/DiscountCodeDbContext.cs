using DiscountAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DiscountAppAPI
{
    public class DiscountCodeDbContext :DbContext
    {
        public DiscountCodeDbContext(DbContextOptions<DiscountCodeDbContext> options) : base(options)
        {
            try
            {
                var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreater != null)
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
        public DbSet<DiscountCode> DiscountCodes { get; set; }
    }
}
