using Microsoft.EntityFrameworkCore;

namespace eCommerceWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<CustomerData> Customers => Set <CustomerData>();
    }
}
